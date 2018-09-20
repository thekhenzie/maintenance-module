import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { AuthService } from '../../../core/services/auth.service';
import Utils from '../../../shared/Utils';
import { leave } from '@angular/core/src/profile/wtf_impl';

@Component({
  selector: 'app-forgotpassword',
  templateUrl: './forgotpassword.component.html',
  styleUrls: ['./forgotpassword.component.css']
})
export class ForgotpasswordComponent implements OnInit {
  form: FormGroup;
  rexExpEmailFormat = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

  constructor(private router: Router,
    private fb: FormBuilder,
    private authService: AuthService) {
  }

  ngOnInit() {
    this.form = this.fb.group({
      'emailAddress': new FormControl('', Validators.compose([Validators.required, Validators.pattern(this.rexExpEmailFormat)])),
    });
    this.form.markAsPristine();
  }

  onSubmit() {
    let defaults: any = {
      confirmButtonText: "Click here to login"
    };

    Utils.blockUI();
    this.authService.forgotpassword(this.form.value.emailAddress)
      .subscribe(res => {
        this.form.setErrors(null);
        Utils.showSuccess(defaults);
        this.router.navigate(["/account/login"]);
      },
      err => {

        Utils.unblockUI();
        Utils.showSuccess(defaults);
        this.router.navigate(["/account/login"]);
      });
  }


  createForm() {
    this.form = this.fb.group({
      'EmailAddress': new FormControl('', Validators.compose([Validators.required, Validators.minLength(6)])),
    });
  }

  hasError(name: string) {
    var e = this.getFormControl(name);
    return e && (e.dirty || e.touched) && !e.valid;
  }
  getFormControl(name: string) {
    return this.form.get(name);
  }

}
