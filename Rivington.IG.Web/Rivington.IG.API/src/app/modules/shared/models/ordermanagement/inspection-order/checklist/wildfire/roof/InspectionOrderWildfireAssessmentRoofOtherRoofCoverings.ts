import { OtherRoofCovering } from "./other-roof-covering";

export class InspectionOrderWildfireAssessmentRoofOtherRoofCoverings {
    otherRoofCoveringId?: string;
    /*[ForeignKey(nameof(OtherRoofCoveringId))]*/
    otherRoofCovering?: OtherRoofCovering;
    public constructor(init?:Partial<InspectionOrderWildfireAssessmentRoofOtherRoofCoverings>) {
        Object.assign(this, init);
    }
}