import { SurroundingAreaConcernDetail } from "./surrounding-area-concern-detail";

export class InspectionOrderPropertyBuildingConcernSurroundingAreaConcernDetails {
    surroundingAreaConcernDetailId?: string;
    /*[ForeignKey(nameof(surroundingAreaConcernDetailId))]*/
    surroundingAreaConcernDetail?: SurroundingAreaConcernDetail;
    public constructor(init?:Partial<InspectionOrderPropertyBuildingConcernSurroundingAreaConcernDetails>) {
        Object.assign(this, init);
    }
}