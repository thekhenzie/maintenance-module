import { AgmCoreModule } from '@agm/core';
import { AgmJsMarkerClustererModule } from '@agm/js-marker-clusterer';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BreadcrumbModule } from 'primeng/components/breadcrumb/breadcrumb';
import { ConfirmDialogModule } from 'primeng/components/confirmdialog/confirmdialog';
import { DropdownModule } from 'primeng/components/dropdown/dropdown';
import { GrowlModule } from 'primeng/components/growl/growl';
import { PaginatorModule } from 'primeng/components/paginator/paginator';
import { SpinnerModule } from 'primeng/components/spinner/spinner';
import { TableModule } from 'primeng/components/table/table';
import { FileUploadModule } from 'primeng/fileupload';
import * as primeModules from 'primeng/primeng';
import { DataListModule, LightboxModule, OverlayPanelModule, ProgressSpinnerModule, TooltipModule } from 'primeng/primeng';
import { DashboardRoutingModule } from '../dashboard/dashboard.routes';
import { DynamicComponentWrapperComponent } from '../shared/components/dynamic-component-wrapper.component';
import { SharedModule } from '../shared/shared.module';
import { AgentinfoComponent } from './components/agentinfo/agentinfo.component';
import { GetchecklistComponent } from './components/getchecklist/getchecklist.component';
import { InspectionChecklistPhotoComponent } from './components/inspection-checklist/photo/inspection-checklist-photo.component';
import { InspectionChecklistPropertyAdditionalExposureComponent } from './components/inspection-checklist/property/category/additional-exposure/inspection-checklist-property-additional-exposure.component';
import { InspectionChecklistPropertyBuildingConcernComponent } from './components/inspection-checklist/property/category/building-concern/inspection-checklist-property-building-concern.component';
import { InspectionChecklistPropertyDetachedStructureComponent } from './components/inspection-checklist/property/category/detached-structure/inspection-checklist-property-detached-structure.component';
import { InspectionChecklistPropertyGeneralComponent } from './components/inspection-checklist/property/category/general/inspection-checklist-property-general.component';
import { InspectionChecklistPropertyHighValueBathComponent } from './components/inspection-checklist/property/category/high-value-bath/inspection-checklist-property-high-value-bath.component';
import { InspectionChecklistPropertyHighValueFloorToCeilingComponent } from './components/inspection-checklist/property/category/high-value-floor-to-ceiling/inspection-checklist-property-high-value-floor-to-ceiling.component';
import { InspectionChecklistPropertyHighValueInteriorFeatureComponent } from './components/inspection-checklist/property/category/high-value-interior-feature/inspection-checklist-property-high-value-interior-feature.component';
import { InspectionChecklistPropertyHighValueKitchenComponent } from './components/inspection-checklist/property/category/high-value-kitchen/inspection-checklist-property-high-value-kitchen.component';
import { InspectionChecklistPropertyHomeDetailComponent } from './components/inspection-checklist/property/category/home-detail/inspection-checklist-property-home-detail.component';
import { InspectionChecklistPropertyInteriorDetailComponent } from './components/inspection-checklist/property/category/interior-detail/inspection-checklist-property-interior-detail.component';
import { NonwildfireMitigationComponent } from './components/inspection-checklist/property/category/nonwildfire-mitigation/nonwildfire-mitigation.component';
import { InspectionChecklistPropertyComponent } from './components/inspection-checklist/property/inspection-checklist-property.component';
import { InspectionChecklistRiskSummaryComponent } from './components/inspection-checklist/risk-summary/risk-summary.component';
import { InspectionChecklistTabsComponent } from './components/inspection-checklist/tabs/inspection-checklist-tabs.component';
import { InspectionChecklistWildfireAccessAndFireProtectionComponent } from './components/inspection-checklist/wildfire-assessment/category/access-and-fire-protection/inspection-checklist-wildfire-access-and-fire-protection.component';
import { InspectionChecklistWildfireDecksAndBalconiesComponent } from './components/inspection-checklist/wildfire-assessment/category/decks-and-balconies/inspection-checklist-wildfire-decks-and-balconies.component';
import { InspectionChecklistWildfireExteriorSidingComponent } from './components/inspection-checklist/wildfire-assessment/category/exterior-siding/inspection-checklist-wildfire-exterior-siding.component';
import { InspectionChecklistWildfireExternalFuelSourceComponent } from './components/inspection-checklist/wildfire-assessment/category/external-fuel-source/inspection-checklist-wildfire-external-fuel-source.component';
import { InspectionChecklistWildfireFencingAndOtherAttachmentsComponent } from './components/inspection-checklist/wildfire-assessment/category/fencing-and-other-attachments/inspection-checklist-wildfire-fencing-and-other-attachments.component';
import { InspectionChecklistWildfireFoundationToFrameComponent } from './components/inspection-checklist/wildfire-assessment/category/foundation-to-frame/inspection-checklist-wildfire-foundation-to-frame.component';
import { MitigationComponent } from './components/inspection-checklist/wildfire-assessment/category/mitigation/mitigation.component';
import { InspectionChecklistWildfireRoofComponent } from './components/inspection-checklist/wildfire-assessment/category/roof/inspection-checklist-wildfire-roof.component';
import { InspectionChecklistWildfireSurroundingsComponent } from './components/inspection-checklist/wildfire-assessment/category/surroundings/inspection-checklist-wildfire-surroundings.component';
import { InspectionChecklistWildfireWindowsComponent } from './components/inspection-checklist/wildfire-assessment/category/windows/inspection-checklist-wildfire-windows.component';
import { InspectionChecklistWildfireAssessmentComponent } from './components/inspection-checklist/wildfire-assessment/inspection-checklist-wildfire-assessment.component';
import { MapItMapMarkerComponent } from './components/inspection-info/map-it-map-marker/map-it-map-marker.component';
import { MapItComponent } from './components/inspection-info/map-it/map-it.component';
import { InspectionorderformComponent } from './components/inspectionorderform/inspectionorderform.component';
import { InspectionordernavComponent } from './components/inspectionordernav/inspectionordernav.component';
import { InspectionorderstatusComponent } from './components/inspectionorderstatus/inspectionorderstatus.component';
import { InsuredinfoComponent } from './components/insuredinfo/insuredinfo.component';
import { PhotoMemoCrudComponent } from './components/photo-memo-crud/photo-memo-crud.component';
import { PolicyComponent } from './components/policy/policy.component';
import { CreateinspectionorderComponent } from './pages/createinspectionorder/createinspectionorder.component';
import { OrdermanagementComponent } from './pages/index/ordermanagement.component';
import { InspectionChecklistComponent } from './pages/inspection-checklist/inspection-checklist.component';
import { InspectionNotesComponent } from './pages/inspection-notes/inspection-notes.component';
import { ChildPhotoMemoCrudComponent } from './components/child-photo-memo-crud/child-photo-memo-crud.component';
import { InspectionNotesConfirmationComponent } from './components/inspection-notes-confirmation/inspection-notes-confirmation.component';
import { InspectioninfoComponent } from './pages/inspectioninfo/inspectioninfo.component';
import { InsuredMitigationComponent } from './pages/insured-mitigation/insured-mitigation.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MglTimelineModule } from 'angular-mgl-timeline';
import { InspectionOrderTimelineComponent } from './pages/inspection-order-timeline/inspection-order-timeline.component';
import { PolicyXmlComponent } from './pages/policy-xml/policy-xml.component';

