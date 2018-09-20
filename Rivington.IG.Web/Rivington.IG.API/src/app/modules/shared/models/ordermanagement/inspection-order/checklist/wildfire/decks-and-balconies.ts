import { InspectionOrderWildfireAssessment } from "../wildfire";
import { InspectionOrderWildfireAssessmentDeckAndBalconyPorchDeckBalconyConstructions } from "./decks-and-balconies/InspectionOrderWildfireAssessmentDeckAndBalconyPorchDeckBalconyConstructions";
import { InspectionOrderWildfireAssessmentDeckAndBalconyDeckConditionConcernDetails } from "./decks-and-balconies/InspectionOrderWildfireAssessmentDeckAndBalconyDeckConditionConcernDetails";

export class InspectionOrderWildfireAssessmentDeckAndBalcony {
    /*[Parent]*/
    inspectionOrderWildfireAssessment?: InspectionOrderWildfireAssessment;
    Id?: string;
    attachedPorcheDeckorBalcony?: boolean;
    porchDeckBalconyConstructions?: InspectionOrderWildfireAssessmentDeckAndBalconyPorchDeckBalconyConstructions[];
    porchDeckBalconyCovered?: boolean;
    coveringMaterial?: string;
    deckConditionConcern?: boolean;
    deckConditionConcernsDetails?: InspectionOrderWildfireAssessmentDeckAndBalconyDeckConditionConcernDetails[];
    attachedStructuresComment?: string;
    combustibleMaterialsONDeckBalconyPorch?: boolean;
    combustiblesONDeckBalconyPorchDescription?: string;
    combustibleMaterialsUNDERDeckBalconyPorch?: boolean;
    combustiblesUNDERDeckBalconyPorchDescription?: string;

    public constructor(init?:Partial<InspectionOrderWildfireAssessmentDeckAndBalcony>) {
        Object.assign(this, init);
    }
}