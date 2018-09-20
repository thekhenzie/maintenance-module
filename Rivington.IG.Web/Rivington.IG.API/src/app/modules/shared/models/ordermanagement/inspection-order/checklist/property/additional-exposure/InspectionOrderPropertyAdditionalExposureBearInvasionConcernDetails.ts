import { BearInvasionConcernDetail } from "./bear-invasion-concern-detail";

export class InspectionOrderPropertyAdditionalExposureBearInvasionConcernDetails {
    bearInvasionConcernDetailId?: string;
    /*[ForeignKey(nameof(bearInvasionConcernDetailId))]*/
    bearInvasionConcernDetail?: BearInvasionConcernDetail;
    public constructor(init?:Partial<InspectionOrderPropertyAdditionalExposureBearInvasionConcernDetails>) {
        Object.assign(this, init);
    }
}