import { InspectionOrderProperty } from "../property";
import { InspectionOrderPropertyDetachedStructureOtherDetachedStructuresDetails } from "./detached-structure/InspectionOrderPropertyDetachedStructureOtherDetachedStructuresDetails";
import { InspectionOrderPropertyDetachedStructureOutbuildingDetails } from "./detached-structure/InspectionOrderPropertyDetachedStructureOutbuildingDetails";

export class InspectionOrderPropertyDetachedStructure {
    /*[Parent]*/
    inspectionOrderProperty?: InspectionOrderProperty;
    /*[Key]*/
    id?: string;
    outbuilding?: boolean;
    outbuildingDetails?: InspectionOrderPropertyDetachedStructureOutbuildingDetails[];
    outbuildingTypeOrConstruction?: string;
    outbuildingConcernOrComment?: string;
    otherDetachedStructure?: boolean;
    otherDetachedStructuresDetails?: InspectionOrderPropertyDetachedStructureOtherDetachedStructuresDetails[];
    public constructor(init?:Partial<InspectionOrderPropertyDetachedStructure>) {
        Object.assign(this, init);
    }
  }