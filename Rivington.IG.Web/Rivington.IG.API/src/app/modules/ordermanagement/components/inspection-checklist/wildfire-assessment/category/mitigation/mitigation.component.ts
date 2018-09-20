import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { AuthService } from '../../../../../../core/services/auth.service';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ConfirmationService } from 'primeng/primeng';
import { InspectionOrderService } from '../../../../../../core/services/ordermanagement/inspection-order.service';
import { InspectionOrder } from '../../../../../../shared/models/ordermanagement/inspection-order';
import { MitigationStatusConstants } from '../../../../../../shared/mitigation-status-constants';
import Utils from '../../../../../../shared/Utils';

@Component({
  selector: 'app-mitigation',
  templateUrl: './mitigation.component.html',
  styleUrls: ['./mitigation.component.css']
})
export class MitigationComponent implements OnInit {

  constructor(
  ) {
  }

  ngOnInit() {
  }

}
