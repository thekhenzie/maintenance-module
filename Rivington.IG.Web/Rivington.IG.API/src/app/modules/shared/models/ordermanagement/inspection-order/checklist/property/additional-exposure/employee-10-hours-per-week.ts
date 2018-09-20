import { Enumeration } from "../../../../../../enumeration";

export class Employee10HoursPerWeek extends Enumeration {
    public constructor(init?:Partial<Enumeration>) {
        super()
        Object.assign(this, init);
    }
}