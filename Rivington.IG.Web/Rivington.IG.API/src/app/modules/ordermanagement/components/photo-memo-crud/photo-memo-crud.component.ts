import { Component, ElementRef, Input, OnInit, ViewChild, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ConfirmationService } from 'primeng/primeng';
import { Table } from 'primeng/table';
import { AuthService } from '../../../core/services/auth.service';
import { CommonService } from '../../../core/services/common.service';
import { ImageService } from '../../../core/services/image.service';
import { MitigationService } from '../../../core/services/ordermanagement/inspection-order-checklist-section/mitigation.service';
import { BaseComponent } from '../../../shared/BaseComponent';
import { Column } from '../../../shared/components/pArtTable/models/column';
import { InspectionOrder } from '../../../shared/models/ordermanagement/inspection-order';
import { InspectionOrderWildfireAssessment } from '../../../shared/models/ordermanagement/inspection-order/checklist/mitigation/InspectionOrderWildfireAssessment';
import { InspectionOrderWildfireAssessmentMitigation } from '../../../shared/models/ordermanagement/inspection-order/checklist/mitigation/InspectionOrderWildfireAssessmentMitigation';
import { PhotoMemo } from '../../../shared/models/ordermanagement/inspection-order/PhotoMemo';
import { IPaginationResult } from '../../../shared/models/paginationresult';
import { PrimeTableUtils } from '../../../shared/PrimeTableUtils';
import Utils from '../../../shared/Utils';
import { ImageWithDescriptionVm } from '../../../shared/viewmodel/ordermanagement/image-with-description-vm';
import { PlatformLocation } from '@angular/common';
import { InspectionOrderService } from '../../../core/services/ordermanagement/inspection-order.service';
import { InspectionOrderChecklistWildFireService } from '../../../core/services/ordermanagement/inspection-order-checklist-section/wildfire.service';
import { LocalStorageService } from '../../../core/services/localStorageService';
import { MitigationStatusConstants } from '../../../shared/mitigation-status-constants';
import { IfStmt } from '@angular/compiler';

@Component({
  selector: 'app-photo-memo-crud',
  templateUrl: './photo-memo-crud.component.html',
  styleUrls: ['./photo-memo-crud.component.css'],
  providers: [ConfirmationService]
})
export class PhotoMemoCrudComponent extends BaseComponent implements OnInit {

  // Parent
  @Input() getUrl: string;
  @Input() postUrl: string;
  @Input() deleteUrl: string;
  @Input() headerLabel: string;
  @Input() addButtonLabel: string;

  // Child
  @Input() isChild: boolean;
  @Input() getUrlChild: string;
  @Input() postUrlChild: string;
  @Input() deleteUrlChild: string;
  @Input() headerLabelChild: string;
  @Input() addButtonLabelChild: string;
  @Input() parentMitigationId: string;
  @Output() isChildListUpdated: EventEmitter<boolean>;

  @Input() isWildFireMitigation: boolean;
  @Input() isInsured: boolean;

  form: FormGroup;
  currentIoId: string;
  showModalForm: boolean;
  isNew: boolean;
  file: string;
  showComments: boolean;
  parentId: string;
  isChildCountUpdated: boolean;
  currentUser: string;
  editedBy: string;
  io: InspectionOrder;

  // table
  list: ImageWithDescriptionVm[];
  totalRecord: number;
  firstRowOffset: number;
  searchFilterFinal: string;
  showTableLoading: boolean;
  noRecordColspan: number = 0;

  constructor(
    private auth: AuthService,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private confirmationService: ConfirmationService,
    private mitigationService: MitigationService,
    private globalService: CommonService,
    private imageService: ImageService,
    private urlLocation: PlatformLocation,
    public ioService: InspectionOrderService,
    public wildFireService: InspectionOrderChecklistWildFireService,
    private localService: LocalStorageService
  ) {
    super();

    this.list = [];
    this.showTableLoading = false;
    this.searchFilterFinal = "";
    this.totalRecord = 0;
    this.isNew = true;
    this.isChildListUpdated = new EventEmitter<boolean>();
    this.io = new InspectionOrder();

    urlLocation.onPopState(() => {
      this.showModalForm = false;
      $(".ui-widget-overlay.ui-dialog-mask").trigger("click");
    });
  }

  @ViewChild('inputImage') public inputImage: ElementRef;
  @ViewChild('pTable') public pTable: Table;

