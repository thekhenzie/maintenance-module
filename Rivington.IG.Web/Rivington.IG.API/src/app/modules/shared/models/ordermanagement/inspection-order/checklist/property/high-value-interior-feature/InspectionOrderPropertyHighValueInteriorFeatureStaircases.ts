import { Staircase } from "./staircase";

export class InspectionOrderPropertyHighValueInteriorFeatureStaircases {
    staircaseId?: string;
    /*[ForeignKey(nameof(ceilingId))]*/
    staircase?: Staircase;
    public constructor(init?:Partial<InspectionOrderPropertyHighValueInteriorFeatureStaircases>) {
        Object.assign(this, init);
    }
}