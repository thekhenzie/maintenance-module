import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Constants } from "../../../shared/constants";
import { CommonService } from "../common.service";
import { Observable } from "rxjs/Observable";
import { SelectItem } from "primeng/components/common/selectitem";
import { StateService } from "../ordermanagement/state.service";
import Utils from "../../../shared/Utils";
import { CityService } from "../ordermanagement/city.service";
import { User } from "../../../shared/models/user";
import { LocalStorageService } from "../localStorageService";

@Injectable()
export class UserManagementservice {
    public profilePhoto: string;
    public userAccount: User;
    username: string;

    constructor(private http: HttpClient,
        private commonService: CommonService,
        private stateService: StateService,
        private cityService: CityService,
        private localService: LocalStorageService) {
            this.userAccount = null;
         }

    postUser(user: User): Observable<any> {
        return this.http.post(`${Constants.ApiUrl}/User`, user)
            .catch(this.commonService.handleObservableHttpError);
    }

    putProfileInfo(user: User): Observable<any> {
        return this.http.put(`${Constants.ApiUrl}/UpdateProfileInfo`, user)
            .catch(this.commonService.handleObservableHttpError);
    }

    putProfileInfoViaGuid(user: User, id: string): Observable<any> {
        return this.http.put(`${Constants.ApiUrl}/UpdateProfileInfo/${id}`, user)
            .catch(this.commonService.handleObservableHttpError);
    }

    getUser(username: string): Observable<any> {
        return this.http.get(`${Constants.ApiUrl}/GetUser/${username}`, {})
            .catch(this.commonService.handleObservableHttpError);
    }

    getUserById(id: string): Observable<any> {
        return this.http.get(`${Constants.ApiUrl}/GetUserId/${id}`, {})
            .catch(this.commonService.handleObservableHttpError);
    }

    getCities(stateId: string): Promise<SelectItem[]> {
        return this.cityService.getCityList(stateId)
            .then(data => {
                let list: SelectItem[] = [];
                data.forEach(item => {
                    list.push({
                        value: item.id,
                        label: item.name
                    });
                })

                return list;
            });
    }

    checkIfUserIsNew(id: string): Observable<boolean> {
        return this.http.get<boolean>(`${Constants.ApiUrl}/GetUserIdForCredential/${id}`)
            .catch(this.commonService.handleObservableHttpError);
    }

    checkIfUserExist(id: string): Observable<boolean> {
        return this.http.get<boolean>(`${Constants.ApiUrl}/CheckIfUserExist/${id}`)
            .catch(this.commonService.handleObservableHttpError);
    }

    updatePassword(username: string, newPassword: string,
        currentPassword: string, id: string): Observable<boolean> {
        return this.http.put<boolean>(`${Constants.ApiUrl}/UpdateUser`, {
            username: username,
            newPassword: newPassword,
            currentPassword: currentPassword,
            id: id
        })
            .catch(this.commonService.handleObservableHttpError);
    }

    updatePasswordViaUserName(username: string, newPassword: string,
        currentPassword: string, storedUserName: string): Observable<boolean> {
        return this.http.put<boolean>(`${Constants.ApiUrl}/UpdateUser/${storedUserName}`, {
            username: username,
            newPassword: newPassword,
            currentPassword: currentPassword,
            storedUserName: storedUserName
        })
            .catch(this.commonService.handleObservableHttpError);
    }

    setUserInfoValues() {
        this.username = this.localService.getUserName();
        this.getUser(this.username).subscribe(data => {
            this.userAccount = data,
            this.profilePhoto = data.profilePhoto ? data.profilePhoto.filePath : Constants.defaultUserProfileImage
        })
    }

}
