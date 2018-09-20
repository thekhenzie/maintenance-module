import { FoundationType } from "./foundation-to-frame/foundation-type";
import { FramingType } from "./foundation-to-frame/framing-type";
import { InspectionOrderWildfireAssessment } from "../wildfire";

export class InspectionOrderWildfireAssessmentFoundationToFrame {
    /*[Parent]*/
    inspectionOrderWildfireAssessment?: InspectionOrderWildfireAssessment;
    Id?: string;
    openingsEmberEntry?: boolean;
    openingsEmberEntryComment?: string;
    elevatedwithCombustibleMaterial?: boolean;
    elevatedwithCombustibleMaterialsComment?: string;
    foundationTypeId?: string;
    // [ForeignKey(nameof(FoundationTypeId))]
    foundationType?: FoundationType;
    foundationComment?: string;
    framingTypeId?: string;
    // [ForeignKey(nameof(FramingTypeId))]
    framingType?: FramingType;

    
    public constructor(init?:Partial<InspectionOrderWildfireAssessmentFoundationToFrame>) {
        Object.assign(this, init);
    }
}