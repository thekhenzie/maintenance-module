export interface IMaintenance {
    id?: string;
    name?: string;
    sortOrder?: number;
}

export class Maintenance implements IMaintenance {
    id: string;
    name: string;
    sortOrder: number;

    public constructor(init?:Partial<Maintenance>) {
        Object.assign(this, init);
    }
}