  ngOnInit() {
    this.route.params.subscribe(params => {
      let paramId = params["id"];
      this.currentIoId = paramId;
    });

    this.currentUser = this.localService.getUserName();
    this.auth.currentUserRole = this.auth.getRoles().toString();

    this.form = this.fb.group({
      'id': new FormControl(),
      'imageId': new FormControl(),
      'file': new FormControl('', Validators.required),
      'description': new FormControl('', Validators.required),
      'status': new FormControl(false)
    });

    this.pTable.columns = [
      new Column({ field: "file", header: "Photo", sortable: false, width: '170' }),
      new Column({ field: "description", header: "Memo", sortable: false }),
      new Column({ field: "control", header: "", sortable: false, width: '150' })
    ];

    if (!this.isChild) {
      let statusColumn = new Column({ field: "control", header: "Complete?", sortable: false, width: '125' });
      this.pTable.columns.splice(2, 0, statusColumn);
    }
    else {
      let statusColumn = new Column({ field: "control", header: "User", sortable: false, width: '200' });
      this.pTable.columns.splice(2, 0, statusColumn);
    }

    this.noRecordColspan = this.pTable.columns.filter(c => c.visible).length;
    PrimeTableUtils.setDefaults(this.pTable);

    // For Insured Page
    if (this.isInsured && !this.wildFireService.isWildFireRequired) {
      this.ioService.getInspectionOrders("InspectionList", this.currentIoId).then(
        data => {
          this.ioService.inspectionOrder = data[0];
          this.io = data[0];
          if (this.ioService.inspectionOrder){
            this.wildFireService.isWildFireRequired = this.ioService.inspectionOrder.policy.wildfireAssessmentRequired;
            this.ioService.mitigationStatusId = this.io.policy.mitigationStatusId;
          } 
        });
    }
  }

  paginate(event) {
    setTimeout(() => {

      if (this.ioService.inspectionOrder) this.io = this.ioService.inspectionOrder;

      let fetchId = this.route.snapshot.params['id'];
      if (this.isChild) {
        fetchId = this.parentMitigationId;
      }
      this.showTableLoading = true;
      this.globalService.postGenericList<IPaginationResult<PhotoMemo>>(
        this.getUrl,
        event,
        this.searchFilterFinal,
        this.pTable.columns.map(c => c.field),
        null,
        {
          inspectionOrderId: fetchId
        }
      ).finally(() => {
        this.showTableLoading = false;
      })
        .subscribe(paginationResult => {
          let getResult: IPaginationResult<PhotoMemo> = paginationResult;

          let list: ImageWithDescriptionVm[] = [];
          if (paginationResult && paginationResult.results) {
            paginationResult.results.forEach(item => {
              if (this.isChild) {
                if(item.user){ // For Inspector
                  list.push({
                    id: item.id,
                    imageId: item.imageId,
                    fileName: item.image.fileName,
                    filePath: item.image.filePath,
                    thumbnailPath: item.image.thumbnailPath,
                    description: item.description,
                    childMitigationCount: item.childMitigationCount,
                    displayName: item.user.firstName + " " + item.user.lastName,
                    userName: item.user.userName
                  });
                }
                else{ // For Insured
                  list.push({
                    id: item.id,
                    imageId: item.imageId,
                    fileName: item.image.fileName,
                    filePath: item.image.filePath,
                    thumbnailPath: item.image.thumbnailPath,
                    description: item.description,
                    childMitigationCount: item.childMitigationCount,
                    displayName: this.io.policy.insuredFirstName + " " + this.io.policy.insuredLastName,
                    userName: this.io.id
                  });
                }
              }
              else {
                list.push({
                  id: item.id,
                  imageId: item.imageId,
                  fileName: item.image.fileName,
                  filePath: item.image.filePath,
                  thumbnailPath: item.image.thumbnailPath,
                  description: item.description,
                  childMitigationCount: item.childMitigationCount,
                  status: item.status,
                });
              }
            });
          }

          if (this.getUrl == "RetrieveNonWildfireAssessmentMitigationRequirements"
            || this.getUrl == "RetrieveWildfireAssessmentMitigationRequirements") {
            this.mitigationService.getMitigationRequirementsCount(this.currentIoId).takeUntil(this.stop$).subscribe(mitigationCount => {
              this.ioService.incompleteMitigationCount = mitigationCount;
            })
          }

          this.list = list;
          this.totalRecord = getResult.totalRecords;
        },
          err => {
          },
          () => {
            this.firstRowOffset = event.first;
          });

    });
  }

