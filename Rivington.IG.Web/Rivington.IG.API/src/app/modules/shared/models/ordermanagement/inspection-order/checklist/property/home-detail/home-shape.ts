import { Enumeration } from "../../../../../../enumeration";

export class HomeShape extends Enumeration {
    public constructor(init?:Partial<Enumeration>) {
        super()
        Object.assign(this, init);
    }
}