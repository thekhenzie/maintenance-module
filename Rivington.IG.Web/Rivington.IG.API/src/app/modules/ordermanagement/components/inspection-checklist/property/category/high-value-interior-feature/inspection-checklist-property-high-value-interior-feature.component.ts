import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../../../../../shared/BaseComponent';
import { InspectionOrderChecklistPropertyService } from '../../../../../../core/services/ordermanagement/inspection-order-checklist-section/property.service';
import { InteriorDoorType } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/high-value-interior-feature/interior-door-type';
import { DoorHardware } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/high-value-interior-feature/door-hardware';
import { RoomWithCabinetry } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/high-value-interior-feature/room-with-cabinetry';
import { LightingType } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/high-value-interior-feature/lighting-type';
import { FireplaceType } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/high-value-interior-feature/fire-place-type';
import { Staircase } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/high-value-interior-feature/staircase';
import { MiscellaneousExtraFeature } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/high-value-interior-feature/miscellaneous-extra-feature';
import { SelectItem } from 'primeng/primeng';
import { InspectionOrderService } from '../../../../../../core/services/ordermanagement/inspection-order.service';

@Component({
  selector: 'app-inspection-checklist-property-high-value-interior-feature',
  templateUrl: './inspection-checklist-property-high-value-interior-feature.component.html',
  styleUrls: ['./inspection-checklist-property-high-value-interior-feature.component.css']
})
export class InspectionChecklistPropertyHighValueInteriorFeatureComponent extends BaseComponent implements OnInit {
  minNumofFirePlaces: number;
  interiorDoorTypes: SelectItem[];
  doorHardwares: SelectItem[];
  roomWithCabinetrys: SelectItem[];
  lightingTypes: SelectItem[];
  fireplaceTypes: SelectItem[];
  staircases: SelectItem[];
  miscellaneousExtraFeatures: SelectItem[];

  constructor(public propertyService: InspectionOrderChecklistPropertyService,
    public ioService: InspectionOrderService) { 
    super();
    this.minNumofFirePlaces = 0;
  }

  ngOnInit() {
    this.propertyService.getInteriorDoorTypes().takeUntil(this.stop$).subscribe(data => this.interiorDoorTypes = data);
    this.propertyService.getDoorHardwares().takeUntil(this.stop$).subscribe(data => this.doorHardwares = data);
    this.propertyService.getRoomWithCabinetrys().takeUntil(this.stop$).subscribe(data => this.roomWithCabinetrys = data);
    this.propertyService.getLightingTypes().takeUntil(this.stop$).subscribe(data => this.lightingTypes = data);
    this.propertyService.getFireplaceTypes().takeUntil(this.stop$).subscribe(data => this.fireplaceTypes = data);
    this.propertyService.getStaircases().takeUntil(this.stop$).subscribe(data => this.staircases = data);
    this.propertyService.getMiscellaneousExtraFeatures().takeUntil(this.stop$).subscribe(data => this.miscellaneousExtraFeatures = data);
  }

  setNumOfFirePlacesValue() {
    let num = this.propertyService.propertyForms.highValueInteriorFeature.get('numberofFireplace').value;
    this.propertyService.isNumOfFirePlaces = (+num > this.minNumofFirePlaces);

    if(!this.propertyService.isNumOfFirePlaces) {
      this.propertyService.propertyForms.highValueInteriorFeature.get('fireplaceTypes').setValue(null);
    }
  }

}