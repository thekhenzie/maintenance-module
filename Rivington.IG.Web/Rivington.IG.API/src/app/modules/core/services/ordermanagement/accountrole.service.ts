import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Constants } from "../../../shared/constants";
import { AccountRole } from "../../../shared/models/accountrole";
import { CommonService } from "../common.service";
import { Observable } from "rxjs/Observable";
import { SelectItem } from "primeng/components/common/selectitem";
import Utils from "../../../shared/Utils";
import { AuthService } from "../auth.service";

@Injectable()
export class AccountRoleService {


    constructor(private http: HttpClient,
        private commonService: CommonService) { }

    getAccountRoleList(serviceName): Observable<any> {
        return this.http.get(`${Constants.ApiUrl}/${serviceName}`)
            .map(data => { return data })
            .catch(this.commonService.handleObservableHttpError);
    }

    getRoles(): Observable<SelectItem[]> {
        return this.getAccountRoleList("GetRoles")
            .map(data => Utils.convertEnumerableListToSelectItemList(data));
    }

}