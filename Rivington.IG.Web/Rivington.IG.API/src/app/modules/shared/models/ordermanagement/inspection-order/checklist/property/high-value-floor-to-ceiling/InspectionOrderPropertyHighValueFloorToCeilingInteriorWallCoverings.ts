import { InteriorWallCovering } from "./interior-wall-covering";

export class InspectionOrderPropertyHighValueFloorToCeilingInteriorWallCoverings {
    interiorWallCoveringId?: string;
    /*[ForeignKey(nameof(interiorWallCoveringId))]*/
    interiorWallCovering?: InteriorWallCovering;
    public constructor(init?:Partial<InspectionOrderPropertyHighValueFloorToCeilingInteriorWallCoverings>) {
        Object.assign(this, init);
    }
}