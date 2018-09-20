import { Locale } from "./locale";

export class InspectionOrderPropertyHomeDetailLocales {
    localeId?: string;
    /*[ForeignKey(nameof(doorHardwareId))]*/
    locale?: Locale;
    public constructor(init?:Partial<InspectionOrderPropertyHomeDetailLocales>) {
        Object.assign(this, init);
    }
}