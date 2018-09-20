import { Enumeration } from "../../../../../../enumeration";

export class DogTemperament extends Enumeration {
    public constructor(init?:Partial<Enumeration>) {
        super()
        Object.assign(this, init);
    }
}