import { InspectionOrderWildfireAssessmentRoof } from "./wildfire/roof";
import { InspectionOrderWildfireAssessmentFoundationToFrame } from "./wildfire/foundation-to-frame";
import { InspectionOrderWildfireAssessmentExteriorSiding } from "./wildfire/exterior-siding";
import { InspectionOrderWildfireAssessmentWindow } from "./wildfire/windows";
import { InspectionOrderWildfireAssessmentDeckAndBalcony } from "./wildfire/decks-and-balconies";
import { InspectionOrderWildfireAssessmentFencingAndOtherAttachment } from "./wildfire/fencing-and-other-attachments";
import { InspectionOrderWildfireAssessmentSurrounding } from "./wildfire/surrounding";
import { InspectionOrderWildfireAssessmentAccessAndFireProtection } from "./wildfire/access-and-fire-protection";
import { InspectionOrderWildfireAssessmentExternalFuelSource } from "./wildfire/external-fuel-source";
import { InspectionOrderWildfireAssessmentMitigation } from "./mitigation/InspectionOrderWildfireAssessmentMitigation";

export class InspectionOrderWildfireAssessment {
    id?: string;
    roof?: InspectionOrderWildfireAssessmentRoof;
    foundationToFrame?: InspectionOrderWildfireAssessmentFoundationToFrame;
    exteriorSiding?: InspectionOrderWildfireAssessmentExteriorSiding;
    window?: InspectionOrderWildfireAssessmentWindow;
    deckAndBalcony?: InspectionOrderWildfireAssessmentDeckAndBalcony;
    fencingAndOtherAttachment?: InspectionOrderWildfireAssessmentFencingAndOtherAttachment;
    surrounding?: InspectionOrderWildfireAssessmentSurrounding;
    accessAndFireProtection?: InspectionOrderWildfireAssessmentAccessAndFireProtection;
    externalFuelSource?: InspectionOrderWildfireAssessmentExternalFuelSource;
    mitigation?: InspectionOrderWildfireAssessmentMitigation;
    
    public constructor(init?:Partial<InspectionOrderWildfireAssessment>) {
        Object.assign(this, init);
    }
}