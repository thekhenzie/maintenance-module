import { Component, OnInit, OnDestroy, state } from '@angular/core';
import { PolicyService } from '../../../core/services/ordermanagement/policy.service';
import { AuthService } from '../../../core/services/auth.service';
import { Policy } from '../../../shared/models/ordermanagement/policy';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import Utils from '../../../shared/Utils';
import { StateService } from '../../../core/services/ordermanagement/state.service';
import { Observable } from 'rxjs';
import { State } from '../../../shared/models/ordermanagement/state';
import { CityService } from '../../../core/services/ordermanagement/city.service';
import { City } from '../../../shared/models/ordermanagement/city';
import { PathConstants } from '../../../shared/pathconstants';
import { InspectionOrderService } from '../../../core/services/ordermanagement/inspection-order.service';

@Component({
  selector: 'app-inspectionorderform',
  templateUrl: './inspectionorderform.component.html',
  styleUrls: ['./inspectionorderform.component.css']
})
export class InspectionorderformComponent implements OnInit {

  policyData: Policy;
  createInspecForm: FormGroup;
  policyList: Policy[];
  states: State[];
  cities: City[];
  selectedState: State;
  tempPolicy: Policy;

  constructor(
    private policyService: PolicyService,
    private stateService: StateService,
    private cityService: CityService,
    private inspectionOrderService: InspectionOrderService,
    private auth: AuthService,
    private router: Router,
    private fb: FormBuilder
  ) {
    this.selectedState = null;
  }

  ngOnInit() {

    this.stateService.getStateList().then(states => {
      this.states = states;
    });

    this.createInspecForm = this.fb.group({
      'policyNumber': new FormControl('', Validators.required),
      'insuredFirstName': new FormControl('', Validators.required),
      'insuredLastName': new FormControl('', Validators.required),
      'insuredEmail': new FormControl(''),
      'insuredMiddleName': new FormControl(''),
      'address1': new FormControl('', Validators.required),
      'address2': new FormControl(''),
      'stateId': new FormControl('', Validators.required),
      'cityId': new FormControl('', Validators.required),
      'zipcode': new FormControl('', Validators.required)
    });
  }

  getPolicy() {
    if (this.createInspecForm.valid) {
      this.createInspecForm.value.stateId = this.createInspecForm.value.stateId.id;
      this.createInspecForm.value.cityId = this.createInspecForm.value.cityId.id;
      this.tempPolicy = Object.assign({}, this.createInspecForm.value);
      this.policyService.getPolicy(this.tempPolicy).then(
        policy => {
          if (policy == undefined) {
            let errorMessage = "Policy Not Found."
            Utils.showError(errorMessage);
          } else {
            this.createInspecForm.value.state = this.selectedState.name;
            this.router.navigate([PathConstants.OrderManagement.InspectionOrder.Create.Info]);
          }
        });
    }
    else{
      Object.keys(this.createInspecForm.controls).forEach(field => {
        const control = this.createInspecForm.get(field);
        if (control instanceof FormControl) {
          control.markAsTouched({ onlySelf: true });
        }
      });
      Utils.showError("Please complete all the required fields.");
    }
  }

  filterCities() {
    this.inspectionOrderService.state = this.createInspecForm.value.stateId;
    this.selectedState = this.createInspecForm.value.stateId.id;
    this.cityService.getCityList(this.selectedState).then(
      cities => {
        this.cities = cities;
      }
    )
  }

  getCity(){
    this.inspectionOrderService.city = this.createInspecForm.value.cityId;
  }

  getZipcode(){
    this.inspectionOrderService.zipcode = this.createInspecForm.value.zipcode;
  }

  hasError(name: string) {
    let e = this.getFormControl(name);
    return e && (e.dirty || e.touched) && !e.valid
  }

  getFormControl(name: string) {
    return this.createInspecForm.get(name);
  }

}
