import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ReportingComponent } from './pages/index/reporting.component';
import { InspectionOrderReportComponent } from './pages/inspection-order/inspection-order.component';
import { AuthGuard } from '../modules/core/guards/auth.guard';
import { InsuredAuthGuard } from '../modules/core/guards/insured-auth.guard';
import { AutoLogoutGuard } from '../modules/core/guards/auto-logout.guard';
import { RoleGuard } from '../modules/core/guards/role.guard';
import { RoleConstants } from '../modules/shared/roleconstants';
import { InsuredReportGuard } from '../modules/core/guards/insured-report.guard';

const childrenRoutes: Routes = [
  {
    path: 'order-management/inspection-order/:id', 
    component: InspectionOrderReportComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'order-management/inspection-order/insured/:id', 
    component: InspectionOrderReportComponent,
    canActivate: [InsuredReportGuard]
  },
];

const routes: Routes = [
  {
    path: 'reporting',
    component: ReportingComponent,
    children: [
      {
        path: '',
        children: childrenRoutes
      }
    ]
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [ RouterModule ]
})

export class ReportingRoutingModule {}