import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../../../../../shared/BaseComponent';
import { InspectionOrderChecklistWildFireService } from '../../../../../../core/services/ordermanagement/inspection-order-checklist-section/wildfire.service';
import { InspectionOrderService } from '../../../../../../core/services/ordermanagement/inspection-order.service';

@Component({
  selector: 'app-inspection-checklist-wildfire-surroundings',
  templateUrl: './inspection-checklist-wildfire-surroundings.component.html',
  styleUrls: ['./inspection-checklist-wildfire-surroundings.component.css']
})
export class InspectionChecklistWildfireSurroundingsComponent extends BaseComponent implements OnInit {
  
  constructor(public wildFireService: InspectionOrderChecklistWildFireService,
    public ioService: InspectionOrderService) {
    super();
    }

  ngOnInit() {
  }
}
