import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../../../../../shared/BaseComponent';
import { InspectionOrderChecklistWildFireService } from '../../../../../../core/services/ordermanagement/inspection-order-checklist-section/wildfire.service';
import { SelectItem } from 'primeng/components/common/selectitem';
import { InspectionOrderService } from '../../../../../../core/services/ordermanagement/inspection-order.service';

@Component({
  selector: 'app-inspection-checklist-wildfire-external-fuel-source',
  templateUrl: './inspection-checklist-wildfire-external-fuel-source.component.html',
  styleUrls: ['./inspection-checklist-wildfire-external-fuel-source.component.css']
})
export class InspectionChecklistWildfireExternalFuelSourceComponent extends BaseComponent implements OnInit {
  externalFuelSourceType: SelectItem[];

  constructor(public wildFireService: InspectionOrderChecklistWildFireService,
    public ioService: InspectionOrderService) {
    super();
   }

  ngOnInit() {
    this.wildFireService.getExternalFuelSourceType().takeUntil(this.stop$).subscribe(data => this.externalFuelSourceType = data);
  }

  setWildFireValue(value, fieldname) {
    this.wildFireService[value] = this.wildFireService.wildfireAssessmentForms.externalFuelSource.get(fieldname).value;

    this.wildFireService.clearValue(value);
  }
}
