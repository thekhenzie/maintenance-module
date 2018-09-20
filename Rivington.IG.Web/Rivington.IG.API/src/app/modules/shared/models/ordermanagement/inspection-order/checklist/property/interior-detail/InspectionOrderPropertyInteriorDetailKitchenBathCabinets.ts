import { KitchenBathCabinet } from "./kitchen-bath-cabinet";

export class InspectionOrderPropertyInteriorDetailKitchenBathCabinets {
    kitchenBathCabinetId?: string;
    /*[ForeignKey(nameof(kitchenBathCabinetId))]*/
    kitchenBathCabinet?: KitchenBathCabinet;
    public constructor(init?:Partial<InspectionOrderPropertyInteriorDetailKitchenBathCabinets>) {
        Object.assign(this, init);
    }
}