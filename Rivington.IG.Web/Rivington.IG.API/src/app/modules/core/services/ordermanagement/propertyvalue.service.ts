import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { HttpClient } from '@angular/common/http';
import { Constants } from '../../../shared/constants';
import { PropertyValue } from '../../../shared/models/ordermanagement/propertyvalue';

@Injectable()
export class PropertyValueService {

    constructor(private http: HttpClient) { }

    getPropertyValueList(serviceName) {
        return this.http.get(`${Constants.ApiUrl}/${serviceName}`)
            .toPromise()
            .then(data => { return data as PropertyValue[] });
    }

}
