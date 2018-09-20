import { Component, OnInit } from '@angular/core';
import { InspectionOrderChecklistWildFireService } from '../../../../../../core/services/ordermanagement/inspection-order-checklist-section/wildfire.service';
import { BaseComponent } from '../../../../../../shared/BaseComponent';
import { SelectItem } from 'primeng/components/common/selectitem';
import { InspectionOrderService } from '../../../../../../core/services/ordermanagement/inspection-order.service';

@Component({
  selector: 'app-inspection-checklist-wildfire-fencing-and-other-attachments',
  templateUrl: './inspection-checklist-wildfire-fencing-and-other-attachments.component.html',
  styleUrls: ['./inspection-checklist-wildfire-fencing-and-other-attachments.component.css']
})
export class InspectionChecklistWildfireFencingAndOtherAttachmentsComponent extends BaseComponent implements OnInit {
  otherDetachedStructuresDetails: SelectItem[];
  outbuildingDetails: SelectItem[];
  otherAttachmentsType: SelectItem[];
  fenceConditionConernsDetails: SelectItem[];
  fencingType: SelectItem[];

  constructor(public wildFireService: InspectionOrderChecklistWildFireService,
    public ioService: InspectionOrderService,) {
    super();
   }

  ngOnInit() {
    this.wildFireService.getFencingType().takeUntil(this.stop$).subscribe(data => this.fencingType = data);
    this.wildFireService.getFenceConditionConcernsDetails().takeUntil(this.stop$).subscribe(data => this.fenceConditionConernsDetails = data);
    this.wildFireService.getOtherAttachmentTypes().takeUntil(this.stop$).subscribe(data => this.otherAttachmentsType = data);
    this.wildFireService.getOutbuildingDetails().takeUntil(this.stop$).subscribe(data => this.outbuildingDetails = data);
    this.wildFireService.getOtherDetachedStructuresDetails().takeUntil(this.stop$).subscribe(data => this.otherDetachedStructuresDetails = data);
  }

  setWildFireValue(value, fieldname) {
    this.wildFireService[value] = this.wildFireService.wildfireAssessmentForms.fencingAndOtherAttachments.get(fieldname).value;

    this.wildFireService.clearValue(value);
  }
}
