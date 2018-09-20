import { Component, OnInit } from '@angular/core';
import { Validators, FormControl, FormBuilder, FormGroup } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from '../../../core/services/auth.service';
import Utils from '../../../shared/Utils';
import { ForgotPasswordService } from '../../../core/services/forgotpasswordservice';
import { UserActivityLogService } from '../../../core/services/ordermanagement/user-activity-log.service';
import { CategoryConstants } from '../../../shared/models/user-activity-category-constants';

@Component({
  selector: 'app-resetpassword',
  templateUrl: './resetpassword.component.html',
  styleUrls: ['./resetpassword.component.css']
})
export class ResetpasswordComponent implements OnInit {

  form: FormGroup;
  rexExpPasswordFormat = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,20}/;
  params: string;

  constructor(private router: Router,
    private fb: FormBuilder,
    private authService: AuthService,
    private route: ActivatedRoute,
    private forgotpassword: ForgotPasswordService,
    private userActivityService: UserActivityLogService
    ) {
    this.createForm();
  }

  ngOnInit() {
    
  }

  createForm() {
    this.form = this.fb.group({
        password:['',Validators.pattern(this.rexExpPasswordFormat)],
        confirmPassword: ['', Validators.required]
      }, 
      {
        validator: this.passwordConfirmValidator,
        //validator: this.passwordValidator
      });
  }

  hasError(name: string) {
    var e = this.getFormControl(name);
    return e && (e.dirty || e.touched) && !e.valid;
  }

  getFormControl(name: string) {
    return this.form.get(name);
  }

  passwordConfirmValidator(control: FormControl): any {
    let p = control.root.get('password');
    let pc = control.root.get('confirmPassword');

    if (p && pc) {
      if (p.value !== pc.value && pc.dirty) {
        pc.setErrors(
          { "PasswordMismatch": true }
        );
      }
      else {
        return null;
      }
    }
  }

  onSubmit() {
    Utils.blockUI();
    this.forgotpassword.resetpassword(this.route.snapshot.params['id'], this.form.value.password)
      .subscribe(res => {
        let successMessage = "Your password has been updated!"
        this.form.setErrors(null);
        Utils.showSuccess(successMessage);
        this.router.navigate(["/account/login"]);

        this.userActivityService.sendEvent(CategoryConstants.Update, 'resetpassword', 'Changed Password');
      },
      err => {
        let errorMessage = "Password does not match";

        Utils.unblockUI();
        Utils.showError(errorMessage);
      });
  }
}
