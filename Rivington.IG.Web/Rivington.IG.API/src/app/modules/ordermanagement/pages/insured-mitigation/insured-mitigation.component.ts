import { Component, OnInit, HostListener } from '@angular/core';
import { AuthService } from '../../../core/services/auth.service';
import { RoleConstants } from '../../../shared/roleconstants';
import { SafeHtml, DomSanitizer } from '@angular/platform-browser';
import { InspectionOrderService } from '../../../core/services/ordermanagement/inspection-order.service';
import { InspectionOrderChecklistWildFireService } from '../../../core/services/ordermanagement/inspection-order-checklist-section/wildfire.service';
import { ActivatedRoute } from '@angular/router';
import { InspectionOrder } from '../../../shared/models/ordermanagement/inspection-order';
import { MitigationStatusConstants } from '../../../shared/mitigation-status-constants';
import Utils from '../../../shared/Utils';

@Component({
  selector: 'app-insured-mitigation',
  templateUrl: './insured-mitigation.component.html',
  styleUrls: ['./insured-mitigation.component.css']
})
export class InsuredMitigationComponent implements OnInit {

  hideLinks: SafeHtml;
  currentIoId: string;
  inspectionOrder: InspectionOrder;
  isWildfireAssessment: boolean;
  insuredName: string;

  constructor(
    public auth: AuthService,
    private sanitizer: DomSanitizer,
    private ioService: InspectionOrderService,
    private wildfireService: InspectionOrderChecklistWildFireService,
    private route: ActivatedRoute
  ) {
    this.inspectionOrder = new InspectionOrder();
    this.insuredName = "";
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      let paramId = params["id"];
      this.currentIoId = paramId;
    });

    this.ioService.getInspectionOrders("InspectionList", this.currentIoId).then(
      data => {
        this.inspectionOrder = data[0];
        this.insuredName = this.inspectionOrder.policy.insuredFirstName + " " + this.inspectionOrder.policy.insuredLastName;
        this.isWildfireAssessment = this.inspectionOrder.policy.wildfireAssessmentRequired;
      });

    this.hideLinks = this.sanitizer.bypassSecurityTrustHtml(
      `<style>
      ma-sidebar{
        display:none;
      }
      .page-wrapper{
        margin-left: 0;
      }  
      breadcrumb{
        display:none;
      }
      .footer{
        left: 0;
      }
      html{
        background: #eef5f9;
      }
      .headerList{
        display:none;
      }
      #insuredMitigationCard{
        margin-top: 2%;
      }
    </style>`);
  }

  @HostListener('window:unload', ['$event'])
  unloadHandler($event: any) {
    let currentRole = this.auth.getRoles().toString();
    if (currentRole == RoleConstants.Insured) {
      this.auth.logout();
    }
  }

  setMitigationToPendingReview() {
    this.inspectionOrder.policy.mitigationStatusId = MitigationStatusConstants.PendingReview;
    Utils.blockUI();
    this.ioService.putInspectionOrder(this.inspectionOrder).then(data => {
      Utils.showSuccess("Mitigation sent to Inspector.");
      this.ioService.mitigationStatusId = MitigationStatusConstants.PendingReview;
    }).catch(error => {
      Utils.showError("There's a problem while completing the mitigation.");
    })
  }

  checkIfButtonDisabled(): boolean {
    if (this.ioService.incompleteMitigationCount != 0) {
      return true;
    }
    else {
      if (this.ioService.mitigationStatusId == MitigationStatusConstants.OutstandingItems) {
        return false;
      }
      else {
        return true;
      }
    }
  }

}
