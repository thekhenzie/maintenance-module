import { WindowStyle } from "./window-style";

export class InspectionOrderPropertyHighValueFloorToCeilingWindowStyles {
    windowStyleId?: string;
    /*[ForeignKey(nameof(windowStyleId))]*/
    windowStyle?: WindowStyle;
    public constructor(init?:Partial<InspectionOrderPropertyHighValueFloorToCeilingWindowStyles>) {
        Object.assign(this, init);
    }
}