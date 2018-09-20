import { RoomWithCabinetry } from "./room-with-cabinetry";

export class InspectionOrderPropertyHighValueInteriorFeatureRoomsWithCabinetry {
    roomsWithCabinetryId?: string;
    /*[ForeignKey(nameof(roomsWithCabinetryId))]*/
    roomsWithCabinetry?: RoomWithCabinetry;
    public constructor(init?:Partial<InspectionOrderPropertyHighValueInteriorFeatureRoomsWithCabinetry>) {
        Object.assign(this, init);
    }
}