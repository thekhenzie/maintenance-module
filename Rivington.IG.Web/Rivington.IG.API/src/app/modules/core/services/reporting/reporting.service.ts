import { Injectable, OnInit, EventEmitter } from '@angular/core';
import { Http, Response } from '@angular/http';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { InspectionOrder } from '../../../shared/models/ordermanagement/inspection-order';
import { Constants } from '../../../shared/constants';
import { Observable } from 'rxjs/Observable';
import { T } from '@angular/core/src/render3';
import { CommonService } from '../common.service';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { UtilityService } from '../utility.service';
import { Inspector } from '../../../shared/models/ordermanagement/inspector';
import { InspectionOrderPropertyGeneral } from '../../../shared/models/ordermanagement/inspection-order/checklist/property/general';
import { City } from '../../../shared/models/ordermanagement/city';
import { State } from '../../../shared/models/ordermanagement/state';
import { ActivatedRoute } from '@angular/router';
import { ReportTitleViewModel } from '../../../shared/models/view-model/report-title-page-view-model';
import { InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements } from '../../../shared/models/ordermanagement/inspection-order/checklist/mitigation/InspectionOrderNonWildfireAssessmentMitigationRequirements';
import { InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations } from '../../../shared/models/ordermanagement/inspection-order/checklist/mitigation/InspectionOrderNonWildfireAssessmentMitigationRecommendations';
import { WildfireViewModel } from '../../../shared/models/view-model/wildfire-view-model';

@Injectable()
export class ReportingService {
    reportTitleViewModel: ReportTitleViewModel;
    riskSummary: string;
    policyPremiumCredits: any[];
    mitigationRequirements: InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements[];
    mitigationRecommendations:InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations[];
    wildfireViewModel: WildfireViewModel;
  
    private routeParamSubscribeEmitter: EventEmitter<any> = new EventEmitter();
    getRouteParamSubscribeEmitter(): EventEmitter<any> {
        return this.routeParamSubscribeEmitter;
    }
    broadcastParamChange(value) {
        this.routeParamSubscribeEmitter.emit(value);
    }

    private ioDataSubscribeEmitter: EventEmitter<any> = new EventEmitter();
    getIoDataSubscribeEmitter(): EventEmitter<any> {
        return this.ioDataSubscribeEmitter;
    }
    broadcastIoDataChange(value) {
        this.ioDataSubscribeEmitter.emit(value);
    }

    constructor(private utilityService: UtilityService,
        private route: ActivatedRoute,
        private http: HttpClient,
        private commonService: CommonService
    ) {
    }

    isDownload() {
        return this.route.snapshot.queryParamMap.get("download") === "true";
    }

    showTopLoader(doShow: boolean = true) {
      $(".pace.pace-active").css("display", doShow ? "" : "none");        
    }

    generatePdfReport(id): Observable<Blob> {
        return this.http.get(`${Constants.ApiUrl}/inspectionorder/generateiopdfreport?id=${id}`, {responseType: "blob"})
        // return this.http.get(`http://localhost:49642/api/Values?id=${id}`, {responseType: "blob"})
            .map((value: Blob, index: number) => { 
                return value;
             })
            .catch(this.commonService.handleObservableHttpError);
    }

    getIoReportData(id: string): Observable<any> {
        let url: string;
        // if(this.isDownload()) {
        //     url = `${Constants.ApiUrl.replace("/api", "")}/cdn/reports/io/${id}.json`;
        // } else {
            url = `${Constants.ApiUrl}/GetIoReportData/${id}`;
        // }
        return this.http.get<any>(url)
        .map((data) => { 
            this.reportTitleViewModel = data.titlePage;
            this.riskSummary = data.riskSummary;
            this.policyPremiumCredits = data.premiumPolicyCredits;
            this.mitigationRequirements = data.wildfireMitigationRequirements;
            this.mitigationRecommendations = data.wildfireMitigationRecommendation;
            this.wildfireViewModel = data.wildfireViewModel;
            
            this.broadcastIoDataChange(data);
            console.log(data);
            return data;
         })
        .catch(this.commonService.handleObservableHttpError);
    }

    getTitlePageProperties(id: string): Observable<any> {
        return this.http.get<any>(`${Constants.ApiUrl}/RetrieveTitlePageProperties/${id}`)
        .catch(this.commonService.handleObservableHttpError);
    }

    getPolicyPremiumCredits(id: string) : Observable<any>{
        return this.http.get(`${Constants.ApiUrl}/RetrievePolicyPremiumCredits/${id}`)
            .map(data => { return data })
            .catch(this.commonService.handleObservableHttpError);
    }

    getWildFireValue(id: string): Observable<any> {
        return this.http.get<any>(`${Constants.ApiUrl}/GetIOwildFireWithFieldNames/${id}`)
        .catch(this.commonService.handleObservableHttpError);
    }
}