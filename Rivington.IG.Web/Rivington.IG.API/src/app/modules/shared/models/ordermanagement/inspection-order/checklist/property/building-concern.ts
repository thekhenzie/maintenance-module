import { InspectionOrderProperty } from "../property";
import { InspectionOrderPropertyBuildingConcernElectricalConcernDetails } from "./building-concern/InspectionOrderPropertyBuildingConcernElectricalConcernDetails";
import { InspectionOrderPropertyBuildingConcernExteriorBuildingConcernDetails } from "./building-concern/InspectionOrderPropertyBuildingConcernExteriorBuildingConcernDetails";
import { InspectionOrderPropertyBuildingConcernOtherStructureConcernDetails } from "./building-concern/InspectionOrderPropertyBuildingConcernOtherStructureConcernDetails";
import { InspectionOrderPropertyBuildingConcernPlumbingConcernDetails } from "./building-concern/InspectionOrderPropertyBuildingConcernPlumbingConcernDetails";
import { InspectionOrderPropertyBuildingConcernRoofConcernDetails } from "./building-concern/InspectionOrderPropertyBuildingConcernRoofConcernDetails";
import { InspectionOrderPropertyBuildingConcernSurroundingAreaConcernDetails } from "./building-concern/InspectionOrderPropertyBuildingConcernSurroundingAreaConcernDetails";

export class InspectionOrderPropertyBuildingConcern {
    /*[Parent]*/
    inspectionOrderProperty?: InspectionOrderProperty;
    /*[Key]*/
    id?: string;
    exteriorBuildingConcernDetails?: InspectionOrderPropertyBuildingConcernExteriorBuildingConcernDetails[];
    roofConcernDetails?: InspectionOrderPropertyBuildingConcernRoofConcernDetails[];
    electricalConcernDetails?: InspectionOrderPropertyBuildingConcernElectricalConcernDetails[];
    plumbingConcernDetails?: InspectionOrderPropertyBuildingConcernPlumbingConcernDetails[];
    otherStructureConcernDetails?: InspectionOrderPropertyBuildingConcernOtherStructureConcernDetails[];
    surroundingAreaConcernDetails?: InspectionOrderPropertyBuildingConcernSurroundingAreaConcernDetails[];
    public constructor(init?:Partial<InspectionOrderPropertyBuildingConcern>) {
        Object.assign(this, init);
    }
  }