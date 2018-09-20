export interface ISort {
    Field?: string;
    Dir?: string;
}

export class Sort implements ISort {
    // defaults
    public Field: string;
    public Dir: string;
    
    public constructor(init?:Partial<ISort>) {
        Object.assign(this, init);
    }
}