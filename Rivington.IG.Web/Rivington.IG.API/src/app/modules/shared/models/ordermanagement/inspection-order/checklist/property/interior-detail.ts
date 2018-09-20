import { InspectionOrderProperty } from "../property";
import { InspectionOrderPropertyInteriorDetailTypeOfPlumbings } from "./interior-detail/InspectionOrderPropertyInteriorDetailTypeOfPlumbings";
import { InspectionOrderPropertyInteriorDetailQualityClassUpgrades } from "./interior-detail/InspectionOrderPropertyInteriorDetailQualityClassUpgrades";
import { InspectionOrderPropertyInteriorDetailKitchenBathCounters } from "./interior-detail/InspectionOrderPropertyInteriorDetailKitchenBathCounters";
import { InspectionOrderPropertyInteriorDetailKitchenBathCabinets } from "./interior-detail/InspectionOrderPropertyInteriorDetailKitchenBathCabinets";
import { InspectionOrderPropertyInteriorDetailFlooringTypes } from "./interior-detail/InspectionOrderPropertyInteriorDetailFlooringTypes";

export class InspectionOrderPropertyInteriorDetail {
    /*[Parent]*/
    inspectionOrderProperty?: InspectionOrderProperty;
    id?: string;
    flooringTypes?: InspectionOrderPropertyInteriorDetailFlooringTypes[];
    kitchenBathCabinets?: InspectionOrderPropertyInteriorDetailKitchenBathCabinets[];
    kitchenBathCounters?: InspectionOrderPropertyInteriorDetailKitchenBathCounters[];
    qualityClassUpgrades?: InspectionOrderPropertyInteriorDetailQualityClassUpgrades[];
    interiorDetailComment?: string;
    typeOfPlumbings?: InspectionOrderPropertyInteriorDetailTypeOfPlumbings[];
    electricalServiceAmperage?: string;
    waterHeaterLocation?: string;
    laundryLocation?: string;

    public constructor(init?:Partial<InspectionOrderPropertyInteriorDetail>) {
        Object.assign(this, init);
    }
}