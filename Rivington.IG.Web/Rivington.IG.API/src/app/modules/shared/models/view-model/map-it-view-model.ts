import { OrderManagement } from "../ordermangement";

export class MapItViewModel extends OrderManagement {
    inceptionStatus?: any;
    visible: boolean = true;
    todayToInceptionDaysCount: number;

    public constructor(init?:Partial<MapItViewModel>) {
        super();
        Object.assign(this, init);
    }
}