import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MitigationService } from '../../../../../modules/core/services/ordermanagement/inspection-order-checklist-section/mitigation.service';
import { UtilityService } from '../../../../../modules/core/services/utility.service';
import Utils from '../../../../../modules/shared/Utils';

@Component({
  selector: 'app-mitigation-recommendations',
  templateUrl: './mitigation-recommendations.component.html',
  styleUrls: ['./mitigation-recommendations.component.css']
})
export class MitigationRecommendationsComponent implements OnInit {

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

    this.mitigationService.getNonWildfireAssessmentMitigationRecommendation(this.currentIoId).subscribe(
      mitigations =>{
        this.mitigationRecommendations = mitigations;
      },
      error =>{
        Utils.showGenericHttpErrorResponse(error);
      });
  }
}
