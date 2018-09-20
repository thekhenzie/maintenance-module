import { Enumeration } from "../../../../../../enumeration";

export class RoofType extends Enumeration {
    public constructor(init?:Partial<Enumeration>) {
        super()
        Object.assign(this, init);
    }
}