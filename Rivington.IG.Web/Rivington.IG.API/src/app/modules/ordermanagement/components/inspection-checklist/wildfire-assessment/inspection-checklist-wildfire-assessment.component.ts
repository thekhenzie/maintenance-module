import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IInspectionOrderChecklistWildFireServiceForms, InspectionOrderChecklistWildFireService } from '../../../../core/services/ordermanagement/inspection-order-checklist-section/wildfire.service';
import { InspectionOrderChecklistService } from '../../../../core/services/ordermanagement/inspection-order-checklist.service';
import { BaseComponent } from '../../../../shared/BaseComponent';
import { InspectionChecklistWildfireAccessAndFireProtectionComponent } from './category/access-and-fire-protection/inspection-checklist-wildfire-access-and-fire-protection.component';
import { InspectionChecklistWildfireDecksAndBalconiesComponent } from './category/decks-and-balconies/inspection-checklist-wildfire-decks-and-balconies.component';
import { InspectionChecklistWildfireExteriorSidingComponent } from './category/exterior-siding/inspection-checklist-wildfire-exterior-siding.component';
import { InspectionChecklistWildfireExternalFuelSourceComponent } from './category/external-fuel-source/inspection-checklist-wildfire-external-fuel-source.component';
import { InspectionChecklistWildfireFencingAndOtherAttachmentsComponent } from './category/fencing-and-other-attachments/inspection-checklist-wildfire-fencing-and-other-attachments.component';
import { InspectionChecklistWildfireFoundationToFrameComponent } from './category/foundation-to-frame/inspection-checklist-wildfire-foundation-to-frame.component';
import { InspectionChecklistWildfireRoofComponent } from './category/roof/inspection-checklist-wildfire-roof.component';
import { InspectionChecklistWildfireSurroundingsComponent } from './category/surroundings/inspection-checklist-wildfire-surroundings.component';
import { InspectionChecklistWildfireWindowsComponent } from './category/windows/inspection-checklist-wildfire-windows.component';
import { MitigationComponent } from './category/mitigation/mitigation.component';
import { InspectionOrderChecklistPropertyService } from '../../../../core/services/ordermanagement/inspection-order-checklist-section/property.service';
import { InspectionOrderService } from '../../../../core/services/ordermanagement/inspection-order.service';
import { AuthService } from '../../../../core/services/auth.service';

@Component({
  selector: 'app-inspection-checklist-wildfire-assessment',
  templateUrl: './inspection-checklist-wildfire-assessment.component.html',
  styleUrls: ['./inspection-checklist-wildfire-assessment.component.css']
})
export class InspectionChecklistWildfireAssessmentComponent extends BaseComponent implements OnInit, OnDestroy {
  currentIOid: string;
  public renderedIndexes: number[] = [];
  accordionIsMultiple: boolean;
  accordionIndex: number;
  categories: any[];
  currentCategory: string;

  constructor(private route: ActivatedRoute, private router: Router,
    private ioChecklistService: InspectionOrderChecklistService,
    private ioChecklistWildfireService: InspectionOrderChecklistWildFireService,
    private ioChecklistPropertyService: InspectionOrderChecklistPropertyService,
    private ioService: InspectionOrderService,
    private auth: AuthService
  ) {
    super();
    this.accordionIsMultiple = false;
    this.accordionIndex = 0;
    this.categories = [
      {
        index: 0,
        component: InspectionChecklistWildfireRoofComponent,
        name: "roof",
        header: "Roof",
        leftIcon: "", // "mdi mdi-fire"
        disabled: false
      },
      {
        index: 1,
        component: InspectionChecklistWildfireFoundationToFrameComponent,
        name: "foundationToFrame",
        header: "Foundation To Frame",
        leftIcon: "", // "mdi mdi-fire"
        disabled: false
      },
      {
        index: 2,
        component: InspectionChecklistWildfireExteriorSidingComponent,
        name: "exteriorSiding",
        header: "Exterior Siding",
        leftIcon: "", // "mdi mdi-fire"
        disabled: false
      },
      {
        index: 3,
        component: InspectionChecklistWildfireWindowsComponent,
        name: "windows",
        header: "Windows",
        leftIcon: "", // "mdi mdi-fire"
        disabled: false
      },
      {
        index: 4,
        component: InspectionChecklistWildfireDecksAndBalconiesComponent,
        name: "decksAndBalconies",
        header: "Decks & Balconies",
        leftIcon: "", // "mdi mdi-fire"
        disabled: false
      },
      {
        index: 5,
        component: InspectionChecklistWildfireFencingAndOtherAttachmentsComponent,
        name: "fencingAndOtherAttachments",
        header: "Fencing & Other Attachments",
        leftIcon: "", // "mdi mdi-fire"
        disabled: false
      },
      {
        index: 6,
        component: InspectionChecklistWildfireSurroundingsComponent,
        name: "surroundings",
        header: "Surroundings",
        leftIcon: "", // "mdi mdi-fire"
        disabled: false
      },
      {
        index: 7,
        component: InspectionChecklistWildfireAccessAndFireProtectionComponent,
        name: "accessAndFireProtection",
        header: "Access And Fire Protection",
        leftIcon: "", // "mdi mdi-fire"
        disabled: false
      },
      {
        index: 8,
        component: InspectionChecklistWildfireExternalFuelSourceComponent,
        name: "externalFuelSource",
        header: "External Fuel Source",
        leftIcon: "", // "mdi mdi-fire"
        disabled: false
      },
      {
        index: 9,
        component: MitigationComponent,
        name: "mitigation",
        header: "Mitigation",
        leftIcon: "", // "mdi mdi-fire"
        disabled: false
      }
    ]
  }

