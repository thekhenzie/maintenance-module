import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { FormGroup } from '@angular/forms/src/model';
import { ActivatedRoute } from '@angular/router';
import { SelectItem } from 'primeng/components/common/selectitem';
import { LocalStorageService } from '../../../core/services/localStorageService';
import { CityService } from '../../../core/services/ordermanagement/city.service';
import { InspectionOrderChecklistPropertyService } from '../../../core/services/ordermanagement/inspection-order-checklist-section/property.service';
import { InspectionOrderService } from '../../../core/services/ordermanagement/inspection-order.service';
import { StateService } from '../../../core/services/ordermanagement/state.service';
import { UserManagementservice } from '../../../core/services/usermanagement/user-management.service';
import { Constants } from '../../../shared/constants';
import { State } from '../../../shared/models/ordermanagement/state';
import { User } from '../../../shared/models/user';
import Utils from '../../../shared/Utils';
import { Image } from '../../../shared/models/ordermanagement/image';
import { BaseComponent } from '../../../shared/BaseComponent';
import { ImageService } from '../../../core/services/image.service';
import { ConfirmationService } from 'primeng/primeng';
import { UserActivityLogService } from '../../../core/services/ordermanagement/user-activity-log.service';
import { CategoryConstants } from '../../../shared/models/user-activity-category-constants';

@Component({
  selector: 'app-profileinfo',
  templateUrl: './profileinfo.component.html',
  styleUrls: ['./profileinfo.component.css'],
  providers: [ConfirmationService]
})
export class ProfileinfoComponent extends BaseComponent implements OnInit {
  isActivated: boolean;
  isNew: boolean;
  cities: SelectItem[];
  states: SelectItem[];
  file: string;
  userform: FormGroup;
  user: User;
  
  @ViewChild('inputImage') public inputImage: ElementRef;

  constructor(private fb: FormBuilder,
    private localService: LocalStorageService,
    private userManagementService: UserManagementservice,
    private propertyService: InspectionOrderChecklistPropertyService,
    private route: ActivatedRoute,
    private imageService: ImageService,
    private confirmationService: ConfirmationService,
    private userActivityService: UserActivityLogService
  ) {
      super();
      this.isActivated = true;
      this.isNew = false;
  }

  ngOnInit() {
    this.propertyService.getStates().then(states => this.states = states);

    this.userform = this.fb.group({
      'firstName': new FormControl('', Validators.required),
      'middleName': new FormControl(),
      'lastName': new FormControl('', Validators.required),
      'streetAddress1': new FormControl('', Validators.required),
      'streetAddress2': new FormControl(''),
      'state': new FormControl('', Validators.required),
      'city': new FormControl('', Validators.required),
      'zipCode': new FormControl('', Validators.required),
      'phoneNumber': new FormControl('', Validators.required),
      'mobileNumber': new FormControl('', Validators.required),
      'email': new FormControl('', Validators.compose([Validators.required, Validators.pattern(Constants.regExpEmailFormat)])),
      'isActivated': new FormControl()
    });

    let username = this.localService.getUserName();
    let userId = this.route.snapshot.params['id'];

    let userObservable;
    if(!userId) {
      userObservable = this.userManagementService.getUser(username);
    } else {
      userObservable = this.userManagementService.getUserById(userId);
    }

    Utils.blockUI();
    userObservable
    .takeUntil(this.stop$)
    .finally(() => {
      Utils.unblockUI();      
    }).subscribe(account => {
      this.user = account;
      this.file = account.profilePhoto ? account.profilePhoto.thumbnailPath : Constants.defaultUserProfileImage;
      this.userform.setValue({
        'firstName': account.firstName,
        'middleName': account.middleName,
        'lastName': account.lastName,
        'streetAddress1': account.streetAddress1,
        'streetAddress2': account.streetAddress2,
        'state': account.state,
        'city': account.city,
        'zipCode': account.zipCode,
        'phoneNumber': account.phoneNumber,
        'mobileNumber': account.mobileNumber,
        'email': account.email,
        'isActivated': account.isActivated
      });
      this.isActivated = account.isActivated;
      if(account.lastModifiedDate == null){
        this.isActivated = false;
        this.isNew = true;
      }
    });

    this.userform.get('state').valueChanges.subscribe(id => {
      if (id) {
        this.userManagementService.getCities(id).then(
          cities => this.cities = cities
        )
      } else {
        this.cities = [];
      }
    });
  }

