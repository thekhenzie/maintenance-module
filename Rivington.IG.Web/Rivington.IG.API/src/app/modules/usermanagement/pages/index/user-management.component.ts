import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ConfirmationService } from 'primeng/components/common/confirmationservice';
import { SelectItem } from 'primeng/components/common/selectitem';
import { Table } from 'primeng/table';
import { CommonService } from '../../../core/services/common.service';
import { ImageService } from '../../../core/services/image.service';
import { AccountRoleService } from '../../../core/services/ordermanagement/accountrole.service';
import { UserManagementservice } from '../../../core/services/usermanagement/user-management.service';
import { BaseComponent } from '../../../shared/BaseComponent';
import { Column } from '../../../shared/components/pArtTable/models/column';
import { Constants } from '../../../shared/constants';
import { Filter } from '../../../shared/models/datatable/filter';
import { Image } from '../../../shared/models/ordermanagement/image';
import { IPaginationResult } from '../../../shared/models/paginationresult';
import { User } from '../../../shared/models/user';
import { PrimeTableUtils } from '../../../shared/PrimeTableUtils';
import Utils from '../../../shared/Utils';
import { ApplicationUserView } from '../../../shared/viewmodel/user-management/application-user-view';
import { LocalStorageService } from '../../../core/services/localStorageService';
import { UserActivityLogService } from '../../../core/services/ordermanagement/user-activity-log.service';
import { CategoryConstants } from '../../../shared/models/user-activity-category-constants';
import { AuthService } from '../../../core/services/auth.service';
import { RoleConstants } from '../../../shared/roleconstants';

@Component({
  selector: 'app-user-management',
  templateUrl: './user-management.component.html',
  styleUrls: ['./user-management.component.css'],
  providers: [ConfirmationService]
})
export class UserManagementComponent extends BaseComponent implements OnInit {
  file: string;
  display: boolean;
  accountRole: SelectItem[];
  selectedRole: string;
  userform: FormGroup;
  userList: ApplicationUserView[];
  addressColumns: string[];
  
  minItem: number;
  maxItem: number;
  totalRecord: number = 0;
  showTableLoading: boolean = false;
  searchFilter: string = "";
  noRecordColspan: number = 0;

  private searchFilterFinal: string = "";
  public firstRowOffset: number;

  @ViewChild('inputImage') public inputImage: ElementRef;
  
  constructor(
    private fb: FormBuilder,
    private userService: UserManagementservice,
    private conf: ConfirmationService,
    private role: AccountRoleService,
    private globalService: CommonService,
    private router: Router,
    private imageService: ImageService,
    private localService: LocalStorageService,
    private userActivityService: UserActivityLogService,
    private auth: AuthService
  ) {
      super();
      this.addressColumns = ["streetAddress1","streetAddress2","city","state","zipCode"];
     }

  @ViewChild('pTable') public pTable: Table;
  
  ngOnInit() {
    this.auth.currentUserRole = this.auth.getRoles().toString();
    this.role.getRoles().takeUntil(this.stop$).subscribe(accountRole => this.accountRole = accountRole);

    this.userform = this.fb.group({
      'firstName': new FormControl('', Validators.required),
      'lastName': new FormControl('', Validators.required),
      'middleName': new FormControl(''),
      'accountRole': new FormControl('', Validators.required),
      'emailAddress': new FormControl('', Validators.compose([Validators.required, Validators.pattern(Constants.regExpEmailFormat)]))
    });

    this.pTable.columns = [
      new Column({ field: "profilePhoto", header: "Photo", sortable: false,  width: '65'}),
      new Column({ field: "firstName", header: "Name" }),
      new Column({ field: "streetAddress1", header: "Location" }),
      new Column({ field: "userStatus", header: "Status" }),
      new Column({ field: "roleName", header: "Role" }),
      new Column({ field: "action", header: "Action", sortable: false, width: '63' })
    ];

    this.noRecordColspan = this.pTable.columns.filter(c => c.visible).length;
    PrimeTableUtils.setDefaults(this.pTable);

    this.userActivityService.sendEvent( CategoryConstants.View, 'user-management', CategoryConstants.View + ' User Management Page');
  }

  newInspector() {
    this.display = true;
  }

  hasError(name: string) {
    var e = this.getFormControl(name);
    return e && (e.dirty || e.touched) && !e.valid;
  }

  getFormControl(name: string) {
    return this.userform.get(name);
  }

