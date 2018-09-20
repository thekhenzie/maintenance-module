import { DomesticHelpType } from "./domestic-help-type";

export class InspectionOrderPropertyGeneralDomesticHelpTypes {
    domesticHelpTypeId?: string;
    /*[ForeignKey(nameof(DomesticHelpTypeId))]*/
    domesticHelpType?: DomesticHelpType;
    public constructor(init?:Partial<InspectionOrderPropertyGeneralDomesticHelpTypes>) {
        Object.assign(this, init);
    }
}