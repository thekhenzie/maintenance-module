import { InspectionOrderWildfireAssessmentMitigationRequirements } from "./InspectionOrderWildfireAssessmentMitigationRequirements";
import { InspectionOrderWildfireAssessment } from "./InspectionOrderWildfireAssessment";
import { InspectionOrderWildfireAssessmentMitigationRecommendations } from "./InspectionOrderWildfireAssessmentMitigationRecommendations";

export class InspectionOrderWildfireAssessmentMitigation {
    
    id?: string;

    inspectionOrderWildfireAssessment?: InspectionOrderWildfireAssessment;

    requirements?: InspectionOrderWildfireAssessmentMitigationRequirements[];
    recommendations?: InspectionOrderWildfireAssessmentMitigationRecommendations[];

    public constructor(init?:Partial<InspectionOrderWildfireAssessmentMitigation>) {
        Object.assign(this, init);
    }
}