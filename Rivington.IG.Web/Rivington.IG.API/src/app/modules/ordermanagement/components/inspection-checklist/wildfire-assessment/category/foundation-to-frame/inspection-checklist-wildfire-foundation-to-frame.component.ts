import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../../../../../shared/BaseComponent';
import { InspectionOrderChecklistWildFireService } from '../../../../../../core/services/ordermanagement/inspection-order-checklist-section/wildfire.service';
import { SelectItem } from 'primeng/components/common/selectitem';
import { InspectionOrderService } from '../../../../../../core/services/ordermanagement/inspection-order.service';

@Component({
  selector: 'app-inspection-checklist-wildfire-foundation-to-frame',
  templateUrl: './inspection-checklist-wildfire-foundation-to-frame.component.html',
  styleUrls: ['./inspection-checklist-wildfire-foundation-to-frame.component.css']
})
export class InspectionChecklistWildfireFoundationToFrameComponent extends BaseComponent implements OnInit {
  framingType: SelectItem[];
  foundationType: SelectItem[];

  constructor(public wildFireService: InspectionOrderChecklistWildFireService,
    public ioService: InspectionOrderService) {
    super();
   }

  ngOnInit() {
    this.wildFireService.getFoundationType().takeUntil(this.stop$).subscribe(data => this.foundationType = data);
    this.wildFireService.getFramingType().takeUntil(this.stop$).subscribe(data => this.framingType = data);
  }
}
