import { DatePipe } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MenuItem } from 'primeng/components/common/menuitem';
import { SelectItem } from 'primeng/components/common/selectitem';
import { Table } from 'primeng/table';
import 'rxjs/add/operator/finally';
import swal from 'sweetalert2';
import { AuthService } from '../../../core/services/auth.service';
import { CommonService } from '../../../core/services/common.service';
import { LocalStorageService } from '../../../core/services/localStorageService';
import { InspectionOrderService } from '../../../core/services/ordermanagement/inspection-order.service';
import { InspectionStatusService } from '../../../core/services/ordermanagement/inspectionstatus.service';
import { MitigationStatusService } from '../../../core/services/ordermanagement/mitigationstatus.service';
import { UserActivityLogService } from '../../../core/services/ordermanagement/user-activity-log.service';
import { UtilityService } from '../../../core/services/utility.service';
import { BaseComponent } from '../../../shared/BaseComponent';
import { Column } from '../../../shared/components/pArtTable/models/column';
import { AppSettings } from '../../../shared/models/appSettings';
import { Filter } from '../../../shared/models/datatable/filter';
import { InspectionStatus } from '../../../shared/models/ordermanagement/inspectionstatus';
import { MitigationStatus } from '../../../shared/models/ordermanagement/mitigationstatus';
import { OrderManagement } from '../../../shared/models/ordermangement';
import { IPaginationResult } from '../../../shared/models/paginationresult';
import { CategoryConstants } from '../../../shared/models/user-activity-category-constants';
import { PrimeTableUtils } from '../../../shared/PrimeTableUtils';
import { RoleConstants } from '../../../shared/roleconstants';
import Utils from '../../../shared/Utils';

@Component({
  selector: 'app-ordermanagement',
  templateUrl: './ordermanagement.component.html',
  styleUrls: ['./ordermanagement.component.css'],
  providers: [CommonService]
})
export class OrdermanagementComponent extends BaseComponent implements OnInit {
  rangeDates: string[] = [];
  inceptionRangeDates: string[] = [];
  filterByDate: boolean = false;
  completeAddress: string[];
  selectedInspectionOrder: OrderManagement;
  idString: string;
  isFirstNavigate: boolean;
  currentUser: string;

  orderManagementList: OrderManagement[];
  items: MenuItem[];
  noRecordColspan: number = 0;
  recPerPage: number = 10;
  days: SelectItem[];
  selectedDays: string;

  mitigationSelect: string;
  inspectionSelect: string;
  getMitigationStatus: string = "MitigationStatus";
  getInspectionStatus: string = "InspectionStatus";
  mitigationStatus: MitigationStatus[];
  inspectionStatus: InspectionStatus[];
  selectedStatus: InspectionStatus;
  selectedInspector: string;
  selectedMitigation: MitigationStatus;
  itemsPerPage: SelectItem[];
  selectedItemsPerPage: number[] = [10, 20, 50, 100];
  minItem: number;
  maxItem: number;
  totalRecord: number = 0;
  rowNum: number;
  minNum: number;
  maxNum: number;
  paginationResult: IPaginationResult<OrderManagement>;
  showTableLoading: boolean = false;
  searchFilter: string;

  private searchFilterFinal: string = "";
  scheduledDate: Date;
  appSettings: AppSettings = new AppSettings();
  dateFormat: string;
  public firstRowOffset: number;

  inspectorList: SelectItem[];

  constructor(
    private globalService: CommonService,
    private fb: FormBuilder,
    private auth: AuthService,
    private route: ActivatedRoute,
    private router: Router,
    private inspectionOrderService: InspectionOrderService,
    public utilityService: UtilityService,
    private datePipe: DatePipe,
    private getMitigationStatusService: MitigationStatusService,
    private getInspectionOrderStatus: InspectionStatusService,
    private localService: LocalStorageService,
    private userActivityService: UserActivityLogService) {
    super();
    this.completeAddress = ["streetAddress1", "streetAddress2", "city", "state", "zipCode"];

    this.days = [
      { label: '0-19', value: '0-19' },
      { label: '20-39', value: '20-39' },
      { label: '40 and above', value: '40 and above' }
    ];

    this.isFirstNavigate = true;
    this.searchFilter = "";
    this.searchFilterFinal = "";
  }

  @ViewChild('pTable') public pTable: Table;

