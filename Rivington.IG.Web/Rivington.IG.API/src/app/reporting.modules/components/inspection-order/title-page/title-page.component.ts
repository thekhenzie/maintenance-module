import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../../../modules/shared/BaseComponent';
import { ActivatedRoute } from '@angular/router';
import { InspectionOrderService } from '../../../../modules/core/services/ordermanagement/inspection-order.service';
import { UtilityService } from '../../../../modules/core/services/utility.service';
import { ReportingService } from '../../../../modules/core/services/reporting/reporting.service';
import { DatePipe } from '@angular/common';
import { InspectionOrder } from '../../../../modules/shared/models/ordermanagement/inspection-order';
import { ReportTitleViewModel } from '../../../../modules/shared/models/view-model/report-title-page-view-model';

@Component({
  selector: 'app-title-page',
  templateUrl: './title-page.component.html',
  styleUrls: ['./title-page.component.css']
})
export class TitlePageComponent extends BaseComponent implements OnInit {
  public currentIoId: string;

  reportTitleViewModel: ReportTitleViewModel;

  constructor(
    private route: ActivatedRoute,
    private inspectionOrderService: InspectionOrderService,
    private utilityService: UtilityService,
    public reportingService: ReportingService,
  ) {
    super();
    this.reportTitleViewModel = new ReportTitleViewModel();
  }

  ngOnInit() {

    this.route.params.subscribe(params => {
      this.currentIoId = params["id"];
    });

    this.reportingService.getIoDataSubscribeEmitter().takeUntil(this.stop$).subscribe(data => {
      this.reportTitleViewModel = this.reportingService.reportTitleViewModel;
    });
  }
}
