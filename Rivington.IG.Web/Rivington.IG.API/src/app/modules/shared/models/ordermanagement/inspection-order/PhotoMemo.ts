import { Image } from "../image";
import { User } from "../../user";

export class PhotoMemo {
    id?: string;

    description?: string;

    imageId?: string;
    /*[ForeignKey(nameof(ImageId))]*/
    image?: Image;

    // Parent
    childMitigationCount?: number;
    status?: boolean;

    // Child
    userId?: string;
    user?: User;

    public constructor(init?: Partial<PhotoMemo>) {
        Object.assign(this, init);
    }
}