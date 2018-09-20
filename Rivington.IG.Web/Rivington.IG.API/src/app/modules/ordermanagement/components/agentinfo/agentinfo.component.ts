import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { PolicyService } from '../../../core/services/ordermanagement/policy.service';
import { AuthService } from '../../../core/services/auth.service';
import { Policy } from '../../../shared/models/ordermanagement/policy';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { InspectionOrderService } from '../../../core/services/ordermanagement/inspection-order.service';
import { InspectionOrder } from '../../../shared/models/ordermanagement/inspection-order';

@Component({
  selector: 'app-agentinfo',
  templateUrl: './agentinfo.component.html',
  styleUrls: ['./agentinfo.component.css']
})
export class AgentinfoComponent implements OnInit {

  @Output() agentInfoForm: EventEmitter<FormGroup>;
  isNew: boolean;

  constructor(
    public inspectionOrderService: InspectionOrderService,
    public auth: AuthService,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.agentInfoForm = new EventEmitter<FormGroup>();
  }

  ngOnInit() {

    this.route.params.subscribe(params => {
      let paramId = params["id"];
      if (!paramId) {
        this.isNew = true;
      }
    });

    if (this.inspectionOrderService.agentForm.untouched) {
      this.agentInfoForm.emit(this.inspectionOrderService.agentForm.value);
    }

    this.inspectionOrderService.agentForm.valueChanges.subscribe(data => {
      this.agentInfoForm.emit(this.inspectionOrderService.agentForm.value);
    })

  }
}
