import { PhotoMemo } from "../../PhotoMemo";
import { InspectionOrderWildfireAssessmentMitigationRequirements } from "./InspectionOrderWildfireAssessmentMitigationRequirements";

export class InspectionOrderWildfireAssessmentChildMitigationRequirements extends PhotoMemo {
    
    ioWaParentMitigationRequirementsId?: string;
    ioWaParentMitigationRequirements?: InspectionOrderWildfireAssessmentMitigationRequirements;

    public constructor(init?: Partial<InspectionOrderWildfireAssessmentChildMitigationRequirements>) {
        super();
        Object.assign(this, init);
    }
}