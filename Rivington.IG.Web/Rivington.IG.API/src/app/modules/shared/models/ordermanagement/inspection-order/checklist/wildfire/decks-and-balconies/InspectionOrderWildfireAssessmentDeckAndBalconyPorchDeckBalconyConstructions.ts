import { PorchDeckBalconyConstruction } from "./porch-deck-balcony-construction";

export class InspectionOrderWildfireAssessmentDeckAndBalconyPorchDeckBalconyConstructions {
    porchDeckBalconyConstructionId?: string;
    /*[ForeignKey(nameof(PorchDeckBalconyConstructionId))]*/
    porchDeckBalconyConstruction?: PorchDeckBalconyConstruction;
    public constructor(init?:Partial<InspectionOrderWildfireAssessmentDeckAndBalconyPorchDeckBalconyConstructions>) {
        Object.assign(this, init);
    }
}