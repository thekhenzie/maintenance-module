import { BathroomCounter } from "./bathroom-counter";

export class InspectionOrderPropertyHighValueBathBathroomCounters {
    bathroomCounterId?: string;
    /*[ForeignKey(nameof(bathroomCounterId))]*/
    bathroomCounter?: BathroomCounter;
    public constructor(init?:Partial<InspectionOrderPropertyHighValueBathBathroomCounters>) {
        Object.assign(this, init);
    }
}