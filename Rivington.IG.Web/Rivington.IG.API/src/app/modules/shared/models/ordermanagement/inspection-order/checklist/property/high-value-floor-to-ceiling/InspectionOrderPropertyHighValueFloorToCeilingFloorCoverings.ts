import { FloorCovering } from "./floor-covering";

export class InspectionOrderPropertyHighValueFloorToCeilingFloorCoverings {
    floorCoveringId?: string;
    /*[ForeignKey(nameof(floorCoveringId))]*/
    floorCovering?: FloorCovering;
    public constructor(init?:Partial<InspectionOrderPropertyHighValueFloorToCeilingFloorCoverings>) {
        Object.assign(this, init);
    }
}