  addInspector() {
    Utils.blockUI();
    var tempUser = new User(
      {
        FirstName: this.userform.value.firstName,
        LastName: this.userform.value.lastName,
        MiddleName: this.userform.value.middleName,
        Email: this.userform.value.emailAddress,
        Role: this.userform.value.accountRole,
      }
    );

    if (!!!tempUser.profilePhoto) {
      tempUser.profilePhoto = null;
    }
    else {
      tempUser.profilePhoto = new Image({
        file: this.file.split(',')[1]
      })
      delete tempUser.profilePhoto["id"];
    }
    

    this.userService.postUser(tempUser).takeUntil(this.stop$)
    .finally(() => {
      // Utils.unblockUI();
    })
    .subscribe(
      user => {
        this.display = false;
        this.userform.reset();
        this.inputImage.nativeElement.value = "";
        this.file = null;
        this.userform.markAsPristine();
        this.resetTable();
        Utils.showSuccess("New user has been added!");
      },
      error => {
        Utils.showGenericHttpErrorResponse(error);
      },
      () => {
        Utils.unblockUI();
      });

      this.userActivityService.sendEvent(CategoryConstants.Create, 'user-management', CategoryConstants.CreatedUser);
  }

  closeModal() {
    if (this.userform.dirty && (this.userform.value.firstName != "" || this.userform.value.lastName != ""
      || this.userform.value.middleName != "" || this.userform.value.emailAddress != "")) {
      this.conf.confirm({
        message: 'Do you want to discard changes?',
        accept: () => {
          this.cancelCom();

          this.userActivityService.sendEvent(CategoryConstants.Update, 'user-management', CategoryConstants.CancelledCreatingUser);
        }
      });
    }
    else {
      this.userform.markAsPristine();
      this.display = false;
      this.inputImage.nativeElement.value = "";
      this.file = null;
      this.userform.reset();
    }
  }

  cancelCom() {
    this.userform.markAsPristine();
    this.display = false;
    this.inputImage.nativeElement.value = "";
    this.file = null;
    this.userform.reset();
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

  paginate(event) {    
    setTimeout(() => {
      let filters: Filter[] = [];

      // start role-based
      // if (this.auth.currentUserRole) {
      //   filters.push(new Filter({
      //     Field: "RoleName",
      //     Operator: "eq",
      //     Value: this.auth.currentUserRole,
      //     IsExactSearch: true
      //   }));
      // }
      // end role-based

      if (this.selectedRole) {
        filters.push(new Filter({
          Field: "RoleId",
          Operator: "eq",
          Value: this.selectedRole,
          IsExactSearch: true
        }));
      }

      this.showTableLoading = true;
      this.globalService.postGenericList<IPaginationResult<ApplicationUserView>>(
        "FilterUserList",
        event,
        this.searchFilterFinal,
        this.getFilterColumns(),
        filters
      ).finally(() => {
        this.showTableLoading = false;        
      }).map((data) => {
        if(data && data.results) {
          data.results.forEach(item => {
            if(!!!item.profilePhotoPath)
              item.profilePhotoPath = Constants.defaultUserProfileImage;
            if(!!!item.thumbnailPath)
              item.thumbnailPath = Constants.defaultUserProfileImage;
          });
        }
        return data;
      }).subscribe(paginationResult => {
        this.userList = paginationResult.results;
        this.totalRecord = paginationResult.totalRecords;
        
        if ((event.first + 10) > this.totalRecord) {
          this.maxItem = this.totalRecord;
          this.minItem = event.first + 1;
        }
        else {
          this.maxItem = event.first + event.rows;
          this.minItem = this.maxItem - (event.rows - 1);
        }
        if (event.rows > this.totalRecord) {
          this.maxItem = this.totalRecord;
        }
        if (this.totalRecord == 0) {
          this.maxItem = 0;
          this.minItem = 0;
        }
      },
      err => {
      },
      () => {
        this.firstRowOffset = event.first;
      });
    })
  }

  searchUserManagement() {
    // todo set summary for table. filtered by, total number of rows, etc
    // sample header filter
    // number of rows per page]
    if(this.searchFilter == "") {
        Utils.showError("Please provide search keyword");
    }
    else {
    this.searchFilterFinal = this.searchFilter;
    this.resetTable();
    }
  }

  resetTable() {
    this.pTable.reset();
  }

  clearFilter() {
    this.selectedRole = null;
    this.searchFilterFinal = null;
    this.searchFilter = "";
    this.resetTable();
  }

  onRowSelect(selectedUser) {
    this.router.navigate(["/user-management/profile-info/" + selectedUser.id]);
  }

  getFilterColumns() {
    let oldColumns = this.pTable.columns.map(c => c.field).filter(i => i!="action" && i!="profilePhoto");
    let withNewColumns = oldColumns.concat(this.addressColumns);
    return withNewColumns;
  }

  searchByEnterKey(event) {
    if (event.keyCode == 13) {
      this.searchUserManagement();
    }
  }
}
