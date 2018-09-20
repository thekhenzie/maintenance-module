import { Enumeration } from "../../../../../../enumeration";

export class BathroomVanity extends Enumeration {
    public constructor(init?:Partial<Enumeration>) {
        super()
        Object.assign(this, init);
    }
}