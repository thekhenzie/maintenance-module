import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ReportComponent } from './pages/index/report.component';

const routes: Routes = [
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ]
})

export class ReportRoutingModule {}