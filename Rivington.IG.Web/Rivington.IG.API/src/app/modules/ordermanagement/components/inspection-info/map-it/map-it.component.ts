import { AgmMap } from '@agm/core';
import { Component, Input, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SelectItem } from 'primeng/primeng';
import { MapItService } from '../../../../core/services/ordermanagement/map-it-service';
import { BaseComponent } from '../../../../shared/BaseComponent';
import { InspectionStatus } from '../../../../shared/models/ordermanagement/inspectionstatus';
import { MapItViewModel } from '../../../../shared/models/view-model/map-it-view-model';
import Utils from '../../../../shared/Utils';
import { AgmMarkerCluster } from '../../../../../../../node_modules/@agm/js-marker-clusterer';
import { InspectionStatusConstants } from '../../../../shared/inspection-status-constants';

/// references
// https://blog.ng-book.com/angular-and-google-maps-a-tutorial/
// 
@Component({
  selector: 'app-map-it',
  templateUrl: './map-it.component.html',
  styleUrls: ['./map-it.component.css']
})
export class MapItComponent extends BaseComponent implements OnInit, AfterViewInit {
  @Input() currentInspectionStatus: string;
  currentIoId: string;
  longitude: number = -122.5076406;
  latitude: number = 37.757815;
  inspectionStatuses: InspectionStatus[];
  currentIo: MapItViewModel = new MapItViewModel();
  ioList: MapItViewModel[] = [];
  completeIoList: MapItViewModel[] = [];
  inspectorList: any;
  showNearbyProperties: boolean;

  @ViewChild('mapIt') mapIt: AgmMap;
  @ViewChild('markerCluster') markerCluster: AgmMarkerCluster;
  
  constructor(
    private route: ActivatedRoute,
    private mapItService: MapItService
  ) {
    super();
  }

  ngOnInit() {
    this.route.params.takeUntil(this.stop$).subscribe(params => {
      let ioId = params["id"];
      if (!ioId) return;
      
      this.currentIoId = ioId;
    });
  }

  ngAfterViewInit() {
    // this.inspectionOrderService.getUserListForDropdown().then(data => {
    //   this.inspectorList = data;
    //   console.log(data);
    // });

    // Utils.blockUI();
    this.mapItService.getIoByIoId(this.currentIoId).takeUntil(this.stop$)
      .finally(() => {
      }).subscribe(
        (data: MapItViewModel) => {
          this.currentIo = data;
          this.mapIt.triggerResize(true);

          console.log(data);
        },
        error => {
          Utils.showGenericHttpErrorResponse(error);
      });
      
      this.showNearbyProperties = (this.currentInspectionStatus === InspectionStatusConstants.PendingAssignment ||
      this.currentInspectionStatus === InspectionStatusConstants.ReadyToSchedule ||
      this.currentInspectionStatus === InspectionStatusConstants.Scheduled);

      if(this.showNearbyProperties) {
          this.mapItService.getIoList().takeUntil(this.stop$)
            .finally(() => {
            }).subscribe(
              (data: MapItViewModel[]) => {
                this.completeIoList = this.removeCurrentIoInList(data);
                this.ioList = this.completeIoList;

                this.inspectorList = this.mapItService.getUniqueUsersFromIoList(this.ioList);

                setTimeout(() => {
                  this.mapIt.triggerResize();
                }, 300) 
              },
              error => {
                Utils.showGenericHttpErrorResponse(error);
            });
      }
  }

  filterMarkers(inspector) {
    let inspectorId = inspector.value;
    if(!!!inspectorId) {
      this.ioList = this.completeIoList.slice();
    } else {
      this.ioList = this.completeIoList.slice().filter(io => {
        return io.inspectorId === inspectorId;
      });
    }
  }

  milesToRadius(value: number): number {
    return value / 0.00062137;
  }

  private removeCurrentIoInList(list: MapItViewModel[]) {
    if(!!!list) return [];

    let currentIoId = this.currentIoId;
    return list.filter(function(io) { 
      return io.id !== currentIoId;
    })
  }
}
