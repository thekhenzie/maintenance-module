export interface IGenericEnumeration {
    id?: string;
    name?: string;
    sortOrder?: number;
    isActive?: boolean;
}

export class GenericEnumeration implements IGenericEnumeration {
    id: string;
    name: string;
    sortOrder: number;
    isActive: boolean;

    public constructor(init?:Partial<GenericEnumeration>) {
        Object.assign(this, init);
    }
}