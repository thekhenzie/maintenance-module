import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { CommonService } from "../common.service";
import { Constants } from "../../../shared/constants";
import { Observable } from "rxjs/Observable";
import { InspectionOrderNotes } from "../../../shared/models/inspectionordernotes";
import { FormControl, FormBuilder, Validators, FormGroup } from "@angular/forms";

@Injectable()
export class InspectionOrderNotesService {
    updateData: InspectionOrderNotes;

    constructor(private http: HttpClient, 
        private commonService: CommonService){ }

        postInspectionOrderNote(inspectionOrder) {
            return this.http.post(`${Constants.ApiUrl}/CreateInspectionOrderNote`, inspectionOrder)
                .toPromise()
                .then(data => { return data })
                .catch(this.commonService.handleError);
        }

        putInspectionOrderNote(inspectionOrder) {
            return this.http.put(`${Constants.ApiUrl}/UpdateInspectionNote`, inspectionOrder)
                .toPromise()
                .then(data => { return data })
                .catch(this.commonService.handleError);
        }

        getInspectionOrderNote(serviceName, id) {
            return this.http.get(`${Constants.ApiUrl}/${serviceName}/?id=${id}`)
                .toPromise()
                .then(data => {
                    return data as InspectionOrderNotes;
                })
                .catch(error => {
                    this.updateData = null;
                });
        }
    }