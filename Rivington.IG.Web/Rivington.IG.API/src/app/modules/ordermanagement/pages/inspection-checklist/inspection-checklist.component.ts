import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../../../core/services/auth.service';
import { InspectionOrderChecklistPropertyService } from '../../../core/services/ordermanagement/inspection-order-checklist-section/property.service';
import { InspectionOrderChecklistService } from '../../../core/services/ordermanagement/inspection-order-checklist.service';
import { BaseComponent } from '../../../shared/BaseComponent';
import Utils from '../../../shared/Utils';
import { InspectionOrder } from '../../../shared/models/ordermanagement/inspection-order';
import { InspectionOrderChecklistWildFireService } from '../../../core/services/ordermanagement/inspection-order-checklist-section/wildfire.service';
import { InspectionOrderService } from '../../../core/services/ordermanagement/inspection-order.service';
import { InspectionOrderNotes } from '../../../shared/models/inspectionordernotes';
import { UserActivityLogService } from '../../../core/services/ordermanagement/user-activity-log.service';
import { CategoryConstants } from '../../../shared/models/user-activity-category-constants';

@Component({
  selector: 'app-inspection-checklist',
  templateUrl: './inspection-checklist.component.html',
  styleUrls: ['./inspection-checklist.component.css']
})
export class InspectionChecklistComponent extends BaseComponent implements OnInit, OnDestroy {
  inspectorToUW: boolean;
  isNewNote: boolean;
  isEditable: boolean;
  viewOnly: boolean;
  selectedInspectionOrderNote: InspectionOrderNotes;
  pendingWriteUp: boolean;
  display: boolean;
  highValueCoverageA: number;
  inspectionOrder: InspectionOrder;
  currentIOid: string;
  isChecklist: boolean;

  constructor(
    private ioChecklistService: InspectionOrderChecklistService,
    private ioChecklistPropertyService: InspectionOrderChecklistPropertyService,
    private ioChecklistWildfireService: InspectionOrderChecklistWildFireService,
    public auth: AuthService,
    private route: ActivatedRoute,
    public ioService: InspectionOrderService,
    private router: Router,
    private userActivityService: UserActivityLogService
  ) {
    super();
    this.highValueCoverageA = 1000000;
    this.isChecklist = true;
  }

  ngOnInit() {
    this.route.params.takeUntil(this.stop$).subscribe(params => {
      let ioId = params["id"];
      if(this.currentIOid !== ioId) {
        this.currentIOid = ioId;
      }
    });

    this.ioService.initiateRiskSummaryFormValue();
    this.ioService.isChecklist = this.isChecklist;

    // role-based
    this.ioService.getInspectionOrders("InspectionList", this.currentIOid).then(
      data => {
        this.ioService.inspectionOrder = Object.assign({}, this.ioService.updateData[0]);
        this.auth.currentUserRole = this.auth.getRoles().toString();
        if (this.auth.currentUserRole && !this.ioService.checkIOBasedOnRole(this.auth.currentUserRole)) {
          // io status bar
          this.ioService.orderStatusForm.disable();
          // risk-summary
          this.ioService.riskSummaryForm.disable();
        }
    });

    this.userActivityService.sendEvent(CategoryConstants.View, 'order-management/checklist', CategoryConstants.View + ' Inspection Order Checklist Page');
  }
  updateIO() {
    try {
      Utils.blockUI();

      let inspectionOrder = new InspectionOrder({
        id: this.currentIOid,
        property: this.ioChecklistPropertyService.getPropertyValues(),
        wildfireAssessment: this.ioChecklistWildfireService.getWildfireAssessmentValues(),
        riskSummary: this.ioService.getRiskSummaryValue()
      });
      
      this.ioChecklistService.putInspectionOrder(inspectionOrder).takeUntil(this.stop$)
        .subscribe(data => {
          Utils.showSuccess("Updated successfully.");
        },
        err => {
          Utils.showGenericHttpErrorResponse(err);
        },
        () => {
                 
        });
    } catch (error) {
      Utils.showError(error);
    }
  }

  addNote() {
    this.inspectorToUW = (this.ioService.pendingUnderWriterReview || this.ioService.underWriterIssues);
    this.viewOnly = false;
    this.isEditable = false;
    this.display = true;
    this.isNewNote = true;
    this.selectedInspectionOrderNote = new InspectionOrderNotes();
    this.pendingWriteUp = (this.ioService.pendingWriteUp || this.ioService.outStandingQc);
  }

  getCloseModal(closeModal) {
    this.display = closeModal;
    this.pendingWriteUp = false;
    this.inspectorToUW = false;
  }

  ngOnDestroy() {
    this.ioService.isChecklist = false;
  }
}
