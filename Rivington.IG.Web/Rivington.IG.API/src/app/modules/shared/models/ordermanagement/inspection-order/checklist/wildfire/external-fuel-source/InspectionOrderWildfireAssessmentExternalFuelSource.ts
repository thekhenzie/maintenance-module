import { ExternalFuelSourceType } from "./external-fuel-source-type";


export class InspectionOrderWildfireAssessmentExternalFuelSourceExternalFuelSourceTypes {
    externalFuelSourceTypeId?: string;
    /*[ForeignKey(nameof(ExternalFuelSourceTypeId))]*/
    externalFuelSourceType?: ExternalFuelSourceType;
    public constructor(init?:Partial<InspectionOrderWildfireAssessmentExternalFuelSourceExternalFuelSourceTypes>) {
        Object.assign(this, init);
    }
}