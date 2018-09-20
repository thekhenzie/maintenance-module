import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { HttpClient } from '@angular/common/http';
import { Policy } from '../../../shared/models/ordermanagement/policy';
import { Constants } from '../../../shared/constants';
import { City } from '../../../shared/models/ordermanagement/city';
import { State } from '../../../shared/models/ordermanagement/state';
import { Observable } from 'rxjs/Observable';
import { CommonService } from '../common.service';

@Injectable()
export class PolicyService {

  constructor(private http: HttpClient,
    private commonService: CommonService,) { }

  policyData: any;

  getPolicy(mockRequirement) {
    return this.http.post(`${Constants.ApiUrl}/TempPolicy`, mockRequirement)
      .toPromise()
      .then(data => {
        this.policyData = data;
        return data
      })
      .catch(data => {
        this.policyData = null;
      });
  }

  PostInpsectionOrderFromPolicyXML(xmlString): Observable<any> {
    let jsonXml = JSON.stringify(xmlString);
    return this.http.post(`${Constants.ApiUrl}/CreateInspecionOrder`, jsonXml)
      .catch(this.commonService.handleObservableHttpError);
  }
}
