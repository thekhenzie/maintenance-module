import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { StaticPagesService } from '../services/static-pages.service';
import { BaseComponent } from '../../shared/BaseComponent';
import { PathConstants } from '../../shared/pathconstants';

@Injectable()
export class StaticContentExistGuard extends BaseComponent implements CanActivate {

  constructor(private staticPagesService: StaticPagesService, private router: Router) {
    super();
  }
  
  canActivate(route:ActivatedRouteSnapshot): Observable<boolean> {
    let name = route.params['staticcontentname'];
    let falseCallback = () => {
      this.router.navigate([`/static/${PathConstants.Root.Forbidden}`]);
      return false;
    }
    
    return this.staticPagesService.checkIfStaticContentExists(name).takeUntil(this.stop$).
      map(doExist => {
        return doExist ? true : falseCallback();
      });
  }
}