import { Injectable, Inject, EventEmitter, PLATFORM_ID } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import 'rxjs/Rx';
import { CLIENT_RENEG_WINDOW } from 'tls';
import { Constants } from '../../shared/constants';
import { Router } from '@angular/router';
import { PathConstants } from '../../shared/pathconstants';
import { Jsonp } from '@angular/http/src/http';
import { LocalStorageService } from './localStorageService';
import Utils from '../../shared/Utils';
import { InspectionOrderService } from './ordermanagement/inspection-order.service';
import { UserActivityLogService } from './ordermanagement/user-activity-log.service';
import { RoleConstants } from '../../shared/roleconstants';

@Injectable()
export class AuthService {

  // Inspection Order Routing
  isIOInfo: boolean;
  isLogout: boolean;
  isInsured: boolean;
  isInsuredReport: boolean;
  insuredLogin: string;

  // Role Based
  public currentUserRole: string;

  constructor(private http: HttpClient, @Inject(PLATFORM_ID) private platformId: any, private router: Router,
    private localStorageService: LocalStorageService,
    private userActivityService: UserActivityLogService) {
    this.isIOInfo = false;
    this.isLogout = true;
  }

  login(username: string, password: string): Observable<boolean> {
    let url = `/token/auth`;

    let data = {
      username: username,
      password: password,
      client_id: Constants.ClientId,
      grant_type: Constants.GrantType.Password,
      scope: "offline_access profile email",
      is_insured: this.isInsured
    };

    return this.getAuthFromServer(url, data);
  }

  forgotpassword(email: string): Observable<boolean> {
    let url = `/Account`;

    let data = {
      email: email,
      client_id: Constants.ClientId,
      grant_type: Constants.GrantType.Password,
      scope: "offline_access profile email"
    };

    return this.http.post<any>(`${Constants.ApiUrl}${url}`, data)
      .map((res) => {
        let token = res && res.result.token;
        // if the token is there, login has been successful
        if (token) {
          // store username and jwt token
          this.setAuth(res.result);
          // successful login
          return true;
        }
        // failed login
        console.log("error");
        return Observable.throw('Unauthorized');
      })
      .catch(error => {
        console.log(error);
        return Observable.throw(error);
      });
  }


  logout(): boolean {
    this.setAuth(null);
    this.userActivityService.sendEvent('Logout', 'Logout', 'Logout');
    return true;
  }

  logoutThenRedirect(): void {
    if (this.isIOInfo) {
      this.router.navigate([PathConstants.Account.Login]).then(event =>{
        if (this.isLogout) {
          this.logout();
          Utils.showSuccess("Successfully logged out!");
        }
      });
      return;
    }
    // erase current token
    this.logout();
    // success message
    Utils.showSuccess("Successfully logged out!");
    // redirect to login page
    this.router.navigate([PathConstants.Account.Login]);
  }

  setAuth(auth: TokenResponse | null): boolean {
    if (isPlatformBrowser(this.platformId)) {
      if (auth) {
        this.localStorageService.setItem(Constants.AuthKey, JSON.stringify(auth));
      } else {
        this.localStorageService.removeItem(Constants.AuthKey);
      }
    }
    return true;
  }

  getAuth(): TokenResponse | null {
    if (isPlatformBrowser(this.platformId)) {
      let item = this.localStorageService.getItem(Constants.AuthKey);
      if (item) {
        return JSON.parse(item);
      }

    }
    return null;
  }

  getRoles(): string[] | null {
    var auth = this.getAuth();
    if (auth) {
      return auth.roles;
    }

    return null;
  }

  isLoggedIn(): boolean {
    if (isPlatformBrowser(this.platformId)) {
      return this.localStorageService.getItem(Constants.AuthKey) != null;
    }
    return false;
  }

  // try to refresh token
  refreshToken(): Observable<boolean> {
    let url = "/token/auth";
    let data = {
      client_id: Constants.ClientId,
      // required when signing up with username/password
      grant_type: Constants.GrantType.RefreshToken,
      refresh_token: this.getAuth()!.refresh_token,
      // space-separated list of scopes for which the token is issued
      scope: "offline_access profile email"
    };
    return this.getAuthFromServer(url, data);
  }

  // retrieve the access & refresh tokens from the server
  getAuthFromServer(url: string, data: any): Observable<boolean> {
    return this.http.post<any>(`${Constants.ApiUrl}${url}`, data)
      .map((res) => {
        let token = res && res.result.token;
        // if the token is there, login has been successful
        if (token) {
          // store username and jwt token
          this.setAuth(res.result);
          // successful login
          this.localStorageService.setUserName(res.result.username);
          // save username to localstorage
          this.currentUserRole = this.getRoles().toString();
          // get current user role for shared components
          return true;
        }
        // failed login
        console.log("error");
        return Observable.throw('Unauthorized');
      })
      .catch(error => {
        console.log(error);
        return Observable.throw(error);
      });
  }

  // Start of Role Based Conditions
  isAuthorizedToAccesUserManagement(): boolean{
    return true;
    // return this.currentUserRole != RoleConstants.Inspector;
  }

  isAuthorizeToAccessIOCreation(userRole): boolean{
    return true;
    // return userRole == RoleConstants.UnderWriter ||
    //   userRole == RoleConstants.InspectorManager||
    //   userRole == RoleConstants.System ||
    //   userRole == RoleConstants.Administrator;
  }

  isUnderWriter(userRole): boolean{
    return true;
    // return userRole == RoleConstants.UnderWriter;
  }

  isInspector(userRole): boolean{
    return true;
    // return userRole == RoleConstants.Inspector;
  }

  isAdmin(userRole): boolean{
    return true;
    // return userRole == RoleConstants.System ||
    // userRole == RoleConstants.Administrator;
  }
  
  isInspectorManager(userRole): boolean{
    return true;
    // return userRole == RoleConstants.InspectorManager;
  }
  // End of Role Based Conditions
}