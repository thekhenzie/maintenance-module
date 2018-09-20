import { InspectionOrderWildfireAssessmentWindowWindowGlassTypes } from "./windows/InspectionOrderWildfireAssessmentWindowWindowGlassTypes";
import { InspectionOrderWildfireAssessmentWindowWindowFramingTypes } from "./windows/InspectionOrderWildfireAssessmentWindowWindowFramingTypes";
import { InspectionOrderWildfireAssessmentWindowWindowStyles } from "./windows/InspectionOrderWildfireAssessmentWindowWindowStyles";
import { InspectionOrderWildfireAssessmentWindowWindowScreenTypes } from "./windows/InspectionOrderWildfireAssessmentWindowWindowScreenTypes";
import { InspectionOrderWildfireAssessmentWindowInteriorWindowCoveringTypes } from "./windows/InspectionOrderWildfireAssessmentWindowInteriorWindowCoveringTypes";
import { InspectionOrderWildfireAssessmentWindowExteriorWindowCoveringTypes } from "./windows/InspectionOrderWildfireAssessmentWindowExteriorWindowCoveringTypes";
import { InspectionOrderWildfireAssessmentWindowWindowConcernDetails } from "./windows/InspectionOrderWildfireAssessmentWindowWindowConcernDetails";
import { InspectionOrderWildfireAssessment } from "../wildfire";

export class InspectionOrderWildfireAssessmentWindow {
    /*[Parent]*/
    inspectionOrderWildfireAssessment?: InspectionOrderWildfireAssessment;
    id?: string;
    windowSusceptibleToFlame?: boolean;
    windowGlassTypes?: InspectionOrderWildfireAssessmentWindowWindowGlassTypes[];
    windowFramingTypes?: InspectionOrderWildfireAssessmentWindowWindowFramingTypes[];
    windowStyles?: InspectionOrderWildfireAssessmentWindowWindowStyles[];
    windowScreen?: boolean;
    windowScreenTypes?: InspectionOrderWildfireAssessmentWindowWindowScreenTypes[];
    interiorWindowCovering?: boolean;
    interiorWindowCoveringTypes?: InspectionOrderWildfireAssessmentWindowInteriorWindowCoveringTypes[];
    exteriorWindowCovering?: boolean;
    exteriorWindowCoveringTypes?: InspectionOrderWildfireAssessmentWindowExteriorWindowCoveringTypes[];
    windowConcern?: boolean;
    windowConcernsDetails?: InspectionOrderWildfireAssessmentWindowWindowConcernDetails[];
    windowNote?: string;
    
    public constructor(init?:Partial<InspectionOrderWildfireAssessmentWindow>) {
        Object.assign(this, init);
    }
}