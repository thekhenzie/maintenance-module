import { MiscellaneousExtraFeature } from "./miscellaneous-extra-feature";

export class InspectionOrderPropertyHighValueInteriorFeatureMiscellaneousExtraFeatures {
    miscellaneousExtraFeatureId?: string;
    /*[ForeignKey(nameof(ceilingId))]*/
    miscellaneousExtraFeature?: MiscellaneousExtraFeature;
    public constructor(init?:Partial<InspectionOrderPropertyHighValueInteriorFeatureMiscellaneousExtraFeatures>) {
        Object.assign(this, init);
    }
}