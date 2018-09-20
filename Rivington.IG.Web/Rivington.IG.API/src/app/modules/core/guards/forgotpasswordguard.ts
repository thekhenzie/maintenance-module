import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { Observable } from 'rxjs';
import { ForgotPasswordService } from '../services/forgotpasswordservice';
import { PathConstants } from '../../shared/pathconstants';

@Injectable()
export class ForgotPasswordGuard implements CanActivate {
  constructor(private forgotPasswordService: ForgotPasswordService, private router: Router) {}

  canActivate(route:ActivatedRouteSnapshot, state:RouterStateSnapshot): Observable<boolean> {
    let falseCallback = () => {
      window.alert("Page does not exist");  
      this.router.navigate([PathConstants.Account.Login]);
      return Observable.of(false);
    }
    return this.forgotPasswordService.checkIfForgotPasswordIdExist(route.params['id']).
      map(doExist => {
          if (doExist){
            return true;
          } {
            falseCallback();
          }
      }).
      catch(falseCallback);
  }
}