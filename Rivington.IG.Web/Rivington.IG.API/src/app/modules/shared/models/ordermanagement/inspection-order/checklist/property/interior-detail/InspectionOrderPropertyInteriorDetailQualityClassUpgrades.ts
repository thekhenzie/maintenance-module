import { QualityClassUpgrade } from "./quality-class-upgrade";

export class InspectionOrderPropertyInteriorDetailQualityClassUpgrades {
    qualityClassUpgradeId?: string;
    /*[ForeignKey(nameof(qualityClassUpgradeId))]*/
    qualityClassUpgrade?: QualityClassUpgrade;
    public constructor(init?:Partial<InspectionOrderPropertyInteriorDetailQualityClassUpgrades>) {
        Object.assign(this, init);
    }
}