import { OtherStructureConcernDetail } from "./other-structure-concern-detail";

export class InspectionOrderPropertyBuildingConcernOtherStructureConcernDetails {
    otherStructureConcernDetailId?: string;
    /*[ForeignKey(nameof(otherStructureConcernDetailId))]*/
    otherStructureConcernDetail?: OtherStructureConcernDetail;
    public constructor(init?:Partial<InspectionOrderPropertyBuildingConcernOtherStructureConcernDetails>) {
        Object.assign(this, init);
    }
}