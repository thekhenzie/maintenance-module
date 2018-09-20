import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../../../../../shared/BaseComponent';
import { InspectionOrderChecklistWildFireService } from '../../../../../../core/services/ordermanagement/inspection-order-checklist-section/wildfire.service';
import { PrimaryRoofCovering } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/home-detail/primary-roof-covering';
import { SecondaryRoofCovering } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/home-detail/secondary-roof-covering';
import { OtherRoofCovering } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/wildfire/roof/other-roof-covering';
import { RoofType } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/home-detail/roof-type';
import { RoofConcernDetails } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/wildfire/roof/roof-concern-details';
import { RoofVenting } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/wildfire/roof/roof-venting';
import { GutterType } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/wildfire/roof/gutter-type';
import { EavesType } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/wildfire/roof/eaves-type';
import { SelectItem } from 'primeng/components/common/selectitem';
import { InspectionOrderService } from '../../../../../../core/services/ordermanagement/inspection-order.service';

@Component({
  selector: 'app-inspection-checklist-wildfire-roof',
  templateUrl: './inspection-checklist-wildfire-roof.component.html',
  styleUrls: ['./inspection-checklist-wildfire-roof.component.css']
})
export class InspectionChecklistWildfireRoofComponent extends BaseComponent implements OnInit {
  roofPitch: SelectItem[];
  roofShape: SelectItem[];
  eavesType: SelectItem[];
  gutterType: SelectItem[];
  roofVenting: SelectItem[];
  roofConcernsDetails: SelectItem[];
  roofType: SelectItem[];
  otherRoofCovering: SelectItem[];
  secondaryRoofCovering: SelectItem[];
  primaryRoofCovering: SelectItem[];

  constructor(public wildFireService: InspectionOrderChecklistWildFireService,
    public ioService: InspectionOrderService) {
    super();
   }

  ngOnInit() {
    this.wildFireService.getPrimaryRoofCovering().takeUntil(this.stop$).subscribe(data => this.primaryRoofCovering = data);
    this.wildFireService.getSecondaryRoofCovering().takeUntil(this.stop$).subscribe(data => this.secondaryRoofCovering = data);
    this.wildFireService.getOtherRoofCovering().takeUntil(this.stop$).subscribe(data => this.otherRoofCovering = data);
    this.wildFireService.getRoofShape().takeUntil(this.stop$).subscribe(data => this.roofShape = data);
    this.wildFireService.getRoofPitch().takeUntil(this.stop$).subscribe(data => this.roofPitch = data);
    this.wildFireService.getRoofConcernsDetails().takeUntil(this.stop$).subscribe(data => this.roofConcernsDetails = data);
    this.wildFireService.getRoofVenting().takeUntil(this.stop$).subscribe(data => this.roofVenting = data);
    this.wildFireService.getGutterType().takeUntil(this.stop$).subscribe(data => this.gutterType = data);
    this.wildFireService.getEavesType().takeUntil(this.stop$).subscribe(data => this.eavesType = data);
  }
}
