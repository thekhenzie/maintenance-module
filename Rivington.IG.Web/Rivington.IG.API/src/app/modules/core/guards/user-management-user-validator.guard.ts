import { Injectable } from "@angular/core";
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { Observable } from "rxjs/Observable";
import { PathConstants } from "../../shared/pathconstants";
import { AuthService } from "../services/auth.service";
import Utils from "../../shared/Utils";
import { UserManagementservice } from "../services/usermanagement/user-management.service";

@Injectable()
export class UserExistValidatorGuard implements CanActivate {
  constructor(private userManagementService: UserManagementservice,
    private router: Router,
  ) { }

  canActivate(route: ActivatedRouteSnapshot): Observable<boolean> {
    return this.userManagementService.checkIfUserExist(route.params['id'])
    .catch(()=>{
      Utils.showError("Page does not exist!");
      this.router.navigate([PathConstants.Account.Login]);
      return Observable.of(false)
    });
  }
}