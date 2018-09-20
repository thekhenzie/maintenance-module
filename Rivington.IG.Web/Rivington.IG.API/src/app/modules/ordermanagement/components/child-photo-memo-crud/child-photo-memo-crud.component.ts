import { Component, OnInit, Input, Output } from '@angular/core';
import { PhotoMemoCrudComponent } from '../photo-memo-crud/photo-memo-crud.component';
import { ConfirmationService } from 'primeng/primeng';

@Component({
  selector: 'app-child-photo-memo-crud',
  templateUrl: './child-photo-memo-crud.component.html',
  styleUrls: ['./child-photo-memo-crud.component.css'],
})
export class ChildPhotoMemoCrudComponent extends PhotoMemoCrudComponent {
}
