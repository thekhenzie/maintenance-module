import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import { Constants } from "../../../shared/constants";
import { HttpClient, HttpParams } from "@angular/common/http";
import { CommonService } from "../common.service";
import { InspectionStatusGroupingsView } from "../../../shared/models/dashboard/inspection-status-groupings-view";
import { MitigationStatusCountView } from "../../../shared/models/dashboard/mitigation-status-count-view";
import { Inspector } from "../../../shared/models/ordermanagement/inspector";

@Injectable()
export class DashboardService {

    groupedInspectionStatus: InspectionStatusGroupingsView[];
    groupedMitigationStatus: MitigationStatusCountView[];
    linksSent: number;

    inspector: Inspector;
    currentUser: string;
    inspectorName: string;

    constructor(private http: HttpClient,
        private commonService: CommonService) {
    }

    getMitigationStatusCount(inspector): Observable<any> {
        let params = new HttpParams();
        params = params.append('inspectorUserName', inspector);
        return this.http.get(`${Constants.ApiUrl}/Dashboard/GetMitigationStatusCount`, { params: params })
            .map(data => { return data })
            .catch(this.commonService.handleObservableHttpError);
    }

    getInspectionStatusGroupings(inspector): Observable<any> {
        let params = new HttpParams();
        params = params.append('inspectorUserName', inspector);
        return this.http.get(`${Constants.ApiUrl}/Dashboard`, { params: params })
            .map(data => { return data })
            .catch(this.commonService.handleObservableHttpError);
    }

    getSentToInsuredStatusCount(inspector): Observable<any> {
        let params = new HttpParams();
        params = params.append('inspectorUserName', inspector);
        return this.http.get(`${Constants.ApiUrl}/Dashboard/GetSentToInsuredStatusCount`, { params: params })
            .map(data => { return data })
            .catch(this.commonService.handleObservableHttpError);
    }
}