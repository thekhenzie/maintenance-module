import { FlooringType } from "./flooring-type";

export class InspectionOrderPropertyInteriorDetailFlooringTypes {
    flooringTypeId?: string;
    /*[ForeignKey(nameof(flooringTypeId))]*/
    flooringType?: FlooringType;
    public constructor(init?:Partial<InspectionOrderPropertyInteriorDetailFlooringTypes>) {
        Object.assign(this, init);
    }
}