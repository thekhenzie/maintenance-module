import { WallTrim } from "./wall-trim";

export class InspectionOrderPropertyHighValueFloorToCeilingWallTrims {
    wallTrimId?: string;
    /*[ForeignKey(nameof(wallTrimId))]*/
    wallTrim?: WallTrim;
    public constructor(init?:Partial<InspectionOrderPropertyHighValueFloorToCeilingWallTrims>) {
        Object.assign(this, init);
    }
}