import { Component, OnInit, ViewChild } from '@angular/core';
import { Table } from 'primeng/components/table/table';
import { Column } from '../../../shared/components/pArtTable/models/column';
import { ConfirmationService } from 'primeng/components/common/confirmationservice';
import { PrimeTableUtils } from '../../../shared/PrimeTableUtils';
import { ActivatedRoute } from '@angular/router';
import { Maintenance } from '../../../shared/models/maintenance';
import { CommonService } from '../../../core/services/common.service';
import { IPaginationResult } from '../../../shared/models/paginationresult';
@Component({
  selector: 'app-maintenancemanagement',
  templateUrl: './maintenancemanagement.component.html',
  styleUrls: ['./maintenancemanagement.component.css'],
  providers: [ConfirmationService]
})
export class MaintenancemanagementComponent implements OnInit {

  noRecordColspan: number = 0;
  display: boolean = false;
  showTableLoading: boolean = false;
  totalRecord: number = 0;
  maintenanceList: Maintenance[];
  paginationResult: IPaginationResult<Maintenance>[];
  private searchFilterFinal: string = "";
  public firstRowOffset: number;
  constructor(private globalService: CommonService,
    private route: ActivatedRoute) { }

  @ViewChild('pTable') public pTable: Table;

  ngOnInit() {
    this.pTable.columns = [
      new Column({ field: "id", header: "ID" }),
      new Column({ field: "name", header: "Name" }),
      new Column({ field: "sortOrder", header: "Sort Order" }),
      new Column({ field: "action", header: "", sortable: false, width: '200' })
    ];

    this.noRecordColspan = this.pTable.columns.filter(c => c.visible).length;
    PrimeTableUtils.setDefaults(this.pTable);
  }

  newComment(): void {
    this.display = true;
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

      this.globalService.getEnumList<IPaginationResult<Maintenance>>('FramingType')
        .subscribe(paginationResult => {
          console.log(paginationResult);
          this.paginationResult = paginationResult;
          // this.maintenanceList = this.paginationResult;
          // for (var res of this.paginationResult) {
          //   this.maintenanceList.push(res);
          // }
          this.totalRecord = this.paginationResult.length;

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
}
