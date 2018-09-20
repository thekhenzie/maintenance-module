import { Image } from "../../../image";
import { InspectionOrderPropertyNonWildfireAssessmentMitigation } from "./InspectionOrderNonWildfireAssessmentMitigation";
import { PhotoMemo } from "../../PhotoMemo";
import { InspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirements } from "./InspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirements";

export class InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements extends PhotoMemo {

    id?: string;
    inspectionOrderNonWildfireAssessmentMitigationId?: string;
    inspectionOrderNonWildfireAssessmentMitigation?: InspectionOrderPropertyNonWildfireAssessmentMitigation;

    childMitigation?: InspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirements;

    public constructor(init?: Partial<InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements>) {
        super();
        Object.assign(this, init);
    }
}