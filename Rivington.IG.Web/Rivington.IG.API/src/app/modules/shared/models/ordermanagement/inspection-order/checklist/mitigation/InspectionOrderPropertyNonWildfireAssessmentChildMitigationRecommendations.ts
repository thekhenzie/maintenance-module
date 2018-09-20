import { PhotoMemo } from "../../PhotoMemo";
import { InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations } from "./InspectionOrderNonWildfireAssessmentMitigationRecommendations";

export class InspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendations extends PhotoMemo {

    ioNWaParentMitigationRecommendationsId?: string;
    ioNWaParentMitigationRecommendations?: InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations;

    public constructor(init?: Partial<InspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendations>) {
        super();
        Object.assign(this, init);
    }
}