import { Component } from '@angular/core';
import { MenuItem } from 'primeng/primeng';
import { AuthService } from './modules/core/services/auth.service';
import { Router, NavigationEnd } from '@angular/router';
import { PathConstants } from './modules/shared/pathconstants';
import { UtilityService } from './modules/core/services/utility.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  accountLoginPath: string;

  constructor(private auth: AuthService, private router: Router, private utilityService: UtilityService) {
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        (<any>window).ga('set', 'page', event.urlAfterRedirects);
        (<any>window).ga('send', 'pageview');
      }
    });
    }

  ngOnInit(): void {
    this.accountLoginPath = PathConstants.Account.Login;

    this.utilityService.getAppSettings().subscribe(data => {
      $("body").attr("data-appsetting", JSON.stringify(data));

      let envAbbr: string;
      switch (data.environmentName) {
        case "Development":
          envAbbr = "DEV";
          break;
        case "Test":
          envAbbr = "TST";
          break;
        case "Staging":
          envAbbr = "STG";
          break;
        default:
          envAbbr = "";
          break;
      }

      $("#footer-env-abbr").text(envAbbr);
      
      if(data.copyright) $("#copyright").text(data.copyright);
      
      if(data.appVersion) $("#footer-app-version").text(`v${data.appVersion}`);
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