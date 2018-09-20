import { Enumeration } from "../../../../../../enumeration";

export class KitchenCabinet extends Enumeration {
    public constructor(init?:Partial<Enumeration>) {
        super()
        Object.assign(this, init);
    }
}