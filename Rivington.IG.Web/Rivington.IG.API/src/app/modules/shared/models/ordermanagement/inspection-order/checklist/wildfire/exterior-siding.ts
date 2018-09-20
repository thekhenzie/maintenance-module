import { PrimaryExteriorWallCovering } from "./exterior-siding/primary-exterior-wall-covering";
import { SecondaryExteriorWallCovering } from "./exterior-siding/seecondary-exterior-wall-covering";
import { InspectionOrderWildfireAssessmentExteriorSidingOtherWallCoverings } from "./exterior-siding/InspectionOrderWildfireAssessmentExteriorSidingOtherWallCoverings";
import { InspectionOrderWildfireAssessmentExteriorSidingSidingConditionConcernDetails } from "./exterior-siding/InspectionOrderWildfireAssessmentExteriorSidingSidingConditionConcernDetails";
import { InspectionOrderWildfireAssessment } from "../wildfire";

export class InspectionOrderWildfireAssessmentExteriorSiding {
    /*[Parent]*/
    inspectionOrderWildfireAssessment?: InspectionOrderWildfireAssessment;
    Id?: string;
    primaryExteriorWallCoveringId?: string;
    // [ForeignKey(nameof(PrimaryExteriorWallCoveringId))]
    primaryExteriorWallCoverng?: PrimaryExteriorWallCovering;
    secondaryExteriorWallCoveringId?: string;
    // [ForeignKey(nameof(SecondaryExteriorWallCoveringId))]
    secondaryExteriorWallCovering?: SecondaryExteriorWallCovering;
    otherWallCoverings?: InspectionOrderWildfireAssessmentExteriorSidingOtherWallCoverings[];
    nonCombustibleSiding?: boolean;
    sidingConditionConcern?: boolean;
    sidingConditionConcernDetails?: InspectionOrderWildfireAssessmentExteriorSidingSidingConditionConcernDetails[];
    sidingConditionComment?: string;
    
    public constructor(init?:Partial<InspectionOrderWildfireAssessmentExteriorSiding>) {
        Object.assign(this, init);
    }
}