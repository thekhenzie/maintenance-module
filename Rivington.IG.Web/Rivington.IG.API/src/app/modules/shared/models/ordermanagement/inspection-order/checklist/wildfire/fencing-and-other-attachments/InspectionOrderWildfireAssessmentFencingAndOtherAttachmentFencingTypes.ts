import { FencingType } from "./fencing-type";

export class InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFencingTypes {
    fencingTypeId?: string;
    /*[ForeignKey(nameof(FencingTypeId))]*/
    fencingTypes?: FencingType;
    public constructor(init?:Partial<InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFencingTypes>) {
        Object.assign(this, init);
    }
}