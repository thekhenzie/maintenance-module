import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MaintenancemanagementRoutingModule } from './maintenancemanagement.routes';
import { MaintenancemanagementComponent } from './pages/index/maintenancemanagement.component';

@NgModule({
  imports: [
    CommonModule,
    MaintenancemanagementRoutingModule
  ],
  declarations: [MaintenancemanagementComponent]
})
export class MaintenancemanagementModule { }
