import { KitchenBathCounter } from "./kitchen-bath-counter";

export class InspectionOrderPropertyInteriorDetailKitchenBathCounters {
    kitchenBathCounterId?: string;
    /*[ForeignKey(nameof(kitchenBathCounterId))]*/
    kitchenBathCounter?: KitchenBathCounter;
    public constructor(init?:Partial<InspectionOrderPropertyInteriorDetailKitchenBathCounters>) {
        Object.assign(this, init);
    }
}