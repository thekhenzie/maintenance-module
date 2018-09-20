import { Component, Inject, OnInit } from "@angular/core";
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { Router } from "@angular/router";
import { AuthService } from "../../../../modules/core/services/auth.service";
import { Constants } from "../../../shared/constants";
import { SweetAlert2Module } from '@toverux/ngx-sweetalert2';
import swal from "sweetalert2";
import Utils from "../../../shared/Utils";
import { UserManagementservice } from "../../../core/services/usermanagement/user-management.service";
import { PathConstants } from "../../../shared/pathconstants";
import { LocalStorageService } from "../../../core/services/localStorageService";
import { SafeHtml, DomSanitizer } from "@angular/platform-browser";
import { UserActivityLogService } from "../../../core/services/ordermanagement/user-activity-log.service";
import { NavigationComponent } from "../../../components/header-navigation/navigation.component";
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
  
  title: string;
  form: FormGroup;
  baseUrl: string;
  hideLinks: SafeHtml;

  constructor(
    private router: Router,
    private fb: FormBuilder,
    public authService: AuthService,
    private userService: UserManagementservice,
    private localStorage: LocalStorageService,
    private sanitizer: DomSanitizer,
    private userActivityService: UserActivityLogService
  ) {
    this.title = "User Login";
    this.baseUrl = Constants.ApiUrl;
    this.createForm();
  }

  ngOnInit() {
    if(this.router.url.search("insured") == -1){
      this.authService.isInsured = false;
    }
    else{
      this.authService.isInsured = true;

      this.hideLinks = this.sanitizer.bypassSecurityTrustHtml(
        `<style>
        ma-sidebar{
          display:none;
        }
        .page-wrapper{
          margin-left: 0;
        }
        breadcrumb{
          display:none;
        }
        .footer{
          left: 0;
        }
        html{
          background: #eef5f9;
        }
        .headerList{
          display:none;
        }
        #loginCard{
          margin-top: 5%;
        }
      </style>`);
    }
  }

  createForm() {
    this.form = this.fb.group({
      Username: ['', Validators.required],
      Password: ['', Validators.required]
    });
  }

  onSubmit() {
    Utils.blockUI();
    this.authService.login(this.form.value.Username, this.form.value.Password)
      .subscribe(res => {
        this.form.setErrors(null);
        this.userService.setUserInfoValues();
        this.userActivityService.sendEvent('Login', 'Login', 'Successful login');
        if(this.authService.isInsured){
          let ioId = this.localStorage.getUserName().toString();
          if(this.router.url.search("report") == -1){
            this.router.navigate([PathConstants.OrderManagement.InspectionOrder.InsuredMitigation, ioId])
            this.authService.insuredLogin = PathConstants.Account.InsuredLogin;
            this.authService.isInsuredReport = false;
          }
          else{
            this.router.navigate([PathConstants.OrderManagement.InspectionOrder.InsuredReport, ioId]);
            this.authService.insuredLogin = PathConstants.Account.InsuredReportLogin;
            this.authService.isInsuredReport = true;
          }
        }
        else{
          this.router.navigate(["/"]);
        }
      },
      err => {
        if(err.status == 403){
          let errorMessage = "Something went wrong. Please contact your system administrator.";
          Utils.showError(errorMessage);
        }
        else {
          let errorMessage = "Incorrect username or password";
          Utils.showError(errorMessage);
        }
      },
      () => {
        Utils.unblockUI();
      });
  }

  onBack() {
    this.router.navigate(["/"]);
  }

  // retrieve a FormControl
  getFormControl(name: string) {
    return this.form.get(name);
  }

  // returns TRUE if the FormControl is valid
  isValid(name: string) {
    var e = this.getFormControl(name);
    return e && e.valid;
  }

  // returns TRUE if the FormControl has been changed
  isChanged(name: string) {
    var e = this.getFormControl(name);
    return e && (e.dirty || e.touched);
  }

  // returns TRUE if the FormControl is invalid after user changes
  hasError(name: string) {
    var e = this.getFormControl(name);
    return e && (e.dirty || e.touched) && !e.valid;
  }
}
