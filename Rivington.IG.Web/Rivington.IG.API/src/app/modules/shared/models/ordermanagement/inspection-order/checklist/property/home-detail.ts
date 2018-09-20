import { InspectionOrderProperty } from "../property";
import { InspectionOrderPropertyHomeDetailLocales } from "./home-detail/InspectionOrderPropertyHomeDetailLocales";
import { ArchitecturalStyle } from "./home-detail/architectural-style";
import { ConstructionQuality } from "./home-detail/construction-quality";
import { FoundationType } from "./home-detail/foundation-type";
import { FramingType } from "./home-detail/framing-type";
import { HomeShape } from "./home-detail/home-shape";
import { PrimaryExteriorWallCovering } from "./home-detail/primary-exterior-wall-covering";
import { PrimaryRoofCovering } from "./home-detail/primary-roof-covering";
import { RoofType } from "./home-detail/roof-type";
import { SecondaryExteriorWallCovering } from "./home-detail/secondary-exterior-wall-covering";
import { SecondaryRoofCovering } from "./home-detail/secondary-roof-covering";
import { SlopeOfSite } from "./home-detail/slope-of-site";
import { RoofShape } from "./home-detail/roof-shape";
import { RoofPitch } from "./home-detail/roof-pitch";

export class InspectionOrderPropertyHomeDetail {
    /*[Parent]*/
    inspectionOrderProperty?: InspectionOrderProperty;
    id?: string;
    architecturalStyleId?: string;
    /*[ForeignKey(nameof(ArchitecturalStyleId))]*/
    architecturalStyle?: ArchitecturalStyle;
    framingTypeId?: string;
    /*[ForeignKey(nameof(FramingTypeId))]*/
    framingType?: FramingType;
    constructionQualityId?: string;
    /*[ForeignKey(nameof(ConstructionQualityId))]*/
    constructionQuality?: ConstructionQuality;
    homeShapeId?: string;
    /*[ForeignKey(nameof(HomeShapeId))]*/
    homeShape?: HomeShape;
    primaryExteriorWallCoveringId?: string;
    /*[ForeignKey(nameof(PrimaryExteriorWallCoveringId))]*/
    primaryExteriorWallCovering?: PrimaryExteriorWallCovering;
    secondaryExteriorWallCoveringId?: string;
    /*[ForeignKey(nameof(SecondaryExteriorWallCoveringId))]*/
    secondaryExteriorWallCovering?: SecondaryExteriorWallCovering;
    primaryRoofCoveringId?: string;
    /*[ForeignKey(nameof(PrimaryRoofCoveringId))]*/
    primaryRoofCovering?: PrimaryRoofCovering;
    secondaryRoofCoveringId?: string;
    /*[ForeignKey(nameof(SecondaryRoofCoveringId))]*/
    secondaryRoofCovering?: SecondaryRoofCovering;
    roofShapeId?: string;
    /*[ForeignKey(nameof(roofShapeId))]*/
    roofShape?: RoofShape;
    roofPitchId?: string;
    /*[ForeignKey(nameof(roofPitchId))]*/
    roofPitch?: RoofPitch;
    foundationTypeId?: string;
    /*[ForeignKey(nameof(FoundationTypeId))]*/
    foundationType?: FoundationType;
    numberofStories?: number;
    slopeOfSiteId?: string;
    /*[ForeignKey(nameof(SlopeOfSiteId))]*/
    slopeOfSite?: SlopeOfSite;
    locales?: InspectionOrderPropertyHomeDetailLocales[];
    
    public constructor(init?:Partial<InspectionOrderPropertyHomeDetail>) {
        Object.assign(this, init);
    }
}