import { Enumeration } from "../../../../../../enumeration";

export class OccupancyType extends Enumeration {
    public constructor(init?:Partial<Enumeration>) {
        super()
        Object.assign(this, init);
    }
}