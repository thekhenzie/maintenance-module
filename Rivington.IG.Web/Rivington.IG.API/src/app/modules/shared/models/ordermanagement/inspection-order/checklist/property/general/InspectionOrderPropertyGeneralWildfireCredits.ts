import { WildfireCredit } from "./wildfire-credit";

export class InspectionOrderPropertyGeneralWildfireCredits {
    wildfireCreditId?: string;
    /*[ForeignKey(nameof(WildfireCreditId))]*/
    wildfireCredit?: WildfireCredit;
    public constructor(init?:Partial<InspectionOrderPropertyGeneralWildfireCredits>) {
        Object.assign(this, init);
    }
}