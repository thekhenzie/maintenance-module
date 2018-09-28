import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Table } from 'primeng/components/table/table';
import { Column } from '../../../shared/components/pArtTable/models/column';
import { ConfirmationService } from 'primeng/components/common/confirmationservice';
import { PrimeTableUtils } from '../../../shared/PrimeTableUtils';
import { GenericEnumeration } from '../../../shared/models/genericenumeration';
import { CommonService } from '../../../core/services/common.service';
import { IPaginationResult } from '../../../shared/models/paginationresult';
@Component({
  selector: 'app-maintenancemanagement',
  templateUrl: './maintenancemanagement.component.html',
  styleUrls: ['./maintenancemanagement.component.css'],
  providers: [ConfirmationService]
})
export class MaintenancemanagementComponent implements OnInit {
  genericForm: FormGroup;
  noRecordColspan: number = 0;
  display: boolean = false;
  showTableLoading: boolean = false;
  totalRecord: number = 0;
  isEditable: boolean;
  isNewEnumeration: boolean;
  viewOnly: boolean;
  idSection: string;
  nameSection: string;
  isActiveSection: boolean;
  indexOfNote: number;
  genericEnumerationList: GenericEnumeration[];
  selectedGenericEnumeration: GenericEnumeration;
  paginationResult: IPaginationResult<GenericEnumeration>[];

  public firstRowOffset: number;

  constructor(private genericService: CommonService,
    private route: ActivatedRoute,
    private conf: ConfirmationService,
    private fb: FormBuilder) {

    debugger;
  }

  @ViewChild('pTable') public pTable: Table;

  ngOnInit() {
    this.genericForm = this.fb.group({
      'genId': new FormControl('', Validators.required),
      'genName': new FormControl('', Validators.required),
      'genIsActive': new FormControl('', Validators.required)
    });


    this.pTable.columns = [
      new Column({ field: "id", header: "ID" }),
      new Column({ field: "name", header: "Name" }),
      new Column({ field: "isActive", header: "IsActive"}),
      // new Column({ field: "sortOrder", header: "Sort Order" }),
      new Column({ field: "action", header: "", sortable: false, width: '200' })
    ];

    this.noRecordColspan = this.pTable.columns.filter(c => c.visible).length;
    PrimeTableUtils.setDefaults(this.pTable);
  }

  newComment(): void {
    this.display = true;
    this.viewOnly = false;
    this.isEditable = false;
    this.display = true;
    this.isNewEnumeration = true;
    this.selectedGenericEnumeration = new GenericEnumeration();
  }

  getCloseModal(closeModal): void {
    this.display = closeModal;
  }

  paginate(event) {
    setTimeout(() => {
      this.showTableLoading = true;
      // this.globalService.postGenericList<IPaginationResult<Maintenance>>(
      //   "InspectionNotesList",
      //   event,
      //   this.searchFilterFinal,
      //   this.pTable.columns.map(c => c.field),
      //   null,
      //   {
      //     inspectionOrderId: this.route.snapshot.params['id']
      //   }
      // )

      this.genericService.getGenericList<GenericEnumeration>('OrderManagement.FramingType')
        .subscribe(paginationResult => {
          // this.paginationResult = paginationResult;
          this.genericEnumerationList = paginationResult;

          // this.maintenanceList = this.paginationResult;
          // for (var res of this.paginationResult) {
          //   this.maintenanceList.push(res);
          // }
          this.totalRecord = this.genericEnumerationList.length;

        },
          err => {
            console.log('error')
          },
          () => {
            this.showTableLoading = false;
            this.firstRowOffset = event.first;
          });

    });
  }

  resetTable(resetTable) {
    if (resetTable) {
      this.pTable.reset();
    }
  }

  viewNotes(notes) {
    this.isNewEnumeration = false;
    this.viewOnly = true;
    this.display = true;
    this.selectedGenericEnumeration = notes;
    this.idSection = this.selectedGenericEnumeration.id;
    this.nameSection = this.selectedGenericEnumeration.name;
    this.isActiveSection = this.selectedGenericEnumeration.isActive;
    this.isEditable = true;
  }

  editNotes(notes) {
    this.selectedGenericEnumeration = notes;
    this.isNewEnumeration = false;
    this.viewOnly = false;
    this.display = true;
    this.indexOfNote = this.genericEnumerationList.indexOf(this.selectedGenericEnumeration);
    this.idSection = this.selectedGenericEnumeration.id;
    this.nameSection = this.selectedGenericEnumeration.name;
    this.isActiveSection = this.selectedGenericEnumeration.isActive;
    this.isEditable = false;
  }

}
