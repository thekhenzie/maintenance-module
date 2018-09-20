import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainComponent } from './main.component';
import { OrdermanagementComponent } from './ordermanagement/pages/index/ordermanagement.component';
import { PathConstants } from './shared/pathconstants';
import { AuthGuard } from './core/guards/auth.guard';
import { RoleGuard } from './core/guards/role.guard';
import { RoleConstants } from './shared/roleconstants';
import { InspectioninfoComponent } from './ordermanagement/pages/inspectioninfo/inspectioninfo.component';
import { InspectionChecklistIdIsValidGuard } from './core/guards/inspection-checklist-id-is-valid.guard';
import { CreateinspectionorderComponent } from './ordermanagement/pages/createinspectionorder/createinspectionorder.component';
import { InspectionChecklistComponent } from './ordermanagement/pages/inspection-checklist/inspection-checklist.component';
import { InspectionNotesComponent } from './ordermanagement/pages/inspection-notes/inspection-notes.component';
import { DashboardComponent } from './dashboard/pages/index/dashboard.component';
import { ContactsComponent } from './dashboard/pages/contacts/contacts.component';
import { AccountComponent } from './account/pages/index/account.component';
import { RegisterComponent } from './account/pages/register/register.component';
import { LoginComponent } from './account/pages/login/login.component';
import { ForgotpasswordComponent } from './account/pages/forgotpassword/forgotpassword.component';
import { ResetpasswordComponent } from './account/pages/resetpassword/resetpassword.component';
import { ForgotPasswordGuard } from './core/guards/forgotpasswordguard';
import { ReportComponent } from './report/pages/index/report.component';
import { CredentialComponent } from './usermanagement/pages/credential/credential.component';
import { UserManagementGuard } from './core/guards/usermanagementguard';
import { ProfileinfoComponent } from './usermanagement/pages/profile-info/profileinfo.component';
import { UserExistValidatorGuard } from './core/guards/user-management-user-validator.guard';
import { UserManagementComponent } from './usermanagement/pages/index/user-management.component';
import { IOUnsavedChangesGuard } from './core/guards/io-unsaved-changes.guard';
import { InsuredMitigationComponent } from './ordermanagement/pages/insured-mitigation/insured-mitigation.component';
import { AutoLogoutGuard } from './core/guards/auto-logout.guard';
import { InsuredAuthGuard } from './core/guards/insured-auth.guard';
import { InspectionOrderTimelineComponent } from './ordermanagement/pages/inspection-order-timeline/inspection-order-timeline.component';
import { InsuredReportGuard } from './core/guards/insured-report.guard';
import { ForbiddenComponent } from './root/pages/forbidden/forbidden.component';
import { StaticPagesComponent } from './root/pages/static-pages/static-pages.component';
import { StaticContentExistGuard } from './core/guards/static-content-exists.guard';
import { CheckIfIOIsLockedGuard } from './core/guards/check-if-io-islocked.guard';
import { PolicyXmlComponent } from './ordermanagement/pages/policy-xml/policy-xml.component';
import { MaintenancemanagementComponent } from './maintenancemanagement/pages/index/maintenancemanagement.component';

