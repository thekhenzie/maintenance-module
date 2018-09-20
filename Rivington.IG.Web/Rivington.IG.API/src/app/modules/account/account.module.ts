import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { AuthService } from '../../modules/core/services/auth.service';
import { AccountRoutingModule } from './account.routes';
import { SharedModule } from '../shared/shared.module';
import { AccountComponent } from './pages/index/account.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SweetAlert2Module } from '@toverux/ngx-sweetalert2';
import { ForgotpasswordComponent } from './pages/forgotpassword/forgotpassword.component';
import { ResetpasswordComponent } from './pages/resetpassword/resetpassword.component';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  imports: [
    SharedModule,
    AccountRoutingModule,
    CommonModule,
    ReactiveFormsModule,
    NgbModule,
    SweetAlert2Module,
    HttpClientModule
  ],
  declarations: [
    AccountComponent,    
    LoginComponent,
    RegisterComponent,
    ForgotpasswordComponent,
    ResetpasswordComponent
  ],
  providers: [],  
  bootstrap: [AccountComponent]
})
export class AccountModule { }