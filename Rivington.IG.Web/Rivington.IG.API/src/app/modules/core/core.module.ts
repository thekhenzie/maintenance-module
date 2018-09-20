import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';

import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './services/auth-interceptor';
import { AuthResponseInterceptor } from './services/auth-response-interceptor';

import { AuthService } from './services/auth.service';
import { ContactService } from './services/contact.service';
import { CommonService } from './services/common.service';
import { AuthGuard } from './guards/auth.guard';
import { RoleService } from './services/role.service';
import { RoleGuard } from './guards/role.guard';

import { InspectionChecklistIdIsValidGuard } from './guards/inspection-checklist-id-is-valid.guard';

import { InspectionOrderService } from './services/ordermanagement/inspection-order.service';
import { PolicyService } from './services/ordermanagement/policy.service';
import { StateService } from './services/ordermanagement/state.service';
import { CityService } from './services/ordermanagement/city.service';
import { DatePipe } from '@angular/common';
import { PolicyComponent } from '../ordermanagement/components/policy/policy.component';
import { GetInspectorService } from './services/ordermanagement/getinspector.service';
import { ForgotPasswordGuard } from './guards/forgotpasswordguard';
import { ForgotPasswordService } from './services/forgotpasswordservice';
import { UtilityService } from './services/utility.service';
import { InspectionStatusService } from './services/ordermanagement/inspectionstatus.service';
import { MitigationStatusService } from './services/ordermanagement/mitigationstatus.service';
import { PropertyValueService } from './services/ordermanagement/propertyvalue.service';
import { InspectionOrderChecklistPropertyService } from './services/ordermanagement/inspection-order-checklist-section/property.service';
import { InspectionOrderChecklistService } from './services/ordermanagement/inspection-order-checklist.service';
import { LocalStorageService } from './services/localStorageService';
import { InspectionOrderNotesService } from './services/ordermanagement/inspection-notes.service';
import { ConfirmationService } from 'primeng/components/common/confirmationservice';
import { PhotoTypeService } from './services/ordermanagement/phototype.service';
import { MitigationService } from './services/ordermanagement/inspection-order-checklist-section/mitigation.service';
import { InspectionOrderChecklistWildFireService } from './services/ordermanagement/inspection-order-checklist-section/wildfire.service';
import { AccountRoleService } from './services/ordermanagement/accountrole.service';
import { UserManagementGuard } from './guards/usermanagementguard';
import { UserManagementservice } from './services/usermanagement/user-management.service';
import { UserExistValidatorGuard } from './guards/user-management-user-validator.guard';
import { ReportingService } from './services/reporting/reporting.service';
import { ImageService } from './services/image.service';
import { IOUnsavedChangesGuard } from './guards/io-unsaved-changes.guard';
import { DashboardService } from './services/dashboard/dashboard.service';
import { MapItService } from './services/ordermanagement/map-it-service';
import { AutoLogoutGuard } from './guards/auto-logout.guard';
import { InsuredAuthGuard } from './guards/insured-auth.guard';
import { UserActivityLogService } from './services/ordermanagement/user-activity-log.service';
import { InspectionOrderLogservice } from './services/ordermanagement/inspection-order-log.service';
import { InsuredReportGuard } from './guards/insured-report.guard';
import { StaticPagesService } from './services/static-pages.service';
import { StaticContentExistGuard } from './guards/static-content-exists.guard';
import { CheckIfIOIsLockedGuard } from './guards/check-if-io-islocked.guard';

@NgModule({
  imports: [
    SharedModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthResponseInterceptor,
      multi: true
    },
      
    AuthService,
    ContactService,
    CommonService,
    ContactService,
    RoleService,
    InspectionOrderService,
    MapItService,
    PolicyService,
    StateService,
    CityService,
    DatePipe,
    GetInspectorService,
    UtilityService,
    ImageService,
    InspectionStatusService,
    MitigationStatusService,
    PropertyValueService,
    LocalStorageService,
    InspectionOrderNotesService,
    PhotoTypeService,
    ConfirmationService,
    MitigationService,
    UserManagementservice,
    AccountRoleService,
    DashboardService,
    StaticPagesService,
    
    PolicyComponent,
    ForgotPasswordService,
    InspectionOrderChecklistService,
    InspectionOrderChecklistPropertyService,
    InspectionOrderChecklistWildFireService,

    ReportingService,

    UserActivityLogService,
    InspectionOrderLogservice,

    // guards
    AuthGuard,
    RoleGuard,
    InspectionChecklistIdIsValidGuard,
    ForgotPasswordGuard,
    UserManagementGuard,
    UserExistValidatorGuard,
    IOUnsavedChangesGuard,
    AutoLogoutGuard,
    InsuredAuthGuard,
    InsuredReportGuard,
    StaticContentExistGuard,
    CheckIfIOIsLockedGuard
  ],
  declarations: []
})
export class CoreModule { }
