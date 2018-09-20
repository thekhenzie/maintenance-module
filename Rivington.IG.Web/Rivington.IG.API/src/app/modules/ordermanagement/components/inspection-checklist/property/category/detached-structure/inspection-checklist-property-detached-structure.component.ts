import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../../../../../shared/BaseComponent';
import { OutbuildingDetail } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/detached-structure/outbuilding-detail';
import { OtherDetachedStructuresDetail } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/detached-structure/other-detached-structures-detail';
import { InspectionOrderChecklistPropertyService } from '../../../../../../core/services/ordermanagement/inspection-order-checklist-section/property.service';
import { SelectItem } from 'primeng/primeng';
import { FormGroup } from '@angular/forms';
import { InspectionOrderService } from '../../../../../../core/services/ordermanagement/inspection-order.service';

@Component({
  selector: 'app-inspection-checklist-property-detached-structure',
  templateUrl: './inspection-checklist-property-detached-structure.component.html',
  styleUrls: ['./inspection-checklist-property-detached-structure.component.css']
})
export class InspectionChecklistPropertyDetachedStructureComponent extends BaseComponent implements OnInit {
  detachedStructureForms: FormGroup;
  outbuildingDetails: SelectItem[];
  otherDetachedStructuresDetails: SelectItem[];

  constructor(public propertyService: InspectionOrderChecklistPropertyService,
    public ioService: InspectionOrderService) { 
    super();
  }

  ngOnInit() {
    this.propertyService.getOutbuildingDetails().takeUntil(this.stop$).subscribe(data => this.outbuildingDetails = data);
    this.propertyService.getOtherDetachedStructuresDetails().takeUntil(this.stop$).subscribe(data => this.otherDetachedStructuresDetails = data);

    this.detachedStructureForms = this.propertyService.propertyForms.detachedStructure;

  }

  setOutbuildingValue() {
    let outbuildingValue = this.detachedStructureForms.value.outbuilding;
    this.propertyService.valueChanges(outbuildingValue, "outbuilding", "outBuilding", "fencingAndOtherAttachments");
  }

  setOutbuildingDetailsValue() {
    let outbuildingDetailsValue = this.detachedStructureForms.value.outbuildingDetails;
    this.propertyService.valueChanges(outbuildingDetailsValue, "outbuildingDetails", "outBuildingDetails", "fencingAndOtherAttachments");
  }

  otherDetachedStructuresValue() {
    let otherDetachedStructuresValue = this.detachedStructureForms.value.otherDetachedStructure;
    this.propertyService.valueChanges(otherDetachedStructuresValue, "otherDetachedStructure", "otherDetachedStructure", "fencingAndOtherAttachments");
  }

  otherDetachedStructuresDetailsValue() {
    let otherDetachedStructuresDetailsValue = this.detachedStructureForms.value.otherDetachedStructuresDetails;
    this.propertyService.valueChanges(otherDetachedStructuresDetailsValue, "otherDetachedStructuresDetails", "otherDetachedStructureDetails", "fencingAndOtherAttachments");
  }
}
