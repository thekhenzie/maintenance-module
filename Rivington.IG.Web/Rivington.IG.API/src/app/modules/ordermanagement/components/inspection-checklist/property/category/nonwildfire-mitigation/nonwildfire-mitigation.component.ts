import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../../../../../shared/BaseComponent';
import { InspectionOrderService } from '../../../../../../core/services/ordermanagement/inspection-order.service';
import { ActivatedRoute } from '@angular/router';
import { InspectionOrder } from '../../../../../../shared/models/ordermanagement/inspection-order';
import { MitigationStatusConstants } from '../../../../../../shared/mitigation-status-constants';
import Utils from '../../../../../../shared/Utils';

@Component({
  selector: 'app-nonwildfire-mitigation',
  templateUrl: './nonwildfire-mitigation.component.html',
  styleUrls: ['./nonwildfire-mitigation.component.css']
})
export class NonwildfireMitigationComponent extends BaseComponent implements OnInit {
  constructor(
  ) {
    super();
  }

  ngOnInit() {
  }

}
