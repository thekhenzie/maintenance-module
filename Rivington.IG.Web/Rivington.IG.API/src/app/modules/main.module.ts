import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MenuModule } from 'primeng/primeng';
import 'rxjs/add/operator/toPromise';
import { AccountModule } from './account/account.module';
import { BreadcrumbComponent } from './components/breadcrumb/breadcrumb.component';
import { NavigationComponent } from './components/header-navigation/navigation.component';
import { RightSidebarComponent } from './components/right-sidebar/rightsidebar.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { DashboardModule } from './dashboard/dashboard.module';
import { MainComponent } from './main.component';
import { OrderManagementModule } from './ordermanagement/ordermangement.module';
import { ReportModule } from './report/report.module';
import { RootModule } from './root/root.module';
import { UserManagementModule } from './usermanagement/user-management.module';

@NgModule({
  declarations: [
    MainComponent,
    NavigationComponent,
    BreadcrumbComponent,
    SidebarComponent,
    RightSidebarComponent,
    ],
  imports: [
    // app modules
    AccountModule,
    DashboardModule,
    ReportModule,    
    RootModule,
    OrderManagementModule,
    UserManagementModule,

    // angular modules
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpModule,
    HttpClientModule,

    // primeng modules
    // not used. but removing this throws an error regarding router-outlet missing and makes the page blank
    MenuModule,
  ]
})
export class MainModule { }
