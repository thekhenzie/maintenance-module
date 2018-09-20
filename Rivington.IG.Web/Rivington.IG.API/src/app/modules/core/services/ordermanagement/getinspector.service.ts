import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Constants } from '../../../shared/constants';
import { Inspector } from '../../../shared/models/ordermanagement/inspector';

@Injectable()
export class GetInspectorService {

    constructor(private http: HttpClient) { }

    getInspectorList(serviceName, filter) {
        let params = new HttpParams();
        params = params.append('filter', filter);
        return this.http.get(`${Constants.ApiUrl}/${serviceName}`, {params:params})
            .toPromise()
            .then(data => { return data as Inspector[] });
    }

    getInspector(serviceName, id) {
        return this.http.get(`${Constants.ApiUrl}/${serviceName}/${id}`)
            .toPromise()
            .then(data => { return data as Inspector[] });
    }

}
