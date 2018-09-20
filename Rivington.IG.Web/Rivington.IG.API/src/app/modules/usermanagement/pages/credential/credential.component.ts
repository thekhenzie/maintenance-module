import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormGroup, FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import Utils from '../../../shared/Utils';
import { LocalStorageService } from '../../../core/services/localStorageService';
import { User } from '../../../shared/models/user';
import { UserManagementservice } from '../../../core/services/usermanagement/user-management.service';
import { UserActivityLogService } from '../../../core/services/ordermanagement/user-activity-log.service';
import { CategoryConstants } from '../../../shared/models/user-activity-category-constants';

@Component({
  selector: 'app-credential',
  templateUrl: './credential.component.html',
  styleUrls: ['./credential.component.css']
})
export class CredentialComponent implements OnInit {
  username: string;
  user: User;
  userform: FormGroup;
  rexExpPasswordFormat = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,20}/;

  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private userManagementService: UserManagementservice,
    private localService: LocalStorageService,
    private userService: UserManagementservice,
    private userActivityService: UserActivityLogService) { 

    }

  ngOnInit() {
    this.userform = this.fb.group({
      'username': new FormControl('', Validators.required),
      'currentPassword': new FormControl('', Validators.required),
      'newPassword': new FormControl('', Validators.compose([Validators.required, Validators.pattern(this.rexExpPasswordFormat)])),
      'confirmNewPassword': new FormControl('', Validators.required)
    },
    {
      validator: this.passwordConfirmValidator
    });

    this.username = this.localService.getUserName();
    this.userService.getUser(this.username).subscribe(user => {
      this.user = user;
      this.userform.patchValue({
        'username' : user.userName
      });
    });
  }

  passwordConfirmValidator(control: FormControl): any {
    let p = control.root.get('newPassword');
    let pc = control.root.get('confirmNewPassword');

    if (p && pc) {
      if (p.value !== pc.value && pc.dirty && pc.value != "") {
        pc.setErrors(
          { "PasswordMismatch": true }
        );
      }
      else {
        return null;
      }
    }
  }

  hasError(name: string) {
    var e = this.getFormControl(name);
    return e && (e.dirty || e.touched) && !e.valid;
  }

  getFormControl(name: string) {
    return this.userform.get(name);
  }

  editCredenital(){
    Utils.blockUI();
    let id = this.route.snapshot.params['id'];
    let storedUsername = this.localService.getUserName();
    if (id){
      this.userManagementService.updatePassword(this.userform.value.username, this.userform.value.newPassword,
        this.userform.value.currentPassword, id)
      .subscribe(res => {
        Utils.showSuccess("Your account has been updated!");
        this.router.navigate(["/account/login"]);
      },
      err => {
        Utils.showError("Incorrect Password");
      });
    }
    else {
      this.userManagementService.updatePasswordViaUserName(this.userform.value.username, this.userform.value.newPassword,
        this.userform.value.currentPassword, storedUsername)
      .subscribe(res => {
        Utils.showSuccess("Your account has been updated!");
        this.userActivityService.sendEvent(CategoryConstants.Update, 'user-management/credenital', CategoryConstants.UpdateUserCredential);
      },
      err => {
        Utils.showError("Incorrect Password");
      });
    }
  }
}
