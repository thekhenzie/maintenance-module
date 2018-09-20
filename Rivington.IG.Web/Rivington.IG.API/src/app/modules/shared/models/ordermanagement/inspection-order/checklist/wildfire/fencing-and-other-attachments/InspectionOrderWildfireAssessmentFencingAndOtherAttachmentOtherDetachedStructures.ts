import { OtherDetachedStructuresDetail } from "../../property/detached-structure/other-detached-structures-detail";



export class InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherDetachedStructuresDetails {
    otherDetachedStructuresDetailId?: string;
    /*[ForeignKey(nameof(OtherDetachedStructuresDetailId))]*/
    otherDetachedStructuresDetail?: OtherDetachedStructuresDetail;
    public constructor(init?:Partial<InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherDetachedStructuresDetails>) {
        Object.assign(this, init);
    }
}