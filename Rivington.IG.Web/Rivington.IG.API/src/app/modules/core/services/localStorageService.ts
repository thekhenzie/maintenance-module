import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { AuthService } from "./auth.service";



@Injectable()
export class LocalStorageService {
    constructor(private http: HttpClient) {}
    
    setItem(key: string, value: string) {
        if(localStorage) localStorage.setItem(key, value);
    }
    getItem(key: string) {
        return localStorage ? localStorage.getItem(key) : "";
    }
    removeItem(key: string) {
        if(localStorage) localStorage.removeItem(key);
    }
    
    setUserName(userName: string) {
        this.setItem('username',userName);
    }
    getUserName() {
        return this.getItem('username');
    }
}
