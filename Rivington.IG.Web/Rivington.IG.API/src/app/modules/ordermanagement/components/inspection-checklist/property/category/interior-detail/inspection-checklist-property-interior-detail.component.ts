import { Component, OnInit } from '@angular/core';
import { InspectionOrderChecklistPropertyService } from '../../../../../../core/services/ordermanagement/inspection-order-checklist-section/property.service';
import { BaseComponent } from '../../../../../../shared/BaseComponent';
import { FlooringType } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/interior-detail/flooring-type';
import { TypeOfPlumbing } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/interior-detail/type-of-plumbing';
import { QualityClassUpgrade } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/interior-detail/quality-class-upgrade';
import { KitchenBathCounter } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/interior-detail/kitchen-bath-counter';
import { KitchenBathCabinet } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/interior-detail/kitchen-bath-cabinet';
import { SelectItem } from 'primeng/primeng';
import { InspectionOrderService } from '../../../../../../core/services/ordermanagement/inspection-order.service';

@Component({
  selector: 'app-inspection-checklist-property-interior-detail',
  templateUrl: './inspection-checklist-property-interior-detail.component.html',
  styleUrls: ['./inspection-checklist-property-interior-detail.component.css']
})
export class InspectionChecklistPropertyInteriorDetailComponent extends BaseComponent implements OnInit {
  flooringTypes: SelectItem[];
  kitchenBathCabinets: SelectItem[];
  kitchenBathCounters: SelectItem[];
  qualityClassUpgrades: SelectItem[];
  typeOfPlumbings: SelectItem[];

  constructor(public propertyService: InspectionOrderChecklistPropertyService,
    public ioService: InspectionOrderService,) { 
    super();
  }

  ngOnInit() {
    this.propertyService.getFlooringTypes().takeUntil(this.stop$).subscribe(data => this.flooringTypes = data);
    this.propertyService.getKitchenBathCabinets().takeUntil(this.stop$).subscribe(data => this.kitchenBathCabinets = data);
    this.propertyService.getKitchenBathCounters().takeUntil(this.stop$).subscribe(data => this.kitchenBathCounters = data);
    this.propertyService.getQualityClassUpgrades().takeUntil(this.stop$).subscribe(data => this.qualityClassUpgrades = data);
    this.propertyService.getTypeOfPlumbings().takeUntil(this.stop$).subscribe(data => this.typeOfPlumbings = data);
  
  }
}
