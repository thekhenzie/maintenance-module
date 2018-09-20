import { ExteriorBuildingConcernDetail } from "./exterior-building-concern-detail";

export class InspectionOrderPropertyBuildingConcernExteriorBuildingConcernDetails {
    exteriorBuildingConcernDetailId?: string;
    /*[ForeignKey(nameof(exteriorBuildingConcernDetailId))]*/
    exteriorBuildingConcernDetail?: ExteriorBuildingConcernDetail;
    public constructor(init?:Partial<InspectionOrderPropertyBuildingConcernExteriorBuildingConcernDetails>) {
        Object.assign(this, init);
    }
}