import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../../../../../shared/BaseComponent';
import { InspectionOrderChecklistPropertyService } from '../../../../../../core/services/ordermanagement/inspection-order-checklist-section/property.service';
import { ArchitecturalStyle } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/home-detail/architectural-style';
import { FramingType } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/home-detail/framing-type';
import { ConstructionQuality } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/home-detail/construction-quality';
import { HomeShape } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/home-detail/home-shape';
import { PrimaryExteriorWallCovering } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/home-detail/primary-exterior-wall-covering';
import { SecondaryExteriorWallCovering } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/home-detail/secondary-exterior-wall-covering';
import { PrimaryRoofCovering } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/home-detail/primary-roof-covering';
import { SecondaryRoofCovering } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/home-detail/secondary-roof-covering';
import { RoofType } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/home-detail/roof-type';
import { FoundationType } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/home-detail/foundation-type';
import { SlopeOfSite } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/home-detail/slope-of-site';
import { Locale } from '../../../../../../shared/models/ordermanagement/inspection-order/checklist/property/home-detail/locale';
import { SelectItem, Dropdown } from 'primeng/primeng';
import { InspectionOrderChecklistWildFireService } from '../../../../../../core/services/ordermanagement/inspection-order-checklist-section/wildfire.service';
import { FormGroup } from '@angular/forms';
import { InspectionOrderService } from '../../../../../../core/services/ordermanagement/inspection-order.service';

@Component({
  selector: 'app-inspection-checklist-property-home-detail',
  templateUrl: './inspection-checklist-property-home-detail.component.html',
  styleUrls: ['./inspection-checklist-property-home-detail.component.css']
})
export class InspectionChecklistPropertyHomeDetailComponent extends BaseComponent implements OnInit {
  roofPitch: SelectItem[];
  roofShapes: SelectItem[];
  homeDetailforms: FormGroup;
  value: string;
  primaryRoofvalue: string;
  architecturalStyles: SelectItem[];
  framingTypes: SelectItem[];
  constructionQualities: SelectItem[];
  homeShapes: SelectItem[];
  primaryExteriorWallCoverings: SelectItem[];
  secondaryExteriorWallCoverings: SelectItem[];
  primaryRoofCoverings: SelectItem[];
  secondaryRoofCoverings: SelectItem[];
  roofTypes: SelectItem[];
  foundationTypes: SelectItem[];
  slopeOfSites: SelectItem[];
  locales: SelectItem[];

  constructor(public propertyService: InspectionOrderChecklistPropertyService,
              public wildFireService: InspectionOrderChecklistWildFireService,
              public ioService: InspectionOrderService) { 
    super();
  }

  ngOnInit() {
    this.propertyService.getArchitecturalStyles().takeUntil(this.stop$).subscribe(data => this.architecturalStyles = data);
    this.propertyService.getFramingTypes().takeUntil(this.stop$).subscribe(data => this.framingTypes = data);
    this.propertyService.getConstructionQualities().takeUntil(this.stop$).subscribe(data => this.constructionQualities = data);
    this.propertyService.getHomeShapes().takeUntil(this.stop$).subscribe(data => this.homeShapes = data);
    this.propertyService.getPrimaryExteriorWallCoverings().takeUntil(this.stop$).subscribe(data => this.primaryExteriorWallCoverings = data);
    this.propertyService.getSecondaryExteriorWallCoverings().takeUntil(this.stop$).subscribe(data => this.secondaryExteriorWallCoverings = data);
    this.propertyService.getPrimaryRoofCoverings().takeUntil(this.stop$).subscribe(data => this.primaryRoofCoverings = data);
    this.propertyService.getSecondaryRoofCoverings().takeUntil(this.stop$).subscribe(data => this.secondaryRoofCoverings = data);
    this.propertyService.getRoofShapes().takeUntil(this.stop$).subscribe(data => this.roofShapes = data);
    this.propertyService.getRoofPitch().takeUntil(this.stop$).subscribe(data => this.roofPitch = data);
    this.propertyService.getFoundationType().takeUntil(this.stop$).subscribe(data => this.foundationTypes = data);
    this.propertyService.getSlopeOfSites().takeUntil(this.stop$).subscribe(data => this.slopeOfSites = data);
    this.propertyService.getLocales().takeUntil(this.stop$).subscribe(data => this.locales = data);

    this.homeDetailforms = this.propertyService.propertyForms.homeDetail;

  }

  setFramingTypeValue() {
    let framingTypeValue = this.homeDetailforms.value.framingTypeId;
    this.propertyService.valueChanges(framingTypeValue, "framingTypeId", "framingType", "foundationToFrame");
  }

  setPrimaryExteriorWallValue() {
    let primaryExteriorWallCoveringValue = this.homeDetailforms.value.primaryExteriorWallCoveringId;
    this.propertyService.valueChanges(primaryExteriorWallCoveringValue, "primaryExteriorWallCoveringId", "primaryExteriorWall", "exteriorSiding");
  }

  setSecondaryExteriorWallValue() {
    let secondaryExteriorWallCoveringValue = this.homeDetailforms.value.secondaryExteriorWallCoveringId;
    this.propertyService.valueChanges(secondaryExteriorWallCoveringValue, "secondaryExteriorWallCoveringId", "secondaryExteriorWall", "exteriorSiding");
  }
  
  setPrimaryRoofValue() {
    let primaryRoofValue = this.homeDetailforms.value.primaryRoofCoveringId;
    this.propertyService.valueChanges(primaryRoofValue, "primaryRoofCoveringId", "primaryRoofId", "roof");
  }
  
  setSecondaryRoofValue() {
    let secondaryRoofValue = this.homeDetailforms.value.secondaryRoofCoveringId;
    this.propertyService.valueChanges(secondaryRoofValue, "secondaryRoofCoveringId", "secondaryRoofId", "roof");
  }

  setRoofShapeValue() {
    let roofShapeValue = this.homeDetailforms.value.roofShapeId;
    this.propertyService.valueChanges(roofShapeValue, "roofShapeId", "roofShape", "roof");
  }

  setRoofPitchValue() {
    let roofPitchValue = this.homeDetailforms.value.roofPitchId;
    this.propertyService.valueChanges(roofPitchValue, "roofPitchId", "roofPitch", "roof");
  }

  setFoundationTypeValue() {
    let foundationTypeValue = this.homeDetailforms.value.foundationTypeId;
    this.propertyService.valueChanges(foundationTypeValue, "foundationTypeId", "foundationType", "foundationToFrame");
  }
}
