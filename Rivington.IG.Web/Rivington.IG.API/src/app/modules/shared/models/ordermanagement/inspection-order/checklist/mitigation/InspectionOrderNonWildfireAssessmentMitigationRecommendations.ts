import { Image } from "../../../image";
import { InspectionOrderPropertyNonWildfireAssessmentMitigation } from "./InspectionOrderNonWildfireAssessmentMitigation";
import { PhotoMemo } from "../../PhotoMemo";
import { InspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendations } from "./InspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendations";

export class InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations extends PhotoMemo {

    id?: string;
    inspectionOrderNonWildfireAssessmentMitigationId?: string;
    inspectionOrderNonWildfireAssessmentMitigation?: InspectionOrderPropertyNonWildfireAssessmentMitigation;

    childMitigation?: InspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendations[]; 

    public constructor(init?: Partial<InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations>) {
        super();
        Object.assign(this, init);
    }
}