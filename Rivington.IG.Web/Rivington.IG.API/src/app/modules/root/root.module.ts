import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SharedModule } from '../shared/shared.module';
import { ForbiddenComponent } from './pages/forbidden/forbidden.component';
import { RootRoutingModule } from './root.routes';
import { StaticPagesComponent } from './pages/static-pages/static-pages.component';

@NgModule({
  imports: [
    SharedModule,
    RootRoutingModule,
    CommonModule,
    ReactiveFormsModule,
    NgbModule
  ],
  declarations: [
    ForbiddenComponent,
    StaticPagesComponent
  ]
})
export class RootModule { }
