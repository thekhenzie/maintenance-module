import { BathroomVanity } from "./bathroom-vanity";

export class InspectionOrderPropertyHighValueBathBathroomVanities {
    bathroomVanityId?: string;
    /*[ForeignKey(nameof(bathroomVanityId))]*/
    bathroomVanity?: BathroomVanity;
    public constructor(init?:Partial<InspectionOrderPropertyHighValueBathBathroomVanities>) {
        Object.assign(this, init);
    }
}