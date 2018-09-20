import { Component, OnInit } from '@angular/core';
import { StaticPagesService } from '../../../core/services/static-pages.service';
import Utils from '../../../shared/Utils';
import { Router, ActivatedRoute } from '@angular/router';
import { BaseComponent } from '../../../shared/BaseComponent';

@Component({
  selector: 'app-static-pages',
  templateUrl: './static-pages.component.html',
  styleUrls: ['./static-pages.component.css']
})
export class StaticPagesComponent extends BaseComponent implements OnInit {
  htmlString: string;
  
  constructor(
    private route: ActivatedRoute,
    private staticContentService: StaticPagesService
  ) {
    super();
    this.htmlString = '';
   }

  ngOnInit() {
    this.route.params.takeUntil(this.stop$).subscribe(params => {
      let name = params["staticcontentname"];

      this.staticContentService.getLatestContent(name).subscribe(data => {
        this.htmlString = data.htmlString;        
      },
      (error) => {
        Utils.showError("There's an error found while retrieving data..");
      },
      () => {
      });
    });
  };
  
}
  