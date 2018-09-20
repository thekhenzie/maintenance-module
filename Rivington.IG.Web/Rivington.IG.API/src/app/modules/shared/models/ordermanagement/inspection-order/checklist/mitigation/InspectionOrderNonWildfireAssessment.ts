import { InspectionOrderProperty } from "../property";
import { InspectionOrderPropertyNonWildfireAssessmentMitigation } from "./InspectionOrderNonWildfireAssessmentMitigation";

export class InspectionOrderPropertyNonWildfireAssessment {
    
    id?: string;

    inspectionOrderProperty?: InspectionOrderProperty;

    mitigation?: InspectionOrderPropertyNonWildfireAssessmentMitigation;

    public constructor(init?:Partial<InspectionOrderPropertyNonWildfireAssessment>) {
        Object.assign(this, init);
    }
}