import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SweetAlert2Module } from '@toverux/ngx-sweetalert2';
import { PrimeArtTable } from './components/pArtTable/p.art.table';
import { ClickPreventDefault } from './directives/clickpreventdefault';
import { TableModule } from 'primeng/components/table/table';
import { SafeHtml } from './pipes/SafeHtml';
import { InspectorComponent } from './components/inspector/inspector.component';

@NgModule({
  imports: [
    CommonModule,
    NgbModule,
    SweetAlert2Module.forRoot({
      buttonsStyling: false,
      customClass: 'art-swal modal-content',
      confirmButtonClass: 'btn btn-primary',
      cancelButtonClass: 'btn'
    }),
    FormsModule,
    TableModule
  ],
  declarations: [
    PrimeArtTable,
    ClickPreventDefault,
    SafeHtml,
    InspectorComponent
  ],
  exports: [
    CommonModule,
    ReactiveFormsModule,
    SweetAlert2Module,
    SafeHtml,
    InspectorComponent
  ]
})
export class SharedModule { }
