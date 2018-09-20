import { InspectionOrder } from "../../../inspection-order";
import { InspectionOrderWildfireAssessmentMitigation } from "./InspectionOrderWildfireAssessmentMitigation";

export class InspectionOrderWildfireAssessment {
    
    id?: string;

    inspectionOrder?: InspectionOrder;

    mitigation?: InspectionOrderWildfireAssessmentMitigation;

    public constructor(init?:Partial<InspectionOrderWildfireAssessment>) {
        Object.assign(this, init);
    }
}