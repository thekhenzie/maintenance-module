import { Ceiling } from "./ceiling";

export class InspectionOrderPropertyHighValueFloorToCeilingCeilings {
    ceilingId?: string;
    /*[ForeignKey(nameof(ceilingId))]*/
    ceiling?: Ceiling;
    public constructor(init?:Partial<InspectionOrderPropertyHighValueFloorToCeilingCeilings>) {
        Object.assign(this, init);
    }
}