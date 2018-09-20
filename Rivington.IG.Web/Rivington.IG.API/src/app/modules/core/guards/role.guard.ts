import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { PathConstants } from '../../shared/pathconstants';

@Injectable()
export class RoleGuard implements CanActivate {
  constructor(private _authService: AuthService, private _router: Router) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    let allowedRoles = route.data["roles"] as string[];
    let userRoles = this._authService.getRoles();
    if (userRoles && userRoles.length && allowedRoles && allowedRoles.length) {
      for (const role of allowedRoles) {
        if (userRoles.indexOf(role) != -1) {
          return true;
        }
      }
    }

    // window.alert("You should be logged-in to view this page");
    this._router.navigate([PathConstants.Root.Forbidden]);
    return false;
  }
}
