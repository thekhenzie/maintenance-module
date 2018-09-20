import { Component, OnInit, AfterViewInit, OnDestroy, HostListener } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BaseComponent } from '../../../modules/shared/BaseComponent';
import { InspectionOrderService } from '../../../modules/core/services/ordermanagement/inspection-order.service';
import { UtilityService } from '../../../modules/core/services/utility.service';
import Utils from '../../../modules/shared/Utils';
import { ReportingService } from '../../../modules/core/services/reporting/reporting.service';
import { PathConstants } from '../../../modules/shared/pathconstants';
import { UserActivityLogService } from '../../../modules/core/services/ordermanagement/user-activity-log.service';
import { CategoryConstants } from '../../../modules/shared/models/user-activity-category-constants';
import { AuthService } from '../../../modules/core/services/auth.service';

@Component({
  selector: 'app-inspection-order-report',
  templateUrl: './inspection-order.component.html',
  styleUrls: ['./inspection-order.component.css']
})
export class InspectionOrderReportComponent extends BaseComponent implements OnInit, AfterViewInit, OnDestroy {
  public currentIoId: string;

  constructor(
    private route: ActivatedRoute,
    private inspectionOrderService: InspectionOrderService,
    private utilityService: UtilityService,
    private reportingService: ReportingService,
    private _router: Router,
    private userActivityService: UserActivityLogService,
    private auth: AuthService
  ) { 
    super();
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.reportingService.broadcastParamChange(params);
      this.currentIoId = params["id"];
      
      this.reportingService.getIoReportData(this.currentIoId).takeUntil(this.stop$)
      .subscribe(data => {
        // console.log("this.reportingService.getIoReportData(this.currentIoId)");
        // console.log(data);
        // if (this.reportingService.isDownload()) {
        //   setTimeout(() => {
        //       window.status = "ready_to_print";
        //       // this.utilityService.updateWindowStatusToReadyToPrint();
        //   }, 5000);
        // }
      },
      error => {
        // if(error.status == 401){
        //   // window.alert("You should be logged-in to view this page");
        //   // if(this._router.url.search("insured") != -1){
        //   //   this._router.navigate([PathConstants.Account.InsuredReportLogin]);
        //   // }
        //   // return false;
        // }
        console.log(error);
      }, 
      () => {

      });
    });

    this.auth.isInsured = (this._router.url.search("insured") != -1);

    this.userActivityService.sendEvent( CategoryConstants.View, 'reporting/order-management/inspection-order', CategoryConstants.View + ' Report');
  }

  @HostListener('window:beforeunload', ['$event'])
  unloadNotification($event: any) {
    if(this._router.url.search("insured") != -1){
      this.auth.logout();
    }
  }

  ngOnDestroy(){
    if(this._router.url.search("insured") != -1){
      this.auth.logout();
    }
  }
  
  ngAfterViewInit() {
    if (this.reportingService.isDownload()) {
      this.utilityService.updateWindowStatusToReadyToPrint();
    }
  }
}