  ngOnInit() {
    Utils.unblockUI();
    this.auth.currentUserRole = this.auth.getRoles().toString();

    this.auth.currentUserRole = this.auth.getRoles().toString();
    this.currentUser = this.localService.getUserName();
    // if (this.auth.currentUserRole == RoleConstants.Inspector) {
    // }
      
    this.getMitigationStatusService.getMitigationStatusList(this.getMitigationStatus).then(mitigationStatus => {
      this.mitigationStatus = mitigationStatus;
      if (this.route.snapshot.params['mitigation']) {
        let id = this.route.snapshot.params['mitigation'];
        this.selectedMitigation = this.mitigationStatus.find(function (mitigation) {
          return id == mitigation.id;
        });
      }
    });
    this.getInspectionOrderStatus.getInspectionStatusList(this.getInspectionStatus).then(inspectionStatus => {
      this.inspectionStatus = inspectionStatus;
      if (this.route.snapshot.params['status']) {
        let id = this.route.snapshot.params['status'];
        this.selectedStatus = this.inspectionStatus.find(function (inspection) {
          return id == inspection.id;
        });
      }
    });
  
    this.inspectionOrderService.getUserListForDropdown().then(data => {
      this.inspectorList = data;
      console.log(data);
    });

    this.pTable.columns = [
      new Column({ field: "item", header: "Item", sortable: false, width: '50' }),
      new Column({ field: "policyNumber", header: "Policy #" }),
      new Column({ field: "insuredName", header: "Insured Name" }),
      new Column({ field: "streetAddress1", header: "Location" }),
      new Column({ field: "inspectionDate", header: "Inspection Date" }),
      new Column({ field: "inceptionDate", header: "Inception Date" }),
      new Column({ field: "inspector", header: "Inspector" }),
      new Column({ field: "status", header: "Status" }),
      new Column({ field: "mitigationStatus", header: "Mitigation Status" }),
      new Column({ field: "action", header: "Action", sortable: false, width: '104' })
    ];

    this.noRecordColspan = this.pTable.columns.filter(c => c.visible).length;
    PrimeTableUtils.setDefaults(this.pTable);
  }

