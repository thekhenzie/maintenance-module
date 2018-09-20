import { PrimaryRoofCovering } from "./roof/primary-roof-covering";
import { InspectionOrderWildfireAssessmentRoofOtherRoofCoverings } from "./roof/InspectionOrderWildfireAssessmentRoofOtherRoofCoverings";
import { InspectionOrderWildfireAssessmentRoofRoofConcernDetails } from "./roof/InspectionOrderWildfireAssessmentRoofRoofConcernDetails";
import { InspectionOrderWildfireAssessmentRoofRoofVentings } from "./roof/InspectionOrderWildfireAssessmentRoofRoofVentings";
import { InspectionOrderWildfireAssessmentRoofGutterTypes } from "./roof/InspectionOrderWildfireAssessmentRoofGutterTypes";
import { EavesType } from "./roof/eaves-type";
import { SecondaryRoofCovering } from "./roof/secondary-roof-covering";
import { RoofType } from "./roof/roof-type";
import { InspectionOrderWildfireAssessment } from "../wildfire";
import { RoofShape } from "../property/home-detail/roof-shape";
import { RoofPitch } from "./roof/roof-pitch";

export class InspectionOrderWildfireAssessmentRoof {
    /*[Parent]*/
    inspectionOrderWildfireAssessment?: InspectionOrderWildfireAssessment;
    id?: string;
    primaryRoofCoveringId?: string;
    // [ForeignKey(nameof(PrimaryRoofCoveringId))]
    primaryRoofCovering?: PrimaryRoofCovering;
    secondaryRoofCoveringId?: string;
    // [ForeignKey(nameof(SecondaryRoofCoveringId))]
    secondaryRoofCovering?: SecondaryRoofCovering;
    otherRoofCoverings?: InspectionOrderWildfireAssessmentRoofOtherRoofCoverings[];
    roofShapeId?: string;
    // [ForeignKey(nameof(roofShapeId))]
    roofShape?: RoofShape;
    roofPitchId?: string;
    // [ForeignKey(nameof(roofPitchId))]
    roofPitch?: RoofPitch;
    roofConcernDetails?: InspectionOrderWildfireAssessmentRoofRoofConcernDetails[];
    combustibleMaterialsOnRoof?: boolean;
    combustibleMaterialsonRoofComment?: string;
    roofVentings?: InspectionOrderWildfireAssessmentRoofRoofVentings[];
    ventingOpeningAllowEmberEntry?: boolean;
    ventingMeshCoveringSizeComment?: string;
    gutter?: boolean;
    gutterTypes?: InspectionOrderWildfireAssessmentRoofGutterTypes[];
    gutterComment?: string;
    eavesTypeId?: string;
    // [ForeignKey(nameof(EavesTypeId))]
    eavesType?: EavesType;
    eavesAllowEmberEntry?: boolean;
    eavesComment?: string;
    
    public constructor(init?:Partial<InspectionOrderWildfireAssessmentRoof>) {
        Object.assign(this, init);
    }
}