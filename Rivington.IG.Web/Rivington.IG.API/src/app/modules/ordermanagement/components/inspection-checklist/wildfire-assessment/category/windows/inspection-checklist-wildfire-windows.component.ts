import { Component, OnInit } from '@angular/core';
import { InspectionOrderChecklistWildFireService } from '../../../../../../core/services/ordermanagement/inspection-order-checklist-section/wildfire.service';
import { BaseComponent } from '../../../../../../shared/BaseComponent';
import { SelectItem } from 'primeng/components/common/selectitem';
import { InspectionOrderService } from '../../../../../../core/services/ordermanagement/inspection-order.service';

@Component({
  selector: 'app-inspection-checklist-wildfire-windows',
  templateUrl: './inspection-checklist-wildfire-windows.component.html',
  styleUrls: ['./inspection-checklist-wildfire-windows.component.css']
})
export class InspectionChecklistWildfireWindowsComponent extends BaseComponent implements OnInit {
  windowConcernsDetails: SelectItem[];
  exteriorWindowCoveringType: SelectItem[];
  interiorWindowCoveringType: SelectItem[];
  windowScreenType: SelectItem[];
  windowStyles: SelectItem[];
  windowFramingType: SelectItem[];
  windowGlassType: SelectItem[];

  constructor(public wildfireAssessmentService: InspectionOrderChecklistWildFireService,
    public ioService: InspectionOrderService) {
    super();
  }

  ngOnInit() {
    this.wildfireAssessmentService.getWindowGlassType().takeUntil(this.stop$).subscribe(data => this.windowGlassType = data);
    this.wildfireAssessmentService.getWindowFramingType().takeUntil(this.stop$).subscribe(data => this.windowFramingType = data);
    this.wildfireAssessmentService.getWindowStyle().takeUntil(this.stop$).subscribe(data => this.windowStyles = data);
    this.wildfireAssessmentService.getWindowScreenType().takeUntil(this.stop$).subscribe(data => this.windowScreenType = data);
    this.wildfireAssessmentService.getInteriorWindowCoveringType().takeUntil(this.stop$).subscribe(data => this.interiorWindowCoveringType = data);
    this.wildfireAssessmentService.getExteriorWindowCoveringType().takeUntil(this.stop$).subscribe(data => this.exteriorWindowCoveringType = data);
    this.wildfireAssessmentService.getWindowConcernDetails().takeUntil(this.stop$).subscribe(data => this.windowConcernsDetails = data);
  }
}
