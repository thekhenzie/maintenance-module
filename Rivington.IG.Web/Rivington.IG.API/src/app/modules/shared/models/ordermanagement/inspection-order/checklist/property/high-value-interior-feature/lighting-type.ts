import { Enumeration } from "../../../../../../enumeration";

export class LightingType extends Enumeration {
    public constructor(init?:Partial<Enumeration>) {
        super()
        Object.assign(this, init);
    }
}