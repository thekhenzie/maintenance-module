import { WindowGlassType } from "./window-glass-type";


export class InspectionOrderWildfireAssessmentWindowWindowGlassTypes {
    windowGlassTypeId?: string;
    /*[ForeignKey(nameof(WindowGlassTypeId))]*/
    windowGlassType?: WindowGlassType;
    public constructor(init?:Partial<InspectionOrderWildfireAssessmentWindowWindowGlassTypes>) {
        Object.assign(this, init);
    }
}