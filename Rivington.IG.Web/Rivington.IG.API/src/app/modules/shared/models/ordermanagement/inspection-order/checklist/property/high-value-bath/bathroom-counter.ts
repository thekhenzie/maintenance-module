import { Enumeration } from "../../../../../../enumeration";

export class BathroomCounter extends Enumeration {
    public constructor(init?:Partial<Enumeration>) {
        super()
        Object.assign(this, init);
    }
}