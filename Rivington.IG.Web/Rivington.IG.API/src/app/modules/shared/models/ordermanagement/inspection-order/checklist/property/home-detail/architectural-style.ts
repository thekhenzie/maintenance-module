import { Enumeration } from "../../../../../../enumeration";

export class ArchitecturalStyle extends Enumeration {
    public constructor(init?:Partial<Enumeration>) {
        super()
        Object.assign(this, init);
    }
}