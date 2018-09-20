export class WildfireViewModel {

    //Roof
    primaryRoofCoveringName?: string;
    secondaryRoofCoveringName?: string;
    otherRoofTypeName?: string[] = [];
    roofShapeName?: string;
    roofPitchName?: string;
    roofConcernDetailsName?: string[] = [];
    combustibleMaterialsOnRoof?: boolean;
    combustibleMaterialsOnRoofComment?: string;
    roofVentingName?: string[] = [];
    ventingOpeningAllowEntry?: boolean;
    ventingCoveringsizeComment?: string;
    gutterTypeName?: string[] = [];
    gutterComments?: string;
    eavesTypeName?: string;
    eavesAllowEmberEntry?: boolean;
    eavesComment?: string;
    
    //Foundation to Frame
    openingsEmberEntry?: boolean;
    openingsEmberEntryComments?: string;
    elevatedWithCombustibleMaterials?: boolean;
    elevatedWithCombustibleMaterialsComments?: string;
    foundationTypeName?: string;
    foundationTypeComment?: string;
    framingTypeName?: string;

    //Exterior Siding
    primaryExteriorWallCoveringName?: string;
    secondaryExteriorWallCoveringName?: string;
    otherWallCoverings?: string[] = [];
    nonCombustibleSiding?: boolean;
    sidingConditionConcernsDetails?: string[] = [];
    sidingConditionComments?: string;

    //Windows
    windowSusceptibleToFlame?: boolean;
    windowGlassTypeNames?: string[] = [];
    windowFramingTypeNames?: string[] = [];
    windowStylesName?: string[] = [];
    windowScreenTypeNames?: string[] = [];
    interiorWindowCoveringTypeNames?: string[] = [];
    exteriorWindowCoveringTypeNames?: string[] = [];
    windowConcernDetails?: string[] = [];
    windowNotes?: string;

    //Decks & Balconies
    attachedPorchesDecksOrBalconies?: boolean;
    porchDeckBalconyConstruction?: string[] = [];
    porchDeckBalconyCovered?: boolean;
    coveringMaterial?: string;
    deckConditionConcernsDetailsName?: string[] = [];
    attachedStructuresComments?: string;
    combustibleMaterialsOnDeck?: boolean;
    combustibleMaterialsOnDeckDescription?: string;
    combustibleMaterialsUnderDeck?: boolean;
    combustibleMaterialsUnderDeckDescription?: string;

    //Fencing & Other Attachments
    fencingWithin30Feet?: boolean;
    fencingTypeNames?: string[] = [];
    fenceConditionconcernDetailsName?: string[] = [];
    fenceComments?: string;
    otherAttachmentTypesName?: string[] = [];
    outbuildingDetailNames?: string[] = [];
    otherDetachedStructureDetailsName?: string[] = [];

    //Surroundings
    combustible05Feet?: boolean;
    combustible05FeetComment?: string;
    combustible530Feet?: boolean;
    combustible530FeetComment?: string;
    combustbile30100Feet?: boolean;
    combustible30100Feetcomments?: string;
    additionalstructureContributor?: boolean;
    additionalstructureContributorComment?: string;
    topographicalEnvironmentContributor?: boolean;
    topographicalEnvironmentContributorComment?: string;
    volatileVegetation?: boolean;
    volatilevegetationComment?: string;
    neighboringResidences?: boolean;
    neighboringResidencesComment?: string;

    //Access & Fire Protection
    timelyResponseConcern?: boolean;
    timelyResponseConcernComment?: string;
    addressHardToRead?: boolean;
    addressReadabilitycomment?: string;
    bridgeConcern?: boolean;
    bridgeConcernComment?: string;
    respondingFireDepartment?: string;
    fireDepartmentStaffingName?: string;
    fireDepartmentDistanceToHome?: string;
    fireDepartmentTravelTimeToHome?: number;
    nearestFireHydrant?: string;
    alternateWaterSourceIfNoHydrant?: string;

    //External Fuel Source
    externalFuelSource?: boolean;
    externalFuelSourceTypeNames?: string[] = [];
    externalFuelSourceDistanceFromHome?: number;
    woodStoveFireplace?: boolean;
    woodStorageLocation?: string;
    firePreventiveMeasures?: string;

    public constructor(init?:Partial<WildfireViewModel>) {
        Object.assign(this, init);
    }
}