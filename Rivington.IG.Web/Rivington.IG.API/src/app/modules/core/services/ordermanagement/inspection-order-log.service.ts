import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Constants } from "../../../shared/constants";
import { Observable } from "rxjs/Observable";
import { CommonService } from "../common.service";

@Injectable()
export class InspectionOrderLogservice {

    constructor(private http: HttpClient,
        private commonService: CommonService) { }

    getInspectionOrderLogs(id: string) : Observable<any>{
        return this.http.get(`${Constants.ApiUrl}/GetInspectionLogList/${id}`)
        .catch(this.commonService.handleObservableHttpError);
    }

}