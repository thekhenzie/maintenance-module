import { WindowScreenType } from "./window-screen-type";


export class InspectionOrderWildfireAssessmentWindowWindowScreenTypes {
    windowScreenTypeId?: string;
    /*[ForeignKey(nameof(WindowScreenTypeId))]*/
    windowScreenType?: WindowScreenType;
    public constructor(init?:Partial<InspectionOrderWildfireAssessmentWindowWindowScreenTypes>) {
        Object.assign(this, init);
    }
}