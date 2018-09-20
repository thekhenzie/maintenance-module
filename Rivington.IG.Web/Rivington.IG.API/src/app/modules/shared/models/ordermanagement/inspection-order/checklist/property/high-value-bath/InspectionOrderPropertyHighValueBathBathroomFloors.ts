import { BathroomFloor } from "./bathroom-floor";

export class InspectionOrderPropertyHighValueBathBathroomFloors {
    bathroomFloorId?: string;
    /*[ForeignKey(nameof(outbuildingDetailId))]*/
    bathroomFloor?: BathroomFloor;
    public constructor(init?:Partial<InspectionOrderPropertyHighValueBathBathroomFloors>) {
        Object.assign(this, init);
    }
}