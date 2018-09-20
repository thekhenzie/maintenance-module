import { Enumeration } from "../../../../../../enumeration";
import { SmokeOnlyAlarmType } from "./smoke-only-alarm-type";

export class SmokeOnlyAlarm extends Enumeration {
    public constructor(init?:Partial<Enumeration>) {
        super()
        Object.assign(this, init);
    }
}