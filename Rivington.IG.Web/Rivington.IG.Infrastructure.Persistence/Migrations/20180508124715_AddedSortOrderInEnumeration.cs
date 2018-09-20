using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class AddedSortOrderInEnumeration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "WindowStyle",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "WindowScreenType",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "WindowGlassType",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "WindowFramingType",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "WindowConcernDetail",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "WindowBrand",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "WildfireCredit",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "WallTrim",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "TypeOfPlumbing",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "TubAndShower",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "SurroundingAreaConcernDetail",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "State",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "Staircase",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "SmokeOnlyAlarmType",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "SmokeOnlyAlarm",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "SlopeOfSite",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "SidingConditionConcernDetail",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "SecondaryRoofCovering",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "SecondaryExteriorWallCovering",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "RoomWithCabinetry",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "RoofVenting",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "RoofType",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "RoofConcernDetail",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "QualityClassUpgrade",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "PropertyValue",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "PrimaryRoofCovering",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "PrimaryExteriorWallCovering",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "PorchDeckBalconyConstruction",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "PolicyPremiumCredit",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "PlumbingConcernDetail",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "PhotoTypeGroup",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "PhotoType",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "OutbuildingDetail",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "OtherWallCovering",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "OtherStructureConcernDetail",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "OtherRoofCovering",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "OtherDetachedStructuresDetail",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "OtherAttachmentType",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "OccupancyType",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "MitigationStatus",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "MiscellaneousExtraFeature",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "Locale",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "LightingType",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "KitchenCountertop",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "KitchenCabinet",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "KitchenBathCounter",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "KitchenBathCabinet",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "InteriorWindowCoveringType",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "InteriorWallCovering",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "InteriorDoorType",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "InspectionStatus",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "HomeShape",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "GutterType",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "FramingType",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "FoundationType",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "FlooringType",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "FloorCovering",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "FireplaceType",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "FireDepartmentStaffing",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "FireAlarmType",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "FireAlarm",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "FencingType",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "FenceConditionConcernDetail",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "ExternalFuelSourceType",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "ExteriorWindowCoveringType",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "ExteriorBuildingConcernDetail",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "Employee10HoursPerWeek",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "ElectricalConcernDetail",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "EavesType",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "DoorHardware",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "DomesticHelpType",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "DomesticHelp",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "DogTemperament",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "DeckConditionConcernDetail",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "CustomerOnSite",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "ConstructionQuality",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "ChimneyType",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "Ceiling",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "BurglarAlarmType",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "BurglarAlarm",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "BearInvasionConcernDetail",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "BathroomVanity",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "BathroomFloor",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "BathroomFixture",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "BathroomCounter",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "ArchitecturalStyle",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "ApplianceType",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "ApplianceBrand",
                nullable: false,
                defaultValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "WindowStyle");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "WindowScreenType");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "WindowGlassType");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "WindowFramingType");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "WindowConcernDetail");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "WindowBrand");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "WildfireCredit");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "WallTrim");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "TypeOfPlumbing");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "TubAndShower");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "SurroundingAreaConcernDetail");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "State");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "Staircase");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "SmokeOnlyAlarmType");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "SmokeOnlyAlarm");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "SlopeOfSite");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "SidingConditionConcernDetail");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "SecondaryRoofCovering");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "SecondaryExteriorWallCovering");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "RoomWithCabinetry");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "RoofVenting");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "RoofType");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "RoofConcernDetail");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "QualityClassUpgrade");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "PropertyValue");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "PrimaryRoofCovering");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "PrimaryExteriorWallCovering");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "PorchDeckBalconyConstruction");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "PolicyPremiumCredit");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "PlumbingConcernDetail");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "PhotoTypeGroup");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "PhotoType");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "OutbuildingDetail");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "OtherWallCovering");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "OtherStructureConcernDetail");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "OtherRoofCovering");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "OtherDetachedStructuresDetail");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "OtherAttachmentType");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "OccupancyType");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "MitigationStatus");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "MiscellaneousExtraFeature");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "Locale");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "LightingType");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "KitchenCountertop");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "KitchenCabinet");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "KitchenBathCounter");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "KitchenBathCabinet");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "InteriorWindowCoveringType");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "InteriorWallCovering");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "InteriorDoorType");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "InspectionStatus");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "HomeShape");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "GutterType");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "FramingType");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "FoundationType");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "FlooringType");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "FloorCovering");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "FireplaceType");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "FireDepartmentStaffing");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "FireAlarmType");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "FireAlarm");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "FencingType");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "FenceConditionConcernDetail");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "ExternalFuelSourceType");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "ExteriorWindowCoveringType");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "ExteriorBuildingConcernDetail");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "Employee10HoursPerWeek");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "ElectricalConcernDetail");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "EavesType");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "DoorHardware");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "DomesticHelpType");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "DomesticHelp");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "DogTemperament");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "DeckConditionConcernDetail");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "CustomerOnSite");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "ConstructionQuality");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "ChimneyType");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "Ceiling");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "BurglarAlarmType");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "BurglarAlarm");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "BearInvasionConcernDetail");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "BathroomVanity");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "BathroomFloor");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "BathroomFixture");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "BathroomCounter");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "ArchitecturalStyle");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "ApplianceType");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "ApplianceBrand");
        }
    }
}
