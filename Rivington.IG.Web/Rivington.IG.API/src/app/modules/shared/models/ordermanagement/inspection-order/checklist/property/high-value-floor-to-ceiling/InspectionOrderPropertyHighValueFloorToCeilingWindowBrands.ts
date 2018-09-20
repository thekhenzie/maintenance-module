import { WindowBrand } from "./window-brand";

export class InspectionOrderPropertyHighValueFloorToCeilingWindowBrands {
    windowBrandId?: string;
    /*[ForeignKey(nameof(bathroomCounterId))]*/
    windowBrand?: WindowBrand;
    public constructor(init?:Partial<InspectionOrderPropertyHighValueFloorToCeilingWindowBrands>) {
        Object.assign(this, init);
    }
}