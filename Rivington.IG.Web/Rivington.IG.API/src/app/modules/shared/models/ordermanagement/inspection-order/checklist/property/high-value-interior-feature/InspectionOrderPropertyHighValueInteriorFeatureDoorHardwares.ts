import { DoorHardware } from "./door-hardware";

export class InspectionOrderPropertyHighValueInteriorFeatureDoorHardwares {
    doorHardwareId?: string;
    /*[ForeignKey(nameof(doorHardwareId))]*/
    doorHardware?: DoorHardware;
    public constructor(init?:Partial<InspectionOrderPropertyHighValueInteriorFeatureDoorHardwares>) {
        Object.assign(this, init);
    }
}