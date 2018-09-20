import { Enumeration } from "../../../../../../enumeration";

export class KitchenBathCounter extends Enumeration {
    public constructor(init?:Partial<Enumeration>) {
        super()
        Object.assign(this, init);
    }
}