export interface IStaticContent{
    id?: string;
    name?: string;
    htmlString?: string;
    dateAdded?: Date;
}

export class StaticContent implements IStaticContent{
    id?: string;    
    name?: string;
    htmlString?: string;
    dateAdded?: Date;

    public constructor(init?:Partial<IStaticContent>) {
        Object.assign(this, init);
    }
}