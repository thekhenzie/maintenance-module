import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { HttpClient } from '@angular/common/http';
import { Constants } from '../../../shared/constants';
import { City } from '../../../shared/models/ordermanagement/city';

@Injectable()
export class CityService {

    constructor(private http: HttpClient) { }

    getCityList(stateId) {
        return this.http.get(`${Constants.ApiUrl}/GetCities/${stateId}`)
            .toPromise()
            .then(data => { return data as City[] });
    }

}