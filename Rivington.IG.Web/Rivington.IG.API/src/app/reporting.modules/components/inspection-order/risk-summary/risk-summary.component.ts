import { Component, OnInit } from '@angular/core';
import { InspectionOrderService } from '../../../../modules/core/services/ordermanagement/inspection-order.service';
import { ActivatedRoute } from '@angular/router';
import { BaseComponent } from '../../../../modules/shared/BaseComponent';
import { ReportingService } from '../../../../modules/core/services/reporting/reporting.service';

@Component({
  selector: 'app-risk-summary',
  templateUrl: './risk-summary.component.html',
  styleUrls: ['./risk-summary.component.css']
})
export class RiskSummaryComponent extends BaseComponent implements OnInit {

  riskSummary: string;
  public currentInspectionOrderId: string;

  constructor(
    public ioService: InspectionOrderService,
    private route: ActivatedRoute,
    public reportingService: ReportingService) {
    super();
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.currentInspectionOrderId = params["id"];
    });
    this.reportingService.getIoDataSubscribeEmitter().takeUntil(this.stop$).subscribe(data => {
      this.riskSummary = this.reportingService.riskSummary;
    });
  }

  replaceStringIfNullOrEmpty(value: string, valueToReplace: string): string {
    // if(this.wildfireViewModel) console.log(`replaceStringIfNullOrEmpty("${value}", "${valueToReplace}")`);
    // console.log(value ? value : valueToReplace);
    return value ? value : valueToReplace;
  }

}
