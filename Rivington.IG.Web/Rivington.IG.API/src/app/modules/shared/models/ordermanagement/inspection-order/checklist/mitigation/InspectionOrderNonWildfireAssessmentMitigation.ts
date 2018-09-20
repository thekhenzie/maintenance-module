import { InspectionOrderPropertyNonWildfireAssessment } from "./InspectionOrderNonWildfireAssessment";
import { InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements } from "./InspectionOrderNonWildfireAssessmentMitigationRequirements";
import { InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations } from "./InspectionOrderNonWildfireAssessmentMitigationRecommendations";

export class InspectionOrderPropertyNonWildfireAssessmentMitigation {
    
    id?: string;

    inspectionOrderNonWildfireAssessment?: InspectionOrderPropertyNonWildfireAssessment;

    requirements?: InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements[];
    recommendations?: InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations[];

    public constructor(init?:Partial<InspectionOrderPropertyNonWildfireAssessmentMitigation>) {
        Object.assign(this, init);
    }
}