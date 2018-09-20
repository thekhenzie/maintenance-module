import { Enumeration } from "../../../../../../enumeration";

export class CustomerOnSite extends Enumeration {
    public constructor(init?:Partial<Enumeration>) {
        super()
        Object.assign(this, init);
    }
}