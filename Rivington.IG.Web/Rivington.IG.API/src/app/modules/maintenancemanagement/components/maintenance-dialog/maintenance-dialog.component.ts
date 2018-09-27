import { Component, OnInit, Input } from '@angular/core';
import { ConfirmationService } from 'primeng/components/common/confirmationservice';
@Component({
  selector: 'app-maintenance-dialog',
  templateUrl: './maintenance-dialog.component.html',
  styleUrls: ['./maintenance-dialog.component.css'],
  providers: [ConfirmationService]
})
export class MaintenanceDialogComponent implements OnInit {

  @Input() display: boolean = false;
  constructor() { }

  ngOnInit() {
  }

}
