import { InspectionOrderPropertyPhoto } from "./inspectionorderpropertyphoto";
import { PhotoType } from "./phototype";
import { Image } from "../../../image";

export class InspectionOrderPropertyPhotoPhotos {
    id?: string;
    /*[ForeignKey(nameof(InspectionOrderPropertyPhotoId))]
    [Parent]*/
    InspectionOrderPropertyPhoto?: InspectionOrderPropertyPhoto;

    description?: string;

    photoTypeId?: string;
    /*[ForeignKey(nameof(PhotoTypeId))]*/
    photoType?: PhotoType;

    imageId?: string;
    /*[ForeignKey(nameof(ImageId))]*/
    image?: Image;

    public constructor(init?: Partial<InspectionOrderPropertyPhotoPhotos>) {
        Object.assign(this, init);
    }
}
