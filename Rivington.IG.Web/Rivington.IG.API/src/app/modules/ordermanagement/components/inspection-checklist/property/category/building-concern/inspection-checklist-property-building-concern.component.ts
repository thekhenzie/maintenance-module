import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../../../../../shared/BaseComponent';
import { InspectionOrderChecklistPropertyService } from '../../../../../../core/services/ordermanagement/inspection-order-checklist-section/property.service';
import { SurroundingAreaConcernDetail } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/building-concern/surrounding-area-concern-detail';
import { OtherStructureConcernDetail } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/building-concern/other-structure-concern-detail';
import { PlumbingConcernDetail } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/building-concern/plumbing-concern-detail';
import { ElectricalConcernDetail } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/building-concern/electrical-concern-details';
import { RoofConcernDetail } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/building-concern/roof-concern-detail';
import { ExteriorBuildingConcernDetail } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/building-concern/exterior-building-concern-detail';
import { SelectItem } from 'primeng/components/common/api';
import { FormGroup } from '@angular/forms';
import { InspectionOrderService } from '../../../../../../core/services/ordermanagement/inspection-order.service';

@Component({
  selector: 'app-inspection-checklist-property-building-concern',
  templateUrl: './inspection-checklist-property-building-concern.component.html',
  styleUrls: ['./inspection-checklist-property-building-concern.component.css']
})
export class InspectionChecklistPropertyBuildingConcernComponent extends BaseComponent implements OnInit {
  buildingConcernForms: FormGroup;
  exteriorBuildingConcernDetails: SelectItem[];
  roofConcernDetails: SelectItem[];
  electricalConcernDetails: SelectItem[];
  plumbingConcernDetails: SelectItem[];
  otherStructureConcernDetails: SelectItem[];
  surroundingAreaConcernDetails: SelectItem[];
  
  constructor(public propertyService: InspectionOrderChecklistPropertyService,
    public ioService: InspectionOrderService,) { 
    super();
  }

  ngOnInit() {
    this.propertyService.getExteriorBuildingConcernDetails().takeUntil(this.stop$).subscribe(data => this.exteriorBuildingConcernDetails = data);
    this.propertyService.getRoofConcernDetails().takeUntil(this.stop$).subscribe(data => this.roofConcernDetails = data);
    this.propertyService.getElectricalConcernDetails().takeUntil(this.stop$).subscribe(data => this.electricalConcernDetails = data);
    this.propertyService.getPlumbingConcernDetails().takeUntil(this.stop$).subscribe(data => this.plumbingConcernDetails = data);
    this.propertyService.getOtherStructureConcernDetails().takeUntil(this.stop$).subscribe(data => this.otherStructureConcernDetails = data);
    this.propertyService.getSurroundingAreaConcernDetails().takeUntil(this.stop$).subscribe(data => this.surroundingAreaConcernDetails = data);

    this.buildingConcernForms = this.propertyService.propertyForms.buildingConcern;

  }

  setRoofConcernDetailsValue() {
    let roofConcernDetailValue = this.buildingConcernForms.value.roofConcernDetails;
    this.propertyService.valueChanges(roofConcernDetailValue, "roofConcernDetails", "roofConcernDetails", "roof");
  }
}
