import { DatePipe } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { UtilityService } from '../../../../core/services/utility.service';
import { MapItViewModel } from '../../../../shared/models/view-model/map-it-view-model';
import { MarkerLabel } from '@agm/core';
import { DateDifferenceConstants } from '../../../../shared/date-difference-constants';
import { InfoWindow } from '../../../../../../../node_modules/@agm/core/services/google-maps-types';
import { MapItService } from '../../../../core/services/ordermanagement/map-it-service';
import { InspectionStatusConstants } from '../../../../shared/inspection-status-constants';

@Component({
  selector: 'app-map-it-map-marker',
  templateUrl: './map-it-map-marker.component.html',
  styleUrls: ['./map-it-map-marker.component.css']
})
export class MapItMapMarkerComponent implements OnInit {
  @Input() currentInspectionStatus: string;
  @Input() inspectionOrder: MapItViewModel;
  dateFormat: string;
  @Input() isCurrentProperty: boolean = false;

  constructor(
    private datePipe: DatePipe,
    private utilityService: UtilityService,
    private mapItService: MapItService
  ) {
    this.dateFormat = utilityService.appSettings.defaultDateFormat;
   }

  ngOnInit() {
  }
  
  getStreetViewImageUrl(longitude, latitude) {
    return `https://maps.googleapis.com/maps/api/streetview?size=150x100&location=${latitude},${longitude}&fov=90&heading=235&pitch=10`; // &key=${this.utilityService.appSettings.jsMapApiKey}
  }

  getFormattedDate(date) {
    return this.datePipe.transform(date, this.dateFormat);
  }

  getInceptionDateWithCount() {
    return `${this.getFormattedDate(this.inspectionOrder.inspectionDate)} (${this.inspectionOrder.todayToInceptionDaysCount})`
  }

  getLabel() {
    if(!this.isCurrentProperty) {
      let label = "";
      if(this.currentInspectionStatus === InspectionStatusConstants.PendingAssignment)
        label = this.inspectionOrder.inspector;
      else
        label = this.getFormattedDate(this.inspectionOrder.inspectionDate);

      // if null, don't show count in label
      if(!!this.inspectionOrder.todayToInceptionDaysCount) {
        label += ` (${this.inspectionOrder.todayToInceptionDaysCount})`;
      }
      
      return label;
    } else {
      return "";
    }
  }

  getDetailsFooter() {
    let footer = this.inspectionOrder.policyNumber;
    if(!!this.inspectionOrder.todayToInceptionDaysCount) {
      footer += ` | ${this.getInceptionDateWithCount()}`;
    }

    return footer;
  }

  getIconUrl() {
    if(this.isCurrentProperty)
      return "/assets/images/maps/current-property-blue.png";
      // return `https://chart.googleapis.com/chart?chst=d_simple_text_icon_left&chld=${""}|14|000|home|24|A52719|A52719`;
    else
      return 'http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=%E2%80%A2|' + this.inspectionOrder.inceptionStatus.colorPalette;
  }

  getFontFamily(): string {
    switch (this.inspectionOrder.inceptionStatus) {
        case DateDifferenceConstants.ZeroToNineteenDays:
            return 'CustomMarkerLabelGreen';
        case DateDifferenceConstants.TwentyToThirtyNineDays:
            return 'CustomMarkerLabelYellow';
        default: // case DateDifferenceConstants.FortyToFiftyNineDays;
            return 'CustomMarkerLabelRed';
    }
  }

  clickedMarkerEvent(infowindow: InfoWindow) {
    if (this.mapItService.currentOpenedInfoWindow) {
      try {
        this.mapItService.currentOpenedInfoWindow.close();        
      } catch (error) { }
    }
    this.mapItService.currentOpenedInfoWindow = infowindow;
  }
}
