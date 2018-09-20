import { OutbuildingDetail } from "./outbuilding-detail";

export class InspectionOrderPropertyDetachedStructureOutbuildingDetails {
    outbuildingDetailId?: string;
    /*[ForeignKey(nameof(outbuildingDetailId))]*/
    outbuildingDetail?: OutbuildingDetail;
    public constructor(init?:Partial<InspectionOrderPropertyDetachedStructureOutbuildingDetails>) {
        Object.assign(this, init);
    }
}