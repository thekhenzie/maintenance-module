import { RoofVenting } from "./roof-venting";

export class InspectionOrderWildfireAssessmentRoofRoofVentings {
    roofVentingId?: string;
    /*[ForeignKey(nameof(RoofVentingId))]*/
    roofVenting?: RoofVenting;
    public constructor(init?:Partial<InspectionOrderWildfireAssessmentRoofRoofVentings>) {
        Object.assign(this, init);
    }
}