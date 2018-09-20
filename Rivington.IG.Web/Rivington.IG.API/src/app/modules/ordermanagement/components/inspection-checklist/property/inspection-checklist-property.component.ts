import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IInspectionOrderChecklistPropertyServiceForms, InspectionOrderChecklistPropertyService } from '../../../../core/services/ordermanagement/inspection-order-checklist-section/property.service';
import { InspectionOrderChecklistService } from '../../../../core/services/ordermanagement/inspection-order-checklist.service';
import { BaseComponent } from '../../../../shared/BaseComponent';
import { InspectionChecklistPropertyAdditionalExposureComponent } from './category/additional-exposure/inspection-checklist-property-additional-exposure.component';
import { InspectionChecklistPropertyBuildingConcernComponent } from './category/building-concern/inspection-checklist-property-building-concern.component';
import { InspectionChecklistPropertyDetachedStructureComponent } from './category/detached-structure/inspection-checklist-property-detached-structure.component';
import { InspectionChecklistPropertyGeneralComponent } from './category/general/inspection-checklist-property-general.component';
import { InspectionChecklistPropertyHighValueBathComponent } from './category/high-value-bath/inspection-checklist-property-high-value-bath.component';
import { InspectionChecklistPropertyHighValueFloorToCeilingComponent } from './category/high-value-floor-to-ceiling/inspection-checklist-property-high-value-floor-to-ceiling.component';
import { InspectionChecklistPropertyHighValueInteriorFeatureComponent } from './category/high-value-interior-feature/inspection-checklist-property-high-value-interior-feature.component';
import { InspectionChecklistPropertyHighValueKitchenComponent } from './category/high-value-kitchen/inspection-checklist-property-high-value-kitchen.component';
import { InspectionChecklistPropertyHomeDetailComponent } from './category/home-detail/inspection-checklist-property-home-detail.component';
import { InspectionChecklistPropertyInteriorDetailComponent } from './category/interior-detail/inspection-checklist-property-interior-detail.component';
import { NonwildfireMitigationComponent } from './category/nonwildfire-mitigation/nonwildfire-mitigation.component';
import { InspectionOrderService } from '../../../../core/services/ordermanagement/inspection-order.service';
import { AuthService } from '../../../../core/services/auth.service';

@Component({
  selector: 'app-inspection-checklist-property',
  templateUrl: './inspection-checklist-property.component.html',
  styleUrls: ['./inspection-checklist-property.component.css']
})
export class InspectionChecklistPropertyComponent extends BaseComponent implements OnInit, OnDestroy {
  currentIOid: string;
  public renderedIndexes: number[];
  accordionIsMultiple: boolean;
  accordionIndex: number;  
  categories: any[];
  currentCategory: string;

  constructor(private route:ActivatedRoute, 
    private router: Router,
    private ioChecklistService: InspectionOrderChecklistService,
    private ioChecklistPropertyService: InspectionOrderChecklistPropertyService,
    private ioService: InspectionOrderService,
    private auth: AuthService
  ) {
      super();
      
      this.renderedIndexes = [];
      this.accordionIsMultiple = false;
      this.accordionIndex = 0;  
      this.categories = [
        {
          index: 0,
          component: InspectionChecklistPropertyGeneralComponent,
          name: "general",
          header: "General",
          leftIcon: "", // "mdi mdi-fire"
          disabled: false
        },
        {
          index: 1,
          component: InspectionChecklistPropertyInteriorDetailComponent,
          name: "interior-detail",
          header: "Interior Details",
          leftIcon: "",
          disabled: false
        },
        {
          index: 2,
          component: InspectionChecklistPropertyHomeDetailComponent,
          name: "home-detail",
          header: "Home Details",
          leftIcon: "",
          disabled: false
        },
        {
          index: 3,
          component: InspectionChecklistPropertyBuildingConcernComponent,
          name: "building-concern",
          header: "Building Concerns",
          leftIcon: "",
          disabled: false
        },
        {
          index: 4,
          component: InspectionChecklistPropertyDetachedStructureComponent,
          name: "detached-structure",
          header: "Detached Structures",
          leftIcon: "",
          disabled: false
        },
        {
          index: 5,
          component: InspectionChecklistPropertyAdditionalExposureComponent,
          name: "additional-exposure",
          header: "Additional Exposures",
          leftIcon: "",
          disabled: false
        },
        {
          index: 6,
          component: InspectionChecklistPropertyHighValueKitchenComponent,
          name: "high-value-kitchen",
          header: "High Value - Kitchen",
          leftIcon: "",
          disabled: false
        },
        {
          index: 7,
          component: InspectionChecklistPropertyHighValueBathComponent,
          name: "high-value-bath",
          header: "High Value - Bath",
          leftIcon: "",
          disabled: false
        },
        {
          index: 8,
          component: InspectionChecklistPropertyHighValueFloorToCeilingComponent,
          name: "high-value-floor-to-ceiling",
          header: "High Value - Floor to Ceiling",
          leftIcon: "",
          disabled: false
        },
        {
          index: 9,
          component: InspectionChecklistPropertyHighValueInteriorFeatureComponent,
          name: "high-value-interior-feature",
          header: "High Value - Interior Feature",
          leftIcon: "",
          disabled: false
        },
        {
          index: 10,
          component: NonwildfireMitigationComponent,
          name: "non-wildfire-mitigation",
          header: "Mitigation",
          leftIcon: "",
          disabled: false
        }
      ];
  } 

