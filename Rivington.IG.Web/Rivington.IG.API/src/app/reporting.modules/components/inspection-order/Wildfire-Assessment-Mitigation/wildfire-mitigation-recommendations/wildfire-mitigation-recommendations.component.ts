import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MitigationService } from '../../../../../modules/core/services/ordermanagement/inspection-order-checklist-section/mitigation.service';
import { UtilityService } from '../../../../../modules/core/services/utility.service';
import Utils from '../../../../../modules/shared/Utils';

@Component({
  selector: 'app-wildfire-mitigation-recommendations',
  templateUrl: './wildfire-mitigation-recommendations.component.html',
  styleUrls: ['./wildfire-mitigation-recommendations.component.css']
})
export class WildfireMitigationRecommendationsComponent implements OnInit {

  currentIoId: string;
  mitigationRecommendations: any;

  constructor(
    private route: ActivatedRoute,
    private mitigationService: MitigationService,
    private utilityService: UtilityService
  ) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.currentIoId = params["id"];
    });

    this.mitigationService.getWildfireAssessmentMitigationRecommendation(this.currentIoId).subscribe(
      mitigations =>{
        this.mitigationRecommendations = mitigations;
      },
      error =>{
        Utils.showGenericHttpErrorResponse(error);
      });
  }
}
