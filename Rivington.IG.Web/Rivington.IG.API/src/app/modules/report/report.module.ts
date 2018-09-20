import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { ReportComponent } from './pages/index/report.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  imports: [
    SharedModule,
    CommonModule,
    ReactiveFormsModule,
    NgbModule
  ],
  declarations: [
    ReportComponent
  ],  
  bootstrap: [ReportComponent]
})
export class ReportModule { }
