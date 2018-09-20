import { Enumeration } from "../../../../../../enumeration";

export class ApplianceBrand extends Enumeration {
    public constructor(init?:Partial<Enumeration>) {
        super()
        Object.assign(this, init);
    }
}