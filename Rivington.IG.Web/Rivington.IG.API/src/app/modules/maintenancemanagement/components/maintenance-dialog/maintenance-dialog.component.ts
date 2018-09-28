import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormControl, Validators, FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmationService } from 'primeng/components/common/confirmationservice';
import { GenericEnumeration } from '../../../shared/models/genericenumeration';
import { CommonService } from '../../../core/services/common.service';
import Utils from '../../../shared/Utils';
@Component({
  selector: 'app-maintenance-dialog',
  templateUrl: './maintenance-dialog.component.html',
  styleUrls: ['./maintenance-dialog.component.css'],
  providers: [ConfirmationService]
})
export class MaintenanceDialogComponent implements OnInit {
  genericEnumerationList: GenericEnumeration[];
  genericForm: FormGroup;
  show: boolean;
  @Input() display: boolean = false;
  @Input() idSection: string;
  @Input() nameSection: string;
  @Input() isActiveSection: boolean = true;
  @Input() isNewEnumeration: boolean;
  @Input() viewOnly: boolean;
  @Input() indexOfNote: number;
  @Input() selectedGenericEnumeration: GenericEnumeration;
  @Output() closeModal: EventEmitter<boolean>;
  @Output() resetTable: EventEmitter<boolean>;

  constructor(public genericService: CommonService,
    private conf: ConfirmationService,
    private fb: FormBuilder,
    private route: ActivatedRoute) {
    this.closeModal = new EventEmitter<boolean>();
    this.resetTable = new EventEmitter<boolean>();

  }

  ngOnInit() {
    this.genericForm = this.fb.group({
      'genId': new FormControl('', Validators.required),
      'genName': new FormControl('', Validators.required),
      'genIsActive': new FormControl('', Validators.required)
    });
  }

  addComment() {
    this.selectedGenericEnumeration.id = this.idSection;
    this.selectedGenericEnumeration.name = this.nameSection;
    this.selectedGenericEnumeration.isActive = this.isActiveSection;
    this.selectedGenericEnumeration.sortOrder = 1;

    if (this.isNewEnumeration) {
      this.genericService.addGeneric("OrderManagement.FramingType", this.selectedGenericEnumeration).then(emp => {
        this.cancelCom();
        Utils.showSuccess("New enumeration has been added!");
        this.resetTable.emit(true);
      });
    }
    else {
      this.genericService.updateGeneric("OrderManagement.FramingType", this.selectedGenericEnumeration).then(emp => {
        this.cancelCom();
        this.genericForm.markAsPristine();
        Utils.showSuccess("Your enumeration has been edited!");
        this.resetTable.emit(true);
      });
    }
    this.idSection = "";
    this.nameSection = "";
    this.isActiveSection = true;
  }

  cancelComment() {
    if (this.isNewEnumeration) {
      if (this.genericForm.dirty && (this.idSection != "" || this.nameSection != "")) {
        this.conf.confirm({
          message: 'Do you want to discard changes?',
          accept: () => {
            this.cancelCom();
          }
        })
      }
      else {
        this.cancelCom();
      }
    }
    else {
      if (this.genericForm.dirty) {
        this.conf.confirm({
          message: 'Do you want to discard changes?',
          accept: () => {
            this.cancelCom();
          }
        });
      }
      else{
        this.cancelCom();
      }
    }
  }

  cancelCom() {
    this.closeModal.emit(false);
    this.display = false;
    this.idSection = "";
    this.nameSection = "";
    this.isActiveSection = true;
    this.genericForm.markAsPristine();
  }

}
