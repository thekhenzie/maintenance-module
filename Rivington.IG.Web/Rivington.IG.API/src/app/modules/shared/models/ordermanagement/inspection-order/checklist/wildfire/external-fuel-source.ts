import { InspectionOrderWildfireAssessment } from "../wildfire";
import { InspectionOrderWildfireAssessmentExternalFuelSourceExternalFuelSourceTypes } from "./external-fuel-source/InspectionOrderWildfireAssessmentExternalFuelSource";


export class InspectionOrderWildfireAssessmentExternalFuelSource {
    /*[Parent]*/
    inspectionOrderWildfireAssessment?: InspectionOrderWildfireAssessment;
    Id?: string;
    externalFuelSource?: boolean;
    externalFuelSourceTypes?: InspectionOrderWildfireAssessmentExternalFuelSourceExternalFuelSourceTypes[];
    externalFuelSourceDistanceFromHome?: number;
    woodStoveOrFireplace?: boolean;
    woodStorageLocation?: string;
    firePeventiveMeasure?: string;
    
    public constructor(init?:Partial<InspectionOrderWildfireAssessmentExternalFuelSource>) {
        Object.assign(this, init);
    }
}