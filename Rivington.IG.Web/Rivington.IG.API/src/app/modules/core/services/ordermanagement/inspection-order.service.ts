import { DatePipe } from '@angular/common';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs/Observable';
import { Constants } from '../../../shared/constants';
import { City } from '../../../shared/models/ordermanagement/city';
import { InspectionOrder } from '../../../shared/models/ordermanagement/inspection-order';
import { InspectionOrderPropertyGeneral } from '../../../shared/models/ordermanagement/inspection-order/checklist/property/general';
import { Inspector } from '../../../shared/models/ordermanagement/inspector';
import { State } from '../../../shared/models/ordermanagement/state';
import { CommonService } from '../common.service';
import { UtilityService } from '../utility.service';
import { InspectionOrderChecklistPropertyService } from './inspection-order-checklist-section/property.service';
import { InspectionOrderChecklistWildFireService } from './inspection-order-checklist-section/wildfire.service';
import { InspectionStatusConstants } from '../../../shared/inspection-status-constants';
import { MitigationStatusConstants } from '../../../shared/mitigation-status-constants';
import { GetInspectorService } from './getinspector.service';
import { SelectItem } from '../../../../../../node_modules/primeng/primeng';
import { PropertyIdValueConstants } from '../../../shared/models/property-id-value-constants';
import { isNullOrUndefined } from 'util';
import { AuthService } from '../auth.service';

@Injectable()
export class InspectionOrderService {
    public pendingQc: boolean;
    public pendingWriteUp: boolean;
    public underWriterIssues: boolean;
    public outStandingQc: boolean;
    public pendingUnderWriterReview: boolean;
    public showAcceptRejectButton: boolean;
    public showSubmitButton: boolean;
    inspectionOrder: InspectionOrder;
    inspectionDate: Date;
    public isFutureDate: boolean;
    public inspectionComplete: boolean;
    public showReportAction: boolean;
    public showSubmitReport: boolean;
    public isIOScheduled: boolean;

    // mitigation
    public incompleteMitigationCount: number;
    public isChecklist: boolean;
    public constantOutstanding: string;
    public constantPendingReview: string;
    public mitigationStatusId: string;
    public mitigationCount: number;

    riskSummaryForm: FormGroup;
    updateData: InspectionOrder;
    policyForm: FormGroup;
    orderStatusForm: FormGroup;
    insuredForm: FormGroup;
    agentForm: FormGroup;
    inspector: Inspector;
    dateFormat: string;
    city: City;
    state: State;
    zipcode: string;
    inspectionOrderPropertyGeneral: InspectionOrderPropertyGeneral;

    constructor(
        private http: HttpClient,
        private commonService: CommonService,
        public fb: FormBuilder,
        private datePipe: DatePipe,
        private utilityService: UtilityService,
        private ioChecklistPropertyService: InspectionOrderChecklistPropertyService,
        private ioChecklistWildfireService: InspectionOrderChecklistWildFireService,
        private inspectorService: GetInspectorService,
        private auth: AuthService
    ) {
        this.city = new City();
        this.state = new State();
    }

    initiateFormValues() {

        this.policyForm = this.fb.group({
            'policyNumber': new FormControl(),
            'inspectionDate': new FormControl(),
            'coverageA': new FormControl(),
            'e2ValueReplacementCostValue': new FormControl(),
            'itvPercentage': new FormControl(),
            'wildfireAssessmentRequired': new FormControl(true),
            'propertyValueId': new FormControl('', Validators.required),
            'inspectionStatusId': new FormControl('', Validators.required),
            'mitigationStatusId': new FormControl(),
            'inceptionDate': new FormControl('', Validators.required)
        });
        
        let autoComputeItv = (value) => {
            let coverageA = this.policyForm.get('coverageA').value;
            let e2ValueReplacementCostValue = this.policyForm.get('e2ValueReplacementCostValue').value;

            let itvPercentage = 0;
            if(coverageA && e2ValueReplacementCostValue) {
                itvPercentage = coverageA / e2ValueReplacementCostValue;
                itvPercentage = Math.round(itvPercentage * 100) / 100;
            }

            if(
                itvPercentage === Infinity ||
                isNaN(itvPercentage)
            ) {
                itvPercentage = 0
            }
                
            this.policyForm.get('itvPercentage').setValue(itvPercentage);
        }

        this.policyForm.get('coverageA').valueChanges.subscribe(autoComputeItv);
        this.policyForm.get('e2ValueReplacementCostValue').valueChanges.subscribe(autoComputeItv);

        this.orderStatusForm = this.fb.group({
            'inspectionStatusId': new FormControl(),
            'dateCreated': new FormControl(),
            'policyNumber': new FormControl(),
            'inspectionDate': new FormControl(),
            'assignedDate': new FormControl()
        });

        this.insuredForm = this.fb.group({
            'insuredFirstName': new FormControl(),
            'insuredLastName': new FormControl(),
            'insuredMiddleName': new FormControl(),
            'insuredEmail': new FormControl(),
            'address': new FormControl(),
            'latitude': new FormControl(),
            'longitude': new FormControl(),
            'agencyCity' : new FormControl(),
            'agencyState' : new FormControl(),
            'agencyZipCode' : new FormControl()
        });

        this.agentForm = this.fb.group({
            'agentName': new FormControl(),
            'agencyName': new FormControl(),
            'agentPhoneNumber': new FormControl(),
            'agencyPhoneNumber': new FormControl(),
        });

        this.orderStatusForm.valueChanges.subscribe(data => {
            this.policyForm.patchValue({
                'inspectionDate': this.datePipe.transform(this.orderStatusForm.value.inspectionDate, this.dateFormat)
            });
        });
    }

    initiateRiskSummaryFormValue() {
        this.riskSummaryForm = this.fb.group({
            'riskSummary': new FormControl()
        });
    }

    getInspectionOrders(serviceName, id) {
        return this.http.get(`${Constants.ApiUrl}/${serviceName}/?id=${id}`)
            .toPromise()
            .then(data => {
                this.updateData = data;
                return data as InspectionOrder;
            })
            .catch(error => {
                this.updateData = null;
            });
    }

    postInspectionOrder(inspectionOrder) {
        return this.http.post(`${Constants.ApiUrl}/CreateInspectionOrder`, inspectionOrder)
            .toPromise()
            .then(data => { return data })
            .catch(this.commonService.handleError);
    }

    putInspectionOrder(inspectionOrder) {
        return this.http.put(`${Constants.ApiUrl}/UpdateInspectionOrder`, inspectionOrder)
            .toPromise()
            .then(data => { return data })
            .catch(this.commonService.handleError);
    }

    checkIfInspectionOrderExists(id): Observable<boolean> {
        return this.http.get<boolean>(`${Constants.ApiUrl}/CheckIfInspectionOrderExists/${id}`)
            .map((doExist) => doExist)
            .catch(error => {
                console.log(error);
                return Observable.throw(error);
            });
    }

    postPropertyPhoto(propertyPhoto) {
        return this.http.post(`${Constants.ApiUrl}/UploadInspectionOrderPropertyPhotos`, propertyPhoto)
            .map(data => { return data })
            .catch(this.commonService.handleObservableHttpError);
    }

    getPropertyPhotos(propertyPhotoId) : Observable<any>{
        return this.http.get(`${Constants.ApiUrl}/RetrievePhotos/${propertyPhotoId}`)
            .map(data => { return data })
            .catch(this.commonService.handleObservableHttpError);
    }

    deletePropertyPhoto(inspectionOrderId, photoId) {
        let headers = new HttpHeaders({ 'Content-Type': 'application/JSON' });
        let params = new HttpParams()
            .append('inspectionOrderId', inspectionOrderId)
            .append('photoId', photoId);
        return this.http.delete(`${Constants.ApiUrl}/DeleteInspectionOrderPropertyPhoto`, { params: params })
            .catch(this.commonService.handleObservableHttpError);
    }
    
    getRiskSummaryValue() {
        if (!!!this.riskSummaryForm) return;
        return this.riskSummaryForm.value.riskSummary;
    }
    
    getRiskSummary(id) : Observable<any>{
        return this.http.get(`${Constants.ApiUrl}/GetIORiskSummary/${id}`)
            .catch(this.commonService.handleObservableHttpError);
    }

    getInspectionOrderToEdit(currentIOid) {
        this.getInspectionOrders("InspectionList", currentIOid).then(
          data => {
            this.inspectionOrder = Object.assign({}, this.updateData[0]);
            
            this.inspectionDate = new Date(this.datePipe.transform(this.inspectionOrder.inspectionDate, this.dateFormat));
            let now = new Date(this.datePipe.transform(new Date(), this.dateFormat));
            if(this.inspectionDate > now){
                this.isFutureDate = false;
            }
            else {
                this.isFutureDate = false;
            }

            this.ioChecklistPropertyService.isHighValue = (this.inspectionOrder.policy.propertyValueId == PropertyIdValueConstants.HigValue);
      
            this.ioChecklistWildfireService.isWildFireRequired = this.inspectionOrder.policy.wildfireAssessmentRequired;

            this.showSubmitButton = (this.inspectionOrder.policy.inspectionStatusId == InspectionStatusConstants.PendingWriteUp || this.inspectionOrder.policy.inspectionStatusId == InspectionStatusConstants.PendingQCItem || this.inspectionOrder.policy.inspectionStatusId == InspectionStatusConstants.UWIssues);

            this.showAcceptRejectButton = (this.inspectionOrder.policy.inspectionStatusId == InspectionStatusConstants.PendingQC || this.inspectionOrder.policy.inspectionStatusId == InspectionStatusConstants.PendingUWReview);

            this.pendingUnderWriterReview = (this.inspectionOrder.policy.inspectionStatusId == InspectionStatusConstants.PendingUWReview);

            this.outStandingQc = (this.inspectionOrder.policy.inspectionStatusId == InspectionStatusConstants.PendingQCItem);
            
            this.underWriterIssues = (this.inspectionOrder.policy.inspectionStatusId == InspectionStatusConstants.UWIssues);

            this.pendingWriteUp = (this.inspectionOrder.policy.inspectionStatusId == InspectionStatusConstants.PendingWriteUp);

            this.pendingQc = (this.inspectionOrder.policy.inspectionStatusId == InspectionStatusConstants.PendingQC);

            this.inspectionComplete = (this.inspectionOrder.policy.inspectionStatusId != InspectionStatusConstants.Scheduled 
                && this.inspectionOrder.policy.inspectionStatusId != InspectionStatusConstants.PendingAssignment
                && this.inspectionOrder.policy.inspectionStatusId != InspectionStatusConstants.ReadyToSchedule);

            this.isIOScheduled = (this.inspectionOrder.policy.inspectionStatusId == InspectionStatusConstants.Scheduled);

            this.constantOutstanding = MitigationStatusConstants.OutstandingItems;

            this.constantPendingReview = MitigationStatusConstants.PendingReview;

            this.mitigationStatusId = this.inspectionOrder.policy.mitigationStatusId

            this.showReportAction = (this.inspectionOrder.policy.inspectionStatusId == InspectionStatusConstants.PendingQC || this.inspectionOrder.policy.inspectionStatusId == InspectionStatusConstants.PendingUWReview || this.inspectionOrder.policy.inspectionStatusId == InspectionStatusConstants.PendingWriteUp);

            this.showSubmitReport = (this.inspectionOrder.policy.inspectionStatusId == InspectionStatusConstants.PendingWriteUp);
          });
        }

    setIOStatusAndSendEmail(id: string, status: string, serviceName: string, mitigationStatus?: string) : Observable<any>{
        return this.http.put(`${Constants.ApiUrl}/${serviceName}`, {
            id: id,
            status: status,
            mitigationStatus: mitigationStatus
        })
        .catch(this.commonService.handleObservableHttpError);
    }

    getUserListForDropdown() : Promise<SelectItem[]>{
        return this.inspectorService.getInspectorList("User", "")
            .then((data: any[]) => {
                let list: SelectItem[] = [];
                if(data) {
                    data.forEach(item => {
                        list.push({
                            value: item.id,
                            label: `${item.firstName} ${item.lastName}`
                        });
                    });

                    list.sort((a,b) => {
                        let aa = (a.label || '').toLowerCase();
                        let bb = (b.label || '').toLowerCase(); 
                        return (aa > bb) ? 1 : ((bb > aa) ? -1 : 0);
                    }); 
                }
                return list;
            })
            .catch(this.commonService.handleError);
    }

    generateRiskSummary(id) : Observable<any>{
        return this.http.get(`${Constants.ApiUrl}/GenerateRiskSummary/${id}`)
            .catch(this.commonService.handleObservableHttpError);
    }

    checkIOBasedOnRole(role): boolean{
        return true;
        // if(isNullOrUndefined(this.inspectionOrder)) return false;

        // switch(this.inspectionOrder.policy.inspectionStatusId){
        //     case InspectionStatusConstants.PendingAssignment: {
        //         // If user is manager: can edit IO
        //         return this.auth.isInspectorManager(role) || this.auth.isAdmin(role);
        //     }
        //     case InspectionStatusConstants.ReadyToSchedule: {
        //         // If user is manager/inspector: can edit IO
        //         return this.auth.isInspectorManager(role) || 
        //             this.auth.isInspector(role) ||
        //             this.auth.isAdmin(role);
        //     }
        //     case InspectionStatusConstants.Scheduled: {
        //         // If user is manager/inspector: can edit IO
        //         return this.auth.isInspectorManager(role) || 
        //             this.auth.isInspector(role) ||
        //             this.auth.isAdmin(role);
        //     }
        //     case InspectionStatusConstants.PendingWriteUp: {
        //         // If user is manager/inspector: can edit IO
        //         return this.auth.isInspector(role) ||
        //             this.auth.isAdmin(role);
        //     }
        //     case InspectionStatusConstants.PendingQC: {
        //         // No one can edit, just review for manager
        //         return this.auth.isInspectorManager(role) ||
        //             this.auth.isAdmin(role);
        //     }
        //     case InspectionStatusConstants.PendingQCItem: {
        //         // If user is manager/inspector: can edit IO
        //         return this.auth.isInspectorManager(role) || 
        //             this.auth.isInspector(role) ||
        //             this.auth.isAdmin(role);
        //     }
        //     case InspectionStatusConstants.PendingUWReview: {
        //         // No one can edit, just review for underwriter
        //         return this.auth.isUnderWriter(role) ||
        //             this.auth.isAdmin(role);
        //     }
        //     case InspectionStatusConstants.UWIssues: {
        //         // If user is manager/inspector: can edit IO
        //         return this.auth.isInspectorManager(role) || 
        //             this.auth.isInspector(role) ||
        //             this.auth.isAdmin(role);
        //     }
        //     case InspectionStatusConstants.UWApproved:
        //     default:
        //         return this.auth.isAdmin(role);
        // }
    }

    checkIOMitigationBasedOnRole(role): boolean{
        return true;
        // if(isNullOrUndefined(this.inspectionOrder)) return false;

        // switch(this.inspectionOrder.policy.mitigationStatusId){
        //     case MitigationStatusConstants.PendingReview: {
        //         // inspector can edit/review mitigation
        //         return this.auth.isInspector(role) ||
        //             this.auth.isAdmin(role);
        //     }
        //     case MitigationStatusConstants.NoneRequired:
        //     case MitigationStatusConstants.OutstandingItems:
        //     case MitigationStatusConstants.Completed:
        //     default: 
        //         return this.auth.isAdmin(role);
        // }
    }

    lockIO(id, isLock): Observable<boolean> {
        return this.http.put<boolean>(`${Constants.ApiUrl}/LockIO?id=${id}&isLock=${isLock}`, {})
            .catch(this.commonService.handleObservableHttpError);
    }

    unlockIO(id): Observable<boolean> {
        return this.lockIO(id, false);
    }

    checkIfIOIsLocked(id): Observable<boolean> {
        return this.http.get<boolean>(`${Constants.ApiUrl}/CheckIfIoIsLocked/${id}`)
            .catch(this.commonService.handleObservableHttpError);
    }
}