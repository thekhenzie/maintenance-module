import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { HttpClient } from '@angular/common/http';
import { Constants } from '../../../shared/constants';
import { MitigationStatus } from '../../../shared/models/ordermanagement/mitigationstatus';

@Injectable()
export class MitigationStatusService {

    constructor(private http: HttpClient) { }

    getMitigationStatusList(serviceName) {
        return this.http.get(`${Constants.ApiUrl}/${serviceName}`)
            .toPromise()
            .then(data => { return data as MitigationStatus[] });
    }

}
