import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UtilityService } from '../../../../../modules/core/services/utility.service';
import { MitigationService } from '../../../../../modules/core/services/ordermanagement/inspection-order-checklist-section/mitigation.service';
import Utils from '../../../../../modules/shared/Utils';

@Component({
  selector: 'app-mitigation-requirements',
  templateUrl: './mitigation-requirements.component.html',
  styleUrls: ['./mitigation-requirements.component.css']
})
export class MitigationRequirementsComponent implements OnInit {

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

    this.mitigationService.getNonWildfireAssessmentMitigationRequirement(this.currentIoId).subscribe(
      mitigations =>{
        this.mitigationRequirements = mitigations;
      },
      error =>{
        Utils.showGenericHttpErrorResponse(error);
      });
  }
}
