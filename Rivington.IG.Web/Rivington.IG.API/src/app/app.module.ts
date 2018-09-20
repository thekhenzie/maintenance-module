import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MenuModule } from 'primeng/primeng';
import 'rxjs/add/operator/toPromise';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app.routes';
import { AccountRoutingModule } from './modules/account/account.routes';
import { CoreModule } from './modules/core/core.module';
import { DashboardRoutingModule } from './modules/dashboard/dashboard.routes';
import { MainModule } from './modules/main.module';
import { MainRoutingModule } from './modules/main.routes';
import { OrderManagementRoutingModule } from './modules/ordermanagement/ordermangement.routes';
import { ReportRoutingModule } from './modules/report/report.routes';
import { RootRoutingModule } from './modules/root/root.routes';

// app shared components
import { UserManagementModule } from './modules/usermanagement/user-management.module';
import { UserManagementRoutingModule } from './modules/usermanagement/user-management.routes';
import { SharedModule } from './modules/shared/shared.module';
import { ReportingModule } from './reporting.modules/reporting.module';
import { ReportingRoutingModule } from './reporting.modules/reporting.routes';

@NgModule({
  declarations: [
    AppComponent
    ],
  imports: [
    // app modules
    SharedModule,
    CoreModule,
    MainModule,
    ReportingModule,

    // angular modules
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpModule,
    HttpClientModule,

    // routing modules (by order)

    ReportingRoutingModule,
    
    // RootRoutingModule,
    // OrderManagementRoutingModule,
    // AccountRoutingModule,
    // DashboardRoutingModule,
    // ReportRoutingModule,
    MainRoutingModule,
    
    AppRoutingModule,

    // ng-bootstrap module
    NgbModule.forRoot()

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
