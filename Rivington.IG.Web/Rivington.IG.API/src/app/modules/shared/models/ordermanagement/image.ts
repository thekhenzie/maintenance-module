export class Image {
    id? : string = "";
    fileName?: string = "";
    
    file?: string = "";
    filePath?: string = "";

    thumbnail?: string = "";
    thumbnailPath?: string = "";

    public constructor(init?: Partial<Image>) {
        Object.assign(this, init);
    }
}