import { InspectionOrderWildfireAssessment } from "../wildfire";
import { InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFencingTypes } from "./fencing-and-other-attachments/InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFencingTypes";
import { InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFenceConditionConcernDetails } from "./fencing-and-other-attachments/InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFenceConditionConcern";
import { InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherAttachmentTypes } from "./fencing-and-other-attachments/InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherAttachmentTypes";
import { InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOutbuildingDetails } from "./fencing-and-other-attachments/InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOutbuildingDetails";
import { InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherDetachedStructuresDetails } from "./fencing-and-other-attachments/InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherDetachedStructures";


export class InspectionOrderWildfireAssessmentFencingAndOtherAttachment {
    /*[Parent]*/
    inspectionOrderWildfireAssessment?: InspectionOrderWildfireAssessment;
    Id?: string;
    fencingWithin30Feet?: boolean;
    fencingTypes?: InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFencingTypes[];
    fenceConditionConcern?: boolean;
    fenceConditionConcernDetails?: InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFenceConditionConcernDetails[];
    fenceComment?: string;
    otherAttachment?: boolean;
    otherAttachmentTypes?: InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherAttachmentTypes[];
    outbuilding?: boolean;
    outbuildingDetails?: InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOutbuildingDetails[];
    otherDetachedStructure?: boolean;
    otherDetachedStructuresDetails?: InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherDetachedStructuresDetails[];

    public constructor(init?:Partial<InspectionOrderWildfireAssessmentFencingAndOtherAttachment>) {
        Object.assign(this, init);
    }
}