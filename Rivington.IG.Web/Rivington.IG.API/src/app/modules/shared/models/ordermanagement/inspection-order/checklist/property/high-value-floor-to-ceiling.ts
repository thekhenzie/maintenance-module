import { InspectionOrderProperty } from "../property";
import { InspectionOrderPropertyHighValueFloorToCeilingCeilings } from "./high-value-floor-to-ceiling/InspectionOrderPropertyHighValueFloorToCeilingCeilings";
import { InspectionOrderPropertyHighValueFloorToCeilingFloorCoverings } from "./high-value-floor-to-ceiling/InspectionOrderPropertyHighValueFloorToCeilingFloorCoverings";
import { InspectionOrderPropertyHighValueFloorToCeilingInteriorWallCoverings } from "./high-value-floor-to-ceiling/InspectionOrderPropertyHighValueFloorToCeilingInteriorWallCoverings";
import { InspectionOrderPropertyHighValueFloorToCeilingWallTrims } from "./high-value-floor-to-ceiling/InspectionOrderPropertyHighValueFloorToCeilingWallTrims";
import { InspectionOrderPropertyHighValueFloorToCeilingWindowBrands } from "./high-value-floor-to-ceiling/InspectionOrderPropertyHighValueFloorToCeilingWindowBrands";
import { InspectionOrderPropertyHighValueFloorToCeilingWindowStyles } from "./high-value-floor-to-ceiling/InspectionOrderPropertyHighValueFloorToCeilingWindowStyles";
import { ChimneyType } from "./high-value-floor-to-ceiling/chimney-type";

export class InspectionOrderPropertyHighValueFloorToCeiling {
    /*[Parent]*/
    inspectionOrderProperty?: InspectionOrderProperty;
    /*[Key]*/
    id?: string;
    floorCoverings?: InspectionOrderPropertyHighValueFloorToCeilingFloorCoverings[];
    averageWallHeight?: string;
    ceilings?: InspectionOrderPropertyHighValueFloorToCeilingCeilings[];
    interiorWallCoverings?: InspectionOrderPropertyHighValueFloorToCeilingInteriorWallCoverings[];
    wallTrims?: InspectionOrderPropertyHighValueFloorToCeilingWallTrims[];
    windowStyles?: InspectionOrderPropertyHighValueFloorToCeilingWindowStyles[];
    windowBrands?: InspectionOrderPropertyHighValueFloorToCeilingWindowBrands[];
    numberofChimney?: number;
    chimneyTypeId?: string;
    /*[ForeignKey(nameof(ChimneyTypeId))]*/
    chimneyType?: ChimneyType;
    public constructor(init?:Partial<InspectionOrderPropertyHighValueFloorToCeiling>) {
        Object.assign(this, init);
    }
  }