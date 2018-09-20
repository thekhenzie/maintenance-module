import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { PathConstants } from '../../shared/pathconstants';
import { Observable } from 'rxjs';
import { InspectionOrderService } from '../services/ordermanagement/inspection-order.service';

@Injectable()
export class InspectionChecklistIdIsValidGuard implements CanActivate {
  existingIO: string[];

  constructor(private inspectionOrderService: InspectionOrderService, private router: Router) {
    this.existingIO = [];
  }

  canActivate(route:ActivatedRouteSnapshot, state:RouterStateSnapshot): Observable<boolean> {
    let ioId = route.params['id'];
    let falseCallback = () => {
      this.router.navigate(['/order-management']);
      return Observable.of(false);
    }

    // check array if
    if(this.existingIO.indexOf(ioId) > -1) return Observable.of(true);

    return this.inspectionOrderService.checkIfInspectionOrderExists(ioId).
      map(doExist => {
          if (doExist){
            if(this.existingIO.indexOf(ioId) < 0) this.existingIO.push(ioId);

            return true;
          } {
            falseCallback();
          }
      }).
      catch(falseCallback);
  }
}