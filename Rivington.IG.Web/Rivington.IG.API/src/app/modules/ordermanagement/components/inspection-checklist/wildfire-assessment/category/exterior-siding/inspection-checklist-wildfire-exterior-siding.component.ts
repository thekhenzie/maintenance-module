import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../../../../../shared/BaseComponent';
import { InspectionOrderChecklistWildFireService } from '../../../../../../core/services/ordermanagement/inspection-order-checklist-section/wildfire.service';
import { SelectItem } from 'primeng/components/common/selectitem';
import { InspectionOrderService } from '../../../../../../core/services/ordermanagement/inspection-order.service';

@Component({
  selector: 'app-inspection-checklist-wildfire-exterior-siding',
  templateUrl: './inspection-checklist-wildfire-exterior-siding.component.html',
  styleUrls: ['./inspection-checklist-wildfire-exterior-siding.component.css']
})
export class InspectionChecklistWildfireExteriorSidingComponent extends BaseComponent implements OnInit {
  arrayString: string[];
  sidingConditionConcernDetails: SelectItem[];
  otherExteriorWallCovering: SelectItem[];
  secondaryExteriorWallCovering: SelectItem[];
  primaryExteriorWallCovering: SelectItem[];

  constructor(public wildFireService: InspectionOrderChecklistWildFireService,
    public ioService: InspectionOrderService,) {
    super();
   }

  ngOnInit() {
    this.wildFireService.getPrimaryExteriorWallCovering().takeUntil(this.stop$).subscribe(data => this.primaryExteriorWallCovering = data);
    this.wildFireService.getSecondaryExteriorWallCovering().takeUntil(this.stop$).subscribe(data => this.secondaryExteriorWallCovering = data);
    this.wildFireService.getOtherWallExteriorWallCovering().takeUntil(this.stop$).subscribe(data => this.otherExteriorWallCovering = data);
    this.wildFireService.getSidingConditionConcernDetail().takeUntil(this.stop$).subscribe(data => this.sidingConditionConcernDetails = data);
  }

  setSidingConditionValue() {
    this.arrayString = this.wildFireService.wildfireAssessmentForms.exteriorSiding.get('sidingConditionConcernDetails').value;
    this.wildFireService.sidingCondition = (this.arrayString.includes("N"));
    if(this.wildFireService.sidingCondition) {
      this.wildFireService.wildfireAssessmentForms.exteriorSiding.get('sidingConditionComment').setValue('');
    }
  }
}
