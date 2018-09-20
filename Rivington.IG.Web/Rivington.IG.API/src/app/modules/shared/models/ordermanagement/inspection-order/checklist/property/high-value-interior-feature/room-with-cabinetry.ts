import { Enumeration } from "../../../../../../enumeration";

export class RoomWithCabinetry extends Enumeration {
    public constructor(init?:Partial<Enumeration>) {
        super()
        Object.assign(this, init);
    }
}