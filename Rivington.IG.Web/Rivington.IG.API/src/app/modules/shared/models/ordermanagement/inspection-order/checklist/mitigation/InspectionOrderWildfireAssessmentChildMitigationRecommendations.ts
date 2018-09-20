import { PhotoMemo } from "../../PhotoMemo";
import { InspectionOrderWildfireAssessmentMitigationRecommendations } from "./InspectionOrderWildfireAssessmentMitigationRecommendations";

export class InspectionOrderWildfireAssessmentChildMitigationRecommendations extends PhotoMemo {
    
    ioWaParentMitigationRecommendationsId?: string;
    ioWaParentMitigationRecommendations?: InspectionOrderWildfireAssessmentMitigationRecommendations;
    
    public constructor(init?: Partial<InspectionOrderWildfireAssessmentChildMitigationRecommendations>) {
        super();
        Object.assign(this, init);
    }
}