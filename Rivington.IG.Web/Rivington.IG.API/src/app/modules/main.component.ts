import { Component } from '@angular/core';
import { MenuItem } from 'primeng/primeng';
import { AuthService } from './core/services/auth.service';
import { Router } from '@angular/router';
import { PathConstants } from './shared/pathconstants';
import { UtilityService } from './core/services/utility.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent {
  accountLoginPath: string;

  constructor(private auth: AuthService, private router: Router, private utilityService: UtilityService) {  }

  ngOnInit(): void {
    this.accountLoginPath = PathConstants.Account.Login;

    this.utilityService.getAppSettings().subscribe(data => {
      $("body").attr("data-appsetting", JSON.stringify(data));
    },
    (error) => {
    },
    () => {
    });
  }

  logout(): void {
    // erase current token
    this.auth.logout();
    // redirect to login page
    this.router.navigate([this.accountLoginPath]);
  }
}