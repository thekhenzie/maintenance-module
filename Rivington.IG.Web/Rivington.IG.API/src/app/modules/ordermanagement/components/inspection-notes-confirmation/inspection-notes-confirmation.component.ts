import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { InspectionOrderNotesService } from '../../../core/services/ordermanagement/inspection-notes.service';
import { ConfirmationService } from 'primeng/components/common/confirmationservice';
import { LocalStorageService } from '../../../core/services/localStorageService';
import { FormControl, Validators, FormBuilder, FormGroup } from '@angular/forms';
import Utils from '../../../shared/Utils';
import { InspectionOrderNotes } from '../../../shared/models/inspectionordernotes';
import { ActivatedRoute, Router } from '@angular/router';
import { InspectionOrderService } from '../../../core/services/ordermanagement/inspection-order.service';
import { UserActivityLogService } from '../../../core/services/ordermanagement/user-activity-log.service';
import { CategoryConstants } from '../../../shared/models/user-activity-category-constants';

@Component({
  selector: 'app-inspection-notes-confirmation',
  templateUrl: './inspection-notes-confirmation.component.html',
  styleUrls: ['./inspection-notes-confirmation.component.css'],
  providers: [ConfirmationService]
})
export class InspectionNotesConfirmationComponent implements OnInit {
  inspectionOrderNotesList: InspectionOrderNotes[];
  userform: FormGroup;
  username: string;
  show: boolean;
  @Input() inspectorToUW: boolean;
  @Input() pendUWR:boolean;
  @Input() outstandingQC: boolean;
  @Input() pendingWriteUp: boolean;
  @Input() isEditable: boolean;
  @Input() viewOnly: boolean;
  @Input() noteSubject: string;
  @Input() commentSection: string;
  @Input() isNewNote: boolean;
  @Input() display: boolean;
  @Input() indexOfNote: number;

  @Output() closeModal: EventEmitter<boolean>;

  @Output() resetTable: EventEmitter<boolean>;
  
  @Input() selectedInspectionOrderNote: InspectionOrderNotes;

  constructor(public inspectionOrderNotesService: InspectionOrderNotesService,
    private conf: ConfirmationService,
    private localService: LocalStorageService,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    public ioService: InspectionOrderService,
    private userActivityService: UserActivityLogService) { 
      this.closeModal = new EventEmitter<boolean>();
      this.resetTable = new EventEmitter<boolean>();
    }

  ngOnInit() {
    this.username = this.localService.getUserName();
    
        this.userform = this.fb.group({
          'comment': new FormControl('', Validators.required),
          'subject': new FormControl('', Validators.required)
        });
  }

  addComment() {
    Utils.blockUI();
    this.selectedInspectionOrderNote.notes = this.commentSection;
    this.selectedInspectionOrderNote.subject = this.noteSubject;
    this.selectedInspectionOrderNote.inspectionOrderId = this.route.snapshot.params['id'];
    this.selectedInspectionOrderNote.ModifiedById = this.username;

    if (this.isNewNote) {
      this.inspectionOrderNotesService.postInspectionOrderNote(this.selectedInspectionOrderNote).then(emp => {
        if(this.pendingWriteUp) {
          this.setStatusToPendingQC();
        }
        else if(this.outstandingQC) {
          this.setStatusToOutstandingQC();
        }
        else if(this.pendUWR) {
          this.setStatusToUWIssues();
        }
        else if(this.inspectorToUW) {
          this.setStatusToPendingUnderWriterReview();
        } 
        else {
          this.cancelCom();
          Utils.showSuccess("Your Note has been added!");
          this.resetTable.emit(true);
        }
      });

      this.userActivityService.sendEvent( CategoryConstants.Create, 'order-management/notes', CategoryConstants.CreatedNotes);
      
    }
    else {
      this.selectedInspectionOrderNote.modifiedBy = null;
      this.inspectionOrderNotesService.putInspectionOrderNote(this.selectedInspectionOrderNote).then(emp => {
      this.cancelCom();
      this.userform.markAsPristine();
      Utils.showSuccess("Your Note has been edited!");
      this.resetTable.emit(true);

      this.userActivityService.sendEvent( CategoryConstants.Update, 'order-management/notes', CategoryConstants.UpdatedNotes);
      });
    }
    this.commentSection = "";
    this.noteSubject = "";
  }

  cancelCom() {
    this.closeModal.emit(false);
    this.display = false;
    this.commentSection = "";
    this.noteSubject = "";
    this.userform.markAsPristine();
  }

  cancelComment() {
    if (this.isNewNote) {
      if (this.userform.dirty && (this.commentSection != "" || this.noteSubject != "")) {
        this.conf.confirm({
          message: 'Do you want to discard changes?',
          accept: () => {
            this.cancelCom();

            this.userActivityService.sendEvent( CategoryConstants.Cancel, 'order-management/notes', CategoryConstants.CancelledCreatingNotes);
          }
        });
      }
      else {
        this.cancelCom();
      }
    }
    else {
      if (this.userform.dirty) {
        this.conf.confirm({
          message: 'Do you want to discard changes?',
          accept: () => {
            this.cancelCom();

            this.userActivityService.sendEvent(CategoryConstants.Cancel, 'order-management/notes', CategoryConstants.CancelledUpdatingNotes);
          }
        });
      }
      else {
        this.cancelCom();
      }
    }
  }

  hasError(name: string) {
    var e = this.getFormControl(name);
    return e && (e.dirty || e.touched) && !e.valid;
  }

  getFormControl(name: string) {
    return this.userform.get(name);
  }

  setStatusToPendingQC() {
    this.ioService.setIOStatusAndSendEmail(this.route.snapshot.params['id'], "PQC", "SetStatusPendingQCAndSendEmail").subscribe(res => {
      this.selectedInspectionOrderNote = null;
      this.display = false;
      this.userform.markAsPristine();
      Utils.showSuccess("Report has been submitted for QC!");
      this.router.navigate(['order-management']);
    },
    err => {
      Utils.showGenericHttpErrorResponse(err);
    });
  }

  setStatusToOutstandingQC() {
    this.ioService.setIOStatusAndSendEmail(this.route.snapshot.params['id'], "PQCI", "SetStatusPendingQCIAndSendEmail").subscribe(res => {
        this.selectedInspectionOrderNote = null;
        this.display = false;
        this.userform.markAsPristine();
        Utils.showSuccess("Report has been sent back to the inspector!");
        this.router.navigate(['order-management']);
      },
      err => {
        Utils.showGenericHttpErrorResponse(err);
      });
  }

  setStatusToUWIssues() {
    this.ioService.setIOStatusAndSendEmail(this.route.snapshot.params['id'], "UWI", "SetStatusUWIssuesAndSendEmail").subscribe(res => {
        this.selectedInspectionOrderNote = null;
        this.display = false;
        this.userform.markAsPristine();
        Utils.showSuccess("Report has been sent back to the inspector!");
        this.router.navigate(['order-management']);
      },
      err => {
        Utils.showGenericHttpErrorResponse(err);
      });
  }

  setStatusToPendingUnderWriterReview() {
    Utils.blockUI();
    this.ioService.setIOStatusAndSendEmail(this.route.snapshot.params['id'], "PUWR", "SetStatusPendingUWReviewAndSendEmail").subscribe(res => {
      this.selectedInspectionOrderNote = null;
      this.display = false;
      this.userform.markAsPristine();
      Utils.showSuccess("Report has been sent to Under Writer for review");
      this.router.navigate(['order-management']);
    },
      err => {
        Utils.showGenericHttpErrorResponse(err);
      });
  }
}
