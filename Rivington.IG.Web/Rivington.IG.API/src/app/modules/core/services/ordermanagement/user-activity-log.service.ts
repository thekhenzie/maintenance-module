import { Injectable } from "@angular/core";
import { LocalStorageService } from "../localStorageService";

@Injectable()
export class UserActivityLogService {

    constructor(private localService: LocalStorageService) { 
    }

    sendEvent(eventCategory: string, eventLabel: string, eventAction: string) {
        let userAction = ({
            action: eventAction,
            currentUser: this.localService.getUserName(),
            date: new Date()
          });
          
        (<any>window).ga('send', 'event', {
            eventCategory: eventCategory,
            eventLabel: eventLabel,
            eventAction: JSON.stringify(userAction),
            eventValue: 10
        });
    }
}