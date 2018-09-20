import { PhotoTypeGroup } from "./phototypegroup";
import { Enumeration } from "../../../../../enumeration";

export class PhotoType extends Enumeration {

    groupId? : string;
    phototypegroup? : PhotoTypeGroup;

    public constructor(init?:Partial<PhotoType>) {
        super();
        Object.assign(this, init);
    }
}