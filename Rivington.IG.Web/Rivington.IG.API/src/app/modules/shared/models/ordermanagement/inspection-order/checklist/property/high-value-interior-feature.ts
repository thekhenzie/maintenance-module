import { InspectionOrderProperty } from "../property";
import { InspectionOrderPropertyHighValueInteriorFeatureDoorHardwares } from "./high-value-interior-feature/InspectionOrderPropertyHighValueInteriorFeatureDoorHardwares";
import { InspectionOrderPropertyHighValueInteriorFeatureFireplaceTypes } from "./high-value-interior-feature/InspectionOrderPropertyHighValueInteriorFeatureFireplaceTypes";
import { InspectionOrderPropertyHighValueInteriorFeatureInteriorDoorTypes } from "./high-value-interior-feature/InspectionOrderPropertyHighValueInteriorFeatureInteriorDoorTypes";
import { InspectionOrderPropertyHighValueInteriorFeatureLightingTypes } from "./high-value-interior-feature/InspectionOrderPropertyHighValueInteriorFeatureLightingTypes";
import { InspectionOrderPropertyHighValueInteriorFeatureMiscellaneousExtraFeatures } from "./high-value-interior-feature/InspectionOrderPropertyHighValueInteriorFeatureMiscellaneousExtraFeatures";
import { InspectionOrderPropertyHighValueInteriorFeatureRoomsWithCabinetry } from "./high-value-interior-feature/InspectionOrderPropertyHighValueInteriorFeatureRoomsWithCabinetry";
import { InspectionOrderPropertyHighValueInteriorFeatureStaircases } from "./high-value-interior-feature/InspectionOrderPropertyHighValueInteriorFeatureStaircases";

export class InspectionOrderPropertyHighValueInteriorFeature {
    /*[Parent]*/
    inspectionOrderProperty?: InspectionOrderProperty;
    /*[Key]*/
    id?: string;
    interiorDoorTypes?: InspectionOrderPropertyHighValueInteriorFeatureInteriorDoorTypes[];
    doorHardwares?: InspectionOrderPropertyHighValueInteriorFeatureDoorHardwares[];
    roomWithCabinetrys?: InspectionOrderPropertyHighValueInteriorFeatureRoomsWithCabinetry[];
    lightingTypes?: InspectionOrderPropertyHighValueInteriorFeatureLightingTypes[];
    numberofFireplace?: number;
    fireplaceTypes?: InspectionOrderPropertyHighValueInteriorFeatureFireplaceTypes[];
    staircases?: InspectionOrderPropertyHighValueInteriorFeatureStaircases[];
    miscellaneousExtraFeatures?: InspectionOrderPropertyHighValueInteriorFeatureMiscellaneousExtraFeatures[];
    public constructor(init?:Partial<InspectionOrderPropertyHighValueInteriorFeature>) {
        Object.assign(this, init);
    }
  }