  showAddEditModalForm(display: boolean) {
    if (!display) {
      if (this.form.dirty) {
        this.confirmationService.confirm({
          message: 'Are you sure you want to discard changes?',
          header: 'Discard Changes',
          icon: 'fa fa-question-circle',
          accept: () => {
            this.resetFields();
            this.showModalForm = display;
            this.form.markAsPristine();
          },
          reject: () => {
            this.showModalForm = true;
          }
        });
      } else {
        this.resetFields();
        this.showModalForm = display;
      }
    }
    else {
      this.resetFields()
      this.showModalForm = display;
    }
  }

  getImageValue(event) {
    let uploadedFile = event.target.files[0];
    if (!this.imageService.validateImageSize(uploadedFile)) {
      Utils.showError("Image size exceeds 30MB.");
      this.inputImage.nativeElement.value = "";
      return; // this.removePhoto();
    }

    if (this.imageService.validateFileType(uploadedFile)) {
      Utils.showError("Upload an Image file only.");
      this.inputImage.nativeElement.value = "";
      return; // this.removePhoto();
    }

    Utils.blockUI();
    this.imageService.getOptimizedByteStringImage(uploadedFile).then(reader => {
      const interval = setInterval(() => {
        if (reader.result !== "") {
          Utils.unblockUI();
          this.file = reader.result;
          clearInterval(interval);
        }
      }, 10);
    });
  }

  save() {
    if(this.file) this.form.value.file = this.file;

    if ((this.form.value.file && this.form.value.description) || this.isChild) {
      //#region manipulate data here
      let section = "";
      let field = "";
      switch (this.postUrl) {
        case "CreateWildfireAssessmentMitigationRequirement":
          section = "wildfireAssessment";
          field = "requirements";
          break;
        case "CreateWildfireAssessmentMitigationRecommendation":
          section = "wildfireAssessment";
          field = "recommendations";
          break;
        case "CreateNonWildfireAssessmentMitigationRequirement":
          section = "property";
          field = "requirements";
          break;
        case "CreateNonWildfireAssessmentMitigationRecommendation":
          section = "property";
          field = "recommendations";
          break;
        default:
          break;
      }

      // Initialization for needed ID(s) and Image: Create/Update
      let inspectionOrder = new InspectionOrder({
        id: this.currentIoId,
        wildfireAssessment: new InspectionOrderWildfireAssessment({
          mitigation: new InspectionOrderWildfireAssessmentMitigation({
            id: this.currentIoId,
          })
        })
      });

      if (!this.isChild) {
        inspectionOrder.wildfireAssessment.mitigation.requirements = [{
          description: this.form.value.description,
          imageId: this.form.value.imageId,
          status: this.form.value.status,
          image: {
            id: this.form.value.imageId,
            file: this.form.value.file
          }
        }];

        if (!this.isNew) {
          inspectionOrder.wildfireAssessment.mitigation.requirements[0].id = this.form.value.id;
        }

        if (this.isNew) {
          delete inspectionOrder.wildfireAssessment.mitigation["id"];
          delete inspectionOrder.wildfireAssessment.mitigation.requirements[0]["imageId"];
          delete inspectionOrder.wildfireAssessment.mitigation.requirements[0].image["id"];
        }
      }
      else {
        inspectionOrder.wildfireAssessment.mitigation.requirements = [{
          id: this.parentMitigationId,
          childMitigation: [{
            description: this.form.value.description,
            imageId: this.form.value.imageId,
            userId: this.localService.getUserName(),
            image: {
              id: this.form.value.imageId,
              file: this.form.value.file
            },
          }]
        }];

        if (!this.isNew) {
          inspectionOrder.wildfireAssessment.mitigation.requirements[0].childMitigation[0].id = this.form.value.id;
        }

        if (this.isNew) {
          delete inspectionOrder.wildfireAssessment.mitigation.requirements[0].childMitigation[0]["imageId"];
          delete inspectionOrder.wildfireAssessment.mitigation.requirements[0].childMitigation[0].image["id"];
        }
      }

      if (field !== "requirements") {
        inspectionOrder.wildfireAssessment.mitigation[field] = inspectionOrder.wildfireAssessment.mitigation.requirements;
        delete inspectionOrder.wildfireAssessment.mitigation["requirements"];
      }

      if (section !== "wildfireAssessment") {
        inspectionOrder[section] = {
          id: this.currentIoId,
          nonWildfireAssessment: inspectionOrder.wildfireAssessment
        }

        delete inspectionOrder["wildfireAssessment"];
      }
      //#endregion manipulate data here

      Utils.blockUI();

      if (!this.isChild) {
        this.mitigationService.postGenericPhotoMemo(this.postUrl, inspectionOrder)
          .takeUntil(this.stop$)
          .finally(() => {
            Utils.unblockUI();
          })
          .subscribe(
            () => { // (image: Image)
              this.showModalForm = false;
              this.resetTable();
            },
            error => {
              Utils.showGenericHttpErrorResponse(error);
            })
      }
      else {
        this.mitigationService.postGenericPhotoMemo(this.postUrlChild, inspectionOrder)
          .takeUntil(this.stop$)
          .finally(() => {
            Utils.unblockUI();
          })
          .subscribe(
            () => { // (image: Image)
              this.showModalForm = false;
              this.resetTable();
              this.isChildListUpdated.emit(true);
            },
            error => {
              Utils.showGenericHttpErrorResponse(error);
            })
      }

    }
    else {
      Object.keys(this.form.controls).forEach(field => {
        const control = this.form.get(field);
        if (control instanceof FormControl) {
          control.markAsTouched({ onlySelf: true });
        }
      });

      Utils.showError("Please complete all the required fields.");
    }
  }

