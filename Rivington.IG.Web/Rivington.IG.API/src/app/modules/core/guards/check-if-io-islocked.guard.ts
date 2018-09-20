import { BaseComponent } from "../../shared/BaseComponent";
import { CanActivate, Router, ActivatedRouteSnapshot } from "@angular/router";
import { Injectable } from "@angular/core";
import { InspectionOrderService } from "../services/ordermanagement/inspection-order.service";
import { Observable } from "rxjs/Observable";
import { PathConstants } from "../../shared/pathconstants";

@Injectable()
export class CheckIfIOIsLockedGuard extends BaseComponent implements CanActivate {

  constructor(private ioService: InspectionOrderService, private router: Router) {
    super();
  }
  
  canActivate(route:ActivatedRouteSnapshot): Observable<boolean> {
    let id = route.params['id'];
    let falseCallback = () => {
      this.router.navigate([`/${PathConstants.OrderManagement.Index}`]);
      return false;
    }
    
    return this.ioService.checkIfIOIsLocked(id).takeUntil(this.stop$).
      map(isLocked => {
        return !isLocked ? true : falseCallback();
      });
  }
}