import { PhotoMemo } from "../../PhotoMemo";
import { InspectionOrderWildfireAssessmentMitigation } from "./InspectionOrderWildfireAssessmentMitigation";
import { InspectionOrderWildfireAssessmentChildMitigationRequirements } from "./InspectionOrderWildfireAssessmentChildMitigationRequirements";

export class InspectionOrderWildfireAssessmentMitigationRequirements extends PhotoMemo {

    id?: string;
    inspectionOrderWildfireAssessmentMitigationId?: string;
    inspectionOrderWildfireAssessmentMitigation?: InspectionOrderWildfireAssessmentMitigation;

    childMitigation?: InspectionOrderWildfireAssessmentChildMitigationRequirements[];
    
    public constructor(init?: Partial<InspectionOrderWildfireAssessmentMitigationRequirements>) {
        super();
        Object.assign(this, init);
    }
}