  paginate(event) {
    setTimeout(() => {
      let filters: Filter[] = [];

      if (!this.selectedDays &&
        !this.selectedStatus &&
        !this.selectedMitigation &&
        !this.searchFilter &&
        this.isFirstNavigate
      ) {

        if(this.route.snapshot.params['inspector']){
          this.searchFilter = `\"${this.route.snapshot.params['inspector']}\"`;
          this.searchFilterFinal = `\"${this.route.snapshot.params['inspector']}\"`;
        }

        if (this.route.snapshot.params['status'] && this.route.snapshot.params['days']) {
          this.selectedDays = this.route.snapshot.params['days'];
          filters.push(new Filter({
            Field: "StatusId",
            Operator: "eq",
            Value: this.route.snapshot.params['status'],
            IsExactSearch: true
          }));
          filters.push(new Filter({
            Field: "DateDifference",
            Operator: "eq",
            Value: this.route.snapshot.params['days'],
            IsExactSearch: true
          }));
        }

        if (this.route.snapshot.params['mitigation']) {
          filters.push(new Filter({
            Field: "MitigationId",
            Operator: "eq",
            Value: this.route.snapshot.params['mitigation'],
            IsExactSearch: true
          }));
        }

        this.isFirstNavigate = false;
      }

      if (this.auth.currentUserRole == RoleConstants.Inspector) {
        filters.push(new Filter({
          Field: "Username",
          Operator: "eq",
          Value: this.currentUser,
          IsExactSearch: true
        }));
      }

      if (this.selectedStatus) {
        this.inspectionSelect = this.selectedStatus.name;
        filters.push(new Filter({
          Field: "status",
          Operator: "eq",
          Value: this.inspectionSelect,
          IsExactSearch: true
        }));
      this.userActivityService.sendEvent(CategoryConstants.FilterList, 'order-management', CategoryConstants.FilterByStatus);
      }

      if (this.selectedInspector) {
        filters.push(new Filter({
          Field: "inspectorId",
          Operator: "eq",
          Value: this.selectedInspector,
          IsExactSearch: true
        }));
      }

      if (this.selectedMitigation) {
        this.mitigationSelect = this.selectedMitigation.name;
        filters.push(new Filter({
          Field: "MitigationStatus",
          Operator: "eq",
          Value: this.mitigationSelect,
          IsExactSearch: true
        }));
        this.userActivityService.sendEvent(CategoryConstants.FilterList, 'order-management', CategoryConstants.FilterByMitigationStatus);
      }

      if (this.selectedDays) {
        filters.push(new Filter({
          Field: "DateDifference",
          Operator: "eq",
          Value: this.selectedDays,
          IsExactSearch: true
        }));
        this.userActivityService.sendEvent(CategoryConstants.FilterList, 'order-management', CategoryConstants.FilterByDays);
      }

      if (this.hasValidDateRange()) {
        filters.push(
          {
            "Field": "inspectionDate",
            "Value": this.rangeDates[0],
            "Operator": "gte"
          });
        filters.push(
          {
            "Field": "inspectionDate",
            "Value": this.rangeDates[1],
            "Operator": "lte"
          });
      }

      if(this.hasValidInceptionDateRange()) {
        filters.push(
        {
          "Field": "inceptionDate",
          "Value": this.inceptionRangeDates[0],
          "Operator": "gte"
        });
        filters.push(
        {
          "Field": "inceptionDate",
          "Value": this.inceptionRangeDates[1],
          "Operator": "lte"
        });
      }

      this.showTableLoading = true;
      this.globalService.postGenericList<IPaginationResult<OrderManagement>>(
        "InspectionList",
        event,
        this.searchFilterFinal,
        this.getFilterColumns(),
        filters
      ).finally(() => {
        this.showTableLoading = false;
      }).subscribe(paginationResult => {
        this.paginationResult = paginationResult;
        this.orderManagementList = this.paginationResult.results;
        this.totalRecord = this.paginationResult.totalRecords;

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

  searchOrderManagement() {
    // todo set summary for table. filtered by, total number of rows, etc
    // sample header filter
    // number of rows per page]
    if (this.searchFilter == "") {
      Utils.showError("Please provide search keyword");
    }
    else {
      this.searchFilterFinal = this.searchFilter;
      this.resetTable();
    }
  }

  filterOrderManagement(dates) {
    if (this.hasValidDateRange()) this.resetTable();
    this.userActivityService.sendEvent(CategoryConstants.FilterList, 'order-management', CategoryConstants.FilterByInspectionDate);
  }

  filterByInceptionDate(dates) {
    if(this.hasValidInceptionDateRange()) this.resetTable();
  }

  hasValidDateRange() {
    return !(
      !!!this.rangeDates ||  // not null and undefined
      !this.rangeDates.length || // array not empty
      this.rangeDates.length < 2 || // array items not less than 2
      this.rangeDates[0] == null || // ensure item 1 is not null
      this.rangeDates[1] == null // ensure item 2 is not null
    );
  }

  hasValidInceptionDateRange() {
    return !(
      !!!this.inceptionRangeDates ||  // not null and undefined
      !this.inceptionRangeDates.length || // array not empty
      this.inceptionRangeDates.length < 2 || // array items not less than 2
      this.inceptionRangeDates[0] == null || // ensure item 1 is not null
      this.inceptionRangeDates[1] == null // ensure item 2 is not null
    );
  }

  clearFilterDate() {
    this.rangeDates = [];
    this.inceptionRangeDates = [];
    this.resetTable();
  }

  resetTable() {
    this.pTable.reset();
  }

  clearFilter() {
    this.filterByDate = false;
    this.rangeDates = [];
    this.inceptionRangeDates = [];
    this.selectedStatus = null;
    this.selectedInspector = null;
    this.selectedMitigation = null;
    this.selectedDays = null;
    this.searchFilter = "";
    this.searchFilterFinal = null;
    this.resetTable();
  }

  showOrHideDateFilter() {
    if (this.selectedStatus) {
        this.filterByDate = (this.selectedStatus.name == "Scheduled");
        if(!this.filterByDate) {
          this.rangeDates = [];
        }
    }
    if (!this.selectedStatus) {
      this.rangeDates = [];
      this.filterByDate = false;
    }

    this.resetTable();
  }

  getFilterColumns() {
    let oldColumns = this.pTable.columns.map(c => c.field).filter(i => i != "item");
    let withNewColumns = oldColumns.concat(this.completeAddress);
    return withNewColumns;
  }

  searchByEnterKey(event) {
    if (event.keyCode == 13) {
      this.searchOrderManagement();

      this.userActivityService.sendEvent(CategoryConstants.FilterList, 'order-management', 'Search Inspection Order');
    }
  }
  
  isLocked(rowData: OrderManagement): Boolean {
    return rowData.isLocked; // && this.currentUser != rowData.isLockedByUserName;
  }
  
  unlockIO(rowData: OrderManagement) {
    swal({
      title: 'Are you sure?',
      text: "Unlocking this will make the IO in mobile unable to sync online. Proceed?",
      type: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, unlock it!'
    }).then((result) => {
      if (result.value) {
        this.inspectionOrderService.unlockIO(rowData.id).takeUntil(this.stop$).subscribe(res => {
          rowData.isLocked = false;
        },
        err => {
          Utils.showGenericHttpErrorResponse(err);
        });
      }
    })
  }
  // class PaginationResultClass implements IPaginationResult<Contact>{
  //   constructor (public results, public pageNo, public recordPage, public totalRecords) 
  //   {

  //   }
  // }
}
