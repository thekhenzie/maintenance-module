import { Enumeration } from "../../../../../../enumeration";

export class Locale extends Enumeration {
    public constructor(init?:Partial<Enumeration>) {
        super()
        Object.assign(this, init);
    }
}