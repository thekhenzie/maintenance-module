import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LocalStorageService } from '../../../core/services/localStorageService';
import { CommonService } from '../../../core/services/common.service';
import { UserManagementservice } from '../../../core/services/usermanagement/user-management.service';
import { BaseComponent } from '../../../shared/BaseComponent';

@Component({
  selector: 'app-user-profile-nav',
  templateUrl: './user-profile-nav.component.html',
  styleUrls: ['./user-profile-nav.component.css']
})
export class UserProfileNavComponent extends BaseComponent implements OnInit {
  paramId: string;
  constructor(private route:ActivatedRoute) {
    super();
   }

  ngOnInit() {
    this.route.params.takeUntil(this.stop$).subscribe(params => { 
      this.paramId = params["id"];
    });
  }

}
