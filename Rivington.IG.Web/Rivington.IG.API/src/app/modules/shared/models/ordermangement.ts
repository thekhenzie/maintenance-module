export interface IOrderManagement {
    item?:number;
    id?: string;
    isLocked?: boolean;
	isLockedById?: string;
	isLockedByUserName?: string;
    policyNumber?: string;
    insuredName?: string;
    inceptionDate?: Date;
    inspectionDate?: Date;
    assignedDate?: Date;
    createdDate?: Date;
    statusDate?: Date;
    inspectorId?: string;
    inspector?: string;
    status?: string;
    dateDifference?: string;
    location?: string;
    mitigationStatus?: string;
    state?: string;
    city?: string;
    streetAddress1?: string;
    streetAddress2?: string;
    zipCode?: string;
    date?: Date;
    statusId?: string;
    mitigationId?: string;
    username?: string; 
    longitude?:number;
    latitude?:number;
}

export class OrderManagement implements IOrderManagement {
    item?:number;
    id?: string;
    isLocked?: boolean;
	isLockedById?: string;
	isLockedByUserName?: string;
    policyNumber?: string;
    insuredName?: string;
    inceptionDate?: Date;
    inspectionDate?: Date;
    assignedDate?: Date;
    createdDate?: Date;
    statusDate?: Date;
    inspectorId?: string;
    inspector?: string;
    status?: string;
    dateDifference?: string;
    location?: string;
    mitigationStatus?: string;
    state?: string;
    city?: string;
    streetAddress1?: string;
    streetAddress2?: string;
    zipCode?: string;
    date?: Date;
    statusId?: string;
    mitigationId?: string;
    username?: string; 
    longitude?:number;
    latitude?:number;

    public constructor(init?:Partial<IOrderManagement>) {
        Object.assign(this, init);
    }
}
