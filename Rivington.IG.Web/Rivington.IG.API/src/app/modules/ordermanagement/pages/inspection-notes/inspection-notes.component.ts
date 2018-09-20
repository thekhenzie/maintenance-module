import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ConfirmationService } from 'primeng/components/common/confirmationservice';
import { Table } from 'primeng/components/table/table';
import { CommonService } from '../../../core/services/common.service';
import { LocalStorageService } from '../../../core/services/localStorageService';
import { InspectionOrderNotesService } from '../../../core/services/ordermanagement/inspection-notes.service';
import { UtilityService } from '../../../core/services/utility.service';
import { Column } from '../../../shared/components/pArtTable/models/column';
import { InspectionOrderNotes } from '../../../shared/models/inspectionordernotes';
import { IPaginationResult } from '../../../shared/models/paginationresult';
import { PrimeTableUtils } from '../../../shared/PrimeTableUtils';
import Utils from '../../../shared/Utils';
import { UserActivityLogService } from '../../../core/services/ordermanagement/user-activity-log.service';
import { CategoryConstants } from '../../../shared/models/user-activity-category-constants';

@Component({
  selector: 'app-inspection-notes',
  templateUrl: './inspection-notes.component.html',
  styleUrls: ['./inspection-notes.component.css'],
  providers: [ConfirmationService]
})
export class InspectionNotesComponent implements OnInit {
  username: string;
  notEditable: boolean;
  indexOfNote: number;
  isNewNote: boolean;
  viewOnly: boolean;
  inspectionOrderNotesList: InspectionOrderNotes[];
  selectedInspectionOrderNote: InspectionOrderNotes;
  display: boolean = false;
  userform: FormGroup;
  commentSection: string;
  noteSubject: string;
  commentInput: string;
  outputComment: string;
  isNewComment: boolean;
  show: boolean;
  noRecordColspan: number = 0;
  userName: string;
  selectNote: string;
  isEditable: boolean;

  totalRecord: number = 0;
  private searchFilterFinal: string = "";
  showTableLoading: boolean = false;
  paginationResult: IPaginationResult<InspectionOrderNotes>;
  public firstRowOffset: number;

  constructor(public utilityService: UtilityService,
    private globalService: CommonService,
    private conf: ConfirmationService,
    private fb: FormBuilder,
    public inspectionOrderNotesService: InspectionOrderNotesService,
    private route: ActivatedRoute,
    private localService: LocalStorageService,
    private userActivityService: UserActivityLogService) {
  }

  @ViewChild('pTable') public pTable: Table;

  ngOnInit() {
    this.username = this.localService.getUserName();

    this.userform = this.fb.group({
      'comment': new FormControl('', Validators.required),
      'subject': new FormControl('', Validators.required)
    });

    this.pTable.columns = [
      new Column({ field: "subject", header: "Subject" }),
      new Column({ field: "dateModified", header: "Date Modified" }),
      new Column({ field: "modifiedBy", header: "Modified By" }),
      new Column({ field: "action", header: "", sortable: false, width: '200' })
    ];

    this.noRecordColspan = this.pTable.columns.filter(c => c.visible).length;
    PrimeTableUtils.setDefaults(this.pTable);

    this.userActivityService.sendEvent(CategoryConstants.View, 'order-management/notes', CategoryConstants.View + ' Inspection Order Notes Page');
  }

  paginate(event) {
    setTimeout(() => {

      this.showTableLoading = true;
      this.globalService.postGenericList<IPaginationResult<InspectionOrderNotes>>(
        "InspectionNotesList",
        event,
        this.searchFilterFinal,
        this.pTable.columns.map(c => c.field),
        null,
        {
          inspectionOrderId: this.route.snapshot.params['id']
        }
      ).subscribe(paginationResult => {
        this.paginationResult = paginationResult;
        this.inspectionOrderNotesList = this.paginationResult.results;
        this.totalRecord = this.paginationResult.totalRecords;

      },
        err => {
        },
        () => {
          this.showTableLoading = false;
          this.firstRowOffset = event.first;
        });
    })
  }

  getCloseModal(closeModal) {
    this.display = closeModal;
    this.commentSection = "";
    this.noteSubject = "";
  }

  newComment() {
    this.viewOnly = false;
    this.isEditable = false;
    this.display = true;
    this.isNewNote = true;
    this.selectedInspectionOrderNote = new InspectionOrderNotes();
  }

  resetTable(resetTable) {
    if(resetTable) {
      this.pTable.reset();
    }
  }

  viewNotes(notes) {
    this.isNewNote = false;
    this.viewOnly = true;
    this.display = true;
    this.selectedInspectionOrderNote = notes;
    this.commentSection = this.selectedInspectionOrderNote.notes;
    this.noteSubject = this.selectedInspectionOrderNote.subject;
    this.isEditable = true;
  }

  editNotes(notes) {
    this.selectedInspectionOrderNote = notes;
    this.isNewNote = false;
    this.viewOnly = false;
    this.display = true;
    this.indexOfNote = this.inspectionOrderNotesList.indexOf(this.selectedInspectionOrderNote);
    this.commentSection = this.selectedInspectionOrderNote.notes;
    this.noteSubject = this.selectedInspectionOrderNote.subject;
    this.isEditable = false;
  }
}

