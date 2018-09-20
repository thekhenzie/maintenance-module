import { LightingType } from "./lighting-type";

export class InspectionOrderPropertyHighValueInteriorFeatureLightingTypes {
    lightingTypeId?: string;
    /*[ForeignKey(nameof(lightingTypeId))]*/
    lightingType?: LightingType;
    public constructor(init?:Partial<InspectionOrderPropertyHighValueInteriorFeatureLightingTypes>) {
        Object.assign(this, init);
    }
}