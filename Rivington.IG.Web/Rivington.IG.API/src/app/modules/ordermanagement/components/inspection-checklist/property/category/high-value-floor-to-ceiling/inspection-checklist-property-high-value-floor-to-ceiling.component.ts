import { Component, OnInit } from '@angular/core';
import { FloorCovering } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/high-value-floor-to-ceiling/floor-covering';
import { Ceiling } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/high-value-floor-to-ceiling/ceiling';
import { InteriorWallCovering } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/high-value-floor-to-ceiling/interior-wall-covering';
import { WallTrim } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/high-value-floor-to-ceiling/wall-trim';
import { WindowStyle } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/high-value-floor-to-ceiling/window-style';
import { WindowBrand } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/high-value-floor-to-ceiling/window-brand';
import { ChimneyType } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/high-value-floor-to-ceiling/chimney-type';
import { InspectionOrderChecklistPropertyService } from '../../../../../../core/services/ordermanagement/inspection-order-checklist-section/property.service';
import { BaseComponent } from '../../../../../../shared/BaseComponent';
import { SelectItem } from 'primeng/primeng';
import { FormGroup } from '@angular/forms';
import { InspectionOrderService } from '../../../../../../core/services/ordermanagement/inspection-order.service';

@Component({
  selector: 'app-inspection-checklist-property-high-value-floor-to-ceiling',
  templateUrl: './inspection-checklist-property-high-value-floor-to-ceiling.component.html',
  styleUrls: ['./inspection-checklist-property-high-value-floor-to-ceiling.component.css']
})
export class InspectionChecklistPropertyHighValueFloorToCeilingComponent extends BaseComponent implements OnInit {
  floorToCeilingForms: FormGroup;
  floorCoverings: SelectItem[];
  ceilings: SelectItem[];
  interiorWallCoverings: SelectItem[];
  wallTrims: SelectItem[];
  windowStyles: SelectItem[];
  windowBrands: SelectItem[];
  chimneyTypes: SelectItem[];

  constructor(public propertyService: InspectionOrderChecklistPropertyService,
    public ioService: InspectionOrderService) { 
    super();
  }

  ngOnInit() {
    this.propertyService.getFloorCoverings().takeUntil(this.stop$).subscribe(data => this.floorCoverings = data);
    this.propertyService.getCeilings().takeUntil(this.stop$).subscribe(data => this.ceilings = data);
    this.propertyService.getInteriorWallCoverings().takeUntil(this.stop$).subscribe(data => this.interiorWallCoverings = data);
    this.propertyService.getWallTrims().takeUntil(this.stop$).subscribe(data => this.wallTrims = data);
    this.propertyService.getWindowStyles().takeUntil(this.stop$).subscribe(data => this.windowStyles = data);
    this.propertyService.getWindowBrands().takeUntil(this.stop$).subscribe(data => this.windowBrands = data);
    this.propertyService.getChimneyTypes().takeUntil(this.stop$).subscribe(data => this.chimneyTypes = data);

    this.floorToCeilingForms = this.propertyService.propertyForms.highValueFloorToCeiling;

  }

  setWindowStylesValue() {
    let outbuildingValue = this.floorToCeilingForms.value.windowStyles;
    this.propertyService.valueChanges(outbuildingValue, "windowStyles", "windowStyles", "windows");
  }
}