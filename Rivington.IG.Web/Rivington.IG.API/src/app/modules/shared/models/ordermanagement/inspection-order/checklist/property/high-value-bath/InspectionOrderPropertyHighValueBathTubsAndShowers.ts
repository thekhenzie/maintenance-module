import { TubAndShower } from "./tub-and-shower";

export class InspectionOrderPropertyHighValueBathTubsAndShowers {
    tubAndShowerId?: string;
    /*[ForeignKey(nameof(tubAndShowerId))]*/
    tubAndShower?: TubAndShower;
    public constructor(init?:Partial<InspectionOrderPropertyHighValueBathTubsAndShowers>) {
        Object.assign(this, init);
    }
}