import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";
import { AuthService } from "../services/auth.service";
import { PathConstants } from "../../shared/pathconstants";

@Injectable()
export class InsuredAuthGuard implements CanActivate {
  constructor(private _authService: AuthService, private _router: Router) {}

  canActivate() {

    if(!this._authService.isLoggedIn())
    {
      window.alert("You should be logged-in to view this page");
      this._authService.isInsured = true;
      this._router.navigate([PathConstants.Account.InsuredLogin]);
      return false;
    }

    return true;
  }
}