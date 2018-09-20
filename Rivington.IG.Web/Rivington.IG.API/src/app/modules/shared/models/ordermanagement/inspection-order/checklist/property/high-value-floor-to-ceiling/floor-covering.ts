import { Enumeration } from "../../../../../../enumeration";

export class FloorCovering extends Enumeration {
    public constructor(init?:Partial<Enumeration>) {
        super()
        Object.assign(this, init);
    }
}