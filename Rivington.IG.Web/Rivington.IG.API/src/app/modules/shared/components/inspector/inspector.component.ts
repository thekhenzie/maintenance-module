import { Component, OnInit, ViewChild, EventEmitter, Output, Input } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { Inspector } from '../../../shared/models/ordermanagement/inspector';
import { AuthService } from '../../../core/services/auth.service';
import { GetInspectorService } from '../../../core/services/ordermanagement/getinspector.service';
import { ActivatedRoute, Router } from '@angular/router';
import { InspectionOrderService } from '../../../core/services/ordermanagement/inspection-order.service';
import { UtilityService } from '../../../core/services/utility.service';


@Component({
  selector: 'app-inspector',
  templateUrl: './inspector.component.html',
  styleUrls: ['./inspector.component.css']
})
export class InspectorComponent implements OnInit {

  @Input() inspector: string;
  @Input() componentLabel: string;
  @Input() buttonLabel: string;
  @Input() isIOInfo: boolean;
  @Output() inspectorInfo: EventEmitter<Inspector>;

  inspectorList: any;
  serviceName: string;
  isNew: boolean;
  dateFormat: string;
  inspectorFilter: string;
  currentInspector: Inspector;

  constructor(
    public auth: AuthService,
    private fb: FormBuilder,
    private inspectorService: GetInspectorService,
    private route: ActivatedRoute,
    private inspectionOrderService: InspectionOrderService,
    private router: Router,
    private utilityService: UtilityService,
    private datePipe: DatePipe
  ) {
    this.inspectorList = [];
    this.serviceName = 'User';
    this.inspectorInfo = new EventEmitter<Inspector>();
    this.inspectorFilter = "";
  }

  ngOnInit() {
    this.fetchInspectorList();
    this.auth.currentUserRole = this.auth.getRoles().toString();
  }

  fetchInspectorList(){
    this.inspectorService.getInspectorList(this.serviceName, this.inspectorFilter).then(inspectors => {
      this.inspectorList = inspectors;
    });
    this.route.params.subscribe(params => {
      let paramId = params["id"];
      if (!paramId) {
        this.isNew = true;
      }
    });
  }

  getData(inspector: Inspector) {
    this.inspector = inspector.firstName + " " + inspector.lastName;
    this.dateFormat = this.utilityService.appSettings.defaultDateFormat;
    this.currentInspector = inspector;
    this.inspectorInfo.emit(this.currentInspector);
  }

  filterInspector(){
    this.fetchInspectorList();
  }

  searchByEnterKey(event){
    if (event.keyCode == 13) {
      this.fetchInspectorList();
    }
  }

  clearSearch(){
    this.inspectorFilter="";
    this.fetchInspectorList();
  }

  clearInspector(){
    this.inspector = null;
    this.currentInspector = null;
    this.inspectorInfo.emit(this.currentInspector);
  }

  checkIfButtonHidden(): boolean{
    // for role-based
    // return (this.auth.isInspector(this.auth.currentUserRole) 
    //   || this.auth.isUnderWriter(this.auth.currentUserRole))
    //   && this.isIOInfo;
    return false;
  }

}
