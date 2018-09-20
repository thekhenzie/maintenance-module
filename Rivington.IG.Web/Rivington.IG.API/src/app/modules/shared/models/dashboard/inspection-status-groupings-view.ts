export class InspectionStatusGroupingsView {
    statusId: string;
    status: string;
    zeroToNineteenDays: string;
    twentyToThirtyNineDays: string;
    fortyToFiftyNineDays: string;

    public constructor(init?:Partial<InspectionStatusGroupingsView>) {
        Object.assign(this, init);
    }
}