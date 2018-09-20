import { MitigationStatus } from "./mitigationstatus";
import { PropertyValue } from "./propertyvalue";
import { InspectionStatus } from "./inspectionstatus";

export interface IPolicy {
    id?: string;
    policyNumber?: string;

    inspectionDate?: Date;
    insuredFirstName?: string;
    insuredMiddleName?: string;
    insuredLastName?: string;
    insuredEmail?: string;

    agencyName?: string;
    agencyPhoneNumber?: string;

    agentName?: string;
    agentPhoneNumber?: string;

    coverageA?: number;
    e2ValueReplacementCostValue?: number;
    itvPercentage?: number;
    wildfireAssessmentRequired?: boolean;

    address?: string;

    inspectionStatus?: InspectionStatus;
    mitigationStatus?: MitigationStatus;
    propertyValue?: PropertyValue;

    latitude?: string;
    longitude?: string;
}

export class Policy implements IPolicy {
    id?: string;
    policyNumber?: string;
    inspectionDate?: Date;
    inceptionDate?: Date;    
    insuredFirstName?: string;
    insuredMiddleName?: string;
    insuredLastName?: string
    insuredEmail?: string
    insuredCity? : string;
    insuredState? : string;
    insuredZipCode? : string;

    agencyName?: string;
    agencyPhoneNumber?: string;
    agentName?: string;
    agentPhoneNumber?: string;

    coverageA?: number;
    e2ValueReplacementCostValue?: number;
    itvPercentage?: number;
    wildfireAssessmentRequired?: boolean;

    address?: string;

    inspectionStatusId?:string
    inspectionStatus?: InspectionStatus;

    mitigationStatusId?:string
    mitigationStatus?: MitigationStatus;

    propertyValueId?:string
    propertyValue?: PropertyValue;

    phone?: string;
    mobile?: string;
    email?: string;

    latitude?: string;
    longitude?: string;

    public constructor(init?: Partial<IPolicy>) {
        Object.assign(this, init);
    }
}