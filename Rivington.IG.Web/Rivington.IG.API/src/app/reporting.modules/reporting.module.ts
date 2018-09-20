import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MenuModule } from 'primeng/primeng';
import 'rxjs/add/operator/toPromise';
import { ReportingComponent } from './pages/index/reporting.component';
import { InspectionOrderReportComponent } from './pages/inspection-order/inspection-order.component';
import { PhotosOfYourHomeComponent } from './components/inspection-order/photos-of-your-home/photos-of-your-home.component';
import { CoreModule } from '../modules/core/core.module';
import { MitigationRequirementsComponent } from './components/inspection-order/NonWildfire-Assessment-Mitigation/mitigation-requirements/mitigation-requirements.component';
import { MitigationRecommendationsComponent } from './components/inspection-order/NonWildfire-Assessment-Mitigation/mitigation-recommendations/mitigation-recommendations.component';
import { WildfireMitigationRecommendationsComponent } from './components/inspection-order/Wildfire-Assessment-Mitigation/wildfire-mitigation-recommendations/wildfire-mitigation-recommendations.component';
import { WildfireMitigationRequirementsComponent } from './components/inspection-order/Wildfire-Assessment-Mitigation/wildfire-mitigation-requirements/wildfire-mitigation-requirements.component';
import { TitlePageComponent } from './components/inspection-order/title-page/title-page.component';
import { IntroductionComponent } from './components/inspection-order/introduction/introduction.component';
import { ProactiveProtectionComponent } from './components/inspection-order/proactive-protection/proactive-protection.component';
import { TableModule } from 'primeng/table';
import { RiskSummaryComponent } from './components/inspection-order/risk-summary/risk-summary.component';
import { WildfireAssessmentComponent } from './components/inspection-order/wildfire-assessment/wildfire-assessment.component';
import { ReportFooterComponent } from './components/inspection-order/report-footer/report-footer.component';

@NgModule({
  declarations: [
    ReportingComponent,
    InspectionOrderReportComponent,
    TitlePageComponent,
    IntroductionComponent,
    ProactiveProtectionComponent,
    PhotosOfYourHomeComponent,
    MitigationRequirementsComponent,
    MitigationRecommendationsComponent,
    WildfireMitigationRecommendationsComponent,
    WildfireMitigationRequirementsComponent,
    WildfireAssessmentComponent,
    RiskSummaryComponent,
    ReportFooterComponent
    ],
  imports: [
    // app modules

    // angular modules
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpModule,
    HttpClientModule,
    CoreModule,
    TableModule,

    // primeng modules
    // not used. but removing this throws an error regarding router-outlet missing and makes the page blank
    MenuModule,
  ]
})
export class ReportingModule { }
