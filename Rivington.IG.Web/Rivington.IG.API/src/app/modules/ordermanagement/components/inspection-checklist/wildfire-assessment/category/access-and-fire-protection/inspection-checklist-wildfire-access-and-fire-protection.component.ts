import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../../../../../shared/BaseComponent';
import { InspectionOrderChecklistWildFireService } from '../../../../../../core/services/ordermanagement/inspection-order-checklist-section/wildfire.service';
import { SelectItem } from 'primeng/components/common/selectitem';
import { InspectionOrderService } from '../../../../../../core/services/ordermanagement/inspection-order.service';

@Component({
  selector: 'app-inspection-checklist-wildfire-access-and-fire-protection',
  templateUrl: './inspection-checklist-wildfire-access-and-fire-protection.component.html',
  styleUrls: ['./inspection-checklist-wildfire-access-and-fire-protection.component.css']
})
export class InspectionChecklistWildfireAccessAndFireProtectionComponent extends BaseComponent implements OnInit {
  fireDepartmentStaffing: SelectItem[];

  constructor(public wildFireService: InspectionOrderChecklistWildFireService,
    public ioService: InspectionOrderService) {
    super();
   }

  ngOnInit() {
    this.wildFireService.getFireDepartmentStaffing().takeUntil(this.stop$).subscribe(data => this.fireDepartmentStaffing = data);
  }

  setWildFireValue(value, fieldname) {
    this.wildFireService[value] = this.wildFireService.wildfireAssessmentForms.accessAndFireProtection.get(fieldname).value;

    this.wildFireService.clearValue(value);
  }
}
