import { Image } from "./ordermanagement/image";

export interface IUser {
    id?: string;
    FirstName?: string;
    LastName?: string;
    MiddleName?: string;
    Email?: string;
    userName?: string;
    Password?: string;
    Role?: string;
    streetAddress1?: string;
    streetAddress2?: string;
    state?: string;
    city?: string;
    phoneNumber?: string;
    mobileNumber?: string;
    zipCode?: string;

    profilePhotoId?: string;
    profilePhoto?: Image;
    
    isActivated: boolean;
}
export class User implements IUser {
    id: string;
    firstName: string;
    lastName: string;
    MiddleName?: string;
    email: string;
    userName: string;
    Password: string;
    Role: string;
    streetAddress1: string;
    streetAddress2?: string;
    state: string;
    city: string;
    phoneNumber: string;
    mobileNumber: string;
    zipCode: string;

    profilePhotoId?: string;
    profilePhoto?: Image;

    isActivated: boolean;
    
    public constructor(init?:Partial<IUser>) {
        Object.assign(this, init);
    }
}