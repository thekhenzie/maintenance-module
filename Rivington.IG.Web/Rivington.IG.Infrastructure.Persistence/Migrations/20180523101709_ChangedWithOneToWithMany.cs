using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class ChangedWithOneToWithMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderWildfireAssessmentRoof_EavesTypeId",
                table: "InspectionOrderWildfireAssessmentRoof");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderWildfireAssessmentRoof_PrimaryRoofCoveringId",
                table: "InspectionOrderWildfireAssessmentRoof");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderWildfireAssessmentRoof_RoofTypeId",
                table: "InspectionOrderWildfireAssessmentRoof");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderWildfireAssessmentRoof_SecondaryRoofCoveringId",
                table: "InspectionOrderWildfireAssessmentRoof");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderWildfireAssessmentFoundationToFrame_FoundationTypeId",
                table: "InspectionOrderWildfireAssessmentFoundationToFrame");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderWildfireAssessmentFoundationToFrame_FramingTypeId",
                table: "InspectionOrderWildfireAssessmentFoundationToFrame");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderWildfireAssessmentExteriorSiding_PrimaryExteriorWallCoveringId",
                table: "InspectionOrderWildfireAssessmentExteriorSiding");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderWildfireAssessmentExteriorSiding_SecondaryExteriorWallCoveringId",
                table: "InspectionOrderWildfireAssessmentExteriorSiding");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderWildfireAssessmentAccessAndFireProtection_FireDepartmentStaffingId",
                table: "InspectionOrderWildfireAssessmentAccessAndFireProtection");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_ArchitecturalStyleId",
                table: "InspectionOrderPropertyHomeDetail");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_ConstructionQualityId",
                table: "InspectionOrderPropertyHomeDetail");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_FoundationTypeId",
                table: "InspectionOrderPropertyHomeDetail");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_FramingTypeId",
                table: "InspectionOrderPropertyHomeDetail");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_HomeShapeId",
                table: "InspectionOrderPropertyHomeDetail");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_PrimaryExteriorWallCoveringId",
                table: "InspectionOrderPropertyHomeDetail");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_PrimaryRoofCoveringId",
                table: "InspectionOrderPropertyHomeDetail");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_RoofTypeId",
                table: "InspectionOrderPropertyHomeDetail");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_SecondaryExteriorWallCoveringId",
                table: "InspectionOrderPropertyHomeDetail");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_SecondaryRoofCoveringId",
                table: "InspectionOrderPropertyHomeDetail");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_SlopeOfSiteId",
                table: "InspectionOrderPropertyHomeDetail");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyHighValueKitchen_ApplianceBrandId",
                table: "InspectionOrderPropertyHighValueKitchen");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyHighValueKitchen_KitchenCabinetId",
                table: "InspectionOrderPropertyHighValueKitchen");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyHighValueKitchen_KitchenCountertopId",
                table: "InspectionOrderPropertyHighValueKitchen");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyHighValueFloorToCeiling_ChimneyTypeId",
                table: "InspectionOrderPropertyHighValueFloorToCeiling");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyGeneral_BurglarAlarmId",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyGeneral_BurglarAlarmTypeId",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyGeneral_CityId",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyGeneral_DomesticHelpId",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyGeneral_FireAlarmId",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyGeneral_FireAlarmTypeId",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyGeneral_OccupancyTypeId",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyGeneral_SmokeOnlyAlarmId",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyGeneral_SmokeOnlyAlarmTypeId",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyGeneral_StateId",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyAdditionalExposure_CustomerOnSiteId",
                table: "InspectionOrderPropertyAdditionalExposure");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyAdditionalExposure_DogTemperamentId",
                table: "InspectionOrderPropertyAdditionalExposure");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyAdditionalExposure_Employee10HoursPerWeekId",
                table: "InspectionOrderPropertyAdditionalExposure");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentRoof_EavesTypeId",
                table: "InspectionOrderWildfireAssessmentRoof",
                column: "EavesTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentRoof_PrimaryRoofCoveringId",
                table: "InspectionOrderWildfireAssessmentRoof",
                column: "PrimaryRoofCoveringId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentRoof_RoofTypeId",
                table: "InspectionOrderWildfireAssessmentRoof",
                column: "RoofTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentRoof_SecondaryRoofCoveringId",
                table: "InspectionOrderWildfireAssessmentRoof",
                column: "SecondaryRoofCoveringId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentFoundationToFrame_FoundationTypeId",
                table: "InspectionOrderWildfireAssessmentFoundationToFrame",
                column: "FoundationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentFoundationToFrame_FramingTypeId",
                table: "InspectionOrderWildfireAssessmentFoundationToFrame",
                column: "FramingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentExteriorSiding_PrimaryExteriorWallCoveringId",
                table: "InspectionOrderWildfireAssessmentExteriorSiding",
                column: "PrimaryExteriorWallCoveringId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentExteriorSiding_SecondaryExteriorWallCoveringId",
                table: "InspectionOrderWildfireAssessmentExteriorSiding",
                column: "SecondaryExteriorWallCoveringId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentAccessAndFireProtection_FireDepartmentStaffingId",
                table: "InspectionOrderWildfireAssessmentAccessAndFireProtection",
                column: "FireDepartmentStaffingId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_ArchitecturalStyleId",
                table: "InspectionOrderPropertyHomeDetail",
                column: "ArchitecturalStyleId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_ConstructionQualityId",
                table: "InspectionOrderPropertyHomeDetail",
                column: "ConstructionQualityId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_FoundationTypeId",
                table: "InspectionOrderPropertyHomeDetail",
                column: "FoundationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_FramingTypeId",
                table: "InspectionOrderPropertyHomeDetail",
                column: "FramingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_HomeShapeId",
                table: "InspectionOrderPropertyHomeDetail",
                column: "HomeShapeId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_PrimaryExteriorWallCoveringId",
                table: "InspectionOrderPropertyHomeDetail",
                column: "PrimaryExteriorWallCoveringId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_PrimaryRoofCoveringId",
                table: "InspectionOrderPropertyHomeDetail",
                column: "PrimaryRoofCoveringId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_RoofTypeId",
                table: "InspectionOrderPropertyHomeDetail",
                column: "RoofTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_SecondaryExteriorWallCoveringId",
                table: "InspectionOrderPropertyHomeDetail",
                column: "SecondaryExteriorWallCoveringId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_SecondaryRoofCoveringId",
                table: "InspectionOrderPropertyHomeDetail",
                column: "SecondaryRoofCoveringId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_SlopeOfSiteId",
                table: "InspectionOrderPropertyHomeDetail",
                column: "SlopeOfSiteId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHighValueKitchen_ApplianceBrandId",
                table: "InspectionOrderPropertyHighValueKitchen",
                column: "ApplianceBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHighValueKitchen_KitchenCabinetId",
                table: "InspectionOrderPropertyHighValueKitchen",
                column: "KitchenCabinetId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHighValueKitchen_KitchenCountertopId",
                table: "InspectionOrderPropertyHighValueKitchen",
                column: "KitchenCountertopId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHighValueFloorToCeiling_ChimneyTypeId",
                table: "InspectionOrderPropertyHighValueFloorToCeiling",
                column: "ChimneyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyGeneral_BurglarAlarmId",
                table: "InspectionOrderPropertyGeneral",
                column: "BurglarAlarmId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyGeneral_BurglarAlarmTypeId",
                table: "InspectionOrderPropertyGeneral",
                column: "BurglarAlarmTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyGeneral_CityId",
                table: "InspectionOrderPropertyGeneral",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyGeneral_DomesticHelpId",
                table: "InspectionOrderPropertyGeneral",
                column: "DomesticHelpId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyGeneral_FireAlarmId",
                table: "InspectionOrderPropertyGeneral",
                column: "FireAlarmId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyGeneral_FireAlarmTypeId",
                table: "InspectionOrderPropertyGeneral",
                column: "FireAlarmTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyGeneral_OccupancyTypeId",
                table: "InspectionOrderPropertyGeneral",
                column: "OccupancyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyGeneral_SmokeOnlyAlarmId",
                table: "InspectionOrderPropertyGeneral",
                column: "SmokeOnlyAlarmId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyGeneral_SmokeOnlyAlarmTypeId",
                table: "InspectionOrderPropertyGeneral",
                column: "SmokeOnlyAlarmTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyGeneral_StateId",
                table: "InspectionOrderPropertyGeneral",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyAdditionalExposure_CustomerOnSiteId",
                table: "InspectionOrderPropertyAdditionalExposure",
                column: "CustomerOnSiteId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyAdditionalExposure_DogTemperamentId",
                table: "InspectionOrderPropertyAdditionalExposure",
                column: "DogTemperamentId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyAdditionalExposure_Employee10HoursPerWeekId",
                table: "InspectionOrderPropertyAdditionalExposure",
                column: "Employee10HoursPerWeekId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderWildfireAssessmentRoof_EavesTypeId",
                table: "InspectionOrderWildfireAssessmentRoof");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderWildfireAssessmentRoof_PrimaryRoofCoveringId",
                table: "InspectionOrderWildfireAssessmentRoof");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderWildfireAssessmentRoof_RoofTypeId",
                table: "InspectionOrderWildfireAssessmentRoof");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderWildfireAssessmentRoof_SecondaryRoofCoveringId",
                table: "InspectionOrderWildfireAssessmentRoof");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderWildfireAssessmentFoundationToFrame_FoundationTypeId",
                table: "InspectionOrderWildfireAssessmentFoundationToFrame");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderWildfireAssessmentFoundationToFrame_FramingTypeId",
                table: "InspectionOrderWildfireAssessmentFoundationToFrame");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderWildfireAssessmentExteriorSiding_PrimaryExteriorWallCoveringId",
                table: "InspectionOrderWildfireAssessmentExteriorSiding");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderWildfireAssessmentExteriorSiding_SecondaryExteriorWallCoveringId",
                table: "InspectionOrderWildfireAssessmentExteriorSiding");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderWildfireAssessmentAccessAndFireProtection_FireDepartmentStaffingId",
                table: "InspectionOrderWildfireAssessmentAccessAndFireProtection");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_ArchitecturalStyleId",
                table: "InspectionOrderPropertyHomeDetail");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_ConstructionQualityId",
                table: "InspectionOrderPropertyHomeDetail");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_FoundationTypeId",
                table: "InspectionOrderPropertyHomeDetail");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_FramingTypeId",
                table: "InspectionOrderPropertyHomeDetail");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_HomeShapeId",
                table: "InspectionOrderPropertyHomeDetail");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_PrimaryExteriorWallCoveringId",
                table: "InspectionOrderPropertyHomeDetail");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_PrimaryRoofCoveringId",
                table: "InspectionOrderPropertyHomeDetail");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_RoofTypeId",
                table: "InspectionOrderPropertyHomeDetail");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_SecondaryExteriorWallCoveringId",
                table: "InspectionOrderPropertyHomeDetail");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_SecondaryRoofCoveringId",
                table: "InspectionOrderPropertyHomeDetail");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_SlopeOfSiteId",
                table: "InspectionOrderPropertyHomeDetail");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyHighValueKitchen_ApplianceBrandId",
                table: "InspectionOrderPropertyHighValueKitchen");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyHighValueKitchen_KitchenCabinetId",
                table: "InspectionOrderPropertyHighValueKitchen");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyHighValueKitchen_KitchenCountertopId",
                table: "InspectionOrderPropertyHighValueKitchen");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyHighValueFloorToCeiling_ChimneyTypeId",
                table: "InspectionOrderPropertyHighValueFloorToCeiling");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyGeneral_BurglarAlarmId",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyGeneral_BurglarAlarmTypeId",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyGeneral_CityId",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyGeneral_DomesticHelpId",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyGeneral_FireAlarmId",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyGeneral_FireAlarmTypeId",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyGeneral_OccupancyTypeId",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyGeneral_SmokeOnlyAlarmId",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyGeneral_SmokeOnlyAlarmTypeId",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyGeneral_StateId",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyAdditionalExposure_CustomerOnSiteId",
                table: "InspectionOrderPropertyAdditionalExposure");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyAdditionalExposure_DogTemperamentId",
                table: "InspectionOrderPropertyAdditionalExposure");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyAdditionalExposure_Employee10HoursPerWeekId",
                table: "InspectionOrderPropertyAdditionalExposure");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentRoof_EavesTypeId",
                table: "InspectionOrderWildfireAssessmentRoof",
                column: "EavesTypeId",
                unique: true,
                filter: "[EavesTypeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentRoof_PrimaryRoofCoveringId",
                table: "InspectionOrderWildfireAssessmentRoof",
                column: "PrimaryRoofCoveringId",
                unique: true,
                filter: "[PrimaryRoofCoveringId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentRoof_RoofTypeId",
                table: "InspectionOrderWildfireAssessmentRoof",
                column: "RoofTypeId",
                unique: true,
                filter: "[RoofTypeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentRoof_SecondaryRoofCoveringId",
                table: "InspectionOrderWildfireAssessmentRoof",
                column: "SecondaryRoofCoveringId",
                unique: true,
                filter: "[SecondaryRoofCoveringId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentFoundationToFrame_FoundationTypeId",
                table: "InspectionOrderWildfireAssessmentFoundationToFrame",
                column: "FoundationTypeId",
                unique: true,
                filter: "[FoundationTypeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentFoundationToFrame_FramingTypeId",
                table: "InspectionOrderWildfireAssessmentFoundationToFrame",
                column: "FramingTypeId",
                unique: true,
                filter: "[FramingTypeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentExteriorSiding_PrimaryExteriorWallCoveringId",
                table: "InspectionOrderWildfireAssessmentExteriorSiding",
                column: "PrimaryExteriorWallCoveringId",
                unique: true,
                filter: "[PrimaryExteriorWallCoveringId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentExteriorSiding_SecondaryExteriorWallCoveringId",
                table: "InspectionOrderWildfireAssessmentExteriorSiding",
                column: "SecondaryExteriorWallCoveringId",
                unique: true,
                filter: "[SecondaryExteriorWallCoveringId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentAccessAndFireProtection_FireDepartmentStaffingId",
                table: "InspectionOrderWildfireAssessmentAccessAndFireProtection",
                column: "FireDepartmentStaffingId",
                unique: true,
                filter: "[FireDepartmentStaffingId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_ArchitecturalStyleId",
                table: "InspectionOrderPropertyHomeDetail",
                column: "ArchitecturalStyleId",
                unique: true,
                filter: "[ArchitecturalStyleId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_ConstructionQualityId",
                table: "InspectionOrderPropertyHomeDetail",
                column: "ConstructionQualityId",
                unique: true,
                filter: "[ConstructionQualityId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_FoundationTypeId",
                table: "InspectionOrderPropertyHomeDetail",
                column: "FoundationTypeId",
                unique: true,
                filter: "[FoundationTypeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_FramingTypeId",
                table: "InspectionOrderPropertyHomeDetail",
                column: "FramingTypeId",
                unique: true,
                filter: "[FramingTypeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_HomeShapeId",
                table: "InspectionOrderPropertyHomeDetail",
                column: "HomeShapeId",
                unique: true,
                filter: "[HomeShapeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_PrimaryExteriorWallCoveringId",
                table: "InspectionOrderPropertyHomeDetail",
                column: "PrimaryExteriorWallCoveringId",
                unique: true,
                filter: "[PrimaryExteriorWallCoveringId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_PrimaryRoofCoveringId",
                table: "InspectionOrderPropertyHomeDetail",
                column: "PrimaryRoofCoveringId",
                unique: true,
                filter: "[PrimaryRoofCoveringId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_RoofTypeId",
                table: "InspectionOrderPropertyHomeDetail",
                column: "RoofTypeId",
                unique: true,
                filter: "[RoofTypeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_SecondaryExteriorWallCoveringId",
                table: "InspectionOrderPropertyHomeDetail",
                column: "SecondaryExteriorWallCoveringId",
                unique: true,
                filter: "[SecondaryExteriorWallCoveringId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_SecondaryRoofCoveringId",
                table: "InspectionOrderPropertyHomeDetail",
                column: "SecondaryRoofCoveringId",
                unique: true,
                filter: "[SecondaryRoofCoveringId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_SlopeOfSiteId",
                table: "InspectionOrderPropertyHomeDetail",
                column: "SlopeOfSiteId",
                unique: true,
                filter: "[SlopeOfSiteId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHighValueKitchen_ApplianceBrandId",
                table: "InspectionOrderPropertyHighValueKitchen",
                column: "ApplianceBrandId",
                unique: true,
                filter: "[ApplianceBrandId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHighValueKitchen_KitchenCabinetId",
                table: "InspectionOrderPropertyHighValueKitchen",
                column: "KitchenCabinetId",
                unique: true,
                filter: "[KitchenCabinetId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHighValueKitchen_KitchenCountertopId",
                table: "InspectionOrderPropertyHighValueKitchen",
                column: "KitchenCountertopId",
                unique: true,
                filter: "[KitchenCountertopId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHighValueFloorToCeiling_ChimneyTypeId",
                table: "InspectionOrderPropertyHighValueFloorToCeiling",
                column: "ChimneyTypeId",
                unique: true,
                filter: "[ChimneyTypeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyGeneral_BurglarAlarmId",
                table: "InspectionOrderPropertyGeneral",
                column: "BurglarAlarmId",
                unique: true,
                filter: "[BurglarAlarmId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyGeneral_BurglarAlarmTypeId",
                table: "InspectionOrderPropertyGeneral",
                column: "BurglarAlarmTypeId",
                unique: true,
                filter: "[BurglarAlarmTypeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyGeneral_CityId",
                table: "InspectionOrderPropertyGeneral",
                column: "CityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyGeneral_DomesticHelpId",
                table: "InspectionOrderPropertyGeneral",
                column: "DomesticHelpId",
                unique: true,
                filter: "[DomesticHelpId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyGeneral_FireAlarmId",
                table: "InspectionOrderPropertyGeneral",
                column: "FireAlarmId",
                unique: true,
                filter: "[FireAlarmId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyGeneral_FireAlarmTypeId",
                table: "InspectionOrderPropertyGeneral",
                column: "FireAlarmTypeId",
                unique: true,
                filter: "[FireAlarmTypeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyGeneral_OccupancyTypeId",
                table: "InspectionOrderPropertyGeneral",
                column: "OccupancyTypeId",
                unique: true,
                filter: "[OccupancyTypeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyGeneral_SmokeOnlyAlarmId",
                table: "InspectionOrderPropertyGeneral",
                column: "SmokeOnlyAlarmId",
                unique: true,
                filter: "[SmokeOnlyAlarmId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyGeneral_SmokeOnlyAlarmTypeId",
                table: "InspectionOrderPropertyGeneral",
                column: "SmokeOnlyAlarmTypeId",
                unique: true,
                filter: "[SmokeOnlyAlarmTypeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyGeneral_StateId",
                table: "InspectionOrderPropertyGeneral",
                column: "StateId",
                unique: true,
                filter: "[StateId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyAdditionalExposure_CustomerOnSiteId",
                table: "InspectionOrderPropertyAdditionalExposure",
                column: "CustomerOnSiteId",
                unique: true,
                filter: "[CustomerOnSiteId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyAdditionalExposure_DogTemperamentId",
                table: "InspectionOrderPropertyAdditionalExposure",
                column: "DogTemperamentId",
                unique: true,
                filter: "[DogTemperamentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyAdditionalExposure_Employee10HoursPerWeekId",
                table: "InspectionOrderPropertyAdditionalExposure",
                column: "Employee10HoursPerWeekId",
                unique: true,
                filter: "[Employee10HoursPerWeekId] IS NOT NULL");
        }
    }
}
