import { InteriorDoorType } from "./interior-door-type";

export class InspectionOrderPropertyHighValueInteriorFeatureInteriorDoorTypes {
    interiorDoorTypeId?: string;
    /*[ForeignKey(nameof(interiorDoorTypeId))]*/
    interiorDoorType?: InteriorDoorType;
    public constructor(init?:Partial<InspectionOrderPropertyHighValueInteriorFeatureInteriorDoorTypes>) {
        Object.assign(this, init);
    }
}