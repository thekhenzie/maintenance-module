import { BathroomFixture } from "./bathroom-fixture";

export class InspectionOrderPropertyHighValueBathBathroomFixtures {
    bathroomFixtureId?: string;
    /*[ForeignKey(nameof(outbuildingDetailId))]*/
    bathroomFixture?: BathroomFixture;
    public constructor(init?:Partial<InspectionOrderPropertyHighValueBathBathroomFixtures>) {
        Object.assign(this, init);
    }
}