  view(photoMemo) {
    this.isNew = false;
    this.file = photoMemo.filePath;

    if (this.isChild) this.editedBy = photoMemo.userName;

    this.form.patchValue({
      'imageId': photoMemo.imageId,
      'file': photoMemo.filePath,
      'description': photoMemo.description,
    });

    if (!this.isChild) {
      this.form.patchValue({
        'id': photoMemo.id,
        'status': photoMemo.status
      });
    }
    this.showModalForm = true;
  }

  resetTable() {
    this.pTable.reset();
  }

  delete(photoMemo) {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete?',
      header: `Delete ${this.headerLabel}`,
      icon: 'fa fa-question-circle',
      accept: () => {
        Utils.blockUI();

        if (this.isChild) {
          this.mitigationService.deleteChildGenericPhotoMemo(
            this.deleteUrl,
            this.parentMitigationId,
            photoMemo.imageId)
            .takeUntil(this.stop$)
            .finally(() => {
              Utils.unblockUI();
            })
            .subscribe(
              onSuccess => {
                this.resetTable();
                this.isChildListUpdated.emit(true);
              },
              error => {
                Utils.showGenericHttpErrorResponse(error);
              }
            );
        }
        else {
          this.mitigationService.deleteGenericPhotoMemo(
            this.deleteUrl,
            photoMemo.id)
            .takeUntil(this.stop$)
            .finally(() => {
              Utils.unblockUI();
            })
            .subscribe(
              onSuccess => {
                this.resetTable();
              },
              error => {
                Utils.showGenericHttpErrorResponse(error);
              }
            );
        }
      }
    });
  }

  updateMitigationStatus(mitigation){
    this.form.patchValue({
      'id': mitigation.id,
      'imageId': mitigation.imageId,
      'description': mitigation.description,
      'status': mitigation.status
    });
    this.file = mitigation.filePath;
    this.isNew = false;
    this.save();
  }

  checkIfButtonDisabled(): boolean{
    if(this.isInsured){ // For Insured
      return this.ioService.mitigationStatusId != MitigationStatusConstants.OutstandingItems;
    }
    else{ // For Inspector
      return ((this.isWildFireMitigation && !this.wildFireService.isWildFireRequired) ||
        !this.ioService.checkIOBasedOnRole(this.auth.currentUserRole)) && 
        !this.ioService.checkIOMitigationBasedOnRole(this.auth.currentUserRole);
    }
  }

  viewComments(photoMemo) {
    this.showComments = true;
    if (!this.isChild) {
      this.parentId = photoMemo.id;
    }
  }

  getChildCountUpdate(isChildCountUpdated) {
    if (!this.isChild && isChildCountUpdated) {
      this.resetTable();
    }
  }

  resetFields() {
    this.form.reset();
    this.form.patchValue({
      'status': false
    });
    this.inputImage.nativeElement.value = "";
    this.file = null;
    this.isNew = true;
  }

  hasError(name: string) {
    let e = this.getFormControl(name);
    return e && (e.dirty || e.touched) && !e.valid
  }

  getFormControl(name: string) {
    return this.form.get(name);
  }
}
