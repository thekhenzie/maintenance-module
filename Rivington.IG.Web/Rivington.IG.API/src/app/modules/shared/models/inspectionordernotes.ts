export interface IInspectionOrderNotes {
    subject?:string;
    notes?:string;
    datemodified?:Date;
    ModifiedById?:string;
    modifiedBy?:string;
    inspectionOrderId?:string;
}

export class InspectionOrderNotes implements IInspectionOrderNotes {
    subject:string;
    notes:string;
    datemodified:Date;
    ModifiedById:string;
    modifiedBy:string;
    inspectionOrderId:string;

    public constructor(init?:Partial<IInspectionOrderNotes>) {
        Object.assign(this, init);
    }
}