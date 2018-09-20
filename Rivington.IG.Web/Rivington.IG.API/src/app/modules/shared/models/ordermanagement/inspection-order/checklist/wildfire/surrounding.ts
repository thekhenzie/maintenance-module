import { InspectionOrderWildfireAssessment } from "../wildfire";

export class InspectionOrderWildfireAssessmentSurrounding {
    /*[Parent]*/
    inspectionOrderWildfireAssessment?: InspectionOrderWildfireAssessment;
    id?: string;
    combustible05Feet?: boolean;
    combustible05FeetComment?: string;
    combustible530Feet?: boolean;
    combustible530FeetComment?: string;
    combustible30100Feet?: boolean;
    combustible30100FeetComment?: string;
    additionalStructuresContributor?: boolean;
    additionalStructuresContributorComment?: string;
    topographicalEnvironmentalContributor?: boolean;
    topographicalEnvironmentalContributorComment?: string;
    volatileVegetationBeyond100Feet?: boolean;
    volatileVegetationBeyond100FeetComment?: string;
    neighboringResidence?: boolean;
    neighboringResidenceComment?: string;

    public constructor(init?:Partial<InspectionOrderWildfireAssessmentSurrounding>) {
        Object.assign(this, init);
    }
}