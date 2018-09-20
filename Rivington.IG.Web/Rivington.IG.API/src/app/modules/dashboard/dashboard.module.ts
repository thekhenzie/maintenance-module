import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { DashboardRoutingModule } from './dashboard.routes';
import { ContactsComponent } from './pages/contacts/contacts.component';
import { SharedModule } from '../shared/shared.module';
import { DashboardComponent } from './pages/index/dashboard.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import * as primeModules from 'primeng/primeng';
import { GrowlModule } from "primeng/components/growl/growl";
import { TableModule } from 'primeng/table';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { InspectiontableComponent } from './components/inspectiontable/inspectiontable.component';
import { MitigationstatusComponent } from './components/mitigationstatus/mitigationstatus.component';
import { OrderManagementModule } from '../ordermanagement/ordermangement.module';

@NgModule({
  imports: [
    SharedModule,
    DashboardRoutingModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    OrderManagementModule,
    
    // primeng modules
    primeModules.PanelModule,
    primeModules.TabViewModule,
    primeModules.CalendarModule,
    primeModules.PaginatorModule,
    primeModules.ScheduleModule,

    GrowlModule, 

    primeModules.RadioButtonModule, 
    primeModules.ButtonModule,
    primeModules.SelectButtonModule,
    primeModules.MenuModule,

    TableModule,
    primeModules.SharedModule,
    primeModules.DialogModule,
    primeModules.ConfirmDialogModule,

    primeModules.DropdownModule,
    primeModules.ChartModule,
    primeModules.InputTextModule,
    primeModules.InputMaskModule
  ],
  declarations: [
    DashboardComponent,    
    ContactsComponent, 
    InspectiontableComponent, 
    MitigationstatusComponent
  ],
  bootstrap: [DashboardComponent]
})
export class DashboardModule { }