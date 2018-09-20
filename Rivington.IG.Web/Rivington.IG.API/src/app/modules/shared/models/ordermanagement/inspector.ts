export interface IInspector{
    id? : string;
    accessFailedCount? : number;
    concurrencyStamp? : string;
    createdDate? : Date;
    displayName? : string;
    email? : string;
    emailConfirmed? : Boolean;
    lastModifiedDate? : Date;
    firstName?: string;
    middleName?: string;
    lastName? : string;
    lockoutEnabled? : Boolean;
    lockoutEnd? : Date;
    normalizedEmail? : string;
    normalizedUserName? : string;
    passwordHash? : string;
    phoneNumber? : string;
    phoneNumberConfirmed? : Boolean;
    securityStamp? : string;
    twoFactorEnabled? : Boolean;
    userName? : string;
}

export class Inspector implements IInspector{
    id? : string;
    accessFailedCount? : number;
    concurrencyStamp? : string;
    createdDate? : Date;
    displayName? : string;
    email? : string;
    emailConfirmed? : Boolean;
    lastModifiedDate? : Date;
    firstName?: string;
    middleName?: string;
    lastName? : string;
    lockoutEnabled? : Boolean;
    lockoutEnd? : Date;
    normalizedEmail? : string;
    normalizedUserName? : string;
    passwordHash? : string;
    phoneNumber? : string;
    phoneNumberConfirmed? : Boolean;
    securityStamp? : string;
    twoFactorEnabled? : Boolean;
    userName? : string;

    public constructor(init?:Partial<IInspector>) {
        Object.assign(this, init);
    }
}