import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../core/services/auth.service';
import { RoleConstants } from '../../../shared/roleconstants';
import { Inspector } from '../../../shared/models/ordermanagement/inspector';
import Utils from '../../../shared/Utils';
import { DashboardService } from '../../../core/services/dashboard/dashboard.service';
import { InspectionStatusGroupingsView } from '../../../shared/models/dashboard/inspection-status-groupings-view';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  userRole: string;
  inspectorRole: string;

  constructor(
    private auth: AuthService,
    private dashboardService: DashboardService
  ) {
    this.dashboardService.groupedInspectionStatus = [];
  }

  ngOnInit() {
    this.userRole = this.auth.getRoles().toString();
    this.inspectorRole = RoleConstants.Inspector;

    // Reset dashboard inspector
    this.dashboardService.inspector = null;
    this.dashboardService.currentUser = "";
    this.dashboardService.inspectorName = "";
  }

  getInspector(inspectorInfo) {

    if (inspectorInfo) {
      this.dashboardService.inspector = inspectorInfo;
      this.dashboardService.currentUser = this.dashboardService.inspector.userName;
      this.dashboardService.inspectorName = this.dashboardService.inspector.firstName + " " + this.dashboardService.inspector.lastName;
    }
    else {
      // Clear inspector
      this.dashboardService.inspector = null;
      this.dashboardService.currentUser = "";
      this.dashboardService.inspectorName = "";
    }

    this.dashboardService.getInspectionStatusGroupings(this.dashboardService.currentUser).subscribe(
      statusList => {
        this.dashboardService.groupedInspectionStatus = statusList;
      },
      onerror => {
        Utils.showError("There's an error while retrieving inspection orders.");
      }
    );

    this.dashboardService.getSentToInsuredStatusCount(this.dashboardService.currentUser).subscribe(
      statusCount => {
        this.dashboardService.linksSent = statusCount;
      },
      onerror => {
        Utils.showError("There's an error while retrieving inspection orders.");
      }
    )

    this.dashboardService.getMitigationStatusCount(this.dashboardService.currentUser).subscribe(
      statusList => {
        this.dashboardService.groupedMitigationStatus = statusList;
      },
      onerror => {
        Utils.showError("There's an error while retrieving inspection orders.");
      }
    );

  }

}
