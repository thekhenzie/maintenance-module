import { Component, OnInit } from '@angular/core';
import { ReportingService } from '../../../modules/core/services/reporting/reporting.service';
import { BaseComponent } from '../../../modules/shared/BaseComponent';
import Utils from '../../../modules/shared/Utils';
import { UserActivityLogService } from '../../../modules/core/services/ordermanagement/user-activity-log.service';
import { CategoryConstants } from '../../../modules/shared/models/user-activity-category-constants';
import { AuthService } from '../../../modules/core/services/auth.service';

@Component({
  selector: 'app-reporting',
  templateUrl: './reporting.component.html',
  styleUrls: ['./reporting.component.css']
})
export class ReportingComponent extends BaseComponent implements OnInit {
  public showHeader: boolean;
  currentIoId: string;

  constructor(
    private reportingService: ReportingService,
    private userActivityService: UserActivityLogService,
    private auth: AuthService
  ) { 
    super();
    this.showHeader = !this.reportingService.isDownload();
  }
  
  ngOnInit() {
    if(!this.showHeader) this.reportingService.showTopLoader(false);
    
    this.reportingService.getRouteParamSubscribeEmitter().takeUntil(this.stop$).subscribe(params => {
      this.currentIoId = params["id"];
    });
  }

  generatePDF() {
    Utils.blockUI();

    this.reportingService.generatePdfReport(this.currentIoId).takeUntil(this.stop$)
    .subscribe(fileData => {
      if(fileData.size === 0) {
        return Utils.showError("Error occurred upon generation of PDF report.");
      }

      let url = window.URL.createObjectURL(fileData);

      // open a new tab in chrome
      window.open(url);

      // // start download
      // var a = document.createElement("a");
      // a.href = url;
      // a.download = "Inspection-Order-Report";
      // a.target = "_blank";
      // a.click();
      
      Utils.unblockUI();
    },
    err => {
      Utils.showGenericHttpErrorResponse(err);
    },
    () => {  
    });

    this.userActivityService.sendEvent(CategoryConstants.Generate, 'reporting/order-management/inspection-order', 'Generate Report');
  }
}