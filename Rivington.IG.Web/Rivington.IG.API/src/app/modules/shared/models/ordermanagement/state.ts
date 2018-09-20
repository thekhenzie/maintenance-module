import { Enumeration } from "../../enumeration";

export class State extends Enumeration {
    public constructor(init?:Partial<Enumeration>) {
        super()
        Object.assign(this, init);
    }
}