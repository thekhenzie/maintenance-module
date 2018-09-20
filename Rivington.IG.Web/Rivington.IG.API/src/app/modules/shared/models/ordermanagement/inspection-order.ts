import { Policy } from "./policy";
import { Inspector } from "./inspector";
import { PropertyValue } from "./propertyvalue";
import { InspectionOrderPropertyPhoto } from "./inspection-order/checklist/photos/inspectionorderpropertyphoto";
import { InspectionOrderProperty } from "./inspection-order/checklist/property";
import { InspectionOrderWildfireAssessment } from "./inspection-order/checklist/wildfire";

export class InspectionOrder {
    id?: string;
    assignedDate?: Date;
    dateCreated?: Date;

    policy?: Policy;
    inspectionDate? : Date;
    inspectorId?: string;
    inspector?: Inspector;
    property?: InspectionOrderProperty;
    wildfireAssessment?: InspectionOrderWildfireAssessment;
    propertyPhoto?: InspectionOrderPropertyPhoto;
    
    riskSummary?: string;
    public constructor(init?: Partial<InspectionOrder>) {
        Object.assign(this, init);
    }
}
