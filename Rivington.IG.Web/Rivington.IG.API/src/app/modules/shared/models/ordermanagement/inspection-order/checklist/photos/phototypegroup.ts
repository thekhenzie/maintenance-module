export interface IPhotoTypeGroup{
    id? : string;
    name? : string;
}

export class PhotoTypeGroup implements IPhotoTypeGroup{

    id? : string;
    name? : string;

    public constructor(init?:Partial<IPhotoTypeGroup>) {
        Object.assign(this, init);
    }
}