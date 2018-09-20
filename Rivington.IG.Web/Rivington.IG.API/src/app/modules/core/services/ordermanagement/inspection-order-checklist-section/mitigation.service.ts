import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { HttpClient } from '@angular/common/http';
import { Constants } from '../../../../shared/constants';
import { CommonService } from '../../common.service';
import { Observable } from 'rxjs';
import { Image } from '../../../../shared/models/ordermanagement/image';

@Injectable()
export class MitigationService {

    constructor(private http: HttpClient,
        private commonService: CommonService) { }

    postGenericPhotoMemo(url, data): Observable<any> {
        return this.http.post<Image>(`${Constants.ApiUrl}/${url}`, data)
            .catch(this.commonService.handleObservableHttpError);
    }

    deleteChildGenericPhotoMemo(url, id, imageId): Observable<any> {
        return this.http.delete(`${Constants.ApiUrl}/${url}/${id}/${imageId}`)
            .catch(this.commonService.handleObservableHttpError);
    }
    deleteGenericPhotoMemo(url, id): Observable<any> {
        return this.http.delete(`${Constants.ApiUrl}/${url}/${id}`)
            .catch(this.commonService.handleObservableHttpError);
    }
    getNonWildfireAssessmentMitigationRequirement(mitigationRequirementId) : Observable<any>{
        return this.http.get(`${Constants.ApiUrl}/RetrieveNonWildfireAssessmentMitigationRequirement/${mitigationRequirementId}`)
            .catch(this.commonService.handleObservableHttpError);
    }
    getNonWildfireAssessmentMitigationRecommendation(mitigationRecommendationId) : Observable<any>{
        return this.http.get(`${Constants.ApiUrl}/RetrieveNonWildfireAssessmentMitigationRecommendation/${mitigationRecommendationId}`)
            .catch(this.commonService.handleObservableHttpError);
    }
    getWildfireAssessmentMitigationRequirement(mitigationRequirementId) : Observable<any>{
        return this.http.get(`${Constants.ApiUrl}/RetrieveWildfireAssessmentMitigationRequirement/${mitigationRequirementId}`)
            .catch(this.commonService.handleObservableHttpError);
    }
    getWildfireAssessmentMitigationRecommendation(mitigationRecommendationId) : Observable<any>{
        return this.http.get(`${Constants.ApiUrl}/RetrieveWildfireAssessmentMitigationRecommendation/${mitigationRecommendationId}`)
            .catch(this.commonService.handleObservableHttpError);
    }
    getMitigationRequirementsCount(inspectionOrderId) : Observable<any>{
        return this.http.get(`${Constants.ApiUrl}/RetrieveMitigationRequirementsCount/${inspectionOrderId}`)
            .catch(this.commonService.handleObservableHttpError);
    }
    getMitigationCount(inspectionOrderId) : Observable<any>{
        return this.http.get(`${Constants.ApiUrl}/RetrieveMitigationCount/${inspectionOrderId}`)
            .catch(this.commonService.handleObservableHttpError);
    }
}
