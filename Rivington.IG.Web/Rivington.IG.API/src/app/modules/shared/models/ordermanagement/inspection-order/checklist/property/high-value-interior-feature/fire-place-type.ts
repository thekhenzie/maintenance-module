import { Enumeration } from "../../../../../../enumeration";

export class FireplaceType extends Enumeration {
    public constructor(init?:Partial<Enumeration>) {
        super()
        Object.assign(this, init);
    }
}