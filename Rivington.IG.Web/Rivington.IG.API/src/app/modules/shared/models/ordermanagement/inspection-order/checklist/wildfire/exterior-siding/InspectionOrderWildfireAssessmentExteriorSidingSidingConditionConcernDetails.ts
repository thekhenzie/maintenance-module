import { SidingConditionConernsDetails } from "./siding-condition-concerns-details";


export class InspectionOrderWildfireAssessmentExteriorSidingSidingConditionConcernDetails {
    sidingConditionConcernDetailId?: string;
    /*[ForeignKey(nameof(SidingConditionConcernDetailId))]*/
    sidingConditionConcernDetail?: SidingConditionConernsDetails;
    public constructor(init?:Partial<InspectionOrderWildfireAssessmentExteriorSidingSidingConditionConcernDetails>) {
        Object.assign(this, init);
    }
}