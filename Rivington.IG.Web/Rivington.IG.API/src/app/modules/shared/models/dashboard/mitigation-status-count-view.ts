export class MitigationStatusCountView {
    statusId: string;
    status: string;
    statusCount: string;

    public constructor(init?:Partial<MitigationStatusCountView>) {
        Object.assign(this, init);
    }
}