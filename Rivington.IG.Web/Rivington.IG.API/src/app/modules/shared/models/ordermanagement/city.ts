export interface ICity{
    id? : number;
    stateId? : string;
    name? : string;
    county? : string;
}

export class City implements ICity {
    id? : number;
    stateId? : string;
    name? : string;
    county? : string;

    public constructor(init?:Partial<ICity>) {
        Object.assign(this, init);
    }
}