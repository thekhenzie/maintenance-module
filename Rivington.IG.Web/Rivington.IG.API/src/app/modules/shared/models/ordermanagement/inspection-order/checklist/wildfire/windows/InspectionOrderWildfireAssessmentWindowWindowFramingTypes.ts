import { WindowFramingType } from "./window-framing-type";


export class InspectionOrderWildfireAssessmentWindowWindowFramingTypes {
    windowFramingTypeId?: string;
    /*[ForeignKey(nameof(WindowFramingTypeId))]*/
    windowFramingType?: WindowFramingType;
    public constructor(init?:Partial<InspectionOrderWildfireAssessmentWindowWindowFramingTypes>) {
        Object.assign(this, init);
    }
}