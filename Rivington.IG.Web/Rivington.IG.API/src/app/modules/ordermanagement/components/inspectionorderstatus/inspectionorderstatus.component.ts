import { Component, OnInit, Output, EventEmitter, Input, OnDestroy } from '@angular/core';
import { PolicyService } from '../../../core/services/ordermanagement/policy.service';
import { AuthService } from '../../../core/services/auth.service';
import { Policy } from '../../../shared/models/ordermanagement/policy';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { InspectionOrderService } from '../../../core/services/ordermanagement/inspection-order.service';
import { ActivatedRoute, Router } from '@angular/router';
import { InspectionOrder } from '../../../shared/models/ordermanagement/inspection-order';
import { UtilityService } from '../../../core/services/utility.service';
import { AppSettings } from '../../../shared/models/appSettings';
import { BaseComponent } from '../../../shared/BaseComponent';
import { InspectionOrderNotes } from '../../../shared/models/inspectionordernotes';
import { ConfirmationService } from 'primeng/components/common/confirmationservice';
import Utils from '../../../shared/Utils';
import { MitigationStatusConstants } from '../../../shared/mitigation-status-constants';
import { MitigationService } from '../../../core/services/ordermanagement/inspection-order-checklist-section/mitigation.service';
import { InspectionStatusConstants } from '../../../shared/inspection-status-constants';


@Component({
  selector: 'app-inspectionorderstatus',
  templateUrl: './inspectionorderstatus.component.html',
  styleUrls: ['./inspectionorderstatus.component.css'],
  providers: [ConfirmationService]
})
export class InspectionorderstatusComponent extends BaseComponent implements OnInit, OnDestroy {
  pendingQc: boolean;
  pendUWR: boolean;
  outstandingQC: boolean;
  isNewNote: boolean;
  isEditable: boolean;
  viewOnly: boolean;
  selectedInspectionOrderNote: InspectionOrderNotes;
  display: boolean;
  public currentIOid: string;
  @Output() inspecOrderStatusForm: EventEmitter<FormGroup>;
  @Input() isChecklist: boolean;
  policyData: Policy;
  timeNow: Date;
  inspectionOrderToEdit: InspectionOrder;
  isNew: boolean;
  isExistingInspector: boolean;
  dateFormat: string;

  constructor(
    private policyService: PolicyService,
    public auth: AuthService,
    private fb: FormBuilder,
    private datePipe: DatePipe,
    public inspectionOrderService: InspectionOrderService,
    private route: ActivatedRoute,
    private utilityService: UtilityService,
    private router: Router,
    private mitigationService: MitigationService
  ) {
    super();

    this.inspectionOrderToEdit = new InspectionOrder();
    this.inspecOrderStatusForm = new EventEmitter<FormGroup>();
    this.isNew = true;
    this.isExistingInspector = false;
    this.timeNow = new Date();
    this.isChecklist = false;
  }

  ngOnInit() {
    this.inspectionOrderService.initiateFormValues();
    this.route.params.subscribe(params => {
      let paramId = params["id"];
      if (!paramId) {
        this.isNew = true;
        this.policyData = this.policyService.policyData;
      } else {
        this.isNew = false;
        if (this.isIoIdParamChanged(params)) {
          this.inspectionOrderService.getInspectionOrders("InspectionList", this.currentIOid).then(
            inspectionOrder => {
              this.inspectionOrderToEdit = Object.assign({}, this.inspectionOrderService.updateData[0]);
              this.dateFormat = this.utilityService.appSettings.defaultDateFormat;
              this.assignValues();
            });
        }
      }
    });
    this.mitigationService.getMitigationRequirementsCount(this.currentIOid).takeUntil(this.stop$).subscribe(mitigationCount =>{
      this.inspectionOrderService.incompleteMitigationCount = mitigationCount;
    })
    this.mitigationService.getMitigationCount(this.currentIOid).takeUntil(this.stop$).subscribe(allMitigationCount =>{
      this.inspectionOrderService.mitigationCount = allMitigationCount;
    })
    if (this.isNew) {
      this.inspectionOrderService.orderStatusForm.patchValue({
        'inspectionStatusId': "Pending Assignment",
        'dateCreated': this.datePipe.transform(this.timeNow, 'MMMM d, y'),
        'policyNumber': this.policyData.policyNumber
      });
    }

    this.inspectionOrderService.orderStatusForm.valueChanges.subscribe(data => {
      this.inspecOrderStatusForm.emit(this.inspectionOrderService.orderStatusForm.value);
    });

    if (!this.isNew) {
      this.inspectionOrderService.getInspectionOrderToEdit(this.currentIOid);
    }

    //Role-Based
    this.auth.currentUserRole = this.auth.getRoles().toString();
  }

  ngOnDestroy(){
    this.inspectionOrderService.mitigationStatusId = null;
  }

  isIoIdParamChanged(params: any): boolean {
    let currentParam = params["id"];
    if (this.currentIOid != currentParam) {
      this.currentIOid = currentParam;
      return true;
    }
    return false;
  }

  assignValues() {
    this.inspectionOrderService.orderStatusForm.patchValue({
      'inspectionStatusId': this.inspectionOrderToEdit.policy.inspectionStatus.name,
      'assignedDate': this.datePipe.transform(this.inspectionOrderToEdit.assignedDate, this.dateFormat),
      'policyNumber': this.inspectionOrderToEdit.policy.policyNumber,
      'inspectionDate': this.datePipe.transform(this.inspectionOrderToEdit.inspectionDate, this.dateFormat)
    });
  }

  acceptReport() {
    if (this.inspectionOrderService.pendingUnderWriterReview) {
      let mitigationStatus = "";
      if(this.inspectionOrderService.mitigationCount == 0){
        mitigationStatus = MitigationStatusConstants.NoneRequired;
      }
      else{
        mitigationStatus = MitigationStatusConstants.OutstandingItems;
      }
      Utils.blockUI();
      this.inspectionOrderService.setIOStatusAndSendEmail(this.route.snapshot.params['id'], "UWA", "SetStatusUnderWriterApproved", mitigationStatus).subscribe(res => {
        Utils.showSuccess("Report has been accepted!");
        this.router.navigate(['order-management']);
      },
        err => {
          Utils.showError(err);;
        });
    }
    else {
      Utils.blockUI();
      this.inspectionOrderService.setIOStatusAndSendEmail(this.route.snapshot.params['id'], "PUWR", "SetStatusPendingUWReviewAndSendEmail").subscribe(res => {
        Utils.showSuccess("Report has been sent to Under Writer for review");
        this.router.navigate(['order-management']);
      },
        err => {
          Utils.showError(err);;
        });
    }
  }

  rejectReport() {
    this.pendUWR = this.inspectionOrderService.pendingUnderWriterReview;
    this.viewOnly = false;
    this.isEditable = false;
    this.display = true;
    this.isNewNote = true;
    this.selectedInspectionOrderNote = new InspectionOrderNotes();
    this.outstandingQC = this.inspectionOrderService.pendingQc;
  }

  getCloseModal(closeModal) {
    this.display = closeModal;
    this.outstandingQC = false;
    this.pendUWR = false;
  }

  setMitigationToOutstanding(){
    this.inspectionOrderToEdit.policy.mitigationStatusId = MitigationStatusConstants.OutstandingItems;
    Utils.blockUI();
    this.inspectionOrderService.putInspectionOrder(this.inspectionOrderToEdit).then(data=>{
      Utils.showSuccess("Sent email to insured.")
      this.inspectionOrderService.mitigationStatusId = MitigationStatusConstants.OutstandingItems;
    }).catch(error=>{
      Utils.showError("There's a problem while sending email.");
    })
  }

  setMitigationToCompleted(){
    this.inspectionOrderToEdit.policy.mitigationStatusId = MitigationStatusConstants.Completed;
    Utils.blockUI();
    this.inspectionOrderService.putInspectionOrder(this.inspectionOrderToEdit).then(data=>{
      Utils.showSuccess("Mitigation Completed.")
      this.inspectionOrderService.mitigationStatusId = MitigationStatusConstants.Completed;
      this.router.navigate(['order-management']);
    }).catch(error=>{
      Utils.showError("There's a problem while sending email.");
    })
  }

  setInspectionStatusToPendingWriteUp(){
    this.inspectionOrderToEdit.policy.inspectionStatusId = InspectionStatusConstants.PendingWriteUp;
    Utils.blockUI();
    this.inspectionOrderService.putInspectionOrder(this.inspectionOrderToEdit).then(data=>{
      this.inspectionOrderService.inspectionComplete = true;
      Utils.showSuccess("Inspection Completed.")
      this.router.navigate(['order-management']);
    }).catch(error=>{
      Utils.showError("There's a problem while completing the inspection order.");
    })
  }

  showMitigationAction() : boolean{
    return !this.isNew && (this.inspectionOrderService.constantPendingReview == this.inspectionOrderService.mitigationStatusId 
      || this.inspectionOrderService.constantOutstanding == this.inspectionOrderService.mitigationStatusId);
  }

  enableAcceptButton(): boolean{
    return this.inspectionOrderService.incompleteMitigationCount != 0
      || this.inspectionOrderService.constantPendingReview != this.inspectionOrderService.mitigationStatusId;
  }

  enableRejectButton(): boolean{
    return this.inspectionOrderService.incompleteMitigationCount == 0
      || this.inspectionOrderService.constantPendingReview != this.inspectionOrderService.mitigationStatusId;
  }
  
}
