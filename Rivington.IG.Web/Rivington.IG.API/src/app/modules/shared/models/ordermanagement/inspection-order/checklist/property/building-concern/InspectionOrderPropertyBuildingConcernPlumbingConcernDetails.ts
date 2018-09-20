import { PlumbingConcernDetail } from "./plumbing-concern-detail";

export class InspectionOrderPropertyBuildingConcernPlumbingConcernDetails {
    plumbingConcernDetailId?: string;
    /*[ForeignKey(nameof(plumbingConcernDetailId))]*/
    plumbingConcernDetail?: PlumbingConcernDetail;
    public constructor(init?:Partial<InspectionOrderPropertyBuildingConcernPlumbingConcernDetails>) {
        Object.assign(this, init);
    }
}