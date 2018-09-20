import { ExteriorWindowCoveringType } from "./exterior-window-covering-type";


export class InspectionOrderWildfireAssessmentWindowExteriorWindowCoveringTypes {
    exteriorWindowCoveringTypeId?: string;
    /*[ForeignKey(nameof(ExteriorWindowCoveringTypeId))]*/
    exteriorWindowCoveringType?: ExteriorWindowCoveringType;
    public constructor(init?:Partial<InspectionOrderWildfireAssessmentWindowExteriorWindowCoveringTypes>) {
        Object.assign(this, init);
    }
}