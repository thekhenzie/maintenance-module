import { RoofConcernDetails } from "./roof-concern-details";

export class InspectionOrderWildfireAssessmentRoofRoofConcernDetails {
    roofConcernDetailId?: string;
    /*[ForeignKey(nameof(RoofConcernDetailId))]*/
    roofConcernDetail?: RoofConcernDetails;
    public constructor(init?:Partial<InspectionOrderWildfireAssessmentRoofRoofConcernDetails>) {
        Object.assign(this, init);
    }
}