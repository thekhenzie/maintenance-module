using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class AddedNonUniqueIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_InspectionOrderWildfireAssessmentWindowWindowStyles_WindowStyleId",
                table: "InspectionOrderWildfireAssessmentWindowWindowStyles",
                newName: "IX_IoWaWindowWindowStyles_WindowStyleId");

            migrationBuilder.RenameIndex(
                name: "IX_InspectionOrderWildfireAssessmentWindowWindowScreenTypes_WindowScreenTypeId",
                table: "InspectionOrderWildfireAssessmentWindowWindowScreenTypes",
                newName: "IX_IoWaWindowWindowScreenTypes_WindowScreenTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_InspectionOrderWildfireAssessmentWindowWindowGlassTypes_WindowGlassTypeId",
                table: "InspectionOrderWildfireAssessmentWindowWindowGlassTypes",
                newName: "IX_IoWaWindowWindowGlassTypes_WindowGlassTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_InspectionOrderWildfireAssessmentWindowWindowFramingTypes_WindowFramingTypeId",
                table: "InspectionOrderWildfireAssessmentWindowWindowFramingTypes",
                newName: "IX_IoWaWindowWindowFramingTypes_WindowFramingTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_InspectionOrderWildfireAssessmentWindowWindowConcernDetails_WindowConcernDetailId",
                table: "InspectionOrderWildfireAssessmentWindowWindowConcernDetails",
                newName: "IX_IoWaWindowWindowConcernDetails_WindowConcernDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_InspectionOrderWildfireAssessmentWindowInteriorWindowCoveringTypes_InteriorWindowCoveringTypeId",
                table: "InspectionOrderWildfireAssessmentWindowInteriorWindowCoveringTypes",
                newName: "IX_IoWaWindowInteriorWindowCoveringTypes_InteriorWindowCoveringTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_InspectionOrderWildfireAssessmentWindowExteriorWindowCoveringTypes_ExteriorWindowCoveringTypeId",
                table: "InspectionOrderWildfireAssessmentWindowExteriorWindowCoveringTypes",
                newName: "IX_IoWaWindowExteriorWindowCoveringTypes_ExteriorWindowCoveringTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_InspectionOrderWildfireAssessmentRoofRoofVentings_RoofVentingId",
                table: "InspectionOrderWildfireAssessmentRoofRoofVentings",
                newName: "IX_IoWaRoofRoofVentings_RoofVentingId");

            migrationBuilder.RenameIndex(
                name: "IX_InspectionOrderWildfireAssessmentRoofRoofConcernDetails_RoofConcernDetailId",
                table: "InspectionOrderWildfireAssessmentRoofRoofConcernDetails",
                newName: "IX_IoWaRoofRoofConcernDetails_RoofConcernDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_InspectionOrderWildfireAssessmentRoofOtherRoofCoverings_OtherRoofCoveringId",
                table: "InspectionOrderWildfireAssessmentRoofOtherRoofCoverings",
                newName: "IX_IoWaRoofOtherRoofCoverings_OtherRoofCoveringId");

            migrationBuilder.RenameIndex(
                name: "IX_InspectionOrderWildfireAssessmentRoofGutterTypes_GutterTypeId",
                table: "InspectionOrderWildfireAssessmentRoofGutterTypes",
                newName: "IX_IoWaRoofGutterTypes_GutterTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOutbuildingDetails_OutbuildingDetailId",
                table: "InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOutbuildingDetails",
                newName: "IX_IoWaFencingAndOtherAttachmentOutbuildingDetails_OutbuildingDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherDetachedStructuresDetails_OtherDetachedStructuresDetailId",
                table: "InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherDetachedStructuresDetails",
                newName: "IX_IoWaFencingAndOtherAttachmentOtherDetachedStructuresDetails_OtherDetachedStructuresDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherAttachmentTypes_OtherAttachmentTypeId",
                table: "InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherAttachmentTypes",
                newName: "IX_IoWaFencingAndOtherAttachmentOtherAttachmentTypes_OtherAttachmentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFencingTypes_FencingTypeId",
                table: "InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFencingTypes",
                newName: "IX_IoWaFencingAndOtherAttachmentFencingTypes_FencingTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFenceConditionConcernDetails_FenceConditionConcernDetailId",
                table: "InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFenceConditionConcernDetails",
                newName: "IX_IoWaFencingAndOtherAttachmentFenceConditionConcernDetails_FenceConditionConcernDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_InspectionOrderWildfireAssessmentExternalFuelSourceExternalFuelSourceTypes_ExternalFuelSourceTypeId",
                table: "InspectionOrderWildfireAssessmentExternalFuelSourceExternalFuelSourceTypes",
                newName: "IX_IoWaExternalFuelSourceExternalFuelSourceTypes_ExternalFuelSourceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_InspectionOrderWildfireAssessmentExteriorSidingSidingConditionConcernDetails_SidingConditionConcernDetailId",
                table: "InspectionOrderWildfireAssessmentExteriorSidingSidingConditionConcernDetails",
                newName: "IX_IoWaExteriorSidingSidingConditionConcernDetails_SidingConditionConcernDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_InspectionOrderWildfireAssessmentExteriorSidingOtherWallCoverings_OtherWallCoveringId",
                table: "InspectionOrderWildfireAssessmentExteriorSidingOtherWallCoverings",
                newName: "IX_IoWaExteriorSidingOtherWallCoverings_OtherWallCoveringId");

            migrationBuilder.RenameIndex(
                name: "IX_InspectionOrderWildfireAssessmentDeckAndBalconyPorchDeckBalconyConstructions_PorchDeckBalconyConstructionId",
                table: "InspectionOrderWildfireAssessmentDeckAndBalconyPorchDeckBalconyConstructions",
                newName: "IX_IoWaDeckAndBalconyPorchDeckBalconyConstructions_PorchDeckBalconyConstructionId");

            migrationBuilder.RenameIndex(
                name: "IX_InspectionOrderWildfireAssessmentDeckAndBalconyDeckConditionConcernDetails_DeckConditionConcernDetailId",
                table: "InspectionOrderWildfireAssessmentDeckAndBalconyDeckConditionConcernDetails",
                newName: "IX_IoWaDeckAndBalconyDeckConditionConcernDetails_DeckConditionConcernDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_IoWaWindowWindowStyles_WindowStyleId",
                table: "InspectionOrderWildfireAssessmentWindowWindowStyles",
                newName: "IX_InspectionOrderWildfireAssessmentWindowWindowStyles_WindowStyleId");

            migrationBuilder.RenameIndex(
                name: "IX_IoWaWindowWindowScreenTypes_WindowScreenTypeId",
                table: "InspectionOrderWildfireAssessmentWindowWindowScreenTypes",
                newName: "IX_InspectionOrderWildfireAssessmentWindowWindowScreenTypes_WindowScreenTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_IoWaWindowWindowGlassTypes_WindowGlassTypeId",
                table: "InspectionOrderWildfireAssessmentWindowWindowGlassTypes",
                newName: "IX_InspectionOrderWildfireAssessmentWindowWindowGlassTypes_WindowGlassTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_IoWaWindowWindowFramingTypes_WindowFramingTypeId",
                table: "InspectionOrderWildfireAssessmentWindowWindowFramingTypes",
                newName: "IX_InspectionOrderWildfireAssessmentWindowWindowFramingTypes_WindowFramingTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_IoWaWindowWindowConcernDetails_WindowConcernDetailId",
                table: "InspectionOrderWildfireAssessmentWindowWindowConcernDetails",
                newName: "IX_InspectionOrderWildfireAssessmentWindowWindowConcernDetails_WindowConcernDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_IoWaWindowInteriorWindowCoveringTypes_InteriorWindowCoveringTypeId",
                table: "InspectionOrderWildfireAssessmentWindowInteriorWindowCoveringTypes",
                newName: "IX_InspectionOrderWildfireAssessmentWindowInteriorWindowCoveringTypes_InteriorWindowCoveringTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_IoWaWindowExteriorWindowCoveringTypes_ExteriorWindowCoveringTypeId",
                table: "InspectionOrderWildfireAssessmentWindowExteriorWindowCoveringTypes",
                newName: "IX_InspectionOrderWildfireAssessmentWindowExteriorWindowCoveringTypes_ExteriorWindowCoveringTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_IoWaRoofRoofVentings_RoofVentingId",
                table: "InspectionOrderWildfireAssessmentRoofRoofVentings",
                newName: "IX_InspectionOrderWildfireAssessmentRoofRoofVentings_RoofVentingId");

            migrationBuilder.RenameIndex(
                name: "IX_IoWaRoofRoofConcernDetails_RoofConcernDetailId",
                table: "InspectionOrderWildfireAssessmentRoofRoofConcernDetails",
                newName: "IX_InspectionOrderWildfireAssessmentRoofRoofConcernDetails_RoofConcernDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_IoWaRoofOtherRoofCoverings_OtherRoofCoveringId",
                table: "InspectionOrderWildfireAssessmentRoofOtherRoofCoverings",
                newName: "IX_InspectionOrderWildfireAssessmentRoofOtherRoofCoverings_OtherRoofCoveringId");

            migrationBuilder.RenameIndex(
                name: "IX_IoWaRoofGutterTypes_GutterTypeId",
                table: "InspectionOrderWildfireAssessmentRoofGutterTypes",
                newName: "IX_InspectionOrderWildfireAssessmentRoofGutterTypes_GutterTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_IoWaFencingAndOtherAttachmentOutbuildingDetails_OutbuildingDetailId",
                table: "InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOutbuildingDetails",
                newName: "IX_InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOutbuildingDetails_OutbuildingDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_IoWaFencingAndOtherAttachmentOtherDetachedStructuresDetails_OtherDetachedStructuresDetailId",
                table: "InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherDetachedStructuresDetails",
                newName: "IX_InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherDetachedStructuresDetails_OtherDetachedStructuresDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_IoWaFencingAndOtherAttachmentOtherAttachmentTypes_OtherAttachmentTypeId",
                table: "InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherAttachmentTypes",
                newName: "IX_InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherAttachmentTypes_OtherAttachmentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_IoWaFencingAndOtherAttachmentFencingTypes_FencingTypeId",
                table: "InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFencingTypes",
                newName: "IX_InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFencingTypes_FencingTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_IoWaFencingAndOtherAttachmentFenceConditionConcernDetails_FenceConditionConcernDetailId",
                table: "InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFenceConditionConcernDetails",
                newName: "IX_InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFenceConditionConcernDetails_FenceConditionConcernDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_IoWaExternalFuelSourceExternalFuelSourceTypes_ExternalFuelSourceTypeId",
                table: "InspectionOrderWildfireAssessmentExternalFuelSourceExternalFuelSourceTypes",
                newName: "IX_InspectionOrderWildfireAssessmentExternalFuelSourceExternalFuelSourceTypes_ExternalFuelSourceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_IoWaExteriorSidingSidingConditionConcernDetails_SidingConditionConcernDetailId",
                table: "InspectionOrderWildfireAssessmentExteriorSidingSidingConditionConcernDetails",
                newName: "IX_InspectionOrderWildfireAssessmentExteriorSidingSidingConditionConcernDetails_SidingConditionConcernDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_IoWaExteriorSidingOtherWallCoverings_OtherWallCoveringId",
                table: "InspectionOrderWildfireAssessmentExteriorSidingOtherWallCoverings",
                newName: "IX_InspectionOrderWildfireAssessmentExteriorSidingOtherWallCoverings_OtherWallCoveringId");

            migrationBuilder.RenameIndex(
                name: "IX_IoWaDeckAndBalconyPorchDeckBalconyConstructions_PorchDeckBalconyConstructionId",
                table: "InspectionOrderWildfireAssessmentDeckAndBalconyPorchDeckBalconyConstructions",
                newName: "IX_InspectionOrderWildfireAssessmentDeckAndBalconyPorchDeckBalconyConstructions_PorchDeckBalconyConstructionId");

            migrationBuilder.RenameIndex(
                name: "IX_IoWaDeckAndBalconyDeckConditionConcernDetails_DeckConditionConcernDetailId",
                table: "InspectionOrderWildfireAssessmentDeckAndBalconyDeckConditionConcernDetails",
                newName: "IX_InspectionOrderWildfireAssessmentDeckAndBalconyDeckConditionConcernDetails_DeckConditionConcernDetailId");
        }
    }
}
