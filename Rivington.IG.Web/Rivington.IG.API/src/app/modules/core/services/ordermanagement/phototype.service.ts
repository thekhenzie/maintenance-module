import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { HttpClient } from '@angular/common/http';
import { Constants } from '../../../shared/constants';
import { PhotoType } from '../../../shared/models/ordermanagement/inspection-order/checklist/photos/phototype';
import { PhotoTypeGroup } from '../../../shared/models/ordermanagement/inspection-order/checklist/photos/phototypegroup';
import { CommonService } from '../common.service';

@Injectable()
export class PhotoTypeService {

    constructor(private http: HttpClient, private commonService: CommonService) { }

    getPhotoTypeList(serviceName) {
        return this.http.get(`${Constants.ApiUrl}/${serviceName}`)
            .map(data => { return data as PhotoType[] })
            .catch(this.commonService.handleObservableHttpError)
    }

    getPhotoTypeGroupList(serviceName) {
        return this.http.get(`${Constants.ApiUrl}/${serviceName}`)
            .map(data => { return data as PhotoTypeGroup[] })
            .catch(this.commonService.handleObservableHttpError)
    }

}
