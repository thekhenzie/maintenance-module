import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import * as primeModules from 'primeng/primeng';
import { TableModule } from 'primeng/table';
import { DropdownModule, LightboxModule } from 'primeng/primeng';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ConfirmDialogModule } from 'primeng/components/confirmdialog/confirmdialog';
import { CredentialComponent } from './pages/credential/credential.component';
import { ProfileinfoComponent } from './pages/profile-info/profileinfo.component';
import { FileUploadModule } from 'primeng/components/fileupload/fileupload';
import { UserProfileNavComponent } from './components/profilenav/user-profile-nav.component';
import { UserManagementComponent } from './pages/index/user-management.component';
import { UserManagementRoutingModule } from './user-management.routes';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    UserManagementRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule,

    TableModule,
    DropdownModule,
    ConfirmDialogModule,

    primeModules.DropdownModule,
    primeModules.PanelModule,
    primeModules.ButtonModule,
    primeModules.DialogModule,

    LightboxModule,
    primeModules.InputSwitchModule,
  ],
  declarations: [
    UserManagementComponent,
    UserProfileNavComponent,
    CredentialComponent,
    ProfileinfoComponent
  ]
})
export class UserManagementModule { }
