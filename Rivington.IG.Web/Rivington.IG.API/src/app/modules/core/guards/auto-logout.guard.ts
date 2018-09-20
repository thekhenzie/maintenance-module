import { Injectable } from "@angular/core";
import { CanDeactivate } from "@angular/router";
import { AuthService } from "../services/auth.service";
import { RoleConstants } from "../../shared/roleconstants";

export interface CanComponentDeactivate {
    canDeactivate: () =>  boolean;
}

@Injectable()
export class AutoLogoutGuard implements CanDeactivate<CanComponentDeactivate> {

    constructor(private auth: AuthService) {

    }

    canDeactivate(component: CanComponentDeactivate): boolean {
        let currentRole = this.auth.getRoles().toString();
        if (currentRole == RoleConstants.Insured) {
            this.auth.logout();
            return true;
        }
    }
}