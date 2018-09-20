import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../../../../../shared/BaseComponent';
import { InspectionOrderChecklistPropertyService } from '../../../../../../core/services/ordermanagement/inspection-order-checklist-section/property.service';
import { DogTemperament } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/additional-exposure/dog-temperament';
import { CustomerOnSite } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/additional-exposure/customer-on-site';
import { Employee10HoursPerWeek } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/additional-exposure/employee-10-hours-per-week';
import { BearInvasionConcernDetail } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/additional-exposure/bear-invasion-concern-detail';
import { SelectItem } from 'primeng/primeng';
import { InspectionOrderService } from '../../../../../../core/services/ordermanagement/inspection-order.service';

@Component({
  selector: 'app-inspection-checklist-property-additional-exposure',
  templateUrl: './inspection-checklist-property-additional-exposure.component.html',
  styleUrls: ['./inspection-checklist-property-additional-exposure.component.css']
})
export class InspectionChecklistPropertyAdditionalExposureComponent extends BaseComponent implements OnInit {
  dogTemperaments: SelectItem[];
  customerOnSites: SelectItem[];
  employee10HoursPerWeeks: SelectItem[];
  bearInvasionConcernDetails: SelectItem[];

  constructor(public propertyService: InspectionOrderChecklistPropertyService,
    public ioService: InspectionOrderService) {
    super();
  }

  ngOnInit() {

    this.propertyService.getDogTemperaments().takeUntil(this.stop$).subscribe(data => this.dogTemperaments = data);
    this.propertyService.getCustomerOnSites().takeUntil(this.stop$).subscribe(data => this.customerOnSites = data);
    this.propertyService.getEmployee10HoursPerWeeks().takeUntil(this.stop$).subscribe(data => this.employee10HoursPerWeeks = data);
    this.propertyService.getBearInvasionConcernDetails().takeUntil(this.stop$).subscribe(data => this.bearInvasionConcernDetails = data);

  }

  setPropertyFieldValue(value, fieldname) {
    this.propertyService[value] = this.propertyService.propertyForms.additionalExposure.get(fieldname).value;

    this.propertyService.clearValue(value);
  }
}