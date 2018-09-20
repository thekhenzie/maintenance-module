import { PhotoMemo } from "../../PhotoMemo";
import { InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements } from "./InspectionOrderNonWildfireAssessmentMitigationRequirements";

export class InspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirements extends PhotoMemo {
    
    ioNWaParentMitigationRequirementsId?: string;
    ioNWaParentMitigationRequirements?: InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements;

    public constructor(init?: Partial<InspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirements>) {
        super();
        Object.assign(this, init);
    }
}