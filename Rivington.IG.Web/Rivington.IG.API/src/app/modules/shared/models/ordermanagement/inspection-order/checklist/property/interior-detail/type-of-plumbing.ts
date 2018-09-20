import { Enumeration } from "../../../../../../enumeration";

export class TypeOfPlumbing extends Enumeration {
    public constructor(init?:Partial<Enumeration>) {
        super()
        Object.assign(this, init);
    }
}