import { Image } from "../../../image";
import { InspectionOrderWildfireAssessmentMitigation } from "./InspectionOrderWildfireAssessmentMitigation";
import { PhotoMemo } from "../../PhotoMemo";
import { InspectionOrderWildfireAssessmentChildMitigationRecommendations } from "./InspectionOrderWildfireAssessmentChildMitigationRecommendations";

export class InspectionOrderWildfireAssessmentMitigationRecommendations extends PhotoMemo {

    id?: string;
    inspectionOrderWildfireAssessmentMitigationId?: string;
    inspectionOrderWildfireAssessmentMitigation?: InspectionOrderWildfireAssessmentMitigation;

    childMitigation?: InspectionOrderWildfireAssessmentChildMitigationRecommendations[];

    public constructor(init?: Partial<InspectionOrderWildfireAssessmentMitigationRecommendations>) {
        super();
        Object.assign(this, init);
    }
}