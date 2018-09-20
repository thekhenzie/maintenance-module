import { Component, OnInit } from '@angular/core';
import { SelectItem } from 'primeng/primeng';
import { InspectionOrderChecklistPropertyService } from '../../../../../../core/services/ordermanagement/inspection-order-checklist-section/property.service';
import { BaseComponent } from '../../../../../../shared/BaseComponent';
import { InspectionOrderService } from '../../../../../../core/services/ordermanagement/inspection-order.service';

@Component({
  selector: 'app-inspection-checklist-property-general',
  templateUrl: './inspection-checklist-property-general.component.html',
  styleUrls: ['./inspection-checklist-property-general.component.css']
})
export class InspectionChecklistPropertyGeneralComponent extends BaseComponent implements OnInit {
  JSON: any;
  states: SelectItem[];
  occupancyTypes: SelectItem[];
  domesticHelp: SelectItem[];
  domesticHelpTypes: SelectItem[];
  fireAlarms: SelectItem[];
  fireAlarmTypes: SelectItem[];
  smokeOnlyAlarms: SelectItem[];
  smokeOnlyAlarmTypes: SelectItem[];
  burglarAlarms: SelectItem[];
  burglarAlarmTypes: SelectItem[];
  policyPremiumCredits: SelectItem[];
  wildfireCredits: SelectItem[];

  constructor(public propertyService: InspectionOrderChecklistPropertyService,
    public ioService: InspectionOrderService,) { 
    super();

    this.JSON = JSON;
  }

  ngOnInit() {
    
    this.propertyService.getStates().then(states => this.states = states);
    this.propertyService.getOccupancyTypes().takeUntil(this.stop$).subscribe(data => this.occupancyTypes = data);
    this.propertyService.getDomesticHelp().takeUntil(this.stop$).subscribe(data => this.domesticHelp = data);
    this.propertyService.getDomesticHelpTypes().takeUntil(this.stop$).subscribe(data => this.domesticHelpTypes = data);
    this.propertyService.getFireAlarms().takeUntil(this.stop$).subscribe(data => this.fireAlarms = data);
    this.propertyService.getFireAlarmTypes().takeUntil(this.stop$).subscribe(data => this.fireAlarmTypes = data);
    this.propertyService.getSmokeOnlyAlarms().takeUntil(this.stop$).subscribe(data => this.smokeOnlyAlarms = data);
    this.propertyService.getSmokeOnlyAlarmTypes().takeUntil(this.stop$).subscribe(data => this.smokeOnlyAlarmTypes = data);
    this.propertyService.getBurglarAlarms().takeUntil(this.stop$).subscribe(data => this.burglarAlarms = data);
    this.propertyService.getBurglarAlarmTypes().takeUntil(this.stop$).subscribe(data => this.burglarAlarmTypes = data);
    this.propertyService.getPolicyPremiumCredits().takeUntil(this.stop$).subscribe(data => this.policyPremiumCredits = data);
    this.propertyService.getWildfireCredits().takeUntil(this.stop$).subscribe(data => this.wildfireCredits = data);

  }

  setDomesticHelpValue() {
    this.propertyService.domesticHelp = (this.propertyService.propertyForms.general.get('domesticHelpTypeId').value == "YE")
    if (!this.propertyService.domesticHelp){
      this.propertyService.propertyForms.general.get('domesticHelpTypes').setValue(null);
    }
  }

  setFireAlarmValue() {
    this.propertyService.fireAlarm = (this.propertyService.propertyForms.general.get('fireAlarmId').value == "Y");
    if (!this.propertyService.fireAlarm){
      this.propertyService.propertyForms.general.get('fireAlarmTypeId').setValue(null);
    }
  }

  setSmokeAlarmValue() {
    this.propertyService.smokeAlarm = (this.propertyService.propertyForms.general.get('smokeOnlyAlarmId').value == "Y");
    if (!this.propertyService.smokeAlarm){
      this.propertyService.propertyForms.general.get('smokeOnlyAlarmTypeId').setValue(null);
    }
  }

  setBurglarAlarmValue() {
    this.propertyService.burglarAlarm =  (this.propertyService.propertyForms.general.get('burglarAlarmId').value == "Y");
    if (!this.propertyService.burglarAlarm){
      this.propertyService.propertyForms.general.get('burglarAlarmTypeId').setValue(null);
    }
  }

  setPropertyFieldValue(value, fieldname) {
    this.propertyService[value] = this.propertyService.propertyForms.general.get(fieldname).value;

    this.propertyService.clearValue(value);
  }

  // filterCities($event){
  //   // this.propertyService.forms.general.value.State.Id
  //   let stateId = "";
  //   if($event.value) stateId = $event.value;

  //   this.propertyService.getCities(stateId).then(
  //     cities => this.cities = cities
  //   )
  // }
}
