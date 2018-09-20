import { OutbuildingDetail } from "../../property/detached-structure/outbuilding-detail";



export class InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOutbuildingDetails {
    outbuildingDetailId?: string;
    /*[ForeignKey(nameof(OutbuildingDetailId))]*/
    outbuildingDetail?: OutbuildingDetail;
    public constructor(init?:Partial<InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOutbuildingDetails>) {
        Object.assign(this, init);
    }
}