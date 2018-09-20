import { WindowStyles } from "./window-styles";


export class InspectionOrderWildfireAssessmentWindowWindowStyles {
    windowStyleId?: string;
    /*[ForeignKey(nameof(WindowStyleId))]*/
    windowStyle?: WindowStyles;
    public constructor(init?:Partial<InspectionOrderWildfireAssessmentWindowWindowStyles>) {
        Object.assign(this, init);
    }
}