import { OtherDetachedStructuresDetail } from "./other-detached-structures-detail";

export class InspectionOrderPropertyDetachedStructureOtherDetachedStructuresDetails {
    otherDetachedStructuresDetailId?: string;
    /*[ForeignKey(nameof(otherDetachedStructuresDetailId))]*/
    otherDetachedStructuresDetail?: OtherDetachedStructuresDetail;
    public constructor(init?:Partial<InspectionOrderPropertyDetachedStructureOtherDetachedStructuresDetails>) {
        Object.assign(this, init);
    }
}