  ngOnInit() {
    this.route.params.takeUntil(this.stop$).subscribe(params => { 
      if(this.isCategoryParamChanged(params)) {
        let paramCategory = this.currentCategory;
        let category = this.categories.find(s => s.name == paramCategory);
        if(!!!category) category = this.categories[0];
  
        this.accordionIndex = category.index;
      }

      if(this.isIoIdParamChanged(params)) {
        this.ioChecklistPropertyService.initiateFormValues();

        this.ioService.getInspectionOrders("InspectionList", this.currentIOid).then(
          data => {
            this.ioService.inspectionOrder = Object.assign({}, this.ioService.updateData[0]);
            this.auth.currentUserRole = this.auth.getRoles().toString();
            if (this.auth.currentUserRole) {
              if (!this.ioService.checkIOBasedOnRole(this.auth.currentUserRole)) {
                  //property
                  this.ioChecklistPropertyService.propertyForms.general.disable();
                  this.ioChecklistPropertyService.propertyForms.interiorDetail.disable();
                  this.ioChecklistPropertyService.propertyForms.homeDetail.disable();
                  this.ioChecklistPropertyService.propertyForms.buildingConcern.disable();
                  this.ioChecklistPropertyService.propertyForms.detachedStructure.disable();
                  this.ioChecklistPropertyService.propertyForms.additionalExposure.disable();
                  this.ioChecklistPropertyService.propertyForms.highValueKitchen.disable();
                  this.ioChecklistPropertyService.propertyForms.highValueBath.disable();
                  this.ioChecklistPropertyService.propertyForms.highValueFloorToCeiling.disable();
                  this.ioChecklistPropertyService.propertyForms.highValueInteriorFeature.disable();
              }
          }
        });
        
        this.ioChecklistPropertyService.getIOProperty(this.currentIOid).takeUntil(this.stop$)
        .subscribe(data => {
          this.ioChecklistPropertyService.setFormValues({
            property: data
          });
          console.log("getIOProperty")
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
    if(this.currentCategory != currentParam) {
      this.currentCategory = currentParam;
      return true;
    }
    return false;
  }

  isIoIdParamChanged(params: any): boolean {
    let currentParam = params["id"];
    if(this.currentIOid != currentParam) {
      this.currentIOid = currentParam;
      return true;
    }
    return false;
  }

  tabOpenEvent(e) {
    if(this.renderedIndexes.indexOf(e.index) < 0) this.renderedIndexes.push(e.index);
    this.changeRoute(e);
  }

  changeRoute(e) {
    let currentAccordionIndex = e.index;
    if(currentAccordionIndex > this.categories.length) currentAccordionIndex = 0;
    let category = this.categories.find(s => s.index == currentAccordionIndex);
    if(category) {
      this.router.navigate([`../${category.name}`], { relativeTo: this.route});
    }
  }
  
  ngOnDestroy() {
    this.ioChecklistPropertyService.propertyForms = null;
  }
}
