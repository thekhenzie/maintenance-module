import { Enumeration } from "../../../../../../enumeration";

export class FireAlarm extends Enumeration {
    public constructor(init?:Partial<Enumeration>) {
        super()
        Object.assign(this, init);
    }
}