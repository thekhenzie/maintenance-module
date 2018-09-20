import { InspectionOrderProperty } from "../property";
import { InspectionOrderPropertyHighValueBathBathroomCounters } from "./high-value-bath/InspectionOrderPropertyHighValueBathBathroomCounters";
import { InspectionOrderPropertyHighValueBathBathroomFixtures } from "./high-value-bath/InspectionOrderPropertyHighValueBathBathroomFixtures";
import { InspectionOrderPropertyHighValueBathBathroomFloors } from "./high-value-bath/InspectionOrderPropertyHighValueBathBathroomFloors";
import { InspectionOrderPropertyHighValueBathBathroomVanities } from "./high-value-bath/InspectionOrderPropertyHighValueBathBathroomVanities";
import { InspectionOrderPropertyHighValueBathTubsAndShowers } from "./high-value-bath/InspectionOrderPropertyHighValueBathTubsAndShowers";

export class InspectionOrderPropertyHighValueBath {
    /*[Parent]*/
    inspectionOrderProperty?: InspectionOrderProperty;
    /*[Key]*/
    id?: string;
    numberofFullBath?: boolean;
    numberofHalfBath?: boolean;
    bathroomFloors?: InspectionOrderPropertyHighValueBathBathroomFloors[];
    bathroomVanities?: InspectionOrderPropertyHighValueBathBathroomVanities[];
    bathroomCounters?: InspectionOrderPropertyHighValueBathBathroomCounters[];
    bathroomFixtures?: InspectionOrderPropertyHighValueBathBathroomFixtures[];
    tubsAndShowers?: InspectionOrderPropertyHighValueBathTubsAndShowers[];
    public constructor(init?:Partial<InspectionOrderPropertyHighValueBath>) {
        Object.assign(this, init);
    }
  }