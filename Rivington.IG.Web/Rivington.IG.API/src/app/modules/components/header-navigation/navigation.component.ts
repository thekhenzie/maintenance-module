import { Component } from '@angular/core';
import { AuthService } from '../../core/services/auth.service';
import { Router, ActivatedRoute } from '@angular/router';
import { PathConstants } from '../../shared/pathconstants';
import { UserManagementservice } from '../../core/services/usermanagement/user-management.service';
import { LocalStorageService } from '../../core/services/localStorageService';
import { User } from '../../shared/models/user';
import { Constants } from '../../shared/constants';

@Component({
  selector: 'ma-navigation',
  templateUrl: './navigation.component.html'
})
export class NavigationComponent{
  email: string;
  lastName: string;
  firstName: string;
  profilePhoto: any;
  // firstname: string;
  username: string;
  accountLoginPath: string;
  public user: User;

  constructor(public auth: AuthService, private _router: Router,
              public userService: UserManagementservice,
              private localService: LocalStorageService,
              private route: ActivatedRoute) { 
    this.accountLoginPath = PathConstants.Account.Login;
  }

  ngOnInit() {
        this.userService.setUserInfoValues();
  }

  checkHomePath(){
    if(this.auth.isInsured){
      return;
    }
    else{
      return "/dashboard";
    }
  }

  checkIfNotInsured(): boolean{
    return this._router.url.search("insured") == -1
  }
}
