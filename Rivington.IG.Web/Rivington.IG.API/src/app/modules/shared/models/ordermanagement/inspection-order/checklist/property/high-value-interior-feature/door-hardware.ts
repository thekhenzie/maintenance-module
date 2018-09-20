import { Enumeration } from "../../../../../../enumeration";

export class DoorHardware extends Enumeration {
    public constructor(init?:Partial<Enumeration>) {
        super()
        Object.assign(this, init);
    }
}