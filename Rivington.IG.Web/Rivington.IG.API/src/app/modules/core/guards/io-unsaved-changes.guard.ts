import { Injectable } from "@angular/core";
import { InspectioninfoComponent } from "../../ordermanagement/pages/inspectioninfo/inspectioninfo.component";
import { CanDeactivate } from "@angular/router";
import { AuthService } from "../services/auth.service";

@Injectable()
export class IOUnsavedChangesGuard implements CanDeactivate<InspectioninfoComponent> {

  constructor(private auth: AuthService) {

  }

  canDeactivate(component: InspectioninfoComponent): boolean {

    if (component.hasUnsavedData() && !component.isCreate) {
      if(confirm("You have unsaved changes! If you leave, your changes will be lost.")){
        this.auth.isLogout = true;
        return true;
      }
      else{
        this.auth.isLogout = false;
        return false;
      }
    }
    return true;
  }
}