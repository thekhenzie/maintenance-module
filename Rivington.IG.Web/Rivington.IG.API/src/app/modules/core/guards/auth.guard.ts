import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { PathConstants } from '../../shared/pathconstants';

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private _authService: AuthService, private _router: Router) {}

  canActivate() {

    if(!this._authService.isLoggedIn())
    {
      window.alert("You should be logged-in to view this page");
      this._authService.isInsured = false;
      this._router.navigate([PathConstants.Account.Login]);
      return false;
    }

    return true;
  }
}