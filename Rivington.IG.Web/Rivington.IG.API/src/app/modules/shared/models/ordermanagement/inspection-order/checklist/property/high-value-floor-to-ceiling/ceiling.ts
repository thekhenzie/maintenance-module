import { Enumeration } from "../../../../../../enumeration";

export class Ceiling extends Enumeration {
    public constructor(init?:Partial<Enumeration>) {
        super()
        Object.assign(this, init);
    }
}