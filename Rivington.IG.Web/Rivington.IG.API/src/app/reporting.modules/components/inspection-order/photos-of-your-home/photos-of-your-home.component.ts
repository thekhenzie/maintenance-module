import { Component, OnInit, HostListener } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { InspectionOrderService } from '../../../../modules/core/services/ordermanagement/inspection-order.service';
import { InspectionOrderPropertyPhoto } from '../../../../modules/shared/models/ordermanagement/inspection-order/checklist/photos/inspectionorderpropertyphoto';
import { UtilityService } from '../../../../modules/core/services/utility.service';
import Utils from '../../../../modules/shared/Utils';
import { Observable } from 'rxjs/Observable';
import { PhotoTypeService } from '../../../../modules/core/services/ordermanagement/phototype.service';
import { PhotoTypeGroup } from '../../../../modules/shared/models/ordermanagement/inspection-order/checklist/photos/phototypegroup';
import { PhotoType } from '../../../../modules/shared/models/ordermanagement/inspection-order/checklist/photos/phototype';
import { InspectionOrderPropertyPhotoPhotos } from '../../../../modules/shared/models/ordermanagement/inspection-order/checklist/photos/inspectionorderpropertyphotophotos';

@Component({
  selector: 'app-photos-of-your-home',
  templateUrl: './photos-of-your-home.component.html',
  styleUrls: ['./photos-of-your-home.component.css']
})
export class PhotosOfYourHomeComponent implements OnInit {

  currentIoId: string;
  aerialViewPhoto: any;
  homeSketchPhoto: any;
  inspectionOrderPropertyPhoto: InspectionOrderPropertyPhotoPhotos[];
  photoTypeGroup: PhotoTypeGroup[];
  photoType: PhotoType[];
  propertyPhoto: any;
  Object = Object;

  constructor(
    private route: ActivatedRoute,
    private inspectionOrderService: InspectionOrderService,
    private utilityService: UtilityService,
    private photoTypeService: PhotoTypeService
  ) {
    this.propertyPhoto = {};
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.currentIoId = params["id"];
    });

    Observable.forkJoin(
      this.photoTypeService.getPhotoTypeGroupList("PhotoTypeGroup"),
      this.photoTypeService.getPhotoTypeList("PhotoType"),
      this.inspectionOrderService.getPropertyPhotos(this.currentIoId)
    ).subscribe(response => {

      this.photoTypeGroup = <any>response[0];
      this.photoTypeGroup.forEach(photoType => {
        this.propertyPhoto[photoType.name] = [];
      });

      this.photoType = <any>response[1];
      this.photoType.forEach(photoType => {
        this.photoTypeGroup.forEach(photoTypeGroup => {
          if (photoTypeGroup.id == photoType.groupId) {
            this.propertyPhoto[photoTypeGroup.name][photoType.name] = [];
          }
        });
      });

      this.inspectionOrderPropertyPhoto = <any>response[2];
      if (this.inspectionOrderPropertyPhoto) {
        this.inspectionOrderPropertyPhoto.forEach(photo => {
          this.groupPhoto(photo);
        });
      }
    });
  }

  groupPhoto(propertyPhoto: any) {
    var BreakException = {};
    try {
      this.photoTypeGroup.forEach(photoTypeGroup => {
        this.photoType.forEach(photoType => {
          if (propertyPhoto.photoTypeId == photoType.id && photoTypeGroup.id == photoType.groupId) {
            this.propertyPhoto[photoTypeGroup.name][photoType.name].push(propertyPhoto);
            throw BreakException;
          }
        });
      });
    } catch (e) {
      if (e !== BreakException) throw e;
    }

    this.getAerialView();
    this.getHomeSketch();
  }

  getAerialView() {
    this.aerialViewPhoto = this.propertyPhoto['Miscellaneous Photo']['Aerial View'][0];
  }

  getHomeSketch() {
    this.homeSketchPhoto = this.propertyPhoto['Miscellaneous Photo']['Home Sketch'][0];
  }
}

