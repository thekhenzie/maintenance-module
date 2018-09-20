import { Component, OnInit, OnChanges, Output, EventEmitter, Input } from '@angular/core';
import { Policy } from '../../../shared/models/ordermanagement/policy';
import { AuthService } from '../../../core/services/auth.service';
import { PolicyService } from '../../../core/services/ordermanagement/policy.service';
import { FormControl, FormGroup, ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';
import { InspectionOrderService } from '../../../core/services/ordermanagement/inspection-order.service';
import { ActivatedRoute } from '@angular/router';
import { InspectionOrder } from '../../../shared/models/ordermanagement/inspection-order';
import { InspectionStatus } from '../../../shared/models/ordermanagement/inspectionstatus';
import { MitigationStatus } from '../../../shared/models/ordermanagement/mitigationstatus';
import { PropertyValue } from '../../../shared/models/ordermanagement/propertyvalue';
import { MitigationStatusService } from '../../../core/services/ordermanagement/mitigationstatus.service';
import { InspectionStatusService } from '../../../core/services/ordermanagement/inspectionstatus.service';
import { PropertyValueService } from '../../../core/services/ordermanagement/propertyvalue.service';
import { DatePipe } from '@angular/common';
import { UtilityService } from '../../../core/services/utility.service';

@Component({
  selector: 'app-policy',
  templateUrl: './policy.component.html',
  styleUrls: ['./policy.component.css']
})
export class PolicyComponent implements OnInit, OnChanges {

  @Output() policyFormValue: EventEmitter<FormGroup>;
  policyData: Policy;
  isNew: boolean;
  inspectionStatus: InspectionStatus[];
  isServiceName: string;
  mitigationStatus: MitigationStatus[];
  msServiceName: string;
  propertyValue: PropertyValue[];
  pvServiceName: string;
  dateFormat: string;

  constructor(
    private policyService: PolicyService,
    public inspectionOrderService: InspectionOrderService,
    private mitigationStatusService: MitigationStatusService,
    private propertyValueService: PropertyValueService,
    private inspectionStatusService: InspectionStatusService,
    private utilityService: UtilityService,
    private datePipe: DatePipe,
    private auth: AuthService,
    private fb: FormBuilder,
    private route: ActivatedRoute,
  ) {
    this.policyFormValue = new EventEmitter<FormGroup>();
    this.isServiceName = "InspectionStatus";
    this.msServiceName = "MitigationStatus";
    this.pvServiceName = "PropertyValue";
  }

  ngOnInit() {
    this.dateFormat = this.utilityService.appSettings.defaultDateFormat;
    this.route.params.subscribe(params => {
      let paramId = params["id"];
      if (!paramId) {
        this.isNew = true;
        this.policyData = this.policyService.policyData;
      }
    });

    this.mitigationStatusService.getMitigationStatusList(this.msServiceName).then(
      mitigationStatusList => {
        this.mitigationStatus = mitigationStatusList;
      });

    this.propertyValueService.getPropertyValueList(this.pvServiceName).then(
      propertyValueList => {
        this.propertyValue = propertyValueList;
      });

    this.inspectionStatusService.getInspectionStatusList(this.isServiceName).then(
      inspectionStatusList => {
        this.inspectionStatus = inspectionStatusList;
      });

    if (this.isNew) {
      this.inspectionOrderService.policyForm.patchValue({
        'policyNumber': this.policyData.policyNumber,
        'coverageA': this.policyData.coverageA,
        'e2ValueReplacementCostValue': this.policyData.e2ValueReplacementCostValue,
        'itvPercentage': this.policyData.itvPercentage,
        'wildfireAssessmentRequired': this.policyData.wildfireAssessmentRequired
      });
    }

    this.inspectionOrderService.policyForm.valueChanges.subscribe(data => {
      this.policyFormValue.emit(this.inspectionOrderService.policyForm.value);
    });

    if (this.inspectionOrderService.policyForm.untouched) {
      this.policyFormValue.emit(this.inspectionOrderService.policyForm.value);
    }
  }

  ngOnChanges() {
  }

  hasError(name: string) {
    let e = this.getFormControl(name);
    return e && (e.dirty || e.touched) && !e.valid;
  }

  getFormControl(name: string) {
    return this.inspectionOrderService.policyForm.get(name);
  }
}
