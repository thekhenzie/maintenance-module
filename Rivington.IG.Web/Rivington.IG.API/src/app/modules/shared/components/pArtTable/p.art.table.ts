import { Component, ViewChild, OnInit, ElementRef, NgZone, forwardRef, TemplateRef, AfterContentInit, Input } from '@angular/core';

import { Table, TableService } from 'primeng/table';
import { Column } from './models/column';
import { ObjectUtils } from 'primeng/components/utils/objectutils';
import { DomHandler, PrimeTemplate } from 'primeng/primeng';
import { NG_VALUE_ACCESSOR } from '@angular/forms';
import { CommonService } from '../../../core/services/common.service';
import { IPaginationResult } from '../../models/paginationresult';
import { IVenue } from '../../models/venue';

const DATATABLE_VALUE_ACCESSOR: any = {
  provide: NG_VALUE_ACCESSOR,
  useExisting: forwardRef(() => PrimeArtTable),
  multi: true
};

@Component({
  selector: 'p-art-table',
  templateUrl: './p.art.table.html',
  styleUrls: ['./p.art.table.css'],
  providers: [CommonService, DATATABLE_VALUE_ACCESSOR, DomHandler, ObjectUtils, TableService]
})
export class PrimeArtTable extends Table implements OnInit, AfterContentInit {
  public columns: Column[];
  public value: any[];
  paginationResult: IPaginationResult<IVenue>;

  public sortMode: string = "multiple";

  public lazy: boolean = true;

  public paginator: boolean = true;
  public rows: number = 10;
  public pageLinks: number = 10;

  public responsive: boolean = true;
  public loadingIcon: string = "fa-spinner";

  // filter
  searchFilter: string = "";
  @Input() filterPlaceholder: string = "Search";
  JSON: any;
  
  // templates
  prependCaptionTemplate: TemplateRef<PrimeTemplate>;

  constructor(private _commonService: CommonService,
    el: ElementRef, domHandler: DomHandler, objectUtils: ObjectUtils, zone: NgZone, tableService: TableService
  ) {
    super(el, domHandler, objectUtils, zone, tableService);
    this.JSON = JSON;
  }

  @ViewChild('pTable') protected pTable: Table;
  
  ngOnInit() {
    // defaults

    super.ngOnInit();
  }

  ngAfterContentInit() {
    let that = this;
    this.templates.forEach(function (item) {
      switch (item.getType()) {
        case 'prepend-caption':
          that.prependCaptionTemplate = item.template;
          break;
      }
    });

    super.ngAfterContentInit();
  }

  paginate(event) {
    setTimeout(() => {
      this.loading = true;
      this._commonService.postGenericList < IPaginationResult < IVenue >> (
        "VenueList",
        event,
        this.searchFilter, 
        ["venueName", "description"],
        null,
        null
      ).subscribe(paginationResult => {
        this.paginationResult = paginationResult;
        this.value = this.paginationResult.results;
        this.totalRecords = this.paginationResult.totalRecords;
      },
      err => {
      },
      () => {
        this.loading = false;
      });
    })
  }


  filterTable() {
    this.reset();
  }
}