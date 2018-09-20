import { Component, OnInit } from '@angular/core';
import { InspectionOrderLogservice } from '../../../core/services/ordermanagement/inspection-order-log.service';
import { ActivatedRoute } from '@angular/router';
import { InspectionLog } from '../../../shared/models/inspection-log';
import { DatePipe } from '@angular/common';
import { UtilityService } from '../../../core/services/utility.service';

@Component({
  selector: 'app-inspection-order-timeline',
  templateUrl: './inspection-order-timeline.component.html',
  styleUrls: ['./inspection-order-timeline.component.css']
})
export class InspectionOrderTimelineComponent implements OnInit {
  dateFormat: any;
  inspectionLogList: InspectionLog[];
  alternate: boolean = true;
  toggle: boolean = true;
  color: boolean = false;
  size: number = 40;
  entries = []

  constructor(private inpsectioLogService: InspectionOrderLogservice,
    private route: ActivatedRoute,
    private datePipe: DatePipe,
    private utilityService: UtilityService) { 
      this.dateFormat = utilityService.appSettings.defaultDateFormat;
    }

  ngOnInit() {
    this.inpsectioLogService.getInspectionOrderLogs(this.route.snapshot.params['id']).subscribe(data => {
      this.inspectionLogList = data
      this.initializeTimeline();
    });
  }

  initializeTimeline() {
    this.inspectionLogList.forEach(element => {
      this.entries.push({
        header: element.actionDescription,
        content: this.datePipe.transform(element.dateCreated, this.dateFormat)
      })
    });
  }
}
