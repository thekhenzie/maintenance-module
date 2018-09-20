import { Component, OnInit } from '@angular/core';
import { InspectionOrder } from '../../../shared/models/ordermanagement/inspection-order';
import { AuthService } from '../../../core/services/auth.service';
import { InspectionOrderService } from '../../../core/services/ordermanagement/inspection-order.service';
import { InspectionStatusGroupingsView } from '../../../shared/models/dashboard/inspection-status-groupings-view';
import { DashboardService } from '../../../core/services/dashboard/dashboard.service';
import Utils from '../../../shared/Utils';
import { Router } from '@angular/router';
import { LocalStorageService } from '../../../core/services/localStorageService';
import { RoleConstants } from '../../../shared/roleconstants';
import { DateDifferenceConstants } from '../../../shared/date-difference-constants';
import { UserActivityLogService } from '../../../core/services/ordermanagement/user-activity-log.service';
import { CategoryConstants } from '../../../shared/models/user-activity-category-constants';

@Component({
  selector: 'app-inspectiontable',
  templateUrl: './inspectiontable.component.html',
  styleUrls: ['./inspectiontable.component.css']
})
export class InspectiontableComponent implements OnInit {

  currentUser: string;
  ioUrl: string;
  Object = Object;

  constructor(
    private inspectionOrderService: InspectionOrderService,
    public dashboardService: DashboardService,
    public auth: AuthService,
    private router: Router,
    private localService: LocalStorageService,
    private userActivityService: UserActivityLogService
  ) {
    this.currentUser = "";
    this.ioUrl = "/order-management/inspection-status/";
  }

  ngOnInit() {
    this.auth.currentUserRole = this.auth.getRoles().toString();
    if (this.auth.currentUserRole == RoleConstants.Inspector) {
      this.currentUser = this.localService.getUserName();
    }
    this.dashboardService.getInspectionStatusGroupings(this.currentUser).subscribe(
      statusList => {
        this.dashboardService.groupedInspectionStatus = statusList;
      },
      onerror => {
        Utils.showError("There's an error while retrieving inspection orders.");
      }
    );
    this.dashboardService.getSentToInsuredStatusCount(this.currentUser).subscribe(
      statusCount => {
        this.dashboardService.linksSent = statusCount;
      },
      onerror => {
        Utils.showError("There's an error while retrieving inspection orders.");
      }
    )
  }

  redirectWithStatusAndDays(status, days) {
    if (this.dashboardService.inspector) {
      switch (days) {
        case "zeroToNineteenDays": {
          this.router.navigate([this.ioUrl, status, DateDifferenceConstants.ZeroToNineteenDays.toString(), this.dashboardService.inspectorName]);

          let action = CategoryConstants.View + ' ' + status +  ' ' + DateDifferenceConstants.ZeroToNineteenDays.toString();
          this.userActivityService.sendEvent(CategoryConstants.View, 'dashboard', action);
          break;
        }
        case "twentyToThirtyNineDays": {
          this.router.navigate([this.ioUrl, status, DateDifferenceConstants.TwentyToThirtyNineDays.toString(), this.dashboardService.inspectorName]);

          let action = CategoryConstants.View + ' ' + status +  ' ' + DateDifferenceConstants.TwentyToThirtyNineDays.toString();
          this.userActivityService.sendEvent(CategoryConstants.View, 'dashboard', action);
          break;
        }
        case "fortyToFiftyNineDays": {
          this.router.navigate([this.ioUrl, status, DateDifferenceConstants.FortyToFiftyNineDays.toString(), this.dashboardService.inspectorName]);

          let action = CategoryConstants.View + ' ' + status +  ' ' + DateDifferenceConstants.FortyToFiftyNineDays.toString();
          this.userActivityService.sendEvent(CategoryConstants.View, 'dashboard', action);
          break;
        }
      }
    }
    else {
      switch (days) {
        case "zeroToNineteenDays": {
          this.router.navigate([this.ioUrl, status, DateDifferenceConstants.ZeroToNineteenDays.toString()]);
          break;
        }
        case "twentyToThirtyNineDays": {
          this.router.navigate([this.ioUrl, status, DateDifferenceConstants.TwentyToThirtyNineDays.toString()]);
          break;
        }
        case "fortyToFiftyNineDays": {
          this.router.navigate([this.ioUrl, status, DateDifferenceConstants.FortyToFiftyNineDays.toString()]);
          break;
        }
      }
    }
  }

  checkIfInspector(role, status): boolean {
    if (role == RoleConstants.Inspector) {
      if (status == 'PA') {
        return false;
      }
      else {
        return true;
      }
    }
    else {
      return true
    }
  }
}
