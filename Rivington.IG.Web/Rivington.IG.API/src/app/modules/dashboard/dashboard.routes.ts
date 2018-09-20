import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactsComponent } from './pages/contacts/contacts.component';
import { DashboardComponent } from './pages/index/dashboard.component';
import { AuthGuard } from '../core/guards/auth.guard';
import { RoleConstants } from '../shared/roleconstants';
import { RoleGuard } from '../core/guards/role.guard';
import { PathConstants } from '../shared/pathconstants';
import { OrdermanagementComponent } from '../ordermanagement/pages/index/ordermanagement.component';

const routes: Routes = [
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ]
})

export class DashboardRoutingModule {}