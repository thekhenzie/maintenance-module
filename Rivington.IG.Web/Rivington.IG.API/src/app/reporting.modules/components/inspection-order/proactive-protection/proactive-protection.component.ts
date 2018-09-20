import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../../../modules/shared/BaseComponent';
import { ActivatedRoute } from '@angular/router';
import { MitigationService } from '../../../../modules/core/services/ordermanagement/inspection-order-checklist-section/mitigation.service';
import { InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements } from '../../../../modules/shared/models/ordermanagement/inspection-order/checklist/mitigation/InspectionOrderNonWildfireAssessmentMitigationRequirements';
import { InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations } from '../../../../modules/shared/models/ordermanagement/inspection-order/checklist/mitigation/InspectionOrderNonWildfireAssessmentMitigationRecommendations';
import { InspectionOrderChecklistPropertyService } from '../../../../modules/core/services/ordermanagement/inspection-order-checklist-section/property.service';
import { ReportingService } from '../../../../modules/core/services/reporting/reporting.service';

@Component({
  selector: 'app-proactive-protection',
  templateUrl: './proactive-protection.component.html',
  styleUrls: ['./proactive-protection.component.css']
})
export class ProactiveProtectionComponent extends BaseComponent implements OnInit {

  policyPremiumCredits: any[];
  public currentInspectionOrderId: string;

  mitigationRequirements: InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements[];
  mitigationRecommendations:InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations[];

  constructor(
    private route: ActivatedRoute,
    private mitigationService: MitigationService,
    public propertyService: InspectionOrderChecklistPropertyService,
    public reportingService: ReportingService,) {
    super();
    this.policyPremiumCredits = [];
    this.mitigationRequirements = [];
    this.mitigationRecommendations = [];
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.currentInspectionOrderId = params["id"];
    });

    this.reportingService.getIoDataSubscribeEmitter().takeUntil(this.stop$).subscribe(data => {
      this.policyPremiumCredits = this.reportingService.policyPremiumCredits;
      this.mitigationRequirements = this.reportingService.mitigationRequirements;
      this.mitigationRecommendations = this.reportingService.mitigationRecommendations;
    });
  }

}
