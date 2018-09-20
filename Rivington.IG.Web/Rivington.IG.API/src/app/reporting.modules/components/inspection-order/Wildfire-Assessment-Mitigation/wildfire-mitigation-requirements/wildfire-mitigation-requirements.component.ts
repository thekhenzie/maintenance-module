import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MitigationService } from '../../../../../modules/core/services/ordermanagement/inspection-order-checklist-section/mitigation.service';
import { UtilityService } from '../../../../../modules/core/services/utility.service';
import Utils from '../../../../../modules/shared/Utils';

@Component({
  selector: 'app-wildfire-mitigation-requirements',
  templateUrl: './wildfire-mitigation-requirements.component.html',
  styleUrls: ['./wildfire-mitigation-requirements.component.css']
})
export class WildfireMitigationRequirementsComponent implements OnInit {

  currentIoId: string;
  mitigationRequirements: any;

  constructor(
    private route: ActivatedRoute,
    private mitigationService: MitigationService,
    private utilityService: UtilityService
  ) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.currentIoId = params["id"];
    });

    this.mitigationService.getWildfireAssessmentMitigationRequirement(this.currentIoId).subscribe(
      mitigations =>{
        this.mitigationRequirements = mitigations;
      },
      error =>{
        Utils.showGenericHttpErrorResponse(error);
      });
  }
}
