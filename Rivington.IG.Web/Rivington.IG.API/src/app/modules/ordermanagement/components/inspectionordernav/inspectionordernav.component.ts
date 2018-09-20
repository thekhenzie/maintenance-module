import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-inspectionordernav',
  templateUrl: './inspectionordernav.component.html',
  styleUrls: ['./inspectionordernav.component.css']
})
export class InspectionordernavComponent implements OnInit {
  paramId: string;
  constructor(private route:ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.route.params.subscribe(params => { 
      this.paramId = params["id"];
    });
  }
}
