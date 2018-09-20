import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { AuthService } from '../../../core/services/auth.service';
import { PolicyService } from '../../../core/services/ordermanagement/policy.service';
import { Policy } from '../../../shared/models/ordermanagement/policy';
import { FormGroup, FormControl, ReactiveFormsModule, FormBuilder } from '@angular/forms';
import { InspectionOrderService } from '../../../core/services/ordermanagement/inspection-order.service';
import { ActivatedRoute } from '@angular/router';
import { InspectionOrder } from '../../../shared/models/ordermanagement/inspection-order';
import { City } from '../../../shared/models/ordermanagement/city';
import { State } from '../../../shared/models/ordermanagement/state';
import { InspectionOrderPropertyGeneral } from '../../../shared/models/ordermanagement/inspection-order/checklist/property/general';
import { UserActivityLogService } from '../../../core/services/ordermanagement/user-activity-log.service';
import { CategoryConstants } from '../../../shared/models/user-activity-category-constants';

@Component({
  selector: 'app-insuredinfo',
  templateUrl: './insuredinfo.component.html',
  styleUrls: ['./insuredinfo.component.css']
})
export class InsuredinfoComponent implements OnInit {

  @Output() insureInfoForm: EventEmitter<FormGroup>;
  policyData: any;
  isNew: boolean;
  city: City;
  state: State;
  zipcode: string;
  mapLink: string;
  @Output() showMapItEventEmitter: EventEmitter<boolean> = new EventEmitter<boolean>();
  showMapIt: boolean = false;
  mapButtonsEnabled: boolean = false;

  constructor(
    private policyService: PolicyService,
    public auth: AuthService,
    private fb: FormBuilder,
    public inspectionOrderService: InspectionOrderService,
    private route: ActivatedRoute,
    private userActivityService: UserActivityLogService
  ) {
    this.insureInfoForm = new EventEmitter<FormGroup>();
    this.inspectionOrderService.inspectionOrderPropertyGeneral = new InspectionOrderPropertyGeneral();
    this.state = new State();
    this.city = new City();
    this.state.name= "";
    this.city.name= "";
    this.zipcode ="";
    this.mapLink = "https://www.google.com/maps/search/?api=1&query=";
  }

  ngOnInit() {

    this.route.params.subscribe(params => {
      let paramId = params["id"];
      if (!paramId) {
        this.isNew = true;
        this.policyData = this.policyService.policyData;
      }
    });

    if (this.isNew) {
      this.inspectionOrderService.insuredForm.patchValue({
        'insuredFirstName': this.policyData.insuredFirstName,
        'insuredLastName': this.policyData.insuredLastName,
        'insuredMiddleName': this.policyData.insuredMiddleName,
        'insuredEmail': this.policyData.insuredEmail,
        'address': this.policyData.address,
        'latitude': this.policyData.latitude,
        'longitude': this.policyData.longitude
      });

      this.inspectionOrderService.inspectionOrderPropertyGeneral.streetAddress1 = this.policyData.address1;
      this.inspectionOrderService.inspectionOrderPropertyGeneral.streetAddress2 = this.policyData.address2;
      this.inspectionOrderService.inspectionOrderPropertyGeneral.stateId = this.policyData.stateId;
      this.inspectionOrderService.inspectionOrderPropertyGeneral.cityId = this.policyData.cityId;
      this.inspectionOrderService.inspectionOrderPropertyGeneral.zipCode = this.policyData.zipCode;

      if(this.inspectionOrderService.city) this.city = this.inspectionOrderService.city;
      if(this.inspectionOrderService.state) this.state = this.inspectionOrderService.state;
      if(this.inspectionOrderService.zipcode) this.zipcode = this.inspectionOrderService.zipcode;
    }

    if (this.inspectionOrderService.insuredForm.untouched) {
      this.insureInfoForm.emit(this.inspectionOrderService.insuredForm.value);
    }

    this.inspectionOrderService.insuredForm.valueChanges.subscribe(data => {
      this.insureInfoForm.emit(this.inspectionOrderService.insuredForm.value);

      let lat = this.inspectionOrderService.insuredForm.value.latitude;
      let lng = this.inspectionOrderService.insuredForm.value.longitude;
      if(lat && lng){
        this.mapLink = this.mapLink.concat(lat, ",", lng);
      }else{
        this.mapLink = this.mapLink.concat(this.inspectionOrderService.insuredForm.value.address);
      }

      this.mapButtonsEnabled = true;
    });
  }

  toggleShowMapIt() {
    this.showMapIt = !this.showMapIt;
    this.showMapItEventEmitter.emit(this.showMapIt);
  }

  sendEvent() {
    this.userActivityService.sendEvent( CategoryConstants.View, 'order-management/inpsection-order/info', CategoryConstants.View + 'in Google Maps');
  }

}
