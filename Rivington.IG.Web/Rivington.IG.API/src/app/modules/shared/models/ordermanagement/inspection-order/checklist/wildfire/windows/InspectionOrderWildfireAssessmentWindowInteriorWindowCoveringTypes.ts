import { InteriorWindowCoveringType } from "./interior-window-covering-type";


export class InspectionOrderWildfireAssessmentWindowInteriorWindowCoveringTypes {
    interiorWindowCoveringTypeId?: string;
    /*[ForeignKey(nameof(InteriorWindowCoveringTypeId))]*/
    interiorWindowCoveringType?: InteriorWindowCoveringType;
    public constructor(init?:Partial<InspectionOrderWildfireAssessmentWindowInteriorWindowCoveringTypes>) {
        Object.assign(this, init);
    }
}