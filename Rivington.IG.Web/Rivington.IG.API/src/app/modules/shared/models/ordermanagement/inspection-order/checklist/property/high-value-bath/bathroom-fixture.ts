import { Enumeration } from "../../../../../../enumeration";

export class BathroomFixture extends Enumeration {
    public constructor(init?:Partial<Enumeration>) {
        super()
        Object.assign(this, init);
    }
}