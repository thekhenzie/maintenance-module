import { InspectionOrderWildfireAssessment } from "../wildfire";
import { FireDepartmentStaffing } from "./access-and-fire-protection/fire-department-staffing";


export class InspectionOrderWildfireAssessmentAccessAndFireProtection {
    /*[Parent]*/
    inspectionOrderWildfireAssessment?: InspectionOrderWildfireAssessment;
    Id?: string;
    timelyResponseConcern?: boolean;
    timelyResponseConcernComment?: string;
    addressHardtoRead?: boolean;
    addressReadabilityComment?: string;
    bridgeConcern?: boolean;
    bridgeConcernComment?: string;
    respondingFireDepartment?: string;
    fireDepartmentStaffingId?: string;
    // [ForeignKey(nameof(FireDepartmentStaffingId))]
    fireDepartmentStaffing?: FireDepartmentStaffing;
    fireDepartmentDistancetoHome?: string;
    fireDepartmentTravelTimetoHome?: number;
    nearestFireHydrant?: string;
    alternateWaterSourceIfNoHydrant?: string;

    public constructor(init?:Partial<InspectionOrderWildfireAssessmentAccessAndFireProtection>) {
        Object.assign(this, init);
    }
}