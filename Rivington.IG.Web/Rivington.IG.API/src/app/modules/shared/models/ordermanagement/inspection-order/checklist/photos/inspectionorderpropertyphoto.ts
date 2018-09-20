import { InspectionOrder } from "../../../inspection-order";
import { InspectionOrderPropertyPhotoPhotos } from "./inspectionorderpropertyphotophotos";


export interface IInspectionOrderPropertyPhoto {
  id?: string;
  inspectionOrder?: InspectionOrder;
  photos?: InspectionOrderPropertyPhotoPhotos[];
}

export class InspectionOrderPropertyPhoto {
  id?: string;
  inspectionOrder?: InspectionOrder;
  photos?: InspectionOrderPropertyPhotoPhotos[];

  public constructor(init?: Partial<IInspectionOrderPropertyPhoto>) {
    Object.assign(this, init);
  }
}
