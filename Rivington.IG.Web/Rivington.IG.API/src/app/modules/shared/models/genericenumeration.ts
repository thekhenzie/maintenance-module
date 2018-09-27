export interface IGenericEnumeration {
    id?: string;
    name?: string;
    sortOrder?: number;
}

export class GenericEnumeration implements IGenericEnumeration {
    id: string;
    name: string;
    sortOrder: number;

    public constructor(init?:Partial<GenericEnumeration>) {
        Object.assign(this, init);
    }
}