import { Enumeration } from "../../../../../../enumeration";

export class Staircase extends Enumeration {
    public constructor(init?:Partial<Enumeration>) {
        super()
        Object.assign(this, init);
    }
}