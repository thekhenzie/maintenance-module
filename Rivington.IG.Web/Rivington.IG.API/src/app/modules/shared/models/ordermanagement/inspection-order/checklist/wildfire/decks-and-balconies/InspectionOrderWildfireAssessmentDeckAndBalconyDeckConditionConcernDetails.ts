import { PorchDeckBalconyConstruction } from "./porch-deck-balcony-construction";

export class InspectionOrderWildfireAssessmentDeckAndBalconyDeckConditionConcernDetails {
    deckConditionConcernDetailId?: string;
    /*[ForeignKey(nameof(DeckConditionConcernDetailId))]*/
    deckConditionConcernDetail?: PorchDeckBalconyConstruction;
    public constructor(init?:Partial<InspectionOrderWildfireAssessmentDeckAndBalconyDeckConditionConcernDetails>) {
        Object.assign(this, init);
    }
}