const orderManagementRoutes: Routes = [
  {
    path: '',
    component: OrdermanagementComponent,
    canActivate: [AuthGuard, RoleGuard],
    data: {
      roles: RoleConstants.AnyoneExceptInsured,
      title: 'Inspection Orders',
      urls: [{ title: 'Home', url: `/${PathConstants.Dashboard.Index}` }, { title: 'Inspection Orders' }]
    }
  },
  {
    path: 'inspection-status/:status/:days',
    component: OrdermanagementComponent,
    canActivate: [AuthGuard, RoleGuard],
    data: {
      roles: RoleConstants.AnyoneExceptInsured,
      title: 'Inspection Orders',
      urls: [{ title: 'Home', url: `/${PathConstants.Dashboard.Index}` }, { title: 'Inspection Orders' }]
    }
  },
  {
    path: 'inspection-status/:status/:days/:inspector',
    component: OrdermanagementComponent,
    canActivate: [AuthGuard, RoleGuard],
    data: {
      roles: RoleConstants.AnyoneExceptInsured,
      title: 'Inspection Orders',
      urls: [{ title: 'Home', url: `/${PathConstants.Dashboard.Index}` }, { title: 'Inspection Orders' }]
    }
  },
  {
    path: 'inspection-status/:status/:inspector',
    component: OrdermanagementComponent,
    canActivate: [AuthGuard, RoleGuard],
    data: {
      roles: RoleConstants.AnyoneExceptInsured,
      title: 'Inspection Orders',
      urls: [{ title: 'Home', url: `/${PathConstants.Dashboard.Index}` }, { title: 'Inspection Orders' }]
    }
  },
  {
    path: 'mitigation-status/:mitigation',
    component: OrdermanagementComponent,
    canActivate: [AuthGuard, RoleGuard],
    data: {
      roles: RoleConstants.AnyoneExceptInsured,
      title: 'Inspection Orders',
      urls: [{ title: 'Home', url: `/${PathConstants.Dashboard.Index}` }, { title: 'Inspection Orders' }]
    }
  },
  {
    path: 'mitigation-status/:mitigation/:inspector',
    component: OrdermanagementComponent,
    canActivate: [AuthGuard, RoleGuard],
    data: {
      roles: RoleConstants.AnyoneExceptInsured,
      title: 'Inspection Orders',
      urls: [{ title: 'Home', url: `/${PathConstants.Dashboard.Index}` }, { title: 'Inspection Orders' }]
    }
  },
  {
    path: 'inspection-order/create/info',
    component: InspectioninfoComponent,
    canActivate: [AuthGuard, RoleGuard],
    canDeactivate: [IOUnsavedChangesGuard],
    data: {
      roles: RoleConstants.AnyoneExceptInsured,
      title: 'Inspection Info',
      urls: [{ title: 'Home', url: `/${PathConstants.Dashboard.Index}` }, { title: 'Order Management', url: `/${PathConstants.OrderManagement.Index}` },
      { title: 'Inspection Info' }]
    }
  },
  {
    path: 'inspection-order/:id/info',
    component: InspectioninfoComponent,
    canActivate: [AuthGuard, RoleGuard, InspectionChecklistIdIsValidGuard, CheckIfIOIsLockedGuard],
    data: {
      roles: RoleConstants.AnyoneExceptInsured,
      title: 'Inspection Info',
      urls: [{ title: 'Home', url: `/${PathConstants.Dashboard.Index}` }, { title: 'Order Management', url: `/${PathConstants.OrderManagement.Index}` },
      { title: 'Inspection Info' }]
    }
  },
  {
    path: 'inspection-order/create/get-policy',
    component: CreateinspectionorderComponent,
    canActivate: [AuthGuard, RoleGuard],
    data: {
      roles: RoleConstants.AnyoneExceptInsured,
      title: 'Inspection Info',
      urls: [{ title: 'Home', url: `/${PathConstants.Dashboard.Index}` }, { title: 'Order Management', url: `/${PathConstants.OrderManagement.Index}` },
      { title: 'Inspection Info' }]
    }
  },
  {
    path: 'inspection-order/create/policyXML',
    component: PolicyXmlComponent,
    canActivate: [AuthGuard, RoleGuard],
    data: {
      roles: RoleConstants.AnyoneExceptInsured,
      title: 'Inspection Info',
      urls: [{ title: 'Home', url: `/${PathConstants.Dashboard.Index}` }, { title: 'Order Management', url: `/${PathConstants.OrderManagement.Index}` },
      { title: 'Create Inspection Order From Policy XML' }]
    }
  },
  {
    path: 'inspection-order/:id/checklist/:section/:category',
    component: InspectionChecklistComponent,
    canActivate: [AuthGuard, RoleGuard, InspectionChecklistIdIsValidGuard, CheckIfIOIsLockedGuard],
    data: {
      roles: RoleConstants.AnyoneExceptInsured,
      title: 'Inspection Checklist',
      urls: [
        { title: 'Home', url: `/${PathConstants.Dashboard.Index}` },
        { title: 'Order Management', url: `/${PathConstants.OrderManagement.Index}` },
        { title: 'Inspection Checklist' }
      ]
    }
  },
  {
    path: 'inspection-order/:id/notes',
    component: InspectionNotesComponent,
    canActivate: [AuthGuard, RoleGuard, InspectionChecklistIdIsValidGuard, CheckIfIOIsLockedGuard],
    data: {
      roles: RoleConstants.AnyoneExceptInsured,
      title: 'Inspection Notes',
      urls: [{ title: 'Home', url: `/${PathConstants.Dashboard.Index}` }, { title: 'Order Management', url: `/${PathConstants.OrderManagement.Index}` },
      { title: 'Inspection Notes' }]
    }
  },
  {
    path: 'inspection-order/:id/inspection-order-timeline',
    component: InspectionOrderTimelineComponent,
    canActivate: [AuthGuard, RoleGuard, InspectionChecklistIdIsValidGuard, CheckIfIOIsLockedGuard],
    data: {
      roles: RoleConstants.AnyoneExceptInsured,
      title: 'Inspection Order Timeline',
      urls: [{ title: 'Home', url: `/${PathConstants.Dashboard.Index}` }, { title: 'Order Management', url: `/${PathConstants.OrderManagement.Index}` },
      { title: 'Inspection Order Timeline' }]
    }
  },
  { path: 'inspection-order/:id/checklist', redirectTo: 'inspection-order/:id/checklist/property/general' },
  { path: 'inspection-order/:id', redirectTo: 'inspection-order/:id/info' },
  {
    path: 'inspection-order/mitigation/insured/:id',
    canActivate: [InsuredAuthGuard, RoleGuard, InspectionChecklistIdIsValidGuard, CheckIfIOIsLockedGuard],
    canDeactivate: [AutoLogoutGuard],
    component: InsuredMitigationComponent,
    data: {
      roles: [RoleConstants.Insured],
      title: 'Pending Mitigations',
      urls: [{ title: 'Mitigations' }]
    }
  },
  {
    path: 'inspection-order/report/insured/:id',
    canActivate: [InsuredReportGuard, RoleGuard, InspectionChecklistIdIsValidGuard, CheckIfIOIsLockedGuard],
    component: InsuredMitigationComponent,
    data: {
      roles: [RoleConstants.Insured],
      title: 'Download Report',
      urls: [{ title: 'Inspection Order Report' }]
    }
  },
];