@NgModule({
  imports: [
    CommonModule,

    SharedModule,
    DashboardRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    DataListModule,
    BrowserAnimationsModule,
    MglTimelineModule,

    // primeng modules
    primeModules.PanelModule,
    primeModules.TabViewModule,
    primeModules.CalendarModule,
    primeModules.PaginatorModule,
    primeModules.ScheduleModule,
    primeModules.AccordionModule,

    GrowlModule,
    ProgressSpinnerModule,

    primeModules.RadioButtonModule,
    primeModules.ButtonModule,
    primeModules.SelectButtonModule,
    primeModules.MenuModule,

    TableModule,
    primeModules.SharedModule,
    primeModules.DialogModule,

    primeModules.DropdownModule,
    primeModules.ChartModule,
    primeModules.InputMaskModule,

    primeModules.MultiSelectModule,
    primeModules.KeyFilterModule,
    primeModules.CheckboxModule,

    BreadcrumbModule,
    SpinnerModule,
    PaginatorModule,
    DropdownModule,
    ConfirmDialogModule,
    FileUploadModule,
    OverlayPanelModule,
    LightboxModule,
    TooltipModule,
    AgmCoreModule.forRoot({
      apiKey: "AIzaSyDwnXciP44QzXQjTLNrJDc8DIsRUfQ8428"
    }),
    AgmJsMarkerClustererModule
  ],
  declarations: [
	  OrdermanagementComponent, 
	  InspectioninfoComponent, 
	  InspectionorderstatusComponent, 
	  InsuredinfoComponent, 
	  PolicyComponent, 
	  AgentinfoComponent, 
	  InspectionordernavComponent, 
	  CreateinspectionorderComponent, 
	  InspectionorderformComponent, 
	  GetchecklistComponent, 
	  InspectionChecklistComponent,
    InspectionChecklistTabsComponent,
    InspectionNotesComponent,
    MitigationComponent,
    NonwildfireMitigationComponent,
    PhotoMemoCrudComponent,
    ChildPhotoMemoCrudComponent,
    InspectionNotesConfirmationComponent,
    InsuredMitigationComponent,
    PolicyXmlComponent,
    
    // inspection checklist sections
	  InspectionChecklistPropertyComponent,
	  InspectionChecklistWildfireAssessmentComponent,
	  InspectionChecklistPhotoComponent,

    // inspection checklist property categories
	  InspectionChecklistPropertyGeneralComponent,
	  InspectionChecklistPropertyInteriorDetailComponent,
	  InspectionChecklistPropertyHomeDetailComponent,
	  InspectionChecklistPropertyBuildingConcernComponent,
	  InspectionChecklistPropertyDetachedStructureComponent,
	  InspectionChecklistPropertyAdditionalExposureComponent,
	  InspectionChecklistPropertyHighValueKitchenComponent,
	  InspectionChecklistPropertyHighValueBathComponent,
	  InspectionChecklistPropertyHighValueFloorToCeilingComponent,
    InspectionChecklistPropertyHighValueInteriorFeatureComponent,
    NonwildfireMitigationComponent,
    
    //inspection checklist wildfire assessment categories
    InspectionChecklistWildfireRoofComponent,
    InspectionChecklistWildfireFoundationToFrameComponent,
    InspectionChecklistWildfireExteriorSidingComponent,
    InspectionChecklistWildfireWindowsComponent,
    InspectionChecklistWildfireDecksAndBalconiesComponent,
    InspectionChecklistWildfireFencingAndOtherAttachmentsComponent,
    InspectionChecklistWildfireSurroundingsComponent,
    InspectionChecklistWildfireAccessAndFireProtectionComponent,
    InspectionChecklistWildfireExternalFuelSourceComponent,
    MitigationComponent,
	  InspectionChecklistRiskSummaryComponent,

	  // from shared module
	  DynamicComponentWrapperComponent,

	  MapItComponent,
    MapItMapMarkerComponent,
    InspectionOrderTimelineComponent
  ],
  entryComponents: [
    InspectionChecklistPropertyComponent,
	  InspectionChecklistWildfireAssessmentComponent,
	  InspectionChecklistPhotoComponent,
	  InspectionChecklistRiskSummaryComponent,
    
    InspectionChecklistPropertyGeneralComponent,
	  InspectionChecklistPropertyInteriorDetailComponent,
	  InspectionChecklistPropertyHomeDetailComponent,
	  InspectionChecklistPropertyBuildingConcernComponent,
	  InspectionChecklistPropertyDetachedStructureComponent,
	  InspectionChecklistPropertyAdditionalExposureComponent,
	  InspectionChecklistPropertyHighValueKitchenComponent,
	  InspectionChecklistPropertyHighValueBathComponent,
	  InspectionChecklistPropertyHighValueFloorToCeilingComponent,
    InspectionChecklistPropertyHighValueInteriorFeatureComponent,
    NonwildfireMitigationComponent,

    InspectionChecklistWildfireRoofComponent,
    InspectionChecklistWildfireFoundationToFrameComponent,
    InspectionChecklistWildfireExteriorSidingComponent,
    InspectionChecklistWildfireWindowsComponent,
    InspectionChecklistWildfireDecksAndBalconiesComponent,
    InspectionChecklistWildfireFencingAndOtherAttachmentsComponent,
    InspectionChecklistWildfireSurroundingsComponent,
    InspectionChecklistWildfireAccessAndFireProtectionComponent,
    InspectionChecklistWildfireExternalFuelSourceComponent,
    MitigationComponent
  ]
})
export class OrderManagementModule { }
