import { Injectable } from "@angular/core";
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { Observable } from "rxjs/Observable";
import { PathConstants } from "../../shared/pathconstants";
import { AuthService } from "../services/auth.service";
import Utils from "../../shared/Utils";
import { UserManagementservice } from "../services/usermanagement/user-management.service";

@Injectable()
export class UserManagementGuard implements CanActivate {
  constructor(private userManagementService: UserManagementservice,
    private router: Router,
    private authService: AuthService) {}

  canActivate(route:ActivatedRouteSnapshot, state:RouterStateSnapshot): Observable<boolean> {
    let falseCallback = () => {
      Utils.showError("Page does not exist!");
      this.router.navigate([PathConstants.Account.Login]);
      return Observable.of(false);
    }
    return this.userManagementService.checkIfUserIsNew(route.params['id']).
      map(isNew => {
        if (isNew){
          this.authService.logout();
          localStorage.clear();
          return true;
        } {
          return false;
        }
      }).
      catch(falseCallback);
  }
}
