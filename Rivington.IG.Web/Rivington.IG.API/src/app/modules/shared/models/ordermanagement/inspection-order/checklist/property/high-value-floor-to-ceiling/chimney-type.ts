import { Enumeration } from "../../../../../../enumeration";

export class ChimneyType extends Enumeration {
    public constructor(init?:Partial<Enumeration>) {
        super()
        Object.assign(this, init);
    }
}