import { User } from "../../models/user";

export class ImageWithDescriptionVm {
    id? : string = "";
    imageId?: string = "";
    fileName?: string = "";
    filePath?: string = "";
    thumbnailPath?: string = "";
    description?: string = "";

    // Parent
    childMitigationCount?: number;
    status?: boolean;

    // Child
    displayName?: string;
    userName?: string;
    
    public constructor(init?: Partial<ImageWithDescriptionVm>) {
        Object.assign(this, init);
    }
}