import { Injectable, EventEmitter } from  '@angular/core';
import { Http, Response, RequestOptions } from '@angular/http';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { UrlSegment } from '@angular/router';
import { AuthService } from './auth.service';
import { Constants } from '../../shared/constants';
import { IDataSourceRequest } from '../../shared/models/datatable/datasourcerequest';
import { IFilter, Filter } from '../../shared/models/datatable/filter';
import { CommonService } from './common.service';
import { AppSettings } from '../../shared/models/appSettings';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class UtilityService {
    appSettings: AppSettings;

    private appSettingsSubscribeEmitter: EventEmitter<AppSettings> = new EventEmitter();
    getAppSettingsSubscribeEmitter(): EventEmitter<AppSettings> {
        return this.appSettingsSubscribeEmitter;
    }
    broadcastAppSettingsChange(value: AppSettings) {
        this.appSettingsSubscribeEmitter.emit(value);
    }

    constructor(private http: HttpClient, private commonService: CommonService) {}
    
    getAppSettings(): Observable<AppSettings> {
        if(this.appSettings) {
            return Observable.of(this.appSettings);
        }

        return this.http.get<AppSettings>(`${Constants.ApiUrl}/GetAppSettings`)
            .map(data => {
                this.appSettings = data;
                this.broadcastAppSettingsChange(data);
                return data;
            })
            .catch(this.commonService.handleObservableHttpError);
    }

    updateWindowStatusToReadyToPrint() {
        let getStatusInterval;
        getStatusInterval = window.setInterval(() => {
            if(this.appSettings){
                window.status = this.appSettings.readyToPrintStatus;
                
                window.clearInterval(getStatusInterval);
            }
        }, 100);
    }
}
