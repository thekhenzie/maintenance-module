export interface IMitigationStatus{
    id? : string;
    name? : string;
}

export class MitigationStatus implements IMitigationStatus{
    id? : string;
    name? : string;
    
    public constructor(init?:Partial<IMitigationStatus>) {
        Object.assign(this, init);
    }
}