import { FenceConditionConcernsDetails } from "./fence-condition-concerns-details";


export class InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFenceConditionConcernDetails {
    fenceConditionConcernDetailId?: string;
    /*[ForeignKey(nameof(FenceConditionConcernDetailId))]*/
    fenceConditionConcernDetail?: FenceConditionConcernsDetails;
    public constructor(init?:Partial<InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFenceConditionConcernDetails>) {
        Object.assign(this, init);
    }
}