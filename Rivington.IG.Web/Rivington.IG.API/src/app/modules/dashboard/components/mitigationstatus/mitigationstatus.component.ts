import { Component, OnInit } from '@angular/core';
import { InspectionOrderService } from '../../../core/services/ordermanagement/inspection-order.service';
import { AuthService } from '../../../core/services/auth.service';
import { InspectionOrder } from '../../../shared/models/ordermanagement/inspection-order';
import { DashboardService } from '../../../core/services/dashboard/dashboard.service';
import { MitigationStatusCountView } from '../../../shared/models/dashboard/mitigation-status-count-view';
import Utils from '../../../shared/Utils';
import { Router } from '@angular/router';
import { LocalStorageService } from '../../../core/services/localStorageService';
import { RoleConstants } from '../../../shared/roleconstants';
import { UserActivityLogService } from '../../../core/services/ordermanagement/user-activity-log.service';
import { CategoryConstants } from '../../../shared/models/user-activity-category-constants';

@Component({
  selector: 'app-mitigationstatus',
  templateUrl: './mitigationstatus.component.html',
  styleUrls: ['./mitigationstatus.component.css']
})
export class MitigationstatusComponent implements OnInit {

  currentUser: string;

  constructor(
    private inspectionOrderService: InspectionOrderService,
    public dashboardService: DashboardService,
    public auth: AuthService,
    private router: Router,
    private localService: LocalStorageService,
    private userActivityService: UserActivityLogService) {
    this.dashboardService.groupedMitigationStatus = [];
    this.currentUser = "";
  }

  ngOnInit() {
    this.auth.currentUserRole = this.auth.getRoles().toString();
    if (this.auth.currentUserRole == RoleConstants.Inspector) {
      this.currentUser = this.localService.getUserName();
    }
    this.dashboardService.getMitigationStatusCount(this.currentUser).subscribe(
      statusList => {
        this.dashboardService.groupedMitigationStatus = statusList;
      },
      onerror => {
        Utils.showError("There's an error while retrieving inspection orders.");
      }
    );
  }

  redirectWithStatus(orderStatus) {
    let ioUrl = "/order-management/mitigation-status/";
    if(this.dashboardService.inspector){
      this.router.navigate([ioUrl, orderStatus.statusId, this.dashboardService.inspectorName]);
    }
    else{
      this.router.navigate([ioUrl, orderStatus.statusId]);
    }

    this.userActivityService.sendEvent( CategoryConstants.View, 'dashboard', CategoryConstants.View +' Mitigation Status ' + orderStatus.statusId);
  }
}
