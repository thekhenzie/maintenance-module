import { InspectionOrderPropertyGeneral } from "./property/general";
import { InspectionOrderPropertyInteriorDetail } from "./property/interior-detail";
import { InspectionOrderPropertyHomeDetail } from "./property/home-detail";
import { InspectionOrderPropertyBuildingConcern } from "./property/building-concern";
import { InspectionOrderPropertyDetachedStructure } from "./property/detached-structure";
import { InspectionOrderPropertyAdditionalExposure } from "./property/additional-exposure";
import { InspectionOrderPropertyHighValueKitchen } from "./property/high-value-kitchen";
import { InspectionOrderPropertyHighValueBath } from "./property/high-value-bath";
import { InspectionOrderPropertyHighValueFloorToCeiling } from "./property/high-value-floor-to-ceiling";
import { InspectionOrderPropertyHighValueInteriorFeature } from "./property/high-value-interior-feature";
import { InspectionOrderPropertyNonWildfireAssessment } from "./mitigation/InspectionOrderNonWildfireAssessment";

export class InspectionOrderProperty {
    id?: string;
    general?: InspectionOrderPropertyGeneral;
    interiorDetail?: InspectionOrderPropertyInteriorDetail;
    homeDetail?: InspectionOrderPropertyHomeDetail;
    buildingConcern?: InspectionOrderPropertyBuildingConcern;
    detachedStructure?: InspectionOrderPropertyDetachedStructure;
    additionalExposure?: InspectionOrderPropertyAdditionalExposure;
    highValueKitchen?: InspectionOrderPropertyHighValueKitchen;
    highValueBath?: InspectionOrderPropertyHighValueBath;
    highValueFloorToCeiling?: InspectionOrderPropertyHighValueFloorToCeiling;
    highValueInteriorFeature?: InspectionOrderPropertyHighValueInteriorFeature;
    nonWildfireAssessment?: InspectionOrderPropertyNonWildfireAssessment;
    
    public constructor(init?:Partial<InspectionOrderProperty>) {
        Object.assign(this, init);
    }
}