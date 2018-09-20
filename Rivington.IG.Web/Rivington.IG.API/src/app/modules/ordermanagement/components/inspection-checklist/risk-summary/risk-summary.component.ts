import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../../../../shared/BaseComponent';
import { InspectionOrderService } from '../../../../core/services/ordermanagement/inspection-order.service';
import { ActivatedRoute } from '@angular/router';
import { ConfirmationService } from 'primeng/primeng';
import { AuthService } from '../../../../core/services/auth.service';

@Component({
  selector: 'app-risk-summary',
  templateUrl: './risk-summary.component.html',
  styleUrls: ['./risk-summary.component.css'],
  providers: [ConfirmationService]
})
export class InspectionChecklistRiskSummaryComponent extends BaseComponent implements OnInit {
  currentIoId: string;
  confirmationMessage: string;
  constructor(
    public ioService: InspectionOrderService,
    private route: ActivatedRoute,
    private confirmationService: ConfirmationService,
    public auth: AuthService
  ) {
    super();
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      if(this.isIoIdParamChanged(params)) {
        this.ioService.getRiskSummary(params['id']).subscribe(data => {
          let riskSummary = data;
          if(riskSummary) this.ioService.riskSummaryForm.get('riskSummary').setValue(riskSummary)
        })
      }
    });
  }

  isIoIdParamChanged(params: any): boolean {
    let currentParam = params["id"];
    if(this.currentIoId != currentParam) {
      this.currentIoId = currentParam;
      return true;
    }
    return false;
  }

  generateRiskSummary(){
    this.ioService.generateRiskSummary(this.currentIoId).subscribe(data => {
      let riskSummary = data;
      if(riskSummary) this.ioService.riskSummaryForm.get('riskSummary').setValue(riskSummary)
    })
  }

  confirmGenerateFromData() {
    
    if (this.ioService.riskSummaryForm.value.riskSummary == null) {
        this.confirmationMessage = "This will now generate Risk Management Summary based on the inputted values from the checklist. Do you want to proceed?"
    } else {
      this.confirmationMessage = "Are you sure you want to generate from data? This will delete your current progress"
    }

    this.confirmationService.confirm({
     
      message: this.confirmationMessage,
      header: 'Generate from Data',
      icon: 'fa fa-question-circle',
      accept: () => {
        if (this.ioService.riskSummaryForm.dirty) {
          this.ioService.riskSummaryForm.reset();
          this.ioService.riskSummaryForm.markAsPristine();
        }
        this.generateRiskSummary();
      }
    });
  }
}
