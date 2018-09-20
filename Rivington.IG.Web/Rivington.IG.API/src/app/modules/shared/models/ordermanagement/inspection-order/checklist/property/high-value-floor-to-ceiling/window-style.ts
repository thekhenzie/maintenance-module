import { Enumeration } from "../../../../../../enumeration";

export class WindowStyle extends Enumeration {
    public constructor(init?:Partial<Enumeration>) {
        super()
        Object.assign(this, init);
    }
}