  ngOnInit() {
    this.route.params.takeUntil(this.stop$).subscribe(params => {
      if (this.isCategoryParamChanged(params)) {
        let paramCategory = this.currentCategory;
        let category = this.categories.find(s => s.name == paramCategory);
        if (!!!category) category = this.categories[0];

        this.accordionIndex = category.index;
      }

      if (this.isIoIdParamChanged(params)) {
        this.ioChecklistWildfireService.initiateFormValues();

        this.ioService.getInspectionOrders("InspectionList", this.currentIOid).then(
          data => {
            this.ioService.inspectionOrder = Object.assign({}, this.ioService.updateData[0]);
            this.auth.currentUserRole = this.auth.getRoles().toString();
            if (this.auth.currentUserRole) {
              if (!this.ioService.checkIOBasedOnRole(this.auth.currentUserRole)) {
                  // wildfire
                  this.ioChecklistWildfireService.wildfireAssessmentForms.roof.disable();
                  this.ioChecklistWildfireService.wildfireAssessmentForms.foundationToFrame.disable();
                  this.ioChecklistWildfireService.wildfireAssessmentForms.exteriorSiding.disable();
                  this.ioChecklistWildfireService.wildfireAssessmentForms.windows.disable();
                  this.ioChecklistWildfireService.wildfireAssessmentForms.decksAndBalconies.disable();
                  this.ioChecklistWildfireService.wildfireAssessmentForms.fencingAndOtherAttachments.disable();
                  this.ioChecklistWildfireService.wildfireAssessmentForms.surroundings.disable();
                  this.ioChecklistWildfireService.wildfireAssessmentForms.accessAndFireProtection.disable();
                  this.ioChecklistWildfireService.wildfireAssessmentForms.externalFuelSource.disable();
              }
          }
        });

        this.ioChecklistWildfireService.isInitiated = true;

        this.ioChecklistWildfireService.getIOWildFire(this.currentIOid).takeUntil(this.stop$)
          .subscribe(data => {
            this.ioChecklistWildfireService.setFormValues({
              wildfireAssessment: data,
              id: this.currentIOid
            });
            
            let prefilledValues = this.ioChecklistPropertyService.prefilledVaules;
            let wildfireForms = this.ioChecklistWildfireService.wildfireAssessmentForms;

              if (prefilledValues.primaryRoofId) {
                wildfireForms.roof.get('primaryRoofCoveringId').
                setValue(prefilledValues.primaryRoofId);
                this.ioChecklistPropertyService.prefilledVaules.primaryRoofId = null;
              }
              if (prefilledValues.secondaryRoofId) {
                wildfireForms.roof.get('secondaryRoofCoveringId').
                setValue(prefilledValues.secondaryRoofId);
                this.ioChecklistPropertyService.prefilledVaules.secondaryRoofId = null;
              }
              if (prefilledValues.roofShape) {
                wildfireForms.roof.get('roofShapeId').
                setValue(prefilledValues.roofShape);
                this.ioChecklistPropertyService.prefilledVaules.roofShape = null;
              }
              if (prefilledValues.roofPitch) {
                wildfireForms.roof.get('roofPitchId').
                setValue(prefilledValues.roofPitch);
                this.ioChecklistPropertyService.prefilledVaules.roofPitch = null;
              }
              if (prefilledValues.roofConcernDetails) {
                wildfireForms.roof.get('roofConcernDetails').
                setValue(prefilledValues.roofConcernDetails);
                this.ioChecklistPropertyService.prefilledVaules.roofConcernDetails = null;
              }
              if (prefilledValues.foundationType) {
                wildfireForms.foundationToFrame.get('foundationTypeId').
                setValue(prefilledValues.foundationType);
                this.ioChecklistPropertyService.prefilledVaules.foundationType = null;
              }
              if (prefilledValues.framingType) {
                wildfireForms.foundationToFrame.get('framingTypeId').
                setValue(prefilledValues.framingType);
                this.ioChecklistPropertyService.prefilledVaules.framingType = null;
              }
              if (prefilledValues.primaryExteriorWall) {
                wildfireForms.exteriorSiding.get('primaryExteriorWallCoveringId').
                setValue(prefilledValues.primaryExteriorWall);
                this.ioChecklistPropertyService.prefilledVaules.primaryExteriorWall = null;
              }
              if (prefilledValues.secondaryExteriorWall) {
                wildfireForms.exteriorSiding.get('secondaryExteriorWallCoveringId').
                setValue(prefilledValues.secondaryExteriorWall);
                this.ioChecklistPropertyService.prefilledVaules.secondaryExteriorWall = null;
              }
              if (prefilledValues.windowStyles) {
                wildfireForms.windows.get('windowStyles').
                setValue(prefilledValues.windowStyles);
                this.ioChecklistPropertyService.prefilledVaules.windowStyles = null;
              }
              if (prefilledValues.outBuilding) {
                wildfireForms.fencingAndOtherAttachments.get('outbuilding').
                setValue(prefilledValues.outBuilding);
                this.ioChecklistPropertyService.prefilledVaules.outBuilding = null;
              }
              if (prefilledValues.outBuildingDetails) {
                wildfireForms.fencingAndOtherAttachments.get('outbuildingDetails').
                setValue(prefilledValues.outBuildingDetails);
                this.ioChecklistPropertyService.prefilledVaules.outBuildingDetails = null;
              }
              if (prefilledValues.otherDetachedStructure) {
                wildfireForms.fencingAndOtherAttachments.get('otherDetachedStructure').
                setValue(prefilledValues.otherDetachedStructure);
                this.ioChecklistPropertyService.prefilledVaules.otherDetachedStructure = null;
              }
              if (prefilledValues.otherDetachedStructureDetails) {
                wildfireForms.fencingAndOtherAttachments.get('otherDetachedStructuresDetails').
                setValue(prefilledValues.otherDetachedStructureDetails);
                this.ioChecklistPropertyService.prefilledVaules.otherDetachedStructureDetails = null;
              }
            
            console.log("getIOWildFire")
            console.log(data)
          },
          error => {
            console.log(error);
            // Utils.showError("Complete the fields Property Value and Inspection Status");
          },
          () => {

          });
      }

    });
  }

  isCategoryParamChanged(params: any): boolean {
    let currentParam = params["category"];
    if (this.currentCategory != currentParam) {
      this.currentCategory = currentParam;
      return true;
    }
    return false;
  }

  isIoIdParamChanged(params: any): boolean {
    let currentParam = params["id"];
    if (this.currentIOid != currentParam) {
      this.currentIOid = currentParam;
      return true;
    }
    return false;
  }

  tabOpenEvent(e) {
    if (this.renderedIndexes.indexOf(e.index) < 0) this.renderedIndexes.push(e.index);
    this.changeRoute(e);
  }

  changeRoute(e) {
    let currentAccordionIndex = e.index;
    if (currentAccordionIndex > this.categories.length) currentAccordionIndex = 0;
    let category = this.categories.find(s => s.index == currentAccordionIndex);
    if (category) {
      this.router.navigate([`../${category.name}`], { relativeTo: this.route });
    }
  }

  ngOnDestroy() {
    this.ioChecklistWildfireService.wildfireAssessmentForms = null;
  }
}
