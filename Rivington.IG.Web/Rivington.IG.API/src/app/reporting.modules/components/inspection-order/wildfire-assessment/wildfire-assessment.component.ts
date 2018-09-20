import { Component, OnInit } from "@angular/core";
import { BaseComponent } from "../../../../modules/shared/BaseComponent";
import { WildfireViewModel } from "../../../../modules/shared/models/view-model/wildfire-view-model";
import { ActivatedRoute } from "@angular/router";
import { ReportingService } from "../../../../modules/core/services/reporting/reporting.service";

@Component({
  selector: 'app-wildfire-assessment',
  templateUrl: './wildfire-assessment.component.html',
  styleUrls: ['./wildfire-assessment.component.css']
})
export class WildfireAssessmentComponent extends BaseComponent implements OnInit {
  currentIOid: string;
  wildfireViewModel: WildfireViewModel;
  constructor(
    private route: ActivatedRoute,
    private reportingService: ReportingService
  ) {
    super();
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.currentIOid = params['id']

      // this.reportingService.getWildFireValue(this.currentIOid).takeUntil(this.stop$).subscribe(data => {
      //   // if(data) {
      //   //   let defaults = new WildfireViewModel();
      //   //   Object.keys(defaults).forEach(key => {
      //   //     if(defaults[key] instanceof Array && !!!data[key]) {
      //   //       data[key] = defaults[key];
      //   //     }
      //   //   });
      //   //   this.wildfireViewModel = data;
      //   // }
      //   if(data) this.wildfireViewModel = data;
      // },
      //   error => {
      //     console.log(error);
      //   },
      //   () => {
      //   });

    });

    this.reportingService.getIoDataSubscribeEmitter().takeUntil(this.stop$).subscribe(data => {
      this.wildfireViewModel = this.reportingService.wildfireViewModel;
    });
  }

  replaceStringIfNullOrEmpty(value: string, valueToReplace: string): string {
    // if(this.wildfireViewModel) console.log(`replaceStringIfNullOrEmpty("${value}", "${valueToReplace}")`);
    // console.log(value ? value : valueToReplace);
    return value ? value : valueToReplace;
  }

  replaceArrayIfNullOrEmpty(value: string[], valueToReplace: string): string {
    // if(this.wildfireViewModel) console.log(`replaceArrayIfNullOrEmpty("${value}", "${valueToReplace}")`);
    // console.log((value && value.length) ? value : valueToReplace);
    return (value && value.length) ? value.join(", ") : valueToReplace;
  }

  booleanToYesOrNo(value: boolean): string {
    // if(this.wildfireViewModel) console.log(`booleanToYesOrNo(${value})`);
    // console.log(value ? "Yes" : "No");
    return value ? "Yes" : "No";
  }
}
