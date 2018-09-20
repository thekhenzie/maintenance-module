import { ApplianceType } from "./appliance-type";
import { ApplianceBrand } from "./appliance-brand";

export class InspectionOrderPropertyHighValueKitchenAppliances {
    applianceTypeId?: string;
    /*[ForeignKey(nameof(doorHardwareId))]*/
    applianceType?: ApplianceType;
    applianceBrandId?: string;
    /*[ForeignKey(nameof(ApplianceBrandId))]*/
    applianceBrand?: ApplianceBrand;
    numberofAppliance?: number;
    public constructor(init?:Partial<InspectionOrderPropertyHighValueKitchenAppliances>) {
        Object.assign(this, init);
    }
}