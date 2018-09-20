import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ConfirmationService, Dropdown, SelectItem } from 'primeng/primeng';
import { Observable } from 'rxjs';
import { AuthService } from '../../../../core/services/auth.service';
import { ImageService } from '../../../../core/services/image.service';
import { InspectionOrderService } from '../../../../core/services/ordermanagement/inspection-order.service';
import { PhotoTypeService } from '../../../../core/services/ordermanagement/phototype.service';
import { Image } from '../../../../shared/models/ordermanagement/image';
import { InspectionOrder } from '../../../../shared/models/ordermanagement/inspection-order';
import { InspectionOrderPropertyPhoto } from '../../../../shared/models/ordermanagement/inspection-order/checklist/photos/inspectionorderpropertyphoto';
import { InspectionOrderPropertyPhotoPhotos } from '../../../../shared/models/ordermanagement/inspection-order/checklist/photos/inspectionorderpropertyphotophotos';
import { PhotoType } from '../../../../shared/models/ordermanagement/inspection-order/checklist/photos/phototype';
import { PhotoTypeGroup } from '../../../../shared/models/ordermanagement/inspection-order/checklist/photos/phototypegroup';
import Utils from '../../../../shared/Utils';
import { BaseComponent } from '../../../../shared/BaseComponent';
import { PlatformLocation } from '@angular/common';

@Component({
  selector: 'app-inspection-checklist-photo',
  templateUrl: './inspection-checklist-photo.component.html',
  styleUrls: ['./inspection-checklist-photo.component.css'],
  providers: [ConfirmationService]
})
export class InspectionChecklistPhotoComponent extends BaseComponent implements OnInit {
  photoTypeGroup: PhotoTypeGroup[];
  photoType: PhotoType[];
  propertyPhotoForm: FormGroup;
  photoValue: string;
  file: string;
  currentIoId: string;
  display: boolean;
  propertyPhoto: any;
  photoTypeList: SelectItem[];
  isNew: boolean;
  Object = Object;
  dialogHeader: string;
  currentPhoto: {
    propertyPhoto: any,
    keyGroup: string,
    keyType: string
  };

  constructor(
    private fb: FormBuilder,
    private photoTypeService: PhotoTypeService,
    public inspectionOrderService: InspectionOrderService,
    private route: ActivatedRoute,
    private confirmationService: ConfirmationService,
    private imageService: ImageService,
    private urlLocation: PlatformLocation,
    public auth: AuthService
  ) { 
    super();
    this.propertyPhoto = {};
    this.photoTypeList = []
    this.isNew = true;

    urlLocation.onPopState(() => {
      this.display = false;
    });
  }

  @ViewChild('inputImage') public inputImage: ElementRef;
  @ViewChild('typeDropDown') public typeDropDown: Dropdown;

  ngOnInit() {
    this.route.params.subscribe(params => {
      if(this.isIoIdParamChanged(params)) {
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
          this.photoTypeList = Utils.convertEnumerableListToSelectItemList(this.photoType);
  
          let ioPhotos = <any>response[2];
          if (ioPhotos) {
            ioPhotos.forEach(propertyPhoto => {
              propertyPhoto.id = propertyPhoto.image.id;
  
              this.groupPhoto(propertyPhoto);
            });
          }
        });
      }
    });

    this.propertyPhotoForm = this.fb.group({
      'id': new FormControl(''),
      'photo': new FormControl('', Validators.required),
      'description': new FormControl('', Validators.required),
      'photoTypeId': new FormControl('', Validators.required)
    });
  }

  isIoIdParamChanged(params: any): boolean {
    let currentParam = params["id"];
    if(this.currentIoId != currentParam) {
      this.currentIoId = currentParam;
      return true;
    }
    return false;
  }

  getImageValue(event) {
    let uploadedFile = event.target.files[0];
    if(!this.imageService.validateImageSize(uploadedFile)) {
      Utils.showError("Image size exceeds 30MB.");
      this.inputImage.nativeElement.value = "";
      return; // this.removePhoto();
    }

    if(this.imageService.validateFileType(uploadedFile)){
      Utils.showError("Upload an Image file only.");
      this.inputImage.nativeElement.value = "";
      return; // this.removePhoto();
    }

    Utils.blockUI();
    this.imageService.getOptimizedByteStringImage(uploadedFile).then(reader => {
      const interval = setInterval(() => {
        if(reader.result !== "") {
          this.file = reader.result;
          Utils.unblockUI();
          clearInterval(interval);
        }
      }, 10);
    });
  }

  SavePhoto() {
    this.propertyPhotoForm.value.photo = this.file;

    if (
      this.propertyPhotoForm.value.photo &&
      this.propertyPhotoForm.value.description &&
      this.propertyPhotoForm.value.photoTypeId
    ) {
      // Initialization for needed ID(s) and Image: Create/Update
      let photo = this.propertyPhotoForm.value;
      let inspectionOrder = new InspectionOrder({
        id: this.currentIoId,
        propertyPhoto: new InspectionOrderPropertyPhoto({
          photos: [{
            description: photo.description,
            imageId: photo.id,
            image: {
              id: photo.id,
              file: photo.photo
            },
            photoTypeId: photo.photoTypeId
          }]
        })
      });
      
      if (this.isNew) {
        delete inspectionOrder.propertyPhoto.photos[0]["imageId"];
        delete inspectionOrder.propertyPhoto.photos[0].image["id"];
      }

      Utils.blockUI();
      this.inspectionOrderService.postPropertyPhoto(inspectionOrder).takeUntil(this.stop$)
      .finally(() => {
        Utils.unblockUI();
      }).subscribe(
        (image: Image) => {
          let newPhoto = new InspectionOrderPropertyPhotoPhotos({
            id: image.id,
            description: photo.description,
            imageId: photo.id,
            image: image,
            photoTypeId: photo.photoTypeId
          });
          
          if (this.isNew) {
            this.groupPhoto(newPhoto);
          } else {
            let photoList = this.propertyPhoto[this.currentPhoto.keyGroup][this.currentPhoto.keyType];
            if(photoList) {
              let index = photoList.findIndex(x => x.imageId === newPhoto.imageId);
              if(index > -1)
                photoList[index] = newPhoto;
            }
          }
          this.display = false;
          this.resetFields();
        },
        error => {
          Utils.showGenericHttpErrorResponse(error);
        });
    }
    else {
      Object.keys(this.propertyPhotoForm.controls).forEach(field => {
        const control = this.propertyPhotoForm.get(field);
        if (control instanceof FormControl) {
          control.markAsTouched({ onlySelf: true });
        }
      });
      Utils.showError("Please complete all the required fields.");
    }
  }

  showAddPhoto(isShow: boolean) {
    if (!isShow) {
      if (this.propertyPhotoForm.dirty) {
        this.confirmationService.confirm({
          message: 'Are you sure you want to discard changes?',
          header: 'Discard Changes',
          icon: 'fa fa-question-circle',
          accept: () => {
            this.resetFields();
            this.display = isShow;
            this.propertyPhotoForm.markAsPristine();
          },
          reject: () => {
            this.display = true;
          }
        });
      } else {
        this.display = isShow;
      }
    }
    else {
      this.dialogHeader = "Add Photo"
      this.typeDropDown.disabled = false;
      this.resetFields();
      this.display = isShow;
    }
  }

  resetFields() {
    this.propertyPhotoForm.reset();
    this.inputImage.nativeElement.value = "";
    this.isNew = true;
    this.file = null;
  }

  viewPhoto(propertyPhoto, keyGroup, keyType) {
    this.currentPhoto = {
      propertyPhoto: propertyPhoto,
      keyGroup: keyGroup,
      keyType: keyType
    };
    
    this.dialogHeader = "Edit Photo"
    this.isNew = false;
    this.typeDropDown.disabled = true;
    this.file = propertyPhoto.image.filePath;
    this.propertyPhotoForm.setValue({
      'id': propertyPhoto.image.id,
      'photo': propertyPhoto.image.filePath,
      'description': propertyPhoto.description,
      'photoTypeId': propertyPhoto.photoTypeId,
    });
    this.display = true;
  }

  deletePhoto(propertyPhoto) {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete?',
      header: 'Delete Photo',
      icon: 'fa fa-question-circle',
      accept: () => {
        Utils.blockUI();
        this.inspectionOrderService.
          deletePropertyPhoto(this.currentIoId, propertyPhoto.id).
          takeUntil(this.stop$).
          finally(() => {
            Utils.unblockUI();
          }).
          subscribe(()=> {
            this.removePhoto(propertyPhoto);
          }
        );
      },
    });
  }

  removePhoto(propertyPhotoToDelete: any) {
    let index = 0;

    // Find PhotoType
    let currentPhotoType = this.photoType.find(function (type) {
      return type.id == propertyPhotoToDelete.photoTypeId;
    });

    // Find PhotoTypeGroup
    let currentPhotoTypeGroup = this.photoTypeGroup.find(function (group) {
      return group.id == currentPhotoType.groupId;
    });

    // Delete Photo
    if (currentPhotoType && currentPhotoTypeGroup) {
      let existingPhoto = this.propertyPhoto[currentPhotoTypeGroup.name][currentPhotoType.name].find(function (photo) {
        if (photo.id != propertyPhotoToDelete.id) {
          index++;
        }
        return photo.id == propertyPhotoToDelete.id;
      });
      if (existingPhoto) this.propertyPhoto[currentPhotoTypeGroup.name][currentPhotoType.name].splice(index, 1);
    }else{
      Utils.showError("There's an error while deleting the photo.");
    }
  }

  hasError(name: string) {
    let e = this.getFormControl(name);
    return e && (e.dirty || e.touched) && !e.valid
  }

  getFormControl(name: string) {
    return this.propertyPhotoForm.get(name);
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
  }
}
