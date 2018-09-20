import { OtherAttachmentType } from "./other-attachment-type";


export class InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherAttachmentTypes {
    otherAttachmentTypeId?: string;
    /*[ForeignKey(nameof(OtherAttachmentTypeId))]*/
    otherAttachmentType?: OtherAttachmentType;
    public constructor(init?:Partial<InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherAttachmentTypes>) {
        Object.assign(this, init);
    }
}