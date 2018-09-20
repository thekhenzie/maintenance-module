import { Enumeration } from "../../../../../../enumeration";

export class RoofShape implements Enumeration {
    public constructor(init?:Partial<Enumeration>) {
        Object.assign(this, init);
    }
}