import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { CommonService } from "./common.service";
import { Observable } from "rxjs";
import { Constants } from "../../shared/constants";
import { StaticContent } from "../../shared/models/static-content";

@Injectable()
export class StaticPagesService {
    url: string = `${Constants.ApiUrl}/staticcontent`;
    
    constructor(private http: HttpClient,
        private commonService: CommonService){
    }

    getLatestContent(name: string): Observable<StaticContent> {
        return this.http
            .get(`${this.url}?name=${name}`)
            .catch(this.commonService.handleObservableHttpError);
    }

    checkIfStaticContentExists(name: string): Observable<boolean> {
        return this.http.get<boolean>(`${this.url}/CheckIfContentExistByName?name=${name}`)
            .catch(this.commonService.handleObservableHttpError);
    }
}