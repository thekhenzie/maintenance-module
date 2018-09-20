import { Enumeration } from "../enumeration";

export class AccountRole extends Enumeration {
    public constructor(init?:Partial<Enumeration>) {
        super();
        Object.assign(this, init);
    }
}