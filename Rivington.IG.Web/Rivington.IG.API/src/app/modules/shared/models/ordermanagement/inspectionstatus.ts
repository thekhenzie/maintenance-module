export interface IInspectionStatus{
    id? : string;
    name? : string;
}

export class InspectionStatus implements IInspectionStatus{

    id? : string;
    name? : string;

    public constructor(init?:Partial<IInspectionStatus>) {
        Object.assign(this, init);
    }
}