export class ApplicationUserView {
    id?: string ;
    firstName?: string ;
    lastName?: string ;
    middleName?: string ;
    createdDate?: Date ;
    lastModifiedDate?: Date ;
    displayName?: string ;
    streetAddress1?: string ;
    streetAddress2?: string ;
    state?: string ;
    city?: string ;
    mobileNumber?: string ;
    zipCode?: string ;
    roleId?: string ;
    roleName?: string ;
    email?: string ;
    profilePhotoPath?: string ;
    thumbnailPath?: string ; 
    
    public constructor(init?: Partial<ApplicationUserView>) {
        Object.assign(this, init);
    }
}