using System;
using System.Collections.Generic;
using System.Text;

namespace Rivington.IG.Domain.Models.ViewModel
{
    public class WildFireViewModel
    {
        #region Properties

        #region Roof Fields
        public string PrimaryRoofCoveringName { get; set; }
        public string SecondaryRoofCoveringName { get; set; }
        public string[] OtherRoofTypeName { get; set; }
        public string RoofTypeName { get; set; }
        public string RoofShapeName { get; set; }
        public string RoofPitchName { get; set; }
        public string[] RoofConcernDetailsName { get; set; }
        public bool CombustibleMaterialsOnRoof { get; set; }
        public string CombustibleMaterialsOnRoofComment { get; set; }
        public string[] RoofVentingName { get; set; }
        public bool VentingOpeningAllowEntry { get; set; }
        public string VentingCoveringsizeComment { get; set; }
        public bool Gutter { get; set; }
        public string[] GutterTypeName { get; set; }
        public string GutterComments { get; set; }
        public string EavesTypeName { get; set; }
        public bool EavesAllowEmberEntry { get; set; }
        public string EavesComment { get; set; }
        #endregion

        #region Foundation to Frame Fields
        public bool OpeningsEmberEntry { get; set; }
        public string OpeningsEmberEntryComments { get; set; }
        public bool ElevatedWithCombustibleMaterials { get; set; }
        public string ElevatedWithCombustibleMaterialsComments { get; set; }
        public string FoundationTypeName { get; set; }
        public string FoundationTypeComment { get; set; }
        public string FramingTypeName { get; set; }
        #endregion

        #region Exterior Siding Fields
        public string PrimaryExteriorWallCoveringName { get; set; }
        public string SecondaryExteriorWallCoveringName { get; set; }
        public string[] OtherWallCoverings { get; set; }
        public bool NonCombustibleSiding { get; set; }
        public bool SidingConditionConcerns { get; set; }
        public string[] SidingConditionConcernsDetails { get; set; }
        public string SidingConditionComments { get; set; }
        #endregion

        #region Windows Fields
        public bool WindowSusceptibleToFlame { get; set; }
        public string[] WindowGlassTypeNames { get; set; }
        public string[] WindowFramingTypeNames { get; set; }
        public string[] WindowStylesName { get; set; }
        public bool WindowScreens { get; set; }
        public string[] WindowScreenTypeNames { get; set; }
        public bool InteriorWindowCoverings { get; set; }
        public string[] InteriorWindowCoveringTypeNames { get; set; }
        public bool ExteriorWindowCoverings { get; set; }
        public string[] ExteriorWindowCoveringTypeNames { get; set; }
        public bool WindowConcerns { get; set; }
        public string[] WindowConcernDetails { get; set; }
        public string WindowNotes { get; set; }
        #endregion

        #region Decks & Balconies Fields
        public bool AttachedPorchesDecksOrBalconies { get; set; }
        public string[] PorchDeckBalconyConstruction { get; set; }
        public bool PorchDeckBalconyCovered { get; set; }
        public string CoveringMaterial { get; set; }
        public bool DeckConditionConcerns { get; set; }
        public string[] DeckConditionConcernsDetailsName { get; set; }
        public string AttachedStructuresComments { get; set; }
        public bool CombustibleMaterialsOnDeck { get; set; }
        public string CombustibleMaterialsOnDeckDescription { get; set; }
        public bool CombustibleMaterialsUnderDeck { get; set; }
        public string CombustibleMaterialsUnderDeckDescription { get; set; }
        #endregion

        #region Fencing & Other Attachments Fields
        public bool FencingWithin30Feet { get; set; }
        public string[] FencingTypeNames { get; set; }
        public bool FenceConditionConcerns { get; set; }
        public string[] FenceConditionconcernDetailsName { get; set; }
        public string FenceComments { get; set; }
        public bool OtherAttachments { get; set; }
        public string[] OtherAttachmentTypesName { get; set; }
        public bool Outbuilding { get; set; }
        public string[] OutbuildingDetailNames { get; set; }
        public bool OtherDetachedStructures { get; set; }
        public string[] OtherDetachedStructureDetailsName { get; set; }
        #endregion

        #region Surroundings Fields
        public bool Combustible05Feet { get; set; }
        public string Combustible05FeetComment { get; set; }
        public bool Combustible530Feet { get; set; }
        public string Combustible530FeetComment { get; set; }
        public bool Combustbile30100Feet { get; set; }
        public string Combustible30100Feetcomments { get; set; }
        public bool AdditionalstructureContributor { get; set; }
        public string AdditionalstructureContributorComment { get; set; }
        public bool TopographicalEnvironmentContributor { get; set; }
        public string TopographicalEnvironmentContributorComment { get; set; }
        public bool VolatileVegetation { get; set; }
        public string VolatilevegetationComment { get; set; }
        public bool NeighboringResidences { get; set; }
        public string NeighboringResidencesComment { get; set; }
        #endregion

        #region Acces & Fire Protection Fields
        public bool TimelyResponseConcern { get; set; }
        public string TimelyResponseConcernComment { get; set; }
        public bool AddressHardToRead { get; set; }
        public string AddressReadabilitycomment { get; set; }
        public bool BridgeConcern { get; set; }
        public string BridgeConcernComment { get; set; }
        public string RespondingFireDepartment { get; set; }
        public string FireDepartmentStaffingName { get; set; }
        public string FireDepartmentDistanceToHome { get; set; }
        public int? FireDepartmentTravelTimeToHome { get; set; }
        public string NearestFireHydrant { get; set; }
        public string AlternateWaterSourceIfNoHydrant { get; set; }
        #endregion

        #region External Fuel Source
        public bool ExternalFuelSource { get; set; }
        public string[] ExternalFuelSourceTypeNames { get; set; }
        public int? ExternalFuelSourceDistanceFromHome { get; set; }
        public bool WoodStoveFireplace { get; set; }
        public string WoodStorageLocation { get; set; }
        public string FirePreventiveMeasures { get; set; }
        #endregion

        #endregion
    }
}