  hasError(name: string) {
    var e = this.getFormControl(name);
    return e && (e.dirty || e.touched) && !e.valid;
  }

  getFormControl(name: string) {
    return this.userform.get(name);
  }

  getImageValue(event) {
    let uploadedFile = event.target.files[0];
    if(!this.imageService.validateImageSize(uploadedFile)) {
      Utils.showError("Image size exceeds 30MB.");
      this.inputImage.nativeElement.value = "";
      return; // this.removePhoto();
    }

    Utils.blockUI();
    this.imageService.getOptimizedByteStringImage(uploadedFile).then(reader => {
      const interval = setInterval(() => {
        if(reader.result !== "") {
          Utils.unblockUI();
          this.file = reader.result;
          clearInterval(interval);
        }
      }, 10);
    });
  }

  removePhoto() {
    this.inputImage.nativeElement.value = "";
    this.file = null;
  }

  updateCredential() {
    Utils.blockUI();
    
    var tempUser = new User({
      FirstName: this.userform.value.firstName,
      MiddleName: this.userform.value.middleName,
      LastName: this.userform.value.lastName,
      streetAddress1: this.userform.value.streetAddress1,
      streetAddress2: this.userform.value.streetAddress2,
      state: this.userform.value.state,
      city: this.userform.value.city,
      zipCode: this.userform.value.zipCode,
      phoneNumber: this.userform.value.phoneNumber,
      mobileNumber: this.userform.value.mobileNumber,
      Email: this.userform.value.email,
      profilePhoto: new Image(),
      isActivated: this.userform.value.isActivated,
    });

    let sPhoto = this.file;
    if (sPhoto) {
      if (sPhoto.startsWith(Constants.dataUri))
      {
        sPhoto = sPhoto.substring(Constants.dataUri.length).trim();
        tempUser.profilePhoto.file = sPhoto;
      }
      else
      {
        // this means that this is update
        // and image file is not changed
        tempUser.profilePhoto.file = null;
        tempUser.profilePhoto.filePath = sPhoto;
      }
      delete tempUser.profilePhoto["id"];
    }
    else {
      tempUser.profilePhoto = null;
    }
   
    Utils.blockUI();
    let id = this.route.snapshot.params['id'];
    tempUser.userName = this.localService.getUserName();
    if (id) {
      this.userManagementService.putProfileInfoViaGuid(tempUser, id)
      .takeUntil(this.stop$)
      .finally(() => {
        // Utils.unblockUI();      
      }).subscribe(
        user => {
          if(user.profilePhoto) this.file = user.profilePhoto.filePath;
          
          this.isActivated = user.isActivated;
          Utils.showSuccess("Account has been updated!");
        },
        error => {
          Utils.showGenericHttpErrorResponse(error);
        },
        () => {
          // Utils.unblockUI();
        });
    }
    else {
      this.userManagementService.putProfileInfo(tempUser)
      .takeUntil(this.stop$)
      .finally(() => {
        // Utils.unblockUI();      
      }).subscribe(
        user => {
          if(user.profilePhoto) this.file = user.profilePhoto.filePath;
          Utils.showSuccess("Your account has been updated!");
          this.userActivityService.sendEvent(CategoryConstants.Update, 'user-management/profile-info', CategoryConstants.UpdatedUserProfile);
        },
        error => {
          Utils.showGenericHttpErrorResponse(error);
        },
        () => {
          // Utils.unblockUI();
        });
    }
  }
}
