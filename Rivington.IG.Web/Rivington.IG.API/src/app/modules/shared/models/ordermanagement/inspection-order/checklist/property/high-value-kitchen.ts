import { InspectionOrderProperty } from "../property";
import { InspectionOrderPropertyHighValueKitchenAppliances } from "./high-value-kitchen/InspectionOrderPropertyHighValueKitchenAppliances";
import { ApplianceBrand } from "./high-value-kitchen/appliance-brand";
import { KitchenCabinet } from "./high-value-kitchen/kitchen-cabinet";
import { KitchenCountertop } from "./high-value-kitchen/kitchen-countertop";

export class InspectionOrderPropertyHighValueKitchen {
    /*[Parent]*/
    inspectionOrderProperty?: InspectionOrderProperty;
    /*[Key]*/
    id?: string;
    kitchenCabinetId?: string;
    /*[ForeignKey(nameof(KitchenCabinetId))]*/
    kitchenCabinet?: KitchenCabinet;
    kitchenCountertopId?: string;
    /*[ForeignKey(nameof(KitchenCountertopId))]*/
    kitchenCountertop?: KitchenCountertop;
    kitchenBacksplashMaterial?: string;
    kitchenIsland?: boolean;
    islandCabinetMaterial?: string;
    islandCountertopMaterial?: string;
    appliances?: InspectionOrderPropertyHighValueKitchenAppliances[];
    public constructor(init?:Partial<InspectionOrderPropertyHighValueKitchen>) {
        Object.assign(this, init);
    }
  }