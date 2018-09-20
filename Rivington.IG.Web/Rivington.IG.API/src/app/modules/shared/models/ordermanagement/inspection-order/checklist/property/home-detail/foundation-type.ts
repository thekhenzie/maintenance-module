import { Enumeration } from "../../../../../../enumeration";

export class FoundationType extends Enumeration {
    public constructor(init?:Partial<Enumeration>) {
        super()
        Object.assign(this, init);
    }
}