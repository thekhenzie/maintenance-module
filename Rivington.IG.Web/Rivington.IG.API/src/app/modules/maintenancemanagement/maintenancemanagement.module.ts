import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaintenancemanagementRoutingModule } from './maintenancemanagement.routes';
import { MaintenancemanagementComponent } from './pages/index/maintenancemanagement.component';

import * as primeModules from 'primeng/primeng';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ConfirmationService } from 'primeng/api';
import { PaginatorModule } from 'primeng/components/paginator/paginator';
import { SpinnerModule } from 'primeng/components/spinner/spinner';
import { TableModule } from 'primeng/components/table/table';
import { CheckboxModule } from 'primeng/checkbox';
import { MaintenanceDialogComponent } from './components/maintenance-dialog/maintenance-dialog.component';
@NgModule({
  imports: [
    CommonModule,
    MaintenancemanagementRoutingModule,

    FormsModule,
    ReactiveFormsModule,
    //primeng modules
    PaginatorModule,
    SpinnerModule,
    TableModule,
    CheckboxModule,
    primeModules.PanelModule,
    primeModules.TabViewModule,
    primeModules.CalendarModule,
    primeModules.PaginatorModule,
    primeModules.ScheduleModule,
    primeModules.AccordionModule,
    primeModules.RadioButtonModule,
    primeModules.ButtonModule,
    primeModules.SelectButtonModule,
    primeModules.MenuModule,
    primeModules.SharedModule,
    primeModules.DialogModule,
    primeModules.DropdownModule,
    primeModules.CheckboxModule,
    ConfirmDialogModule
  ],
  declarations: [MaintenancemanagementComponent, MaintenanceDialogComponent]
})
export class MaintenancemanagementModule { }
