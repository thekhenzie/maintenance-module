import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../../../../../shared/BaseComponent';
import { BathroomFloor } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/high-value-bath/bathroom-floor';
import { BathroomVanity } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/high-value-bath/bathroom-vanity';
import { BathroomCounter } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/high-value-bath/bathroom-counter';
import { BathroomFixture } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/high-value-bath/bathroom-fixture';
import { TubAndShower } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/high-value-bath/tub-and-shower';
import { InspectionOrderChecklistPropertyService } from '../../../../../../core/services/ordermanagement/inspection-order-checklist-section/property.service';
import { SelectItem } from 'primeng/primeng';
import { InspectionOrderService } from '../../../../../../core/services/ordermanagement/inspection-order.service';

@Component({
  selector: 'app-inspection-checklist-property-high-value-bath',
  templateUrl: './inspection-checklist-property-high-value-bath.component.html',
  styleUrls: ['./inspection-checklist-property-high-value-bath.component.css']
})
export class InspectionChecklistPropertyHighValueBathComponent extends BaseComponent implements OnInit {
  bathroomFloors: SelectItem[];
  bathroomVanities: SelectItem[];
  bathroomCounters: SelectItem[];
  bathroomFixtures: SelectItem[];
  tubsAndShowers: SelectItem[];

  constructor(public propertyService: InspectionOrderChecklistPropertyService,
    public ioService: InspectionOrderService) { 
    super();
  }

  ngOnInit() {

    this.propertyService.getBathroomFloors().takeUntil(this.stop$).subscribe(data => this.bathroomFloors = data);
    this.propertyService.getBathroomVanities().takeUntil(this.stop$).subscribe(data => this.bathroomVanities = data);
    this.propertyService.getBathroomCounters().takeUntil(this.stop$).subscribe(data => this.bathroomCounters = data);
    this.propertyService.getBathroomFixtures().takeUntil(this.stop$).subscribe(data => this.bathroomFixtures = data);
    this.propertyService.getTubsAndShowers().takeUntil(this.stop$).subscribe(data => this.tubsAndShowers = data);

  }
}
