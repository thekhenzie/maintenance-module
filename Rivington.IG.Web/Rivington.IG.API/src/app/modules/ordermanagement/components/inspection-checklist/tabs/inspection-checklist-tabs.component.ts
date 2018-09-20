import { Component, OnInit } from '@angular/core';
import { ActivatedRouteSnapshot } from '@angular/router/src/router_state';
import { Router, ActivatedRoute } from '@angular/router';
import { InspectionChecklistPropertyComponent } from '../property/inspection-checklist-property.component';
import { InspectionChecklistWildfireAssessmentComponent } from '../wildfire-assessment/inspection-checklist-wildfire-assessment.component';
import { InspectionChecklistPhotoComponent } from '../photo/inspection-checklist-photo.component';
import { InspectionChecklistRiskSummaryComponent } from '../risk-summary/risk-summary.component';


@Component({
  selector: 'app-inspection-checklist-tabs',
  templateUrl: './inspection-checklist-tabs.component.html',
  styleUrls: ['./inspection-checklist-tabs.component.css']
})
export class InspectionChecklistTabsComponent implements OnInit {
  public tabIndex: number = 0;
  public renderedIndexes: number[] = [];
  sections: any[] = [{
      index: 0,
      component: InspectionChecklistPropertyComponent,
      name: "property",
      header: "Property",
      leftIcon: "mdi mdi-home-outline",
      disabled: false
    },
    {
      index: 1,
      component: InspectionChecklistWildfireAssessmentComponent,
      name: "wildfire-assessment",
      header: "Wildfire Assessment",
      leftIcon: "mdi mdi-fire",
      disabled: false
    },
    {
      index: 2,
      component: InspectionChecklistPhotoComponent,
      name: "photos",
      header: "Photos",
      leftIcon: "mdi mdi-image",
      disabled: false
    },
    {
      index: 3,
      component: InspectionChecklistRiskSummaryComponent,
      name: "risk",
      header: "Risk Summary",
      leftIcon: "mdi mdi-pencil",
      disabled: false
    }
  ];
  defaults: any[] = [{
      section: "property",
      category: "general"
    },{
      section: "wildfire-assessment",
      category: "roof"
    },{
      section: "photos",
      category: "list"
    },{
      section: "risk",
      category: "summary"
    }
  ];

  constructor(private route:ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.route.params.subscribe(params => { 
      let paramSection = params["section"];
      let paramCategory = params["category"];
      if(!!!paramCategory) {
        let defaultCategory = this.defaults.find(s => s.section == paramSection);
        if(defaultCategory) {
          this.router.navigate([defaultCategory.category], { relativeTo: this.route});
        }
      }

      let section = this.sections.find(s => s.name == paramSection);
      
      if(section) {
        this.tabIndex = section.index;
      }
    });
  }
  
  tabChangedEvent(e) {
    if(this.renderedIndexes.indexOf(e.index) < 0) this.renderedIndexes.push(e.index);
    this.changeRoute(e);
  }

  changeRoute(e) {
    let currentTabIndex = e.index;
    if(currentTabIndex > this.sections.length) currentTabIndex = 0;
    let section = this.sections.find(s => s.index == currentTabIndex);
    if(section) {
      let params = this.route.snapshot.params;
      
      let defaultCategory = this.defaults.find(s => s.section == section.name);
      
      let routes = ['order-management/inspection-order', params["id"], "checklist", section.name];
      if(defaultCategory) routes.push(defaultCategory.category);

      this.router.navigate(routes);
    }
  }

}
