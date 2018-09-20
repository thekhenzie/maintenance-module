import { RoofConcernDetail } from "./roof-concern-detail";

export class InspectionOrderPropertyBuildingConcernRoofConcernDetails {
    roofConcernDetailId?: string;
    /*[ForeignKey(nameof(roofConcernDetailId))]*/
    roofConcernDetail?: RoofConcernDetail;
    public constructor(init?:Partial<InspectionOrderPropertyBuildingConcernRoofConcernDetails>) {
        Object.assign(this, init);
    }
}