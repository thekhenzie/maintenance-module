import { GutterType } from "./gutter-type";

export class InspectionOrderWildfireAssessmentRoofGutterTypes {
    gutterTypeId?: string;
    /*[ForeignKey(nameof(GutterTypeId))]*/
    gutterTypes?: GutterType;
    public constructor(init?:Partial<InspectionOrderWildfireAssessmentRoofGutterTypes>) {
        Object.assign(this, init);
    }
}