import { Injectable } from  '@angular/core';
import { Http, Response } from '@angular/http';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Constants } from '../../shared/constants';

@Injectable()
export class ForgotPasswordService{
    constructor(private http: HttpClient){}

    checkIfForgotPasswordIdExist(id): Observable<boolean> {
        return this.http.get<boolean>(`${Constants.ApiUrl}/ResetPasswordGetId/${id}`)
        .map((doExist) => doExist)
        .catch(error => {
          console.log(error);
          return Observable.throw(error);  
        });
    }

    resetpassword(id, password): Observable<boolean> {
        return this.http.put<boolean>(`${Constants.ApiUrl}/ResetPassword`, {
            id: id,
            password: password
        })
        .map((doExist) => doExist)
        .catch(error => {
          console.log(error);
          return Observable.throw(error);  
        });
    }

    private handleError(error: any): Promise<any> {
        if(console && console.error) console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
      }

    // updateContact(id, objContact: Contact) {
    //     return this.http.put('http://localhost:16013/api/Contacts/?id=' + id, objContact)
    //         .toPromise()
    //         .then(() => objContact)
    //         .catch(this.handleError);
    // }

}