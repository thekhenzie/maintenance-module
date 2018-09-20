export interface IContact {
    contactId?: string;
    firstName?: string;
    lastName?: string;
    fullName?: string;
    mobilePhone?: string;
    emailAddress?: string;
    streetAddress?: string;
    cityAddress?: string;
    country?: string;
    zipCode?: string;
    isActive?: boolean;
    dateActivated?: Date;
}

export class Contact implements IContact {
    // defaults
    contactId: string;
    firstName: string;
    lastName: string;
    fullName: string;
    mobilePhone: string;
    emailAddress: string;
    streetAddress: string;
    cityAddress: string;
    country: string;
    zipCode: string;
    isActive: boolean;
    dateActivated: Date;
    
    public constructor(init?:Partial<IContact>) {
        Object.assign(this, init);
    }
}