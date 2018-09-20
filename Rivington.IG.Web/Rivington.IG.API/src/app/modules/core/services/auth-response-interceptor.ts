import { Injectable, Injector } from "@angular/core";
import { Router } from "@angular/router";
import { HttpClient, HttpHandler, HttpEvent, HttpInterceptor, HttpRequest, HttpResponse, HttpErrorResponse } from "@angular/common/http";
import { AuthService } from "./auth.service";
import { Observable } from "rxjs";
import { PathConstants } from "../../shared/pathconstants";


@Injectable()
export class AuthResponseInterceptor implements HttpInterceptor {
    currentRequest: HttpRequest<any>;
    auth: AuthService;
    constructor(
        private injector: Injector,
        private router: Router
    ) {}

    // intercept any
    intercept(request: HttpRequest<any>,
            next: HttpHandler): Observable<HttpEvent<any>> {
        this.auth = this.injector.get(AuthService);

        let token = null;
        if(this.auth.isLoggedIn()) {
            let auth = this.auth.getAuth();
            token = auth ? auth.token : null;
        }
        
        if (!token) {
            return next.handle(request);
        }
        
        // save current request
        this.currentRequest = request;
        return next.handle(request)
            .do((event: HttpEvent<any>) => {
                if (event instanceof HttpResponse) {
                    // do nothing
                } })
            .catch(error => {
                return this.handleError(error)
        });
    }

    handleError(err: any) {
        if (err instanceof HttpErrorResponse) {
            if (err.status === 401) {
                // JWT token might be expired:
                // try to get a new one using refresh token
                console.log("Token expired. Attempting refresh...");
                this.auth.refreshToken()
                    .subscribe(res => {
                    if (res) {
                        // refresh token successful
                        console.log("refresh token successful");
                        // re-submit the failed request
                        var http = this.injector.get(HttpClient);
                        http.request(this.currentRequest).subscribe(
                            result => {
                                // do something
                            }, error => {
                                if(console && console.error) console.error(error);
                            }
                        );
                     } else {
                        // refresh token failed
                        console.log("refresh token failed");
                        // erase current token
                        this.auth.logout();
                        // redirect to login page
                        this.router.navigate([PathConstants.Account.Login]);

                    }
                }, error => console.log(error));
            }
        }
        return Observable.throw(err);
    }
}             