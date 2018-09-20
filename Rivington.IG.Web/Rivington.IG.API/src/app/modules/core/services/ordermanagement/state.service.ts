import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { HttpClient } from '@angular/common/http';
import { Constants } from '../../../shared/constants';
import { State } from '../../../shared/models/ordermanagement/state';

@Injectable()
export class StateService {

    constructor(private http: HttpClient) { }

    getStateList() {
        return this.http.get(`${Constants.ApiUrl}/GetStates`)
            .toPromise()
            .then(data => { return data as State[] });
    }

}
