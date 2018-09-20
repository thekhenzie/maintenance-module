import { WindowConcernsDetails } from "./window-concerns-details";


export class InspectionOrderWildfireAssessmentWindowWindowConcernDetails {
    windowConcernDetailId?: string;
    /*[ForeignKey(nameof(WindowConcernDetailId))]*/
    windowConcernsDetail?: WindowConcernsDetails;
    public constructor(init?:Partial<InspectionOrderWildfireAssessmentWindowWindowConcernDetails>) {
        Object.assign(this, init);
    }
}