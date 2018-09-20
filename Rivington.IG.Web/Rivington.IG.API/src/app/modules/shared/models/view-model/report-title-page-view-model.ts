export class ReportTitleViewModel {

    public constructor(init?:Partial<ReportTitleViewModel>) {
        Object.assign(this, init);
    }

    //Roof
    id? : string;
    insuredFullname? : string;
    insuredAddress? : string;
    insuredCityStateZipCode? : string;
    inspectorFullName? : string;
    inspectorEmail? : string;
    inspectorMobileNumber? : string;
    
    agentName? : string;
    agencyName? : string;
    agentPhoneNumber? : string;

    inspectionDate? : Date;
    policyNumber? : string;

    photo? : string;
}