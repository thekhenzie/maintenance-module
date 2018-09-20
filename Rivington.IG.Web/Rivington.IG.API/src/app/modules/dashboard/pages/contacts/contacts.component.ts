import { Component, OnInit } from '@angular/core';
import { Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { ConfirmationService, DataTable } from 'primeng/primeng';
import { ViewChild } from '@angular/core';
import { Table } from 'primeng/table';
import { CommonService } from '../../../../modules/core/services/common.service';
import { PrimeTableUtils } from '../../../shared/PrimeTableUtils';
import { AuthService } from '../../../../modules/core/services/auth.service';
import { Contact } from '../../../shared/models/contact';
import { IPaginationResult } from '../../../shared/models/paginationresult';
import { Column } from '../../../shared/components/pArtTable/models/column';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.css'],
  providers: [CommonService, ConfirmationService]
})

export class ContactsComponent implements OnInit {
  contactList: Contact[];
  contactListDefault: Contact[];
  cloneContact: Contact;
  selectedContact: Contact;
  isNewContact: boolean;
  isDeleteContact: boolean = false;
  indexOfContact: number;
  totalRecords: number = 0;
  dateActivate: any;
  minDate: Date = new Date();
  isTrueFalse: object[];
  selectedActive: string;
  userform: FormGroup;

  searchFilter: string = "";
  private searchFilterFinal: string = "";

  paginationResult: IPaginationResult<Contact>;
  rexExpEmailFormat: string = "[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
  showTableLoading: boolean = false;
  noRecordColspan: number = 0;

  constructor(private globalService: CommonService, private confirmationService: ConfirmationService,
    private fb: FormBuilder, public auth: AuthService) { }

  @ViewChild('pTable') public pTable: Table;

  ngOnInit() {
    this.isTrueFalse = [];
    this.isTrueFalse.push({ label: 'true', value: 'true' });
    this.isTrueFalse.push({ label: 'false', value: 'false' });

    this.userform = this.fb.group({
      'firstName': new FormControl('', Validators.required),
      'lastName': new FormControl('', Validators.required),
      'mobilePhone': new FormControl('', Validators.required),
      'emailAddress': new FormControl('', Validators.compose([Validators.required, Validators.pattern(this.rexExpEmailFormat)])),
      'streetAddress': new FormControl('', Validators.required),
      'cityAddress': new FormControl('', Validators.required),
      'country': new FormControl('', Validators.required),
      'zipCode': new FormControl('', Validators.compose([Validators.required, Validators.min(1)])),
      'active': new FormControl(''),
      'dateActivated': new FormControl(''),
    });

    this.pTable.columns = [
      new Column({field: "contactId", sortable: false, visible: this.auth.isLoggedIn() }),
      new Column({field: "firstName", header: "Contact Name"}),
      new Column({field: "mobilePhone", header: "Mobile Phone"}),
      new Column({field: "emailAddress", header: "Email Address"}),
      new Column({field: "streetAddress", header: "Street Address"}),
      new Column({field: "cityAddress", header: "City Address"}),
      new Column({field: "country", header: "Country"}),
      new Column({field: "zipCode", header: "Zip Code"})
    ];
    this.noRecordColspan = this.pTable.columns.filter(c => c.visible).length;
    PrimeTableUtils.setDefaults(this.pTable);
  }

  paginate(event) {
    setTimeout(() => {
      this.showTableLoading = true;
      this.globalService.postGenericList<IPaginationResult<Contact>>(
        "ContactList", 
        event, 
        this.searchFilterFinal, 
        this.pTable.columns.filter(c => c.field !== "contactId").map(c => c.field),
        null,
        null
      ).subscribe(paginationResult => {
        this.paginationResult = paginationResult;
        this.contactList = this.paginationResult.results;
        this.totalRecords = this.paginationResult.totalRecords;

        // this.contactList.forEach(contact => {
        //   contact.dateActivated = contact.dateActivated == null ? null :
        //     new Date(contact.dateActivated);
        // });
      },
      err => {
      },
      () => {
        this.showTableLoading = false;
      });
    })
  }

  searchContact() {
    // todo set summary for table. filtered by, total number of rows, etc
    // sample header filter
    // number of rows per page
    this.searchFilterFinal = this.searchFilter;
    this.resetTable();
  }

  resetTable() {
    this.pTable.reset();
  }

  addContact() {
    this.userform.enable();
    this.isNewContact = true;
    this.selectedContact = new Contact();
    this.selectedActive = "false";
    this.dateActivate = null;
  }

  onRowSelect(contact) {
    this.userform.enable();
    this.isNewContact = false;
    this.selectedContact = contact;
    this.indexOfContact = this.contactList.indexOf(this.selectedContact);
    this.selectedActive = this.selectedContact.isActive ? "true" : "false";
    this.cloneContact = Object.assign({}, this.selectedContact);
    this.selectedContact = Object.assign({}, this.selectedContact);
  }

  btnSave(isSaveAndNew: boolean) {
    this.userform.markAsPristine();
    let tmpContactList = [...this.contactList];
    this.selectedContact.isActive = this.selectedActive == 'true' ? true : false;
    if (this.isNewContact) {
      this.globalService.addSomething<Contact>("Contacts", this.selectedContact).then(contacts => {
        tmpContactList.push(contacts);
        this.contactList = tmpContactList;
        this.selectedContact = isSaveAndNew ? new Contact() : null;
        this.isNewContact = isSaveAndNew ? true : false;
        if(!isSaveAndNew) {
          this.resetTable(); 
        }
        else {
          this.selectedActive = "false";
          this.dateActivate = null;
        }
      });
    }
    else {
      this.globalService.updateSomething<Contact>("Contacts", this.selectedContact.contactId, this.selectedContact).then(contacts => {
        tmpContactList[this.indexOfContact] = this.selectedContact;
        this.resetTable();
        this.contactList = tmpContactList;
        this.selectedContact = null;
        this.isNewContact = false;
      });
    }
  }

  btnCancel() {
    if (this.isNewContact || this.isDeleteContact || !this.userform.dirty) {
      this.selectedContact = null;
      this.isDeleteContact = false;
      this.isNewContact = false
      this.userform.markAsPristine();
    }
    else if (this.userform.dirty) {
      this.confirmationService.confirm({
        message: 'Are you sure you want to discard the changes?',
        header: 'Cancel Confirmation',
        icon: 'fa fa-ban',
        accept: () => {
          let tmpContactList = [...this.contactList];
          tmpContactList[this.indexOfContact] = this.cloneContact;
          this.contactList = tmpContactList;
          this.selectedContact = Object.assign({}, this.cloneContact);
          this.userform.markAsPristine();
        }
      });
    }
  }

  btnDelete(contact) {
    this.userform.disable();
    this.selectedContact = contact;
    this.indexOfContact = this.contactList.indexOf(contact);
    this.selectedActive = this.selectedContact.isActive ? "true" : "false";
    this.isDeleteContact = true;
  }

  btnOk() {
    this.confirmationService.confirm({
      message: 'Do you want to delete this record?',
      header: 'Delete Confirmation',
      icon: 'fa fa-trash',
      accept: () => {
        let tmpContactList = [...this.contactList];
        this.globalService.deleteSomething<Contact>("Contacts", this.selectedContact.contactId).then(contacts => {
          tmpContactList.splice(this.indexOfContact, 1);
          this.contactList = tmpContactList;
          this.selectedContact = null;
          this.isNewContact = false;
          this.isDeleteContact = false;
          this.resetTable();
        });
      }
    });
  }
}

class PaginationResultClass implements IPaginationResult<Contact>{
  constructor (public results, public pageNo, public recordPage, public totalRecords) 
  {
      
  }
}
