import { OtherWallCovering } from "./other-wall-covering";



export class InspectionOrderWildfireAssessmentExteriorSidingOtherWallCoverings {
    otherWallCoveringId?: string;
    /*[ForeignKey(nameof(OtherWallCoveringId))]*/
    otherWallCovering?: OtherWallCovering;
    public constructor(init?:Partial<InspectionOrderWildfireAssessmentExteriorSidingOtherWallCoverings>) {
        Object.assign(this, init);
    }
}