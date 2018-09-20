import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { HttpClient } from '@angular/common/http';
import { Constants } from '../../../shared/constants';
import { InspectionStatus } from '../../../shared/models/ordermanagement/inspectionstatus';

@Injectable()
export class InspectionStatusService {

    constructor(private http: HttpClient) { }

    getInspectionStatusList(serviceName) {
        return this.http.get(`${Constants.ApiUrl}/${serviceName}`)
            .toPromise()
            .then(data => { return data as InspectionStatus[] });
    }

}