const dashboardRoutes: Routes = [
  {
    path: '',
    component: DashboardComponent,
    canActivate: [AuthGuard, RoleGuard],
    data: {
      roles: RoleConstants.AnyoneExceptInsured,
      title: 'Dashboard',
      urls: [{ title: 'Home', url: `/${PathConstants.Dashboard.Index}` }, { title: 'Dashboard' }]
    }
  }
];


const accountRoutes: Routes = [
  { path: '', component: AccountComponent },
  { path: 'register', component: RegisterComponent },
  {
    path: 'login',
    component: LoginComponent,
    data: {
      title: 'Login',
      urls: [{ title: 'Account' }, { title: 'Login' }]
    }
  },
  { path: 'forgotpassword', component: ForgotpasswordComponent },
  {
    path: 'resetpassword/:id',
    component: ResetpasswordComponent,
    canActivate: [ForgotPasswordGuard]
  },
  {
    path: 'login/insured',
    component: LoginComponent,
    data: {
      title: 'Insured Login',
      urls: [{ title: 'Account' }, { title: 'Login' }]
    }
  },
  {
    path: 'login/insured/report',
    component: LoginComponent,
    data: {
      title: 'Insured Login',
      urls: [{ title: 'Account' }, { title: 'Login' }]
    }
  }
];

const reportRoutes: Routes = [
  {
    path: '',
    component: ReportComponent
  }
];

const maintenanceManagementRoutes = [
  {
    path: '',
    component: MaintenancemanagementComponent,
    canActivate: [AuthGuard, RoleGuard],
    data: {
      roles: RoleConstants.AnyoneExceptInsured,
      title: 'Maintenance Management',
      urls: [{ title: 'Home', url: `/${PathConstants.Dashboard.Index}` }, { title: 'Maintenance Management' }]
    }
  }
]

const userManagementRoutes = [
  {
    path: '',
    component: UserManagementComponent,
    canActivate: [AuthGuard, RoleGuard],
    data: {
      roles: RoleConstants.AnyoneExceptInsured,
      title: 'User Management',
      urls: [{ title: 'Home', url: `/${PathConstants.Dashboard.Index}` }, { title: 'User Management' }]
    }
  },
  {
    path: 'credential/:id',
    component: CredentialComponent,
    canActivate: [UserManagementGuard]
  },
  {
    path: 'profile-info',
    component: ProfileinfoComponent,
    canActivate: [AuthGuard, RoleGuard],
    data: {
      roles: RoleConstants.AnyoneExceptInsured,
      title: 'Profile Info',
      urls: [{ title: 'Home', url: `/${PathConstants.Dashboard.Index}` },
      { title: 'Profile Info' }]
    }
  },
  {
    path: 'profile-info/:id',
    component: ProfileinfoComponent,
    canActivate: [AuthGuard, UserExistValidatorGuard],
    data: {
      roles: RoleConstants.AnyoneExceptInsured,
      title: 'Profile Info',
      urls: [{ title: 'Home', url: `/${PathConstants.Dashboard.Index}` },
      { title: 'User Management', url: `/${PathConstants.UserManagement.Index}` },
      { title: 'Profile Info' }]
    }
  },
  {
    path: 'credential',
    component: CredentialComponent,
    canActivate: [AuthGuard, RoleGuard],
    data: {
      roles: RoleConstants.AnyoneExceptInsured,
      title: 'Credential',
      urls: [{ title: 'Home', url: `/${PathConstants.Dashboard.Index}` },
      { title: 'User Management', url: `/${PathConstants.UserManagement.Index}` },
      { title: 'Credential' }]
    }
  }
];

const rootRoutes: Routes = [
  { path: PathConstants.Root.Forbidden, component: ForbiddenComponent },
  {
    path: ':staticcontentname',
    canActivate: [StaticContentExistGuard],
    component: StaticPagesComponent
  }
];

const routes: Routes = [
  {
    path: '',
    component: MainComponent,
    // redirectTo: PathConstants.OrderManagement.Index,
    children: [
      {
        path: '',
        children: [
          {
            path: PathConstants.OrderManagement.Index,
            children: orderManagementRoutes
          },
          {
            path: PathConstants.Dashboard.Index,
            children: dashboardRoutes
          },
          {
            path: PathConstants.UserManagement.Index,
            children: userManagementRoutes
          },
          {
            path: PathConstants.MaintenanceManagement.Index,
            children: maintenanceManagementRoutes
          },
          {
            path: 'account',
            children: accountRoutes
          },
          {
            path: 'report',
            children: reportRoutes
          },
          {
            path: 'static',
            children: rootRoutes
          },
        ]
      },
    ]
  }
];


@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})

export class MainRoutingModule { }