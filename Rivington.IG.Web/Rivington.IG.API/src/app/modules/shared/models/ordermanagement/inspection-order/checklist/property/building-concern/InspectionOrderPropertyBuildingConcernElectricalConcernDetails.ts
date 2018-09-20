import { ElectricalConcernDetail } from "./electrical-concern-details";

export class InspectionOrderPropertyBuildingConcernElectricalConcernDetails {
    electricalConcernDetailId?: string;
    /*[ForeignKey(nameof(electricalConcernDetailId))]*/
    electricalConcernDetail?: ElectricalConcernDetail;
    public constructor(init?:Partial<InspectionOrderPropertyBuildingConcernElectricalConcernDetails>) {
        Object.assign(this, init);
    }
}