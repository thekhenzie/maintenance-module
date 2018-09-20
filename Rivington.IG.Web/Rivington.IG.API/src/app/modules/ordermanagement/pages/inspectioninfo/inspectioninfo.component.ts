import { Component, OnInit, Input, OnChanges, HostListener, OnDestroy, ViewChild, ElementRef } from '@angular/core';
import { PolicyService } from '../../../core/services/ordermanagement/policy.service';
import { AuthService } from '../../../core/services/auth.service';
import { PolicyComponent } from '../../components/policy/policy.component';
import { FormGroup } from '@angular/forms';
import { Inspector } from '../../../shared/models/ordermanagement/inspector';
import { InspectionOrderService } from '../../../core/services/ordermanagement/inspection-order.service';
import { Router, ActivatedRoute } from '@angular/router';
import { InspectionOrder } from '../../../shared/models/ordermanagement/inspection-order';
import Utils from '../../../shared/Utils';
import { Policy } from '../../../shared/models/ordermanagement/policy';
import { DatePipe } from '@angular/common';
import { UtilityService } from '../../../core/services/utility.service';
import { isNullOrUndefined } from 'util';
import { InspectionOrderProperty } from '../../../shared/models/ordermanagement/inspection-order/checklist/property';
import { InspectionOrderPropertyGeneral } from '../../../shared/models/ordermanagement/inspection-order/checklist/property/general';
import { InspectionOrderNotesService } from '../../../core/services/ordermanagement/inspection-notes.service';
import { InspectionOrderNotes } from '../../../shared/models/inspectionordernotes';
import { UserActivityLogService } from '../../../core/services/ordermanagement/user-activity-log.service';
import { CategoryConstants } from '../../../shared/models/user-activity-category-constants';
import { InspectionStatusConstants } from '../../../shared/inspection-status-constants';

@Component({
  selector: 'app-inspectioninfo',
  templateUrl: './inspectioninfo.component.html',
  styleUrls: ['./inspectioninfo.component.css']
})
export class InspectioninfoComponent implements OnInit, OnDestroy {
  submitButtonText: string;
  policy: any;
  inspector: Inspector;
  agentInfo: Policy;
  policyInfo: any;
  insuredInfo: Policy;
  inspectionStatusInfo: Policy;
  isNew: boolean;
  inspectionOrderToEdit: InspectionOrder;
  inspectionOrder: InspectionOrder;
  currentPolicyId: string;
  stringId: string;
  dateFormat: string;
  inspectorUserName: string;
  isCreate: boolean;
  mapItIsInitialized: boolean = false;

  orderNotes: InspectionOrderNotes[];

  constructor(
    private policyService: PolicyService,
    private utilityService: UtilityService,
    public inspectionOrderService: InspectionOrderService,
    public auth: AuthService,
    private datePipe: DatePipe,
    private route: ActivatedRoute,
    private router: Router,
    private ioNotes: InspectionOrderNotesService,
    private userActivityService: UserActivityLogService
  ) {
    this.inspectionOrder = new InspectionOrder();
    this.inspectionOrder.property = new InspectionOrderProperty();
    this.inspectionOrder.property.general = new InspectionOrderPropertyGeneral();
    this.agentInfo = new Policy();
    this.policyInfo = new Policy();
    this.insuredInfo = new Policy();
    this.isNew = true;
    this.inspectorUserName = "";
    this.isCreate = false;
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      let paramId = params["id"];
      this.submitButtonText = "Inspection Order";
      if (!paramId) {
        if (!this.policyService.policyData) {
          return this.router.navigate(['order-management/inspection-order/create/get-policy']);
        }
        this.isNew = true;
        this.submitButtonText = "Create " + this.submitButtonText;
      } else {
        this.isNew = false;
        this.stringId = paramId;
        this.getInspectionOrderToEdit();
        this.submitButtonText = "Update " + this.submitButtonText;
      }
    });

    this.inspectionOrderService.initiateFormValues();
    this.dateFormat = this.utilityService.appSettings.defaultDateFormat;
    this.auth.isIOInfo = true;

    if (!this.isNew) {
      this.inspectionOrderService.getInspectionOrderToEdit(this.stringId);
    }
  }

  ngOnDestroy(){
    this.auth.isIOInfo = false;
  }

  @HostListener('window:beforeunload', ['$event'])
  unloadNotification($event: any) {
    if (isNullOrUndefined(this.policyService.policyData)) {
      $event.returnValue = false;
    }
    else if (this.hasUnsavedData()) {
      $event.returnValue = true;
    }
  }

  hasUnsavedData(){
    if(this.isNew && 
      !this.isCreate &&
      this.policyService.policyData
    ){
      return true;
    }
    else{
      return false;
    }
  }

  assignValues() {
    if (!this.isNew) {
      this.inspectionOrderService.insuredForm.patchValue({
        'insuredFirstName': this.inspectionOrderToEdit.policy.insuredFirstName,
        'insuredLastName': this.inspectionOrderToEdit.policy.insuredLastName,
        'insuredMiddleName': this.inspectionOrderToEdit.policy.insuredMiddleName,
        'insuredEmail': this.inspectionOrderToEdit.policy.insuredEmail,
        'address': this.inspectionOrderToEdit.property.general.streetAddress1 + " " + this.inspectionOrderToEdit.property.general.streetAddress2 + " " + this.inspectionOrderToEdit.property.general.state.name + " " + this.inspectionOrderToEdit.property.general.city.name + " " + this.inspectionOrderToEdit.property.general.zipCode,
        'latitude': this.inspectionOrderToEdit.policy.latitude,
        'longitude': this.inspectionOrderToEdit.policy.longitude,
        'insuredCity': this.inspectionOrderToEdit.policy.insuredCity,
        'insuredState': this.inspectionOrderToEdit.policy.insuredState,
        'insuredZipCode': this.inspectionOrderToEdit.policy.insuredZipCode,
      });

      this.inspectionOrderService.city = this.inspectionOrderToEdit.property.general.city;
      this.inspectionOrderService.state = this.inspectionOrderToEdit.property.general.state;
      this.inspectionOrderService.zipcode = this.inspectionOrderToEdit.property.general.zipCode;

      if (this.inspectionOrderToEdit.policy.mitigationStatus != null) {
        this.inspectionOrderService.policyForm.setValue({
          'policyNumber': this.inspectionOrderToEdit.policy.policyNumber,
          'inspectionDate': this.datePipe.transform(this.inspectionOrderToEdit.policy.inspectionDate, this.dateFormat),
          'inceptionDate': this.datePipe.transform(this.inspectionOrderToEdit.policy.inceptionDate, this.dateFormat),          
          'coverageA': this.inspectionOrderToEdit.policy.coverageA,
          'e2ValueReplacementCostValue': this.inspectionOrderToEdit.policy.e2ValueReplacementCostValue,
          'itvPercentage': this.inspectionOrderToEdit.policy.itvPercentage,
          'wildfireAssessmentRequired': this.inspectionOrderToEdit.policy.wildfireAssessmentRequired,
          'propertyValueId': this.inspectionOrderToEdit.policy.propertyValue.id,
          'inspectionStatusId': this.inspectionOrderToEdit.policy.inspectionStatus.id,
          'mitigationStatusId': this.inspectionOrderToEdit.policy.mitigationStatus.id
        })
      } else {
        this.inspectionOrderService.policyForm.patchValue({
          'policyNumber': this.inspectionOrderToEdit.policy.policyNumber,
          'inceptionDate': this.datePipe.transform(this.inspectionOrderToEdit.policy.inceptionDate, this.dateFormat),          
          'inspectionDate': this.datePipe.transform(this.inspectionOrderToEdit.policy.inspectionDate, this.dateFormat),
          'coverageA': this.inspectionOrderToEdit.policy.coverageA,
          'e2ValueReplacementCostValue': this.inspectionOrderToEdit.policy.e2ValueReplacementCostValue,
          'itvPercentage': this.inspectionOrderToEdit.policy.itvPercentage,
          'wildfireAssessmentRequired': this.inspectionOrderToEdit.policy.wildfireAssessmentRequired,
          'propertyValueId': this.inspectionOrderToEdit.policy.propertyValue.id,
          'inspectionStatusId': this.inspectionOrderToEdit.policy.inspectionStatus.id
        })
      }

      this.inspectionOrderService.agentForm.setValue({
        'agentName': this.inspectionOrderToEdit.policy.agentName,
        'agencyName': this.inspectionOrderToEdit.policy.agencyName,
        'agentPhoneNumber': this.inspectionOrderToEdit.policy.agentPhoneNumber,
        'agencyPhoneNumber': this.inspectionOrderToEdit.policy.agencyPhoneNumber,
      });

      if (this.inspectionOrderToEdit.inspector) {
        this.inspectionOrderService.inspector = this.inspectionOrderToEdit.inspector;
        this.inspectorUserName = this.inspectionOrderService.inspector.firstName + " " + this.inspectionOrderService.inspector.lastName;
      }

      this.policyInfo.id = this.inspectionOrderToEdit.policy.id;
    }
  }

  getInspectionOrderToEdit() {
    this.inspectionOrderService.getInspectionOrders("InspectionList", this.stringId).then(
      data => {
        this.inspectionOrderToEdit = Object.assign({}, this.inspectionOrderService.updateData[0]);
        this.inspectionOrderService.inspectionOrder = Object.assign({}, this.inspectionOrderService.updateData[0]);
        this.assignValues();
        this.roleBasedRestrictions();
      });
  }

  roleBasedRestrictions(){
    // For Role-Based
    this.auth.currentUserRole = this.auth.getRoles().toString();
    if (this.auth.currentUserRole) {
        if (!this.inspectionOrderService.checkIOBasedOnRole(this.auth.currentUserRole)) {
            this.inspectionOrderService.policyForm.disable();
            this.inspectionOrderService.orderStatusForm.disable();
            this.inspectionOrderService.insuredForm.disable();
            this.inspectionOrderService.agentForm.disable();
        }
    }
  }

  saveInspectionOrder() {
    try {
      Utils.blockUI();
      let status = this.inspectionOrderService.policyForm.value.inspectionStatusId;
      if (this.isNew) {
        // if(this.inspectionOrderService.policyForm.invalid){
        //   Utils.showError("Please complete all required fields in Policy Form!");
        // }
        // else if(this.inspectionOrderService.agentForm.invalid){
        //   Utils.showError("Please complete all required fields in Agent Info Form!");
        // }
        // else {
        if (this.inspector) this.inspectionOrder.inspectorId = this.inspector.id;
        this.inspectionOrder.policy = Object.assign({}, this.agentInfo, this.insuredInfo, this.policyInfo);
        this.inspectionOrder.property.general = Object.assign({}, this.inspectionOrderService.inspectionOrderPropertyGeneral);

        if (status == "S" &&
          (isNullOrUndefined(this.inspectionOrderService.policyForm.value.inspectionDate) ||
            isNullOrUndefined(this.inspectionOrder.inspectorId))) {
          Utils.showError("Inspector and Inspection Date is required when inspection status is Scheduled.");
        }
        else if (status == "RTS" && isNullOrUndefined(this.inspectionOrder.inspectorId)) {
          Utils.showError("Inspector is required when inspection status is Ready to Schedule.");
        }
        else if (this.inspectionOrderService.policyForm.value.inceptionDate == "") {
          Utils.showError("Inception Date is required");
        }
        else {
          this.inspectionOrderService.postInspectionOrder(this.inspectionOrder)
            .then(data => {
              this.isCreate = true;

              this.userActivityService.sendEvent(CategoryConstants.Create, 'order-management/info', CategoryConstants.CreatedIO);

              this.router.navigate(['order-management']);
            }).catch((error) => {
              this.isCreate = false;
              Utils.showError("Complete the fields Property Value and Inspection Status");
            });
        }
        // }
      }
      else {
        // if (this.inspectionOrderService.policyForm.invalid) {
        //   Utils.showError("Please complete all required fields in Policy Form!");
        // }
        // else if (this.inspectionOrderService.agentForm.invalid) {
        //   Utils.showError("Please complete all required fields in Agent Info Form!");
        // }
        // else {
        if (this.inspector) this.inspectionOrderToEdit.inspectorId = this.inspector.id;
        this.currentPolicyId = this.inspectionOrderToEdit.policy.id;
        this.inspectionOrderToEdit.assignedDate = this.inspectionOrderService.orderStatusForm.value.assignedDate;
        this.inspectionOrderToEdit.policy = Object.assign({}, this.agentInfo, this.insuredInfo, this.inspectionStatusInfo, this.policyInfo);
        this.inspectionOrderToEdit.policy.id = this.currentPolicyId;
        this.inspectionOrderToEdit.inspectionDate = this.inspectionStatusInfo.inspectionDate;

        if (status == "S" &&
          (isNullOrUndefined(this.inspectionOrderService.policyForm.value.inspectionDate) ||
            isNullOrUndefined(this.inspectionOrderToEdit.inspectorId))) {
          Utils.showError("Inspector and Inspection Date is required when inspection status is Scheduled.");
        }
        else if (status == "RTS" && isNullOrUndefined(this.inspectionOrderToEdit.inspectorId)) {
          Utils.showError("Inspector is required when inspection status is Ready to Schedule.");
        }
        else if (this.inspectionOrderService.policyForm.value.inceptionDate == null) {
          Utils.showError("Inception Date is required");
        }
        else {
          this.inspectionOrderService.putInspectionOrder(this.inspectionOrderToEdit)
            .then(data => {

              this.userActivityService.sendEvent(CategoryConstants.Update, 'order-management/info', CategoryConstants.UpdatedIO);

              this.router.navigate(['order-management']);
            }).catch(error => {
              Utils.showError("Complete the fields Property Value and Inspection Status");
            });
        }
        // }
      }
    } catch (error) {
      Utils.showError("Complete the fields Property Value and Inspection Status");
    }
  }

  getInspectorInfo(inspectorInfo) {
    this.inspector = inspectorInfo;
    this.inspectionOrderService.orderStatusForm.patchValue({
      'assignedDate': this.datePipe.transform(new Date(), this.dateFormat),
    });
    this.inspectionOrderService.inspector = inspectorInfo;
  }

  getAgentInfo(agentInfo) {
    this.agentInfo = Object.assign({}, agentInfo);
  }

  getPolicyInfo(policyInfo) {
    this.policyInfo = Object.assign({}, policyInfo);
  }

  getinsuredForm(insuredInfo) {
    this.insuredInfo = Object.assign({}, insuredInfo);
  }

  getInspecOrderStatus(inspectionOrderStatus) {
    this.inspectionStatusInfo = Object.assign({}, inspectionOrderStatus);
  }

  showMapItEvent(doShow) {
    if(doShow) {
      if(!this.mapItIsInitialized) {
        this.mapItIsInitialized = true;
      } else{
        $("#mapItContainer").slideDown();
      }
    } else {
        $("#mapItContainer").slideUp();
    }
  }
}
