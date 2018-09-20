import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BaseComponent } from '../../../shared/BaseComponent';
import { Constants } from '../../../shared/constants';
import { InspectionOrder } from '../../../shared/models/ordermanagement/inspection-order';
import { CommonService } from '../common.service';

@Injectable()
export class InspectionOrderChecklistService extends BaseComponent implements OnInit  {
    inspectionOrder: InspectionOrder;
    currentIOid: string;

    constructor(private http: HttpClient, 
        private commonService: CommonService,
        private route: ActivatedRoute   
    ) {
        super();
        this.inspectionOrder = new InspectionOrder();
      }
     
  ngOnInit() {
    this.route.params.takeUntil(this.stop$).subscribe(params => {
      let ioId = params["id"];
      if(this.currentIOid !== ioId) {
        this.inspectionOrder = new InspectionOrder();        
        this.inspectionOrder.id = ioId;
      }
    });
  }
  
  putInspectionOrder(inspectionOrder) {
      return this.http.put(`${Constants.ApiUrl}/inspectionorderproperty`, inspectionOrder)
      .catch(this.commonService.handleObservableHttpError);
  }
}