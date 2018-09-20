import { Enumeration } from "../../../../../../enumeration";

export class RoofShape extends Enumeration {
    public constructor(init?:Partial<Enumeration>) {
        super()
        Object.assign(this, init);
    }
}