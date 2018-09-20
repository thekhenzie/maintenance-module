import { FireplaceType } from "./fire-place-type";

export class InspectionOrderPropertyHighValueInteriorFeatureFireplaceTypes {
    fireplaceTypeId?: string;
    /*[ForeignKey(nameof(fireplaceTypeId))]*/
    fireplaceType?: FireplaceType;
    public constructor(init?:Partial<InspectionOrderPropertyHighValueInteriorFeatureFireplaceTypes>) {
        Object.assign(this, init);
    }
}