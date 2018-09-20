using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplianceBrand",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplianceBrand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplianceType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplianceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArchitecturalStyle",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchitecturalStyle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BathroomCounter",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BathroomCounter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BathroomFixture",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BathroomFixture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BathroomFloor",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BathroomFloor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BathroomVanity",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BathroomVanity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BearInvasionConcernDetail",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BearInvasionConcernDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BurglarAlarmType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BurglarAlarmType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ceiling",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ceiling", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChimneyType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChimneyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConstructionQuality",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstructionQuality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerOnSite",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOnSite", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeckConditionConcernDetail",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeckConditionConcernDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DogTemperament",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogTemperament", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DomesticHelpType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomesticHelpType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoorHardware",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoorHardware", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EavesType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EavesType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ElectricalConcernDetail",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricalConcernDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee10HoursPerWeek",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee10HoursPerWeek", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExteriorBuildingConcernDetail",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExteriorBuildingConcernDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExteriorWindowCoveringType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExteriorWindowCoveringType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExternalFuelSourceType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalFuelSourceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FenceConditionConcernDetail",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FenceConditionConcernDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FencingType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FencingType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FireAlarmType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireAlarmType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FireDepartmentStaffing",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireDepartmentStaffing", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FireplaceType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireplaceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FloorCovering",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloorCovering", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlooringType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlooringType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ForgotPassword",
                columns: table => new
                {
                    ForgotID = table.Column<Guid>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForgotPassword", x => x.ForgotID);
                });

            migrationBuilder.CreateTable(
                name: "FoundationType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoundationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FramingType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FramingType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GutterType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GutterType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeShape",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeShape", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InspectionStatus",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InteriorDoorType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteriorDoorType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InteriorWallCovering",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteriorWallCovering", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InteriorWindowCoveringType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteriorWindowCoveringType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KitchenBathCabinet",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitchenBathCabinet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KitchenBathCounter",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitchenBathCounter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KitchenCabinet",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitchenCabinet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KitchenCountertop",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitchenCountertop", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LightingType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LightingType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locale",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locale", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MiscellaneousExtraFeature",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiscellaneousExtraFeature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MitigationStatus",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MitigationStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OccupancyType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccupancyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OtherAttachmentType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherAttachmentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OtherDetachedStructuresDetail",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherDetachedStructuresDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OtherRoofCovering",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherRoofCovering", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OtherStructureConcernDetail",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherStructureConcernDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OtherWallCovering",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherWallCovering", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OutbuildingDetail",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutbuildingDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhotoTypeGroup",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoTypeGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlumbingConcernDetail",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlumbingConcernDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PolicyPremiumCredit",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyPremiumCredit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PorchDeckBalconyConstruction",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PorchDeckBalconyConstruction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrimaryExteriorWallCovering",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrimaryExteriorWallCovering", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrimaryRoofCovering",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrimaryRoofCovering", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyValue",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyValue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityClassUpgrade",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityClassUpgrade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoofConcernDetail",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoofConcernDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoofType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoofType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoofVenting",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoofVenting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomWithCabinetry",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomWithCabinetry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SecondaryExteriorWallCovering",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecondaryExteriorWallCovering", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SecondaryRoofCovering",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecondaryRoofCovering", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SidingConditionConcernDetail",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SidingConditionConcernDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SlopeOfSite",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlopeOfSite", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmokeOnlyAlarmType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmokeOnlyAlarmType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Staircase",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staircase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SurroundingAreaConcernDetail",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurroundingAreaConcernDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TubAndShower",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TubAndShower", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfPlumbing",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfPlumbing", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DisplayName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastModifiedDate = table.Column<DateTime>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WallTrim",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WallTrim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WildfireCredit",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WildfireCredit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WindowBrand",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WindowBrand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WindowConcernDetail",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WindowConcernDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WindowFramingType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WindowFramingType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WindowGlassType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WindowGlassType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WindowScreenType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WindowScreenType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WindowStyle",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WindowStyle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhotoType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    GroupId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotoType_PhotoTypeGroup_GroupId",
                        column: x => x.GroupId,
                        principalTable: "PhotoTypeGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaim_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    County = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    StateId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateAssigned = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    InspectorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionOrder_User_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Token",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Token", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Token_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaim_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogin_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserToken_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderNonWildfireAssessment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderNonWildfireAssessment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionOrderNonWildfireAssessment_InspectionOrder",
                        column: x => x.Id,
                        principalTable: "InspectionOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderProperty",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionOrderProperty_InspectionOrder_Id",
                        column: x => x.Id,
                        principalTable: "InspectionOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyPhoto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyPhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyPhoto_InspectionOrder",
                        column: x => x.Id,
                        principalTable: "InspectionOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderWildfireAssessment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderWildfireAssessment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionOrderWildfireAssessment_InspectionOrder",
                        column: x => x.Id,
                        principalTable: "InspectionOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Policy",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    AgencyName = table.Column<string>(nullable: true),
                    AgencyPhoneNumber = table.Column<string>(nullable: true),
                    AgentName = table.Column<string>(nullable: true),
                    AgentPhoneNumber = table.Column<string>(nullable: true),
                    CoverageA = table.Column<int>(nullable: false),
                    E2ValueReplacementCostValue = table.Column<int>(nullable: false),
                    ITVPercentage = table.Column<decimal>(nullable: false),
                    InspectionDate = table.Column<DateTime>(nullable: true),
                    InspectionStatusId = table.Column<string>(nullable: true),
                    InsuredFirstName = table.Column<string>(nullable: true),
                    InsuredLastName = table.Column<string>(nullable: true),
                    InsuredMiddleName = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    MitigationStatusId = table.Column<string>(nullable: true),
                    PolicyNumber = table.Column<string>(nullable: true),
                    PropertyValueId = table.Column<string>(nullable: true),
                    WildfireAssessmentRequired = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Policy_InspectionOrder_Id",
                        column: x => x.Id,
                        principalTable: "InspectionOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Policy_InspectionStatus_InspectionStatusId",
                        column: x => x.InspectionStatusId,
                        principalTable: "InspectionStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Policy_MitigationStatus_MitigationStatusId",
                        column: x => x.MitigationStatusId,
                        principalTable: "MitigationStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Policy_PropertyValue_PropertyValueId",
                        column: x => x.PropertyValueId,
                        principalTable: "PropertyValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderNonWildfireAssessmentMitigation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderNonWildfireAssessmentMitigation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionOrderNonWildfireAssessment_IoNwaMitigation",
                        column: x => x.Id,
                        principalTable: "InspectionOrderNonWildfireAssessment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyAdditionalExposure",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AdditionalComment = table.Column<string>(nullable: true),
                    AdditionalConcern = table.Column<bool>(nullable: false),
                    AdjacentExposure = table.Column<bool>(nullable: false),
                    AdjacentExposureComment = table.Column<string>(nullable: true),
                    BearInvasionConcern = table.Column<bool>(nullable: false),
                    BiteHistory = table.Column<bool>(nullable: false),
                    BracingBolting = table.Column<bool>(nullable: false),
                    BusinessAgricultureType = table.Column<string>(nullable: true),
                    BusinessAgricultureonPremises = table.Column<bool>(nullable: false),
                    CustomerOnSiteId = table.Column<string>(nullable: true),
                    DaycareonSite = table.Column<bool>(nullable: false),
                    Dog = table.Column<bool>(nullable: false),
                    DogBreed = table.Column<string>(nullable: true),
                    DogTemperamentId = table.Column<string>(nullable: true),
                    Employee10HoursPerWeekId = table.Column<string>(nullable: true),
                    HorsesFarmAnimalCount = table.Column<int>(nullable: false),
                    HorsesFarmAnimalType = table.Column<string>(nullable: true),
                    HorsesFarmAnimalsonPremise = table.Column<bool>(nullable: false),
                    NumberofDog = table.Column<int>(nullable: false),
                    OtherAttractiveNuisance = table.Column<bool>(nullable: false),
                    OtherAttractiveNuisanceComment = table.Column<string>(nullable: true),
                    SafetyNetting = table.Column<bool>(nullable: false),
                    SkateboardRamp = table.Column<bool>(nullable: false),
                    Trampoline = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyAdditionalExposure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyAdditionalExposure_CustomerOnSite",
                        column: x => x.CustomerOnSiteId,
                        principalTable: "CustomerOnSite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyAdditionalExposure_DogTemperament",
                        column: x => x.DogTemperamentId,
                        principalTable: "DogTemperament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyAdditionalExposure_Employee10HoursPerWeek",
                        column: x => x.Employee10HoursPerWeekId,
                        principalTable: "Employee10HoursPerWeek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionOrderProperty_InspectionOrderPropertyAdditionalExposure",
                        column: x => x.Id,
                        principalTable: "InspectionOrderProperty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyBuildingConcern",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyBuildingConcern", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionOrderProperty_InspectionOrderPropertyBuildingConcern",
                        column: x => x.Id,
                        principalTable: "InspectionOrderProperty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyDetachedStructure",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OtherDetachedStructure = table.Column<bool>(nullable: false),
                    Outbuilding = table.Column<bool>(nullable: false),
                    OutbuildingConcernOrComment = table.Column<string>(nullable: true),
                    OutbuildingTypeOrConstruction = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyDetachedStructure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionOrderProperty_InspectionOrderPropertyDetachedStructure",
                        column: x => x.Id,
                        principalTable: "InspectionOrderProperty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyGeneral",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BurglarAlarm = table.Column<bool>(nullable: false),
                    BurglarAlarmTypeId = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ContractorName = table.Column<string>(nullable: true),
                    ContractorPhone = table.Column<string>(nullable: true),
                    DomesticHelp = table.Column<bool>(nullable: false),
                    EstimatedSquareFootage = table.Column<int>(nullable: false),
                    FireAlarm = table.Column<bool>(nullable: false),
                    FireAlarmTypeId = table.Column<string>(nullable: true),
                    LastServiceDate = table.Column<string>(nullable: true),
                    MajorSystemAge = table.Column<int>(nullable: false),
                    MajorSystemDescription = table.Column<string>(nullable: true),
                    OccupancyTypeId = table.Column<string>(nullable: true),
                    Pre1970Updates = table.Column<bool>(nullable: false),
                    Pre1970UpdatesDescription = table.Column<string>(nullable: true),
                    PriorLoss = table.Column<bool>(nullable: false),
                    PriorLossDescription = table.Column<string>(nullable: true),
                    ProblemResolved = table.Column<bool>(nullable: false),
                    RecentlyRenovated = table.Column<bool>(nullable: false),
                    RoofAge = table.Column<int>(nullable: false),
                    SepticTank = table.Column<bool>(nullable: false),
                    SmokeOnlyAlarm = table.Column<bool>(nullable: false),
                    SmokeOnlyAlarmTypeId = table.Column<string>(nullable: true),
                    StateId = table.Column<string>(nullable: true),
                    StreetAddress1 = table.Column<string>(nullable: true),
                    StreetAddress2 = table.Column<string>(nullable: true),
                    WaterHeaterAge = table.Column<int>(nullable: false),
                    WoodStoveLocation = table.Column<string>(nullable: true),
                    WoodStoveOrWoodBurningFirePlace = table.Column<bool>(nullable: false),
                    WoodStoveUsage = table.Column<string>(nullable: true),
                    YearBuilt = table.Column<int>(nullable: false),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyGeneral", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyGeneral_BurglarAlarmType",
                        column: x => x.BurglarAlarmTypeId,
                        principalTable: "BurglarAlarmType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyGeneral_FireAlarmType",
                        column: x => x.FireAlarmTypeId,
                        principalTable: "FireAlarmType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionOrderProperty_InspectionOrderPropertyGeneral",
                        column: x => x.Id,
                        principalTable: "InspectionOrderProperty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyGeneral_OccupancyType",
                        column: x => x.OccupancyTypeId,
                        principalTable: "OccupancyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyGeneral_SmokeOnlyAlarmType",
                        column: x => x.SmokeOnlyAlarmTypeId,
                        principalTable: "SmokeOnlyAlarmType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyGeneral_State",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyHighValueBath",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NumberofFullBath = table.Column<bool>(nullable: false),
                    NumberofHalfBath = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyHighValueBath", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionOrderProperty_InspectionOrderPropertyHighValueBath",
                        column: x => x.Id,
                        principalTable: "InspectionOrderProperty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyHighValueFloorToCeiling",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AverageWallHeight = table.Column<string>(nullable: true),
                    ChimneyTypeId = table.Column<string>(nullable: true),
                    NumberofChimney = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyHighValueFloorToCeiling", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueFloorToCeiling_ChimneyType",
                        column: x => x.ChimneyTypeId,
                        principalTable: "ChimneyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionOrderProperty_InspectionOrderPropertyHighValueFloorToCeiling",
                        column: x => x.Id,
                        principalTable: "InspectionOrderProperty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyHighValueInteriorFeature",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NumberofFireplace = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyHighValueInteriorFeature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionOrderProperty_InspectionOrderPropertyHighValueInteriorFeature",
                        column: x => x.Id,
                        principalTable: "InspectionOrderProperty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyHighValueKitchen",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ApplianceBrandId = table.Column<string>(nullable: true),
                    IslandCabinetMaterial = table.Column<string>(nullable: true),
                    IslandCountertopMaterial = table.Column<string>(nullable: true),
                    KitchenBacksplashMaterial = table.Column<string>(nullable: true),
                    KitchenCabinetId = table.Column<string>(nullable: true),
                    KitchenCountertopId = table.Column<string>(nullable: true),
                    KitchenIsland = table.Column<bool>(nullable: false),
                    NumberofApplicance = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyHighValueKitchen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueKitchen_ApplianceBrand",
                        column: x => x.ApplianceBrandId,
                        principalTable: "ApplianceBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionOrderProperty_InspectionOrderPropertyHighValueKitchen",
                        column: x => x.Id,
                        principalTable: "InspectionOrderProperty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueKitchen_KitchenCabinet",
                        column: x => x.KitchenCabinetId,
                        principalTable: "KitchenCabinet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueKitchen_KitchenCountertop",
                        column: x => x.KitchenCountertopId,
                        principalTable: "KitchenCountertop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyHomeDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ArchitecturalStyleId = table.Column<string>(nullable: true),
                    ConstructionQualityId = table.Column<string>(nullable: true),
                    FoundationTypeId = table.Column<string>(nullable: true),
                    FramingTypeId = table.Column<string>(nullable: true),
                    HomeShapeId = table.Column<string>(nullable: true),
                    NumberofStories = table.Column<int>(nullable: false),
                    PrimaryExteriorWallCoveringId = table.Column<string>(nullable: true),
                    PrimaryRoofCoveringId = table.Column<string>(nullable: true),
                    RoofTypeId = table.Column<string>(nullable: true),
                    SecondaryExteriorWallCoveringId = table.Column<string>(nullable: true),
                    SecondaryRoofCoveringId = table.Column<string>(nullable: true),
                    SlopeOfSiteId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyHomeDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHomeDetail_ArchitecturalStyle",
                        column: x => x.ArchitecturalStyleId,
                        principalTable: "ArchitecturalStyle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHomeDetail_ConstructionQuality",
                        column: x => x.ConstructionQualityId,
                        principalTable: "ConstructionQuality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHomeDetail_FoundationType",
                        column: x => x.FoundationTypeId,
                        principalTable: "FoundationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHomeDetail_FramingType",
                        column: x => x.FramingTypeId,
                        principalTable: "FramingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHomeDetail_HomeShape",
                        column: x => x.HomeShapeId,
                        principalTable: "HomeShape",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionOrderProperty_InspectionOrderPropertyHomeDetail",
                        column: x => x.Id,
                        principalTable: "InspectionOrderProperty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHomeDetail_PrimaryExteriorWallCovering",
                        column: x => x.PrimaryExteriorWallCoveringId,
                        principalTable: "PrimaryExteriorWallCovering",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHomeDetail_PrimaryRoofCovering",
                        column: x => x.PrimaryRoofCoveringId,
                        principalTable: "PrimaryRoofCovering",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHomeDetail_RoofType",
                        column: x => x.RoofTypeId,
                        principalTable: "RoofType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHomeDetail_SecondaryExteriorWallCovering",
                        column: x => x.SecondaryExteriorWallCoveringId,
                        principalTable: "SecondaryExteriorWallCovering",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHomeDetail_SecondaryRoofCovering",
                        column: x => x.SecondaryRoofCoveringId,
                        principalTable: "SecondaryRoofCovering",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHomeDetail_SlopeOfSite",
                        column: x => x.SlopeOfSiteId,
                        principalTable: "SlopeOfSite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyInteriorDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ElectricalServiceAmperage = table.Column<string>(nullable: true),
                    InteriorDetailComment = table.Column<bool>(nullable: false),
                    LaundryLocation = table.Column<string>(nullable: true),
                    WaterHeaterLocation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyInteriorDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionOrderProperty_InspectionOrderPropertyInteriorDetail",
                        column: x => x.Id,
                        principalTable: "InspectionOrderProperty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyPhotoPhotos",
                columns: table => new
                {
                    InspectionOrderPropertyPhotoId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Photo = table.Column<byte[]>(nullable: true),
                    PhotoTypeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyPhotoPhotos", x => new { x.InspectionOrderPropertyPhotoId, x.Id });
                    table.UniqueConstraint("AK_InspectionOrderPropertyPhotoPhotos_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyPhotoPhotos_InspectionOrderPropertyPhoto",
                        column: x => x.InspectionOrderPropertyPhotoId,
                        principalTable: "InspectionOrderPropertyPhoto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyPhotoPhotos_PhotoType",
                        column: x => x.PhotoTypeId,
                        principalTable: "PhotoType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderWildfireAssessmentAccessAndFireProtection",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AddressHardtoRead = table.Column<bool>(nullable: false),
                    AddressReadabilityComment = table.Column<string>(nullable: true),
                    AlternateWaterSourceIfNoHydrant = table.Column<string>(nullable: true),
                    BridgeConcern = table.Column<bool>(nullable: false),
                    BridgeConcernComment = table.Column<string>(nullable: true),
                    FireDepartmentDistancetoHome = table.Column<string>(nullable: true),
                    FireDepartmentStaffingId = table.Column<string>(nullable: true),
                    FireDepartmentTravelTimetoHome = table.Column<int>(nullable: false),
                    NearestFireHydrant = table.Column<string>(nullable: true),
                    RespondingFireDepartment = table.Column<string>(nullable: true),
                    TimelyResponseConcern = table.Column<bool>(nullable: false),
                    TimelyResponseConcernComment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderWildfireAssessmentAccessAndFireProtection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IoWaAccessAndFireProtection_FireDepartmentStaffing",
                        column: x => x.FireDepartmentStaffingId,
                        principalTable: "FireDepartmentStaffing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionOrderWildfireAssessment_IoWaAccessAndFireProtection",
                        column: x => x.Id,
                        principalTable: "InspectionOrderWildfireAssessment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderWildfireAssessmentDeckAndBalcony",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AttachedPorcheDeckorBalcony = table.Column<bool>(nullable: false),
                    AttachedStructuresComment = table.Column<string>(nullable: true),
                    CombustibleMaterialsONDeckBalconyPorch = table.Column<bool>(nullable: false),
                    CombustibleMaterialsUNDERDeckBalconyPorch = table.Column<bool>(nullable: false),
                    CombustiblesONDeckBalconyPorchDescription = table.Column<string>(nullable: true),
                    CombustiblesUNDERDeckBalconyPorchDescription = table.Column<string>(nullable: true),
                    CoveringMaterial = table.Column<string>(nullable: true),
                    DeckConditionConcern = table.Column<bool>(nullable: false),
                    PorchDeckBalconyCovered = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderWildfireAssessmentDeckAndBalcony", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionOrderWildfireAssessment_IoWaDeckAndBalcony",
                        column: x => x.Id,
                        principalTable: "InspectionOrderWildfireAssessment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderWildfireAssessmentExteriorSiding",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NonCombustibleSiding = table.Column<bool>(nullable: false),
                    PrimaryExteriorWallCoveringId = table.Column<string>(nullable: true),
                    SecondaryExteriorWallCoveringId = table.Column<string>(nullable: true),
                    SidingConditionComment = table.Column<string>(nullable: true),
                    SidingConditionConcern = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderWildfireAssessmentExteriorSiding", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionOrderWildfireAssessment_IoWaExteriorSiding",
                        column: x => x.Id,
                        principalTable: "InspectionOrderWildfireAssessment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IoWaExteriorSiding_PrimaryExteriorWallCovering",
                        column: x => x.PrimaryExteriorWallCoveringId,
                        principalTable: "PrimaryExteriorWallCovering",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IoWaExteriorSiding_SecondaryExteriorWallCovering",
                        column: x => x.SecondaryExteriorWallCoveringId,
                        principalTable: "SecondaryExteriorWallCovering",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderWildfireAssessmentExternalFuelSource",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExternalFuelSource = table.Column<bool>(nullable: false),
                    ExternalFuelSourceDistanceFromHome = table.Column<int>(nullable: false),
                    FirePeventiveMeasure = table.Column<string>(nullable: true),
                    WoodStorageLocation = table.Column<string>(nullable: true),
                    WoodStoveOrFireplace = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderWildfireAssessmentExternalFuelSource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionOrderWildfireAssessment_IoWaExternalFuelSource",
                        column: x => x.Id,
                        principalTable: "InspectionOrderWildfireAssessment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderWildfireAssessmentFencingAndOtherAttachment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FenceComment = table.Column<string>(nullable: true),
                    FenceConditionConcern = table.Column<bool>(nullable: false),
                    FencingWithin30Feet = table.Column<bool>(nullable: false),
                    OtherAttachment = table.Column<bool>(nullable: false),
                    OtherDetachedStructure = table.Column<bool>(nullable: false),
                    Outbuilding = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderWildfireAssessmentFencingAndOtherAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionOrderWildfireAssessment_IoWaFencingAndOtherAttachment",
                        column: x => x.Id,
                        principalTable: "InspectionOrderWildfireAssessment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderWildfireAssessmentFoundationToFrame",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ElevatedwithCombustibleMaterial = table.Column<bool>(nullable: false),
                    ElevatedwithCombustibleMaterialsComment = table.Column<string>(nullable: true),
                    FoundationComment = table.Column<string>(nullable: true),
                    FoundationTypeId = table.Column<string>(nullable: true),
                    FramingTypeId = table.Column<string>(nullable: true),
                    OpeningsEmberEntry = table.Column<bool>(nullable: false),
                    OpeningsEmberEntryComment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderWildfireAssessmentFoundationToFrame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IoWaFoundationToFrame_FoundationType",
                        column: x => x.FoundationTypeId,
                        principalTable: "FoundationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IoWaFoundationToFrame_FramingType",
                        column: x => x.FramingTypeId,
                        principalTable: "FramingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionOrderWildfireAssessment_IoWaFoundationToFrame",
                        column: x => x.Id,
                        principalTable: "InspectionOrderWildfireAssessment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderWildfireAssessmentMitigation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderWildfireAssessmentMitigation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionOrderWildfireAssessment_IoWaMitigation",
                        column: x => x.Id,
                        principalTable: "InspectionOrderWildfireAssessment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderWildfireAssessmentRoof",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CombustibleMaterialsOnRoof = table.Column<bool>(nullable: false),
                    CombustibleMaterialsonRoofComment = table.Column<string>(nullable: true),
                    EavesAllowEmberEntry = table.Column<bool>(nullable: false),
                    EavesComment = table.Column<string>(nullable: true),
                    EavesTypeId = table.Column<string>(nullable: true),
                    Gutter = table.Column<bool>(nullable: false),
                    GutterComment = table.Column<string>(nullable: true),
                    PrimaryRoofCoveringId = table.Column<string>(nullable: true),
                    RoofTypeId = table.Column<string>(nullable: true),
                    SecondaryRoofCoveringId = table.Column<string>(nullable: true),
                    VentingMeshCoveringSizeComment = table.Column<string>(nullable: true),
                    VentingOpeningAllowEmberEntry = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderWildfireAssessmentRoof", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IoWaRoof_EavesType",
                        column: x => x.EavesTypeId,
                        principalTable: "EavesType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InspectionOrderWildfireAssessment_IoWaRoof",
                        column: x => x.Id,
                        principalTable: "InspectionOrderWildfireAssessment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IoWaRoof_PrimaryRoofCovering",
                        column: x => x.PrimaryRoofCoveringId,
                        principalTable: "PrimaryRoofCovering",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IoWaRoof_RoofType",
                        column: x => x.RoofTypeId,
                        principalTable: "RoofType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IoWaRoof_SecondaryRoofCovering",
                        column: x => x.SecondaryRoofCoveringId,
                        principalTable: "SecondaryRoofCovering",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderWildfireAssessmentSurrounding",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AdditionalStructuresContributor = table.Column<bool>(nullable: false),
                    AdditionalStructuresContributorComment = table.Column<string>(nullable: true),
                    Combustible05Feet = table.Column<bool>(nullable: false),
                    Combustible05FeetComment = table.Column<string>(nullable: true),
                    Combustible30100Feet = table.Column<bool>(nullable: false),
                    Combustible30100FeetComment = table.Column<string>(nullable: true),
                    Combustible530Feet = table.Column<bool>(nullable: false),
                    Combustible530FeetComment = table.Column<string>(nullable: true),
                    NeighboringResidence = table.Column<bool>(nullable: false),
                    NeighboringResidenceComment = table.Column<string>(nullable: true),
                    TopographicalEnvironmentalContributor = table.Column<bool>(nullable: false),
                    TopographicalEnvironmentalContributorComment = table.Column<string>(nullable: true),
                    VolatileVegetationBeyond100Feet = table.Column<bool>(nullable: false),
                    VolatileVegetationBeyond100FeetComment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderWildfireAssessmentSurrounding", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionOrderWildfireAssessment_IoWaSurrounding",
                        column: x => x.Id,
                        principalTable: "InspectionOrderWildfireAssessment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderWildfireAssessmentWindow",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExteriorWindowCovering = table.Column<bool>(nullable: false),
                    InteriorWindowCovering = table.Column<bool>(nullable: false),
                    WindowConcern = table.Column<bool>(nullable: false),
                    WindowNote = table.Column<string>(nullable: true),
                    WindowScreen = table.Column<bool>(nullable: false),
                    WindowSusceptibletoFlame = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderWildfireAssessmentWindow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionOrderWildfireAssessment_IoWaWindow",
                        column: x => x.Id,
                        principalTable: "InspectionOrderWildfireAssessment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderNonWildfireAssessmentMitigationRecommendations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    InspectionOrderNonWildfireAssessmentMitigationId = table.Column<Guid>(nullable: true),
                    Photo = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderNonWildfireAssessmentMitigationRecommendations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IoNwaMitigationRecommendations_InspectionOrderNonWildfireAssessmentMitigation",
                        column: x => x.InspectionOrderNonWildfireAssessmentMitigationId,
                        principalTable: "InspectionOrderNonWildfireAssessmentMitigation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderNonWildfireAssessmentMitigationRequirements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    InspectionOrderNonWildfireAssessmentMitigationId = table.Column<Guid>(nullable: true),
                    Photo = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderNonWildfireAssessmentMitigationRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IoNwaMitigationRequirements_InspectionOrderNonWildfireAssessmentMitigation",
                        column: x => x.InspectionOrderNonWildfireAssessmentMitigationId,
                        principalTable: "InspectionOrderNonWildfireAssessmentMitigation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyAdditionalExposureBearInvasionConcernDetails",
                columns: table => new
                {
                    InspectionOrderPropertyAdditionalExposureId = table.Column<Guid>(nullable: false),
                    BearInvasionConcernDetailId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyAdditionalExposureBearInvasionConcernDetails", x => new { x.InspectionOrderPropertyAdditionalExposureId, x.BearInvasionConcernDetailId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyAdditionalExposureBearInvasionConcernDetails_BearInvasionConcernDetail",
                        column: x => x.BearInvasionConcernDetailId,
                        principalTable: "BearInvasionConcernDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyAdditionalExposureBearInvasionConcernDetails_InspectionOrderPropertyAdditionalExposure",
                        column: x => x.InspectionOrderPropertyAdditionalExposureId,
                        principalTable: "InspectionOrderPropertyAdditionalExposure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyBuildingConcernElectricalConcernDetails",
                columns: table => new
                {
                    InspectionOrderPropertyBuildingConcernId = table.Column<Guid>(nullable: false),
                    ElectricalConcernDetailId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyBuildingConcernElectricalConcernDetails", x => new { x.InspectionOrderPropertyBuildingConcernId, x.ElectricalConcernDetailId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyBuildingConcernElectricalConcernDetails_ElectricalConcernDetail",
                        column: x => x.ElectricalConcernDetailId,
                        principalTable: "ElectricalConcernDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyBuildingConcernElectricalConcernDetails_InspectionOrderPropertyBuildingConcern",
                        column: x => x.InspectionOrderPropertyBuildingConcernId,
                        principalTable: "InspectionOrderPropertyBuildingConcern",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyBuildingConcernExteriorBuildingConcernDetails",
                columns: table => new
                {
                    InspectionOrderPropertyBuildingConcernId = table.Column<Guid>(nullable: false),
                    ExteriorBuildingConcernDetailId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyBuildingConcernExteriorBuildingConcernDetails", x => new { x.InspectionOrderPropertyBuildingConcernId, x.ExteriorBuildingConcernDetailId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyBuildingConcernExteriorBuildingConcernDetails_ExteriorBuildingConcernDetail",
                        column: x => x.ExteriorBuildingConcernDetailId,
                        principalTable: "ExteriorBuildingConcernDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyBuildingConcernExteriorBuildingConcernDetails_InspectionOrderPropertyBuildingConcern",
                        column: x => x.InspectionOrderPropertyBuildingConcernId,
                        principalTable: "InspectionOrderPropertyBuildingConcern",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyBuildingConcernOtherStructureConcernDetails",
                columns: table => new
                {
                    InspectionOrderPropertyBuildingConcernId = table.Column<Guid>(nullable: false),
                    OtherStructureConcernDetailId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyBuildingConcernOtherStructureConcernDetails", x => new { x.InspectionOrderPropertyBuildingConcernId, x.OtherStructureConcernDetailId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyBuildingConcernOtherStructureConcernDetails_InspectionOrderPropertyBuildingConcern",
                        column: x => x.InspectionOrderPropertyBuildingConcernId,
                        principalTable: "InspectionOrderPropertyBuildingConcern",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyBuildingConcernOtherStructureConcernDetails_OtherStructureConcernDetail",
                        column: x => x.OtherStructureConcernDetailId,
                        principalTable: "OtherStructureConcernDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyBuildingConcernPlumbingConcernDetails",
                columns: table => new
                {
                    InspectionOrderPropertyBuildingConcernId = table.Column<Guid>(nullable: false),
                    PlumbingConcernDetailId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyBuildingConcernPlumbingConcernDetails", x => new { x.InspectionOrderPropertyBuildingConcernId, x.PlumbingConcernDetailId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyBuildingConcernPlumbingConcernDetails_InspectionOrderPropertyBuildingConcern",
                        column: x => x.InspectionOrderPropertyBuildingConcernId,
                        principalTable: "InspectionOrderPropertyBuildingConcern",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyBuildingConcernPlumbingConcernDetails_PlumbingConcernDetail",
                        column: x => x.PlumbingConcernDetailId,
                        principalTable: "PlumbingConcernDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyBuildingConcernRoofConcernDetails",
                columns: table => new
                {
                    InspectionOrderPropertyBuildingConcernId = table.Column<Guid>(nullable: false),
                    RoofConcernDetailId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyBuildingConcernRoofConcernDetails", x => new { x.InspectionOrderPropertyBuildingConcernId, x.RoofConcernDetailId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyBuildingConcernRoofConcernDetails_InspectionOrderPropertyBuildingConcern",
                        column: x => x.InspectionOrderPropertyBuildingConcernId,
                        principalTable: "InspectionOrderPropertyBuildingConcern",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyBuildingConcernRoofConcernDetails_RoofConcernDetail",
                        column: x => x.RoofConcernDetailId,
                        principalTable: "RoofConcernDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyBuildingConcernSurroundingAreaConcernDetails",
                columns: table => new
                {
                    InspectionOrderPropertyBuildingConcernId = table.Column<Guid>(nullable: false),
                    SurroundingAreaConcernDetailId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyBuildingConcernSurroundingAreaConcernDetails", x => new { x.InspectionOrderPropertyBuildingConcernId, x.SurroundingAreaConcernDetailId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyBuildingConcernSurroundingAreaConcernDetails_InspectionOrderPropertyBuildingConcern",
                        column: x => x.InspectionOrderPropertyBuildingConcernId,
                        principalTable: "InspectionOrderPropertyBuildingConcern",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyBuildingConcernSurroundingAreaConcernDetails_SurroundingAreaConcernDetail",
                        column: x => x.SurroundingAreaConcernDetailId,
                        principalTable: "SurroundingAreaConcernDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyDetachedStructureOtherDetachedStructuresDetails",
                columns: table => new
                {
                    InspectionOrderPropertyDetachedStructureId = table.Column<Guid>(nullable: false),
                    OtherDetachedStructuresDetailId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyDetachedStructureOtherDetachedStructuresDetails", x => new { x.InspectionOrderPropertyDetachedStructureId, x.OtherDetachedStructuresDetailId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyDetachedStructureOtherDetachedStructuresDetails_InspectionOrderPropertyDetachedStructure",
                        column: x => x.InspectionOrderPropertyDetachedStructureId,
                        principalTable: "InspectionOrderPropertyDetachedStructure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyDetachedStructureOtherDetachedStructuresDetails_OtherDetachedStructuresDetail",
                        column: x => x.OtherDetachedStructuresDetailId,
                        principalTable: "OtherDetachedStructuresDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyDetachedStructureOutbuildingDetails",
                columns: table => new
                {
                    InspectionOrderPropertyDetachedStructureId = table.Column<Guid>(nullable: false),
                    OutbuildingDetailId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyDetachedStructureOutbuildingDetails", x => new { x.InspectionOrderPropertyDetachedStructureId, x.OutbuildingDetailId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyDetachedStructureOutbuildingDetails_InspectionOrderPropertyDetachedStructure",
                        column: x => x.InspectionOrderPropertyDetachedStructureId,
                        principalTable: "InspectionOrderPropertyDetachedStructure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyDetachedStructureOutbuildingDetails_OutbuildingDetail",
                        column: x => x.OutbuildingDetailId,
                        principalTable: "OutbuildingDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyGeneralDomesticHelpTypes",
                columns: table => new
                {
                    InspectionOrderPropertyGeneralId = table.Column<Guid>(nullable: false),
                    DomesticHelpTypeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyGeneralDomesticHelpTypes", x => new { x.InspectionOrderPropertyGeneralId, x.DomesticHelpTypeId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyGeneralDomesticHelpTypes_DomesticHelpType",
                        column: x => x.DomesticHelpTypeId,
                        principalTable: "DomesticHelpType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyGeneralDomesticHelpTypes_InspectionOrderPropertyGeneral",
                        column: x => x.InspectionOrderPropertyGeneralId,
                        principalTable: "InspectionOrderPropertyGeneral",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyGeneralPolicyPremiumCredits",
                columns: table => new
                {
                    InspectionOrderPropertyGeneralId = table.Column<Guid>(nullable: false),
                    PolicyPremiumCreditId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyGeneralPolicyPremiumCredits", x => new { x.InspectionOrderPropertyGeneralId, x.PolicyPremiumCreditId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyGeneralPolicyPremiumCredits_InspectionOrderPropertyGeneral",
                        column: x => x.InspectionOrderPropertyGeneralId,
                        principalTable: "InspectionOrderPropertyGeneral",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyGeneralPolicyPremiumCredits_PolicyPremiumCredit",
                        column: x => x.PolicyPremiumCreditId,
                        principalTable: "PolicyPremiumCredit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyGeneralWildfireCredits",
                columns: table => new
                {
                    InspectionOrderPropertyGeneralId = table.Column<Guid>(nullable: false),
                    WildfireCreditId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyGeneralWildfireCredits", x => new { x.InspectionOrderPropertyGeneralId, x.WildfireCreditId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyGeneralWildfireCredits_InspectionOrderPropertyGeneral",
                        column: x => x.InspectionOrderPropertyGeneralId,
                        principalTable: "InspectionOrderPropertyGeneral",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyGeneralWildfireCredits_WildfireCredit",
                        column: x => x.WildfireCreditId,
                        principalTable: "WildfireCredit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyHighValueBathBathroomCounters",
                columns: table => new
                {
                    InspectionOrderPropertyHighValueBathId = table.Column<Guid>(nullable: false),
                    BathroomCounterId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyHighValueBathBathroomCounters", x => new { x.InspectionOrderPropertyHighValueBathId, x.BathroomCounterId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueBathBathroomCounters_BathroomCounter",
                        column: x => x.BathroomCounterId,
                        principalTable: "BathroomCounter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueBathBathroomCounters_InspectionOrderPropertyHighValueBath",
                        column: x => x.InspectionOrderPropertyHighValueBathId,
                        principalTable: "InspectionOrderPropertyHighValueBath",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyHighValueBathBathroomFixtures",
                columns: table => new
                {
                    InspectionOrderPropertyHighValueBathId = table.Column<Guid>(nullable: false),
                    BathroomFixtureId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyHighValueBathBathroomFixtures", x => new { x.InspectionOrderPropertyHighValueBathId, x.BathroomFixtureId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueBathBathroomFixtures_BathroomFixture",
                        column: x => x.BathroomFixtureId,
                        principalTable: "BathroomFixture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueBathBathroomFixtures_InspectionOrderPropertyHighValueBath",
                        column: x => x.InspectionOrderPropertyHighValueBathId,
                        principalTable: "InspectionOrderPropertyHighValueBath",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyHighValueBathBathroomFloors",
                columns: table => new
                {
                    InspectionOrderPropertyHighValueBathId = table.Column<Guid>(nullable: false),
                    BathroomFloorId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyHighValueBathBathroomFloors", x => new { x.InspectionOrderPropertyHighValueBathId, x.BathroomFloorId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueBathBathroomFloors_BathroomFloor",
                        column: x => x.BathroomFloorId,
                        principalTable: "BathroomFloor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueBathBathroomFloors_InspectionOrderPropertyHighValueBath",
                        column: x => x.InspectionOrderPropertyHighValueBathId,
                        principalTable: "InspectionOrderPropertyHighValueBath",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyHighValueBathBathroomVanities",
                columns: table => new
                {
                    InspectionOrderPropertyHighValueBathId = table.Column<Guid>(nullable: false),
                    BathroomVanityId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyHighValueBathBathroomVanities", x => new { x.InspectionOrderPropertyHighValueBathId, x.BathroomVanityId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueBathBathroomVanities_BathroomVanity",
                        column: x => x.BathroomVanityId,
                        principalTable: "BathroomVanity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueBathBathroomVanities_InspectionOrderPropertyHighValueBath",
                        column: x => x.InspectionOrderPropertyHighValueBathId,
                        principalTable: "InspectionOrderPropertyHighValueBath",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyHighValueBathTubsAndShowers",
                columns: table => new
                {
                    InspectionOrderPropertyHighValueBathId = table.Column<Guid>(nullable: false),
                    TubAndShowerId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyHighValueBathTubsAndShowers", x => new { x.InspectionOrderPropertyHighValueBathId, x.TubAndShowerId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueBathTubsAndShowers_InspectionOrderPropertyHighValueBath",
                        column: x => x.InspectionOrderPropertyHighValueBathId,
                        principalTable: "InspectionOrderPropertyHighValueBath",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueBathTubsAndShowers_TubAndShower",
                        column: x => x.TubAndShowerId,
                        principalTable: "TubAndShower",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyHighValueFloorToCeilingCeilings",
                columns: table => new
                {
                    InspectionOrderPropertyHighValueFloorToCeilingId = table.Column<Guid>(nullable: false),
                    CeilingId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyHighValueFloorToCeilingCeilings", x => new { x.InspectionOrderPropertyHighValueFloorToCeilingId, x.CeilingId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueFloorToCeilingCeilings_Ceiling",
                        column: x => x.CeilingId,
                        principalTable: "Ceiling",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueFloorToCeilingCeilings_InspectionOrderPropertyHighValueFloorToCeiling",
                        column: x => x.InspectionOrderPropertyHighValueFloorToCeilingId,
                        principalTable: "InspectionOrderPropertyHighValueFloorToCeiling",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyHighValueFloorToCeilingFloorCoverings",
                columns: table => new
                {
                    InspectionOrderPropertyHighValueFloorToCeilingId = table.Column<Guid>(nullable: false),
                    FloorCoveringId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyHighValueFloorToCeilingFloorCoverings", x => new { x.InspectionOrderPropertyHighValueFloorToCeilingId, x.FloorCoveringId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueFloorToCeilingFloorCoverings_FloorCovering",
                        column: x => x.FloorCoveringId,
                        principalTable: "FloorCovering",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueFloorToCeilingFloorCoverings_InspectionOrderPropertyHighValueFloorToCeiling",
                        column: x => x.InspectionOrderPropertyHighValueFloorToCeilingId,
                        principalTable: "InspectionOrderPropertyHighValueFloorToCeiling",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyHighValueFloorToCeilingInteriorWallCoverings",
                columns: table => new
                {
                    InspectionOrderPropertyHighValueFloorToCeilingId = table.Column<Guid>(nullable: false),
                    InteriorWallCoveringId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyHighValueFloorToCeilingInteriorWallCoverings", x => new { x.InspectionOrderPropertyHighValueFloorToCeilingId, x.InteriorWallCoveringId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueFloorToCeilingInteriorWallCoverings_InspectionOrderPropertyHighValueFloorToCeiling",
                        column: x => x.InspectionOrderPropertyHighValueFloorToCeilingId,
                        principalTable: "InspectionOrderPropertyHighValueFloorToCeiling",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueFloorToCeilingInteriorWallCoverings_InteriorWallCovering",
                        column: x => x.InteriorWallCoveringId,
                        principalTable: "InteriorWallCovering",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyHighValueFloorToCeilingWallTrims",
                columns: table => new
                {
                    InspectionOrderPropertyHighValueFloorToCeilingId = table.Column<Guid>(nullable: false),
                    WallTrimId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyHighValueFloorToCeilingWallTrims", x => new { x.InspectionOrderPropertyHighValueFloorToCeilingId, x.WallTrimId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueFloorToCeilingWallTrims_InspectionOrderPropertyHighValueFloorToCeiling",
                        column: x => x.InspectionOrderPropertyHighValueFloorToCeilingId,
                        principalTable: "InspectionOrderPropertyHighValueFloorToCeiling",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueFloorToCeilingWallTrims_WallTrim",
                        column: x => x.WallTrimId,
                        principalTable: "WallTrim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyHighValueFloorToCeilingWindowBrands",
                columns: table => new
                {
                    InspectionOrderPropertyHighValueFloorToCeilingId = table.Column<Guid>(nullable: false),
                    WindowBrandId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyHighValueFloorToCeilingWindowBrands", x => new { x.InspectionOrderPropertyHighValueFloorToCeilingId, x.WindowBrandId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueFloorToCeilingWindowBrands_InspectionOrderPropertyHighValueFloorToCeiling",
                        column: x => x.InspectionOrderPropertyHighValueFloorToCeilingId,
                        principalTable: "InspectionOrderPropertyHighValueFloorToCeiling",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueFloorToCeilingWindowBrands_WindowBrand",
                        column: x => x.WindowBrandId,
                        principalTable: "WindowBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyHighValueFloorToCeilingWindowStyles",
                columns: table => new
                {
                    InspectionOrderPropertyHighValueFloorToCeilingId = table.Column<Guid>(nullable: false),
                    WindowStyleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyHighValueFloorToCeilingWindowStyles", x => new { x.InspectionOrderPropertyHighValueFloorToCeilingId, x.WindowStyleId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueFloorToCeilingWindowStyles_InspectionOrderPropertyHighValueFloorToCeiling",
                        column: x => x.InspectionOrderPropertyHighValueFloorToCeilingId,
                        principalTable: "InspectionOrderPropertyHighValueFloorToCeiling",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueFloorToCeilingWindowStyles_WindowStyle",
                        column: x => x.WindowStyleId,
                        principalTable: "WindowStyle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyHighValueInteriorFeatureDoorHardwares",
                columns: table => new
                {
                    InspectionOrderPropertyHighValueInteriorFeatureId = table.Column<Guid>(nullable: false),
                    DoorHardwareId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyHighValueInteriorFeatureDoorHardwares", x => new { x.InspectionOrderPropertyHighValueInteriorFeatureId, x.DoorHardwareId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueInteriorFeatureDoorHardwares_DoorHardware",
                        column: x => x.DoorHardwareId,
                        principalTable: "DoorHardware",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueInteriorFeatureDoorHardwares_InspectionOrderPropertyHighValueInteriorFeature",
                        column: x => x.InspectionOrderPropertyHighValueInteriorFeatureId,
                        principalTable: "InspectionOrderPropertyHighValueInteriorFeature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyHighValueInteriorFeatureFireplaceTypes",
                columns: table => new
                {
                    InspectionOrderPropertyHighValueInteriorFeatureId = table.Column<Guid>(nullable: false),
                    FireplaceTypeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyHighValueInteriorFeatureFireplaceTypes", x => new { x.InspectionOrderPropertyHighValueInteriorFeatureId, x.FireplaceTypeId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueInteriorFeatureFireplaceTypes_FireplaceType",
                        column: x => x.FireplaceTypeId,
                        principalTable: "FireplaceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueInteriorFeatureFireplaceTypes_InspectionOrderPropertyHighValueInteriorFeature",
                        column: x => x.InspectionOrderPropertyHighValueInteriorFeatureId,
                        principalTable: "InspectionOrderPropertyHighValueInteriorFeature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyHighValueInteriorFeatureInteriorDoorTypes",
                columns: table => new
                {
                    InspectionOrderPropertyHighValueInteriorFeatureId = table.Column<Guid>(nullable: false),
                    DomesticHelpTypeIdId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyHighValueInteriorFeatureInteriorDoorTypes", x => new { x.InspectionOrderPropertyHighValueInteriorFeatureId, x.DomesticHelpTypeIdId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueInteriorFeatureInteriorDoorTypes_InteriorDoorType",
                        column: x => x.DomesticHelpTypeIdId,
                        principalTable: "InteriorDoorType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueInteriorFeatureInteriorDoorTypes_InspectionOrderPropertyHighValueInteriorFeature",
                        column: x => x.InspectionOrderPropertyHighValueInteriorFeatureId,
                        principalTable: "InspectionOrderPropertyHighValueInteriorFeature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyHighValueInteriorFeatureLightingTypes",
                columns: table => new
                {
                    InspectionOrderPropertyHighValueInteriorFeatureId = table.Column<Guid>(nullable: false),
                    LightingTypeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyHighValueInteriorFeatureLightingTypes", x => new { x.InspectionOrderPropertyHighValueInteriorFeatureId, x.LightingTypeId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueInteriorFeatureLightingTypes_InspectionOrderPropertyHighValueInteriorFeature",
                        column: x => x.InspectionOrderPropertyHighValueInteriorFeatureId,
                        principalTable: "InspectionOrderPropertyHighValueInteriorFeature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueInteriorFeatureLightingTypes_LightingType",
                        column: x => x.LightingTypeId,
                        principalTable: "LightingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyHighValueInteriorFeatureMiscellaneousExtraFeatures",
                columns: table => new
                {
                    InspectionOrderPropertyHighValueInteriorFeatureId = table.Column<Guid>(nullable: false),
                    MiscellaneousExtraFeatureId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyHighValueInteriorFeatureMiscellaneousExtraFeatures", x => new { x.InspectionOrderPropertyHighValueInteriorFeatureId, x.MiscellaneousExtraFeatureId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueInteriorFeatureMiscellaneousExtraFeatures_InspectionOrderPropertyHighValueInteriorFeature",
                        column: x => x.InspectionOrderPropertyHighValueInteriorFeatureId,
                        principalTable: "InspectionOrderPropertyHighValueInteriorFeature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueInteriorFeatureMiscellaneousExtraFeatures_MiscellaneousExtraFeature",
                        column: x => x.MiscellaneousExtraFeatureId,
                        principalTable: "MiscellaneousExtraFeature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyHighValueInteriorFeatureRoomsWithCabinetry",
                columns: table => new
                {
                    InspectionOrderPropertyHighValueInteriorFeatureId = table.Column<Guid>(nullable: false),
                    RoomWithCabinetryId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyHighValueInteriorFeatureRoomsWithCabinetry", x => new { x.InspectionOrderPropertyHighValueInteriorFeatureId, x.RoomWithCabinetryId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueInteriorFeatureRoomsWithCabinetry_InspectionOrderPropertyHighValueInteriorFeature",
                        column: x => x.InspectionOrderPropertyHighValueInteriorFeatureId,
                        principalTable: "InspectionOrderPropertyHighValueInteriorFeature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueInteriorFeatureRoomsWithCabinetry_RoomWithCabinetry",
                        column: x => x.RoomWithCabinetryId,
                        principalTable: "RoomWithCabinetry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyHighValueInteriorFeatureStaircases",
                columns: table => new
                {
                    InspectionOrderPropertyHighValueInteriorFeatureId = table.Column<Guid>(nullable: false),
                    StaircaseId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyHighValueInteriorFeatureStaircases", x => new { x.InspectionOrderPropertyHighValueInteriorFeatureId, x.StaircaseId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueInteriorFeatureStaircases_InspectionOrderPropertyHighValueInteriorFeature",
                        column: x => x.InspectionOrderPropertyHighValueInteriorFeatureId,
                        principalTable: "InspectionOrderPropertyHighValueInteriorFeature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueInteriorFeatureStaircases_Staircase",
                        column: x => x.StaircaseId,
                        principalTable: "Staircase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyHighValueKitchenApplianceTypes",
                columns: table => new
                {
                    InspectionOrderPropertyHighValueKitchenId = table.Column<Guid>(nullable: false),
                    ApplianceTypeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyHighValueKitchenApplianceTypes", x => new { x.InspectionOrderPropertyHighValueKitchenId, x.ApplianceTypeId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueKitchenApplianceTypes_ApplianceType",
                        column: x => x.ApplianceTypeId,
                        principalTable: "ApplianceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueKitchenApplianceTypes_InspectionOrderPropertyHighValueKitchen",
                        column: x => x.InspectionOrderPropertyHighValueKitchenId,
                        principalTable: "InspectionOrderPropertyHighValueKitchen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyHomeDetailLocales",
                columns: table => new
                {
                    InspectionOrderPropertyHomeDetailId = table.Column<Guid>(nullable: false),
                    LocaleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyHomeDetailLocales", x => new { x.InspectionOrderPropertyHomeDetailId, x.LocaleId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHomeDetailLocales_InspectionOrderPropertyHomeDetail",
                        column: x => x.InspectionOrderPropertyHomeDetailId,
                        principalTable: "InspectionOrderPropertyHomeDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHomeDetailLocales_Locale",
                        column: x => x.LocaleId,
                        principalTable: "Locale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyInteriorDetailFlooringTypes",
                columns: table => new
                {
                    InspectionOrderPropertyInteriorDetailId = table.Column<Guid>(nullable: false),
                    FlooringTypeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyInteriorDetailFlooringTypes", x => new { x.InspectionOrderPropertyInteriorDetailId, x.FlooringTypeId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyInteriorDetailFlooringTypes_FlooringType",
                        column: x => x.FlooringTypeId,
                        principalTable: "FlooringType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyInteriorDetailFlooringTypes_InspectionOrderPropertyInteriorDetail",
                        column: x => x.InspectionOrderPropertyInteriorDetailId,
                        principalTable: "InspectionOrderPropertyInteriorDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyInteriorDetailKitchenBathCabinets",
                columns: table => new
                {
                    InspectionOrderPropertyInteriorDetailId = table.Column<Guid>(nullable: false),
                    KitchenBathCabinetId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyInteriorDetailKitchenBathCabinets", x => new { x.InspectionOrderPropertyInteriorDetailId, x.KitchenBathCabinetId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyInteriorDetailKitchenBathCabinets_InspectionOrderPropertyInteriorDetail",
                        column: x => x.InspectionOrderPropertyInteriorDetailId,
                        principalTable: "InspectionOrderPropertyInteriorDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyInteriorDetailKitchenBathCabinets_KitchenBathCabinet",
                        column: x => x.KitchenBathCabinetId,
                        principalTable: "KitchenBathCabinet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyInteriorDetailKitchenBathCounters",
                columns: table => new
                {
                    InspectionOrderPropertyInteriorDetailId = table.Column<Guid>(nullable: false),
                    KitchenBathCounterId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyInteriorDetailKitchenBathCounters", x => new { x.InspectionOrderPropertyInteriorDetailId, x.KitchenBathCounterId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyInteriorDetailKitchenBathCounters_InspectionOrderPropertyInteriorDetail",
                        column: x => x.InspectionOrderPropertyInteriorDetailId,
                        principalTable: "InspectionOrderPropertyInteriorDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyInteriorDetailKitchenBathCounters_KitchenBathCounter",
                        column: x => x.KitchenBathCounterId,
                        principalTable: "KitchenBathCounter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyInteriorDetailQualityClassUpgrades",
                columns: table => new
                {
                    InspectionOrderPropertyInteriorDetailId = table.Column<Guid>(nullable: false),
                    QualityClassUpgradeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyInteriorDetailQualityClassUpgrades", x => new { x.InspectionOrderPropertyInteriorDetailId, x.QualityClassUpgradeId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyInteriorDetailQualityClassUpgrades_InspectionOrderPropertyInteriorDetail",
                        column: x => x.InspectionOrderPropertyInteriorDetailId,
                        principalTable: "InspectionOrderPropertyInteriorDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyInteriorDetailQualityClassUpgrades_QualityClassUpgrade",
                        column: x => x.QualityClassUpgradeId,
                        principalTable: "QualityClassUpgrade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyInteriorDetailTypeOfPlumbings",
                columns: table => new
                {
                    InspectionOrderPropertyInteriorDetailId = table.Column<Guid>(nullable: false),
                    TypeOfPlumbingId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyInteriorDetailTypeOfPlumbings", x => new { x.InspectionOrderPropertyInteriorDetailId, x.TypeOfPlumbingId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyInteriorDetailTypeOfPlumbings_InspectionOrderPropertyInteriorDetail",
                        column: x => x.InspectionOrderPropertyInteriorDetailId,
                        principalTable: "InspectionOrderPropertyInteriorDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyInteriorDetailTypeOfPlumbings_TypeOfPlumbing",
                        column: x => x.TypeOfPlumbingId,
                        principalTable: "TypeOfPlumbing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderWildfireAssessmentDeckAndBalconyDeckConditionConcernDetails",
                columns: table => new
                {
                    InspectionOrderWildfireAssessmentDeckAndBalconyId = table.Column<Guid>(nullable: false),
                    DeckConditionConcernDetailId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderWildfireAssessmentDeckAndBalconyDeckConditionConcernDetails", x => new { x.InspectionOrderWildfireAssessmentDeckAndBalconyId, x.DeckConditionConcernDetailId });
                    table.ForeignKey(
                        name: "FK_IoWaDeckAndBalconyDeckConditionConcernDetails_DeckConditionConcernDetail",
                        column: x => x.DeckConditionConcernDetailId,
                        principalTable: "DeckConditionConcernDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IoWaDeckAndBalconyDeckConditionConcernDetails_InspectionOrderWildfireAssessmentDeckAndBalcony",
                        column: x => x.InspectionOrderWildfireAssessmentDeckAndBalconyId,
                        principalTable: "InspectionOrderWildfireAssessmentDeckAndBalcony",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderWildfireAssessmentDeckAndBalconyPorchDeckBalconyConstructions",
                columns: table => new
                {
                    InspectionOrderWildfireAssessmentDeckAndBalconyId = table.Column<Guid>(nullable: false),
                    PorchDeckBalconyConstructionId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderWildfireAssessmentDeckAndBalconyPorchDeckBalconyConstructions", x => new { x.InspectionOrderWildfireAssessmentDeckAndBalconyId, x.PorchDeckBalconyConstructionId });
                    table.ForeignKey(
                        name: "FK_IoWaDeckAndBalconyPorchDeckBalconyConstructions_InspectionOrderWildfireAssessmentDeckAndBalcony",
                        column: x => x.InspectionOrderWildfireAssessmentDeckAndBalconyId,
                        principalTable: "InspectionOrderWildfireAssessmentDeckAndBalcony",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IoWaDeckAndBalconyPorchDeckBalconyConstructions_PorchDeckBalconyConstruction",
                        column: x => x.PorchDeckBalconyConstructionId,
                        principalTable: "PorchDeckBalconyConstruction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderWildfireAssessmentExteriorSidingOtherWallCoverings",
                columns: table => new
                {
                    InspectionOrderWildfireAssessmentExteriorSidingId = table.Column<Guid>(nullable: false),
                    OtherWallCoveringId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderWildfireAssessmentExteriorSidingOtherWallCoverings", x => new { x.InspectionOrderWildfireAssessmentExteriorSidingId, x.OtherWallCoveringId });
                    table.ForeignKey(
                        name: "FK_IoWaExteriorSidingOtherWallCoverings_InspectionOrderWildfireAssessmentExteriorSiding",
                        column: x => x.InspectionOrderWildfireAssessmentExteriorSidingId,
                        principalTable: "InspectionOrderWildfireAssessmentExteriorSiding",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IoWaExteriorSidingOtherWallCoverings_OtherWallCovering",
                        column: x => x.OtherWallCoveringId,
                        principalTable: "OtherWallCovering",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderWildfireAssessmentExteriorSidingSidingConditionConcernDetails",
                columns: table => new
                {
                    InspectionOrderWildfireAssessmentExteriorSidingId = table.Column<Guid>(nullable: false),
                    SidingConditionConcernDetailId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderWildfireAssessmentExteriorSidingSidingConditionConcernDetails", x => new { x.InspectionOrderWildfireAssessmentExteriorSidingId, x.SidingConditionConcernDetailId });
                    table.ForeignKey(
                        name: "FK_IoWaExteriorSidingSidingConditionConcernDetails_InspectionOrderWildfireAssessmentExteriorSiding",
                        column: x => x.InspectionOrderWildfireAssessmentExteriorSidingId,
                        principalTable: "InspectionOrderWildfireAssessmentExteriorSiding",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IoWaExteriorSidingSidingConditionConcernDetails_SidingConditionConcernDetail",
                        column: x => x.SidingConditionConcernDetailId,
                        principalTable: "SidingConditionConcernDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderWildfireAssessmentExternalFuelSourceExternalFuelSourceTypes",
                columns: table => new
                {
                    InspectionOrderWildfireAssessmentExternalFuelSourceId = table.Column<Guid>(nullable: false),
                    ExternalFuelSourceTypeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderWildfireAssessmentExternalFuelSourceExternalFuelSourceTypes", x => new { x.InspectionOrderWildfireAssessmentExternalFuelSourceId, x.ExternalFuelSourceTypeId });
                    table.ForeignKey(
                        name: "FK_IoWaExternalFuelSourceExternalFuelSourceTypes_ExternalFuelSourceType",
                        column: x => x.ExternalFuelSourceTypeId,
                        principalTable: "ExternalFuelSourceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IoWaExternalFuelSourceExternalFuelSourceTypes_InspectionOrderWildfireAssessmentExternalFuelSource",
                        column: x => x.InspectionOrderWildfireAssessmentExternalFuelSourceId,
                        principalTable: "InspectionOrderWildfireAssessmentExternalFuelSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFenceConditionConcernDetails",
                columns: table => new
                {
                    InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId = table.Column<Guid>(nullable: false),
                    FenceConditionConcernDetailId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFenceConditionConcernDetails", x => new { x.InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId, x.FenceConditionConcernDetailId });
                    table.ForeignKey(
                        name: "FK_IoWaFencingAndOtherAttachmentFenceConditionConcernDetails_FenceConditionConcernDetail",
                        column: x => x.FenceConditionConcernDetailId,
                        principalTable: "FenceConditionConcernDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IoWaFencingAndOtherAttachmentFenceConditionConcernDetails_InspectionOrderWildfireAssessmentFencingAndOtherAttachment",
                        column: x => x.InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId,
                        principalTable: "InspectionOrderWildfireAssessmentFencingAndOtherAttachment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFencingTypes",
                columns: table => new
                {
                    InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId = table.Column<Guid>(nullable: false),
                    FencingTypeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFencingTypes", x => new { x.InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId, x.FencingTypeId });
                    table.ForeignKey(
                        name: "FK_IoWaFencingAndOtherAttachmentFencingTypes_FencingType",
                        column: x => x.FencingTypeId,
                        principalTable: "FencingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IoWaFencingAndOtherAttachmentFencingTypes_InspectionOrderWildfireAssessmentFencingAndOtherAttachment",
                        column: x => x.InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId,
                        principalTable: "InspectionOrderWildfireAssessmentFencingAndOtherAttachment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherAttachmentTypes",
                columns: table => new
                {
                    InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId = table.Column<Guid>(nullable: false),
                    OtherAttachmentTypeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherAttachmentTypes", x => new { x.InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId, x.OtherAttachmentTypeId });
                    table.ForeignKey(
                        name: "FK_IoWaFencingAndOtherAttachmentOtherAttachmentTypes_InspectionOrderWildfireAssessmentFencingAndOtherAttachment",
                        column: x => x.InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId,
                        principalTable: "InspectionOrderWildfireAssessmentFencingAndOtherAttachment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IoWaFencingAndOtherAttachmentOtherAttachmentTypes_OtherAttachmentType",
                        column: x => x.OtherAttachmentTypeId,
                        principalTable: "OtherAttachmentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherDetachedStructuresDetails",
                columns: table => new
                {
                    InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId = table.Column<Guid>(nullable: false),
                    OtherDetachedStructuresDetailId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherDetachedStructuresDetails", x => new { x.InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId, x.OtherDetachedStructuresDetailId });
                    table.ForeignKey(
                        name: "FK_IoWaFencingAndOtherAttachmentOtherDetachedStructuresDetails_InspectionOrderWildfireAssessmentFencingAndOtherAttachment",
                        column: x => x.InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId,
                        principalTable: "InspectionOrderWildfireAssessmentFencingAndOtherAttachment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IoWaFencingAndOtherAttachmentOtherDetachedStructuresDetails_OtherDetachedStructuresDetail",
                        column: x => x.OtherDetachedStructuresDetailId,
                        principalTable: "OtherDetachedStructuresDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOutbuildingDetails",
                columns: table => new
                {
                    InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId = table.Column<Guid>(nullable: false),
                    OutbuildingDetailId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOutbuildingDetails", x => new { x.InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId, x.OutbuildingDetailId });
                    table.ForeignKey(
                        name: "FK_IoWaFencingAndOtherAttachmentOutbuildingDetails_InspectionOrderWildfireAssessmentFencingAndOtherAttachment",
                        column: x => x.InspectionOrderWildfireAssessmentFencingAndOtherAttachmentId,
                        principalTable: "InspectionOrderWildfireAssessmentFencingAndOtherAttachment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IoWaFencingAndOtherAttachmentOutbuildingDetails_OutbuildingDetail",
                        column: x => x.OutbuildingDetailId,
                        principalTable: "OutbuildingDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderWildfireAssessmentMitigationRecommendations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    InspectionOrderWildfireAssessmentMitigationId = table.Column<Guid>(nullable: true),
                    Photo = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderWildfireAssessmentMitigationRecommendations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IoWaMitigationRecommendations_InspectionOrderWildfireAssessmentMitigation",
                        column: x => x.InspectionOrderWildfireAssessmentMitigationId,
                        principalTable: "InspectionOrderWildfireAssessmentMitigation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderWildfireAssessmentMitigationRequirements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    InspectionOrderWildfireAssessmentMitigationId = table.Column<Guid>(nullable: true),
                    Photo = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderWildfireAssessmentMitigationRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IoWaMitigationRequirements_InspectionOrderWildfireAssessmentMitigation",
                        column: x => x.InspectionOrderWildfireAssessmentMitigationId,
                        principalTable: "InspectionOrderWildfireAssessmentMitigation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderWildfireAssessmentRoofGutterTypes",
                columns: table => new
                {
                    InspectionOrderWildfireAssessmentRoofId = table.Column<Guid>(nullable: false),
                    GutterTypeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderWildfireAssessmentRoofGutterTypes", x => new { x.InspectionOrderWildfireAssessmentRoofId, x.GutterTypeId });
                    table.ForeignKey(
                        name: "FK_IoWaRoofGutterTypes_GutterType",
                        column: x => x.GutterTypeId,
                        principalTable: "GutterType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IoWaRoofGutterTypes_InspectionOrderWildfireAssessmentRoof",
                        column: x => x.InspectionOrderWildfireAssessmentRoofId,
                        principalTable: "InspectionOrderWildfireAssessmentRoof",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderWildfireAssessmentRoofOtherRoofCoverings",
                columns: table => new
                {
                    InspectionOrderWildfireAssessmentRoofId = table.Column<Guid>(nullable: false),
                    OtherRoofCoveringId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderWildfireAssessmentRoofOtherRoofCoverings", x => new { x.InspectionOrderWildfireAssessmentRoofId, x.OtherRoofCoveringId });
                    table.ForeignKey(
                        name: "FK_IoWaRoofOtherRoofCoverings_InspectionOrderWildfireAssessmentRoof",
                        column: x => x.InspectionOrderWildfireAssessmentRoofId,
                        principalTable: "InspectionOrderWildfireAssessmentRoof",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IoWaRoofOtherRoofCoverings_OtherRoofCovering",
                        column: x => x.OtherRoofCoveringId,
                        principalTable: "OtherRoofCovering",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderWildfireAssessmentRoofRoofConcernDetails",
                columns: table => new
                {
                    InspectionOrderWildfireAssessmentRoofId = table.Column<Guid>(nullable: false),
                    RoofConcernDetailId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderWildfireAssessmentRoofRoofConcernDetails", x => new { x.InspectionOrderWildfireAssessmentRoofId, x.RoofConcernDetailId });
                    table.ForeignKey(
                        name: "FK_IoWaRoofRoofConcernDetails_InspectionOrderWildfireAssessmentRoof",
                        column: x => x.InspectionOrderWildfireAssessmentRoofId,
                        principalTable: "InspectionOrderWildfireAssessmentRoof",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IoWaRoofRoofConcernDetails_RoofConcernDetail",
                        column: x => x.RoofConcernDetailId,
                        principalTable: "RoofConcernDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderWildfireAssessmentRoofRoofVentings",
                columns: table => new
                {
                    InspectionOrderWildfireAssessmentRoofId = table.Column<Guid>(nullable: false),
                    RoofVentingId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderWildfireAssessmentRoofRoofVentings", x => new { x.InspectionOrderWildfireAssessmentRoofId, x.RoofVentingId });
                    table.ForeignKey(
                        name: "FK_IoWaRoofRoofVentings_InspectionOrderWildfireAssessmentRoof",
                        column: x => x.InspectionOrderWildfireAssessmentRoofId,
                        principalTable: "InspectionOrderWildfireAssessmentRoof",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IoWaRoofRoofVentings_RoofVenting",
                        column: x => x.RoofVentingId,
                        principalTable: "RoofVenting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderWildfireAssessmentWindowExteriorWindowCoveringTypes",
                columns: table => new
                {
                    InspectionOrderWildfireAssessmentWindowId = table.Column<Guid>(nullable: false),
                    ExteriorWindowCoveringTypeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderWildfireAssessmentWindowExteriorWindowCoveringTypes", x => new { x.InspectionOrderWildfireAssessmentWindowId, x.ExteriorWindowCoveringTypeId });
                    table.ForeignKey(
                        name: "FK_IoWaWindowExteriorWindowCoveringTypes_ExteriorWindowCoveringType",
                        column: x => x.ExteriorWindowCoveringTypeId,
                        principalTable: "ExteriorWindowCoveringType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IoWaWindowExteriorWindowCoveringTypes_InspectionOrderWildfireAssessmentWindow",
                        column: x => x.InspectionOrderWildfireAssessmentWindowId,
                        principalTable: "InspectionOrderWildfireAssessmentWindow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderWildfireAssessmentWindowInteriorWindowCoveringTypes",
                columns: table => new
                {
                    InspectionOrderWildfireAssessmentWindowId = table.Column<Guid>(nullable: false),
                    InteriorWindowCoveringTypeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderWildfireAssessmentWindowInteriorWindowCoveringTypes", x => new { x.InspectionOrderWildfireAssessmentWindowId, x.InteriorWindowCoveringTypeId });
                    table.ForeignKey(
                        name: "FK_IoWaWindowInteriorWindowCoveringTypes_InspectionOrderWildfireAssessmentWindow",
                        column: x => x.InspectionOrderWildfireAssessmentWindowId,
                        principalTable: "InspectionOrderWildfireAssessmentWindow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IoWaWindowInteriorWindowCoveringTypes_InteriorWindowCoveringType",
                        column: x => x.InteriorWindowCoveringTypeId,
                        principalTable: "InteriorWindowCoveringType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderWildfireAssessmentWindowWindowConcernDetails",
                columns: table => new
                {
                    InspectionOrderWildfireAssessmentWindowId = table.Column<Guid>(nullable: false),
                    WindowConcernDetailId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderWildfireAssessmentWindowWindowConcernDetails", x => new { x.InspectionOrderWildfireAssessmentWindowId, x.WindowConcernDetailId });
                    table.ForeignKey(
                        name: "FK_IoWaWindowWindowConcernDetails_InspectionOrderWildfireAssessmentWindow",
                        column: x => x.InspectionOrderWildfireAssessmentWindowId,
                        principalTable: "InspectionOrderWildfireAssessmentWindow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IoWaWindowWindowConcernDetails_WindowConcernDetail",
                        column: x => x.WindowConcernDetailId,
                        principalTable: "WindowConcernDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderWildfireAssessmentWindowWindowFramingTypes",
                columns: table => new
                {
                    InspectionOrderWildfireAssessmentWindowId = table.Column<Guid>(nullable: false),
                    WindowFramingTypeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderWildfireAssessmentWindowWindowFramingTypes", x => new { x.InspectionOrderWildfireAssessmentWindowId, x.WindowFramingTypeId });
                    table.ForeignKey(
                        name: "FK_IoWaWindowWindowFramingTypes_InspectionOrderWildfireAssessmentWindow",
                        column: x => x.InspectionOrderWildfireAssessmentWindowId,
                        principalTable: "InspectionOrderWildfireAssessmentWindow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IoWaWindowWindowFramingTypes_WindowFramingType",
                        column: x => x.WindowFramingTypeId,
                        principalTable: "WindowFramingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderWildfireAssessmentWindowWindowGlassTypes",
                columns: table => new
                {
                    InspectionOrderWildfireAssessmentWindowId = table.Column<Guid>(nullable: false),
                    WindowGlassTypeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderWildfireAssessmentWindowWindowGlassTypes", x => new { x.InspectionOrderWildfireAssessmentWindowId, x.WindowGlassTypeId });
                    table.ForeignKey(
                        name: "FK_IoWaWindowWindowGlassTypes_InspectionOrderWildfireAssessmentWindow",
                        column: x => x.InspectionOrderWildfireAssessmentWindowId,
                        principalTable: "InspectionOrderWildfireAssessmentWindow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IoWaWindowWindowGlassTypes_WindowGlassType",
                        column: x => x.WindowGlassTypeId,
                        principalTable: "WindowGlassType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderWildfireAssessmentWindowWindowScreenTypes",
                columns: table => new
                {
                    InspectionOrderWildfireAssessmentWindowId = table.Column<Guid>(nullable: false),
                    WindowScreenTypeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderWildfireAssessmentWindowWindowScreenTypes", x => new { x.InspectionOrderWildfireAssessmentWindowId, x.WindowScreenTypeId });
                    table.ForeignKey(
                        name: "FK_IoWaWindowWindowScreenTypes_InspectionOrderWildfireAssessmentWindow",
                        column: x => x.InspectionOrderWildfireAssessmentWindowId,
                        principalTable: "InspectionOrderWildfireAssessmentWindow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IoWaWindowWindowScreenTypes_WindowScreenType",
                        column: x => x.WindowScreenTypeId,
                        principalTable: "WindowScreenType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderWildfireAssessmentWindowWindowStyles",
                columns: table => new
                {
                    InspectionOrderWildfireAssessmentWindowId = table.Column<Guid>(nullable: false),
                    WindowStyleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderWildfireAssessmentWindowWindowStyles", x => new { x.InspectionOrderWildfireAssessmentWindowId, x.WindowStyleId });
                    table.ForeignKey(
                        name: "FK_IoWaWindowWindowStyles_InspectionOrderWildfireAssessmentWindow",
                        column: x => x.InspectionOrderWildfireAssessmentWindowId,
                        principalTable: "InspectionOrderWildfireAssessmentWindow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IoWaWindowWindowStyles_WindowStyle",
                        column: x => x.WindowStyleId,
                        principalTable: "WindowStyle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_StateId",
                table: "City",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrder_InspectorId",
                table: "InspectionOrder",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderNonWildfireAssessmentMitigationRecommendations_InspectionOrderNonWildfireAssessmentMitigationId",
                table: "InspectionOrderNonWildfireAssessmentMitigationRecommendations",
                column: "InspectionOrderNonWildfireAssessmentMitigationId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderNonWildfireAssessmentMitigationRequirements_InspectionOrderNonWildfireAssessmentMitigationId",
                table: "InspectionOrderNonWildfireAssessmentMitigationRequirements",
                column: "InspectionOrderNonWildfireAssessmentMitigationId");

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

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyAdditionalExposureBearInvasionConcernDetails_BearInvasionConcernDetailId",
                table: "InspectionOrderPropertyAdditionalExposureBearInvasionConcernDetails",
                column: "BearInvasionConcernDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyBuildingConcernElectricalConcernDetails_ElectricalConcernDetailId",
                table: "InspectionOrderPropertyBuildingConcernElectricalConcernDetails",
                column: "ElectricalConcernDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyBuildingConcernExteriorBuildingConcernDetails_ExteriorBuildingConcernDetailId",
                table: "InspectionOrderPropertyBuildingConcernExteriorBuildingConcernDetails",
                column: "ExteriorBuildingConcernDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyBuildingConcernOtherStructureConcernDetails_OtherStructureConcernDetailId",
                table: "InspectionOrderPropertyBuildingConcernOtherStructureConcernDetails",
                column: "OtherStructureConcernDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyBuildingConcernPlumbingConcernDetails_PlumbingConcernDetailId",
                table: "InspectionOrderPropertyBuildingConcernPlumbingConcernDetails",
                column: "PlumbingConcernDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyBuildingConcernRoofConcernDetails_RoofConcernDetailId",
                table: "InspectionOrderPropertyBuildingConcernRoofConcernDetails",
                column: "RoofConcernDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyBuildingConcernSurroundingAreaConcernDetails_SurroundingAreaConcernDetailId",
                table: "InspectionOrderPropertyBuildingConcernSurroundingAreaConcernDetails",
                column: "SurroundingAreaConcernDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyDetachedStructureOtherDetachedStructuresDetails_OtherDetachedStructuresDetailId",
                table: "InspectionOrderPropertyDetachedStructureOtherDetachedStructuresDetails",
                column: "OtherDetachedStructuresDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyDetachedStructureOutbuildingDetails_OutbuildingDetailId",
                table: "InspectionOrderPropertyDetachedStructureOutbuildingDetails",
                column: "OutbuildingDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyGeneral_BurglarAlarmTypeId",
                table: "InspectionOrderPropertyGeneral",
                column: "BurglarAlarmTypeId",
                unique: true,
                filter: "[BurglarAlarmTypeId] IS NOT NULL");

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
                name: "IX_InspectionOrderPropertyGeneralDomesticHelpTypes_DomesticHelpTypeId",
                table: "InspectionOrderPropertyGeneralDomesticHelpTypes",
                column: "DomesticHelpTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyGeneralPolicyPremiumCredits_PolicyPremiumCreditId",
                table: "InspectionOrderPropertyGeneralPolicyPremiumCredits",
                column: "PolicyPremiumCreditId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyGeneralWildfireCredits_WildfireCreditId",
                table: "InspectionOrderPropertyGeneralWildfireCredits",
                column: "WildfireCreditId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHighValueBathBathroomCounters_BathroomCounterId",
                table: "InspectionOrderPropertyHighValueBathBathroomCounters",
                column: "BathroomCounterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHighValueBathBathroomFixtures_BathroomFixtureId",
                table: "InspectionOrderPropertyHighValueBathBathroomFixtures",
                column: "BathroomFixtureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHighValueBathBathroomFloors_BathroomFloorId",
                table: "InspectionOrderPropertyHighValueBathBathroomFloors",
                column: "BathroomFloorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHighValueBathBathroomVanities_BathroomVanityId",
                table: "InspectionOrderPropertyHighValueBathBathroomVanities",
                column: "BathroomVanityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHighValueBathTubsAndShowers_TubAndShowerId",
                table: "InspectionOrderPropertyHighValueBathTubsAndShowers",
                column: "TubAndShowerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHighValueFloorToCeiling_ChimneyTypeId",
                table: "InspectionOrderPropertyHighValueFloorToCeiling",
                column: "ChimneyTypeId",
                unique: true,
                filter: "[ChimneyTypeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHighValueFloorToCeilingCeilings_CeilingId",
                table: "InspectionOrderPropertyHighValueFloorToCeilingCeilings",
                column: "CeilingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHighValueFloorToCeilingFloorCoverings_FloorCoveringId",
                table: "InspectionOrderPropertyHighValueFloorToCeilingFloorCoverings",
                column: "FloorCoveringId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHighValueFloorToCeilingInteriorWallCoverings_InteriorWallCoveringId",
                table: "InspectionOrderPropertyHighValueFloorToCeilingInteriorWallCoverings",
                column: "InteriorWallCoveringId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHighValueFloorToCeilingWallTrims_WallTrimId",
                table: "InspectionOrderPropertyHighValueFloorToCeilingWallTrims",
                column: "WallTrimId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHighValueFloorToCeilingWindowBrands_WindowBrandId",
                table: "InspectionOrderPropertyHighValueFloorToCeilingWindowBrands",
                column: "WindowBrandId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHighValueFloorToCeilingWindowStyles_WindowStyleId",
                table: "InspectionOrderPropertyHighValueFloorToCeilingWindowStyles",
                column: "WindowStyleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHighValueInteriorFeatureDoorHardwares_DoorHardwareId",
                table: "InspectionOrderPropertyHighValueInteriorFeatureDoorHardwares",
                column: "DoorHardwareId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHighValueInteriorFeatureFireplaceTypes_FireplaceTypeId",
                table: "InspectionOrderPropertyHighValueInteriorFeatureFireplaceTypes",
                column: "FireplaceTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHighValueInteriorFeatureInteriorDoorTypes_DomesticHelpTypeIdId",
                table: "InspectionOrderPropertyHighValueInteriorFeatureInteriorDoorTypes",
                column: "DomesticHelpTypeIdId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHighValueInteriorFeatureLightingTypes_LightingTypeId",
                table: "InspectionOrderPropertyHighValueInteriorFeatureLightingTypes",
                column: "LightingTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHighValueInteriorFeatureMiscellaneousExtraFeatures_MiscellaneousExtraFeatureId",
                table: "InspectionOrderPropertyHighValueInteriorFeatureMiscellaneousExtraFeatures",
                column: "MiscellaneousExtraFeatureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHighValueInteriorFeatureRoomsWithCabinetry_RoomWithCabinetryId",
                table: "InspectionOrderPropertyHighValueInteriorFeatureRoomsWithCabinetry",
                column: "RoomWithCabinetryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHighValueInteriorFeatureStaircases_StaircaseId",
                table: "InspectionOrderPropertyHighValueInteriorFeatureStaircases",
                column: "StaircaseId",
                unique: true);

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
                name: "IX_InspectionOrderPropertyHighValueKitchenApplianceTypes_ApplianceTypeId",
                table: "InspectionOrderPropertyHighValueKitchenApplianceTypes",
                column: "ApplianceTypeId",
                unique: true);

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
                name: "IX_InspectionOrderPropertyHomeDetailLocales_LocaleId",
                table: "InspectionOrderPropertyHomeDetailLocales",
                column: "LocaleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyInteriorDetailFlooringTypes_FlooringTypeId",
                table: "InspectionOrderPropertyInteriorDetailFlooringTypes",
                column: "FlooringTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyInteriorDetailKitchenBathCabinets_KitchenBathCabinetId",
                table: "InspectionOrderPropertyInteriorDetailKitchenBathCabinets",
                column: "KitchenBathCabinetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyInteriorDetailKitchenBathCounters_KitchenBathCounterId",
                table: "InspectionOrderPropertyInteriorDetailKitchenBathCounters",
                column: "KitchenBathCounterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyInteriorDetailQualityClassUpgrades_QualityClassUpgradeId",
                table: "InspectionOrderPropertyInteriorDetailQualityClassUpgrades",
                column: "QualityClassUpgradeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyInteriorDetailTypeOfPlumbings_TypeOfPlumbingId",
                table: "InspectionOrderPropertyInteriorDetailTypeOfPlumbings",
                column: "TypeOfPlumbingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyPhotoPhotos_PhotoTypeId",
                table: "InspectionOrderPropertyPhotoPhotos",
                column: "PhotoTypeId",
                unique: true,
                filter: "[PhotoTypeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentAccessAndFireProtection_FireDepartmentStaffingId",
                table: "InspectionOrderWildfireAssessmentAccessAndFireProtection",
                column: "FireDepartmentStaffingId",
                unique: true,
                filter: "[FireDepartmentStaffingId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentDeckAndBalconyDeckConditionConcernDetails_DeckConditionConcernDetailId",
                table: "InspectionOrderWildfireAssessmentDeckAndBalconyDeckConditionConcernDetails",
                column: "DeckConditionConcernDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentDeckAndBalconyPorchDeckBalconyConstructions_PorchDeckBalconyConstructionId",
                table: "InspectionOrderWildfireAssessmentDeckAndBalconyPorchDeckBalconyConstructions",
                column: "PorchDeckBalconyConstructionId",
                unique: true);

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
                name: "IX_InspectionOrderWildfireAssessmentExteriorSidingOtherWallCoverings_OtherWallCoveringId",
                table: "InspectionOrderWildfireAssessmentExteriorSidingOtherWallCoverings",
                column: "OtherWallCoveringId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentExteriorSidingSidingConditionConcernDetails_SidingConditionConcernDetailId",
                table: "InspectionOrderWildfireAssessmentExteriorSidingSidingConditionConcernDetails",
                column: "SidingConditionConcernDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentExternalFuelSourceExternalFuelSourceTypes_ExternalFuelSourceTypeId",
                table: "InspectionOrderWildfireAssessmentExternalFuelSourceExternalFuelSourceTypes",
                column: "ExternalFuelSourceTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFenceConditionConcernDetails_FenceConditionConcernDetailId",
                table: "InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFenceConditionConcernDetails",
                column: "FenceConditionConcernDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFencingTypes_FencingTypeId",
                table: "InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFencingTypes",
                column: "FencingTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherAttachmentTypes_OtherAttachmentTypeId",
                table: "InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherAttachmentTypes",
                column: "OtherAttachmentTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherDetachedStructuresDetails_OtherDetachedStructuresDetailId",
                table: "InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherDetachedStructuresDetails",
                column: "OtherDetachedStructuresDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOutbuildingDetails_OutbuildingDetailId",
                table: "InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOutbuildingDetails",
                column: "OutbuildingDetailId",
                unique: true);

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
                name: "IX_InspectionOrderWildfireAssessmentMitigationRecommendations_InspectionOrderWildfireAssessmentMitigationId",
                table: "InspectionOrderWildfireAssessmentMitigationRecommendations",
                column: "InspectionOrderWildfireAssessmentMitigationId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentMitigationRequirements_InspectionOrderWildfireAssessmentMitigationId",
                table: "InspectionOrderWildfireAssessmentMitigationRequirements",
                column: "InspectionOrderWildfireAssessmentMitigationId");

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
                name: "IX_InspectionOrderWildfireAssessmentRoofGutterTypes_GutterTypeId",
                table: "InspectionOrderWildfireAssessmentRoofGutterTypes",
                column: "GutterTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentRoofOtherRoofCoverings_OtherRoofCoveringId",
                table: "InspectionOrderWildfireAssessmentRoofOtherRoofCoverings",
                column: "OtherRoofCoveringId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentRoofRoofConcernDetails_RoofConcernDetailId",
                table: "InspectionOrderWildfireAssessmentRoofRoofConcernDetails",
                column: "RoofConcernDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentRoofRoofVentings_RoofVentingId",
                table: "InspectionOrderWildfireAssessmentRoofRoofVentings",
                column: "RoofVentingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentWindowExteriorWindowCoveringTypes_ExteriorWindowCoveringTypeId",
                table: "InspectionOrderWildfireAssessmentWindowExteriorWindowCoveringTypes",
                column: "ExteriorWindowCoveringTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentWindowInteriorWindowCoveringTypes_InteriorWindowCoveringTypeId",
                table: "InspectionOrderWildfireAssessmentWindowInteriorWindowCoveringTypes",
                column: "InteriorWindowCoveringTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentWindowWindowConcernDetails_WindowConcernDetailId",
                table: "InspectionOrderWildfireAssessmentWindowWindowConcernDetails",
                column: "WindowConcernDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentWindowWindowFramingTypes_WindowFramingTypeId",
                table: "InspectionOrderWildfireAssessmentWindowWindowFramingTypes",
                column: "WindowFramingTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentWindowWindowGlassTypes_WindowGlassTypeId",
                table: "InspectionOrderWildfireAssessmentWindowWindowGlassTypes",
                column: "WindowGlassTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentWindowWindowScreenTypes_WindowScreenTypeId",
                table: "InspectionOrderWildfireAssessmentWindowWindowScreenTypes",
                column: "WindowScreenTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentWindowWindowStyles_WindowStyleId",
                table: "InspectionOrderWildfireAssessmentWindowWindowStyles",
                column: "WindowStyleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhotoType_GroupId",
                table: "PhotoType",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_InspectionStatusId",
                table: "Policy",
                column: "InspectionStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_MitigationStatusId",
                table: "Policy",
                column: "MitigationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_PropertyValueId",
                table: "Policy",
                column: "PropertyValueId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleId",
                table: "RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Token_UserId",
                table: "Token",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                table: "UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_UserId",
                table: "UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.Sql(SqlScripts.insert_state);

            migrationBuilder.Sql(SqlScripts.insert_ArchitecturalStyle);
            migrationBuilder.Sql(SqlScripts.insert_BurglarAlarmType);
            migrationBuilder.Sql(SqlScripts.insert_city);
            migrationBuilder.Sql(SqlScripts.insert_ConstructionQuality);
            migrationBuilder.Sql(SqlScripts.insert_DomesticHelpType);
            migrationBuilder.Sql(SqlScripts.insert_FireAlarmType);
            migrationBuilder.Sql(SqlScripts.insert_FlooringType);
            migrationBuilder.Sql(SqlScripts.insert_FoundationType);
            migrationBuilder.Sql(SqlScripts.insert_FramingType);
            migrationBuilder.Sql(SqlScripts.insert_HomeShape);
            migrationBuilder.Sql(SqlScripts.insert_InspectionStatus);
            migrationBuilder.Sql(SqlScripts.insert_KitchenBathCabinet);
            migrationBuilder.Sql(SqlScripts.insert_KitchenBathCounter);
            migrationBuilder.Sql(SqlScripts.insert_Locale);
            migrationBuilder.Sql(SqlScripts.insert_MitigationStatus);
            migrationBuilder.Sql(SqlScripts.insert_OccupancyType);
            migrationBuilder.Sql(SqlScripts.insert_PolicyPremiumCredit);
            migrationBuilder.Sql(SqlScripts.insert_PrimaryExteriorWallCovering);
            migrationBuilder.Sql(SqlScripts.insert_PrimaryRoofCovering);
            migrationBuilder.Sql(SqlScripts.insert_PropertyValue);
            migrationBuilder.Sql(SqlScripts.insert_QualityClassUpgrade);
            migrationBuilder.Sql(SqlScripts.insert_RoofType);
            migrationBuilder.Sql(SqlScripts.insert_SecondaryExteriorWallCovering);
            migrationBuilder.Sql(SqlScripts.insert_SecondaryRoofCovering);
            migrationBuilder.Sql(SqlScripts.insert_SlopeofSite);
            migrationBuilder.Sql(SqlScripts.insert_SmokeOnlyAlarmType);
            migrationBuilder.Sql(SqlScripts.insert_TypeOfPlumbing);
            migrationBuilder.Sql(SqlScripts.insert_WildfireCredit);

            migrationBuilder.Sql(SqlScripts.insert_ApplianceBrand);
            migrationBuilder.Sql(SqlScripts.insert_ApplianceType);
            migrationBuilder.Sql(SqlScripts.insert_BathroomCounter);
            migrationBuilder.Sql(SqlScripts.insert_BathroomFixture);
            migrationBuilder.Sql(SqlScripts.insert_BathroomFloor);
            migrationBuilder.Sql(SqlScripts.insert_BathroomVanity);
            migrationBuilder.Sql(SqlScripts.insert_BearInvasionConcernDetail);
            migrationBuilder.Sql(SqlScripts.insert_Ceiling);
            migrationBuilder.Sql(SqlScripts.insert_ChimneyType);
            migrationBuilder.Sql(SqlScripts.insert_CustomeronSite);
            migrationBuilder.Sql(SqlScripts.insert_DeckConditionConcernDetail);
            migrationBuilder.Sql(SqlScripts.insert_DogTemperament);
            migrationBuilder.Sql(SqlScripts.insert_DoorHardware);
            migrationBuilder.Sql(SqlScripts.insert_EavesType);
            migrationBuilder.Sql(SqlScripts.insert_ElectricalConcernDetail);
            migrationBuilder.Sql(SqlScripts.insert_Employee10HoursPerWeek);
            migrationBuilder.Sql(SqlScripts.insert_ExteriorBuildingConcernDetail);
            migrationBuilder.Sql(SqlScripts.insert_ExternalFuelSourceType);
            migrationBuilder.Sql(SqlScripts.insert_FenceConditionConcernDetail);
            migrationBuilder.Sql(SqlScripts.insert_FencingType);
            migrationBuilder.Sql(SqlScripts.insert_FireDepartmentStaffing);
            migrationBuilder.Sql(SqlScripts.insert_FireplaceType);
            migrationBuilder.Sql(SqlScripts.insert_FloorCovering);
            migrationBuilder.Sql(SqlScripts.insert_GutterType);
            migrationBuilder.Sql(SqlScripts.insert_InteriorDoorType);
            migrationBuilder.Sql(SqlScripts.insert_InteriorWallCovering);
            migrationBuilder.Sql(SqlScripts.insert_InteriorWindowCoveringType);
            migrationBuilder.Sql(SqlScripts.insert_KitchenCabinet);
            migrationBuilder.Sql(SqlScripts.insert_KitchenCountertop);
            migrationBuilder.Sql(SqlScripts.insert_LightingType);
            migrationBuilder.Sql(SqlScripts.insert_MiscellaneousExtraFeature);
            migrationBuilder.Sql(SqlScripts.insert_OtherAttachmentType);
            migrationBuilder.Sql(SqlScripts.insert_OtherDetachedStructuresDetail);
            migrationBuilder.Sql(SqlScripts.insert_OtherStructureConcernDetail);
            migrationBuilder.Sql(SqlScripts.insert_OutbuildingDetail);
            migrationBuilder.Sql(SqlScripts.insert_PhotoTypeGroup);
            migrationBuilder.Sql(SqlScripts.insert_PhotoType);
            migrationBuilder.Sql(SqlScripts.insert_PlumbingConcernDetail);
            migrationBuilder.Sql(SqlScripts.insert_PorchDeckBalconyConstruction);
            migrationBuilder.Sql(SqlScripts.insert_RoofConcernDetail);
            migrationBuilder.Sql(SqlScripts.insert_RoofVenting);
            migrationBuilder.Sql(SqlScripts.insert_RoomWithCabinetry);
            migrationBuilder.Sql(SqlScripts.insert_SidingConditionConcernDetail);
            migrationBuilder.Sql(SqlScripts.insert_Staircase);
            migrationBuilder.Sql(SqlScripts.insert_SurroundingAreaConcernDetail);
            migrationBuilder.Sql(SqlScripts.insert_TubAndShower);
            migrationBuilder.Sql(SqlScripts.insert_WallTrim);
            migrationBuilder.Sql(SqlScripts.insert_WindowBrand);
            migrationBuilder.Sql(SqlScripts.insert_WindowConcernDetail);
            migrationBuilder.Sql(SqlScripts.insert_WindowFramingType);
            migrationBuilder.Sql(SqlScripts.insert_WindowGlassType);
            migrationBuilder.Sql(SqlScripts.insert_WindowScreenType);
            migrationBuilder.Sql(SqlScripts.insert_WindowStyle);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "ForgotPassword");

            migrationBuilder.DropTable(
                name: "InspectionOrderNonWildfireAssessmentMitigationRecommendations");

            migrationBuilder.DropTable(
                name: "InspectionOrderNonWildfireAssessmentMitigationRequirements");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyAdditionalExposureBearInvasionConcernDetails");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyBuildingConcernElectricalConcernDetails");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyBuildingConcernExteriorBuildingConcernDetails");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyBuildingConcernOtherStructureConcernDetails");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyBuildingConcernPlumbingConcernDetails");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyBuildingConcernRoofConcernDetails");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyBuildingConcernSurroundingAreaConcernDetails");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyDetachedStructureOtherDetachedStructuresDetails");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyDetachedStructureOutbuildingDetails");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyGeneralDomesticHelpTypes");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyGeneralPolicyPremiumCredits");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyGeneralWildfireCredits");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyHighValueBathBathroomCounters");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyHighValueBathBathroomFixtures");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyHighValueBathBathroomFloors");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyHighValueBathBathroomVanities");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyHighValueBathTubsAndShowers");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyHighValueFloorToCeilingCeilings");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyHighValueFloorToCeilingFloorCoverings");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyHighValueFloorToCeilingInteriorWallCoverings");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyHighValueFloorToCeilingWallTrims");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyHighValueFloorToCeilingWindowBrands");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyHighValueFloorToCeilingWindowStyles");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyHighValueInteriorFeatureDoorHardwares");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyHighValueInteriorFeatureFireplaceTypes");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyHighValueInteriorFeatureInteriorDoorTypes");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyHighValueInteriorFeatureLightingTypes");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyHighValueInteriorFeatureMiscellaneousExtraFeatures");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyHighValueInteriorFeatureRoomsWithCabinetry");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyHighValueInteriorFeatureStaircases");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyHighValueKitchenApplianceTypes");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyHomeDetailLocales");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyInteriorDetailFlooringTypes");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyInteriorDetailKitchenBathCabinets");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyInteriorDetailKitchenBathCounters");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyInteriorDetailQualityClassUpgrades");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyInteriorDetailTypeOfPlumbings");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyPhotoPhotos");

            migrationBuilder.DropTable(
                name: "InspectionOrderWildfireAssessmentAccessAndFireProtection");

            migrationBuilder.DropTable(
                name: "InspectionOrderWildfireAssessmentDeckAndBalconyDeckConditionConcernDetails");

            migrationBuilder.DropTable(
                name: "InspectionOrderWildfireAssessmentDeckAndBalconyPorchDeckBalconyConstructions");

            migrationBuilder.DropTable(
                name: "InspectionOrderWildfireAssessmentExteriorSidingOtherWallCoverings");

            migrationBuilder.DropTable(
                name: "InspectionOrderWildfireAssessmentExteriorSidingSidingConditionConcernDetails");

            migrationBuilder.DropTable(
                name: "InspectionOrderWildfireAssessmentExternalFuelSourceExternalFuelSourceTypes");

            migrationBuilder.DropTable(
                name: "InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFenceConditionConcernDetails");

            migrationBuilder.DropTable(
                name: "InspectionOrderWildfireAssessmentFencingAndOtherAttachmentFencingTypes");

            migrationBuilder.DropTable(
                name: "InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherAttachmentTypes");

            migrationBuilder.DropTable(
                name: "InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOtherDetachedStructuresDetails");

            migrationBuilder.DropTable(
                name: "InspectionOrderWildfireAssessmentFencingAndOtherAttachmentOutbuildingDetails");

            migrationBuilder.DropTable(
                name: "InspectionOrderWildfireAssessmentFoundationToFrame");

            migrationBuilder.DropTable(
                name: "InspectionOrderWildfireAssessmentMitigationRecommendations");

            migrationBuilder.DropTable(
                name: "InspectionOrderWildfireAssessmentMitigationRequirements");

            migrationBuilder.DropTable(
                name: "InspectionOrderWildfireAssessmentRoofGutterTypes");

            migrationBuilder.DropTable(
                name: "InspectionOrderWildfireAssessmentRoofOtherRoofCoverings");

            migrationBuilder.DropTable(
                name: "InspectionOrderWildfireAssessmentRoofRoofConcernDetails");

            migrationBuilder.DropTable(
                name: "InspectionOrderWildfireAssessmentRoofRoofVentings");

            migrationBuilder.DropTable(
                name: "InspectionOrderWildfireAssessmentSurrounding");

            migrationBuilder.DropTable(
                name: "InspectionOrderWildfireAssessmentWindowExteriorWindowCoveringTypes");

            migrationBuilder.DropTable(
                name: "InspectionOrderWildfireAssessmentWindowInteriorWindowCoveringTypes");

            migrationBuilder.DropTable(
                name: "InspectionOrderWildfireAssessmentWindowWindowConcernDetails");

            migrationBuilder.DropTable(
                name: "InspectionOrderWildfireAssessmentWindowWindowFramingTypes");

            migrationBuilder.DropTable(
                name: "InspectionOrderWildfireAssessmentWindowWindowGlassTypes");

            migrationBuilder.DropTable(
                name: "InspectionOrderWildfireAssessmentWindowWindowScreenTypes");

            migrationBuilder.DropTable(
                name: "InspectionOrderWildfireAssessmentWindowWindowStyles");

            migrationBuilder.DropTable(
                name: "Policy");

            migrationBuilder.DropTable(
                name: "RoleClaim");

            migrationBuilder.DropTable(
                name: "Token");

            migrationBuilder.DropTable(
                name: "UserClaim");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "InspectionOrderNonWildfireAssessmentMitigation");

            migrationBuilder.DropTable(
                name: "BearInvasionConcernDetail");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyAdditionalExposure");

            migrationBuilder.DropTable(
                name: "ElectricalConcernDetail");

            migrationBuilder.DropTable(
                name: "ExteriorBuildingConcernDetail");

            migrationBuilder.DropTable(
                name: "OtherStructureConcernDetail");

            migrationBuilder.DropTable(
                name: "PlumbingConcernDetail");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyBuildingConcern");

            migrationBuilder.DropTable(
                name: "SurroundingAreaConcernDetail");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyDetachedStructure");

            migrationBuilder.DropTable(
                name: "DomesticHelpType");

            migrationBuilder.DropTable(
                name: "PolicyPremiumCredit");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropTable(
                name: "WildfireCredit");

            migrationBuilder.DropTable(
                name: "BathroomCounter");

            migrationBuilder.DropTable(
                name: "BathroomFixture");

            migrationBuilder.DropTable(
                name: "BathroomFloor");

            migrationBuilder.DropTable(
                name: "BathroomVanity");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyHighValueBath");

            migrationBuilder.DropTable(
                name: "TubAndShower");

            migrationBuilder.DropTable(
                name: "Ceiling");

            migrationBuilder.DropTable(
                name: "FloorCovering");

            migrationBuilder.DropTable(
                name: "InteriorWallCovering");

            migrationBuilder.DropTable(
                name: "WallTrim");

            migrationBuilder.DropTable(
                name: "WindowBrand");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyHighValueFloorToCeiling");

            migrationBuilder.DropTable(
                name: "DoorHardware");

            migrationBuilder.DropTable(
                name: "FireplaceType");

            migrationBuilder.DropTable(
                name: "InteriorDoorType");

            migrationBuilder.DropTable(
                name: "LightingType");

            migrationBuilder.DropTable(
                name: "MiscellaneousExtraFeature");

            migrationBuilder.DropTable(
                name: "RoomWithCabinetry");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyHighValueInteriorFeature");

            migrationBuilder.DropTable(
                name: "Staircase");

            migrationBuilder.DropTable(
                name: "ApplianceType");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyHighValueKitchen");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyHomeDetail");

            migrationBuilder.DropTable(
                name: "Locale");

            migrationBuilder.DropTable(
                name: "FlooringType");

            migrationBuilder.DropTable(
                name: "KitchenBathCabinet");

            migrationBuilder.DropTable(
                name: "KitchenBathCounter");

            migrationBuilder.DropTable(
                name: "QualityClassUpgrade");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyInteriorDetail");

            migrationBuilder.DropTable(
                name: "TypeOfPlumbing");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyPhoto");

            migrationBuilder.DropTable(
                name: "PhotoType");

            migrationBuilder.DropTable(
                name: "FireDepartmentStaffing");

            migrationBuilder.DropTable(
                name: "DeckConditionConcernDetail");

            migrationBuilder.DropTable(
                name: "InspectionOrderWildfireAssessmentDeckAndBalcony");

            migrationBuilder.DropTable(
                name: "PorchDeckBalconyConstruction");

            migrationBuilder.DropTable(
                name: "OtherWallCovering");

            migrationBuilder.DropTable(
                name: "InspectionOrderWildfireAssessmentExteriorSiding");

            migrationBuilder.DropTable(
                name: "SidingConditionConcernDetail");

            migrationBuilder.DropTable(
                name: "ExternalFuelSourceType");

            migrationBuilder.DropTable(
                name: "InspectionOrderWildfireAssessmentExternalFuelSource");

            migrationBuilder.DropTable(
                name: "FenceConditionConcernDetail");

            migrationBuilder.DropTable(
                name: "FencingType");

            migrationBuilder.DropTable(
                name: "OtherAttachmentType");

            migrationBuilder.DropTable(
                name: "OtherDetachedStructuresDetail");

            migrationBuilder.DropTable(
                name: "InspectionOrderWildfireAssessmentFencingAndOtherAttachment");

            migrationBuilder.DropTable(
                name: "OutbuildingDetail");

            migrationBuilder.DropTable(
                name: "InspectionOrderWildfireAssessmentMitigation");

            migrationBuilder.DropTable(
                name: "GutterType");

            migrationBuilder.DropTable(
                name: "OtherRoofCovering");

            migrationBuilder.DropTable(
                name: "RoofConcernDetail");

            migrationBuilder.DropTable(
                name: "InspectionOrderWildfireAssessmentRoof");

            migrationBuilder.DropTable(
                name: "RoofVenting");

            migrationBuilder.DropTable(
                name: "ExteriorWindowCoveringType");

            migrationBuilder.DropTable(
                name: "InteriorWindowCoveringType");

            migrationBuilder.DropTable(
                name: "WindowConcernDetail");

            migrationBuilder.DropTable(
                name: "WindowFramingType");

            migrationBuilder.DropTable(
                name: "WindowGlassType");

            migrationBuilder.DropTable(
                name: "WindowScreenType");

            migrationBuilder.DropTable(
                name: "InspectionOrderWildfireAssessmentWindow");

            migrationBuilder.DropTable(
                name: "WindowStyle");

            migrationBuilder.DropTable(
                name: "InspectionStatus");

            migrationBuilder.DropTable(
                name: "MitigationStatus");

            migrationBuilder.DropTable(
                name: "PropertyValue");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "InspectionOrderNonWildfireAssessment");

            migrationBuilder.DropTable(
                name: "CustomerOnSite");

            migrationBuilder.DropTable(
                name: "DogTemperament");

            migrationBuilder.DropTable(
                name: "Employee10HoursPerWeek");

            migrationBuilder.DropTable(
                name: "BurglarAlarmType");

            migrationBuilder.DropTable(
                name: "FireAlarmType");

            migrationBuilder.DropTable(
                name: "OccupancyType");

            migrationBuilder.DropTable(
                name: "SmokeOnlyAlarmType");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "ChimneyType");

            migrationBuilder.DropTable(
                name: "ApplianceBrand");

            migrationBuilder.DropTable(
                name: "KitchenCabinet");

            migrationBuilder.DropTable(
                name: "KitchenCountertop");

            migrationBuilder.DropTable(
                name: "ArchitecturalStyle");

            migrationBuilder.DropTable(
                name: "ConstructionQuality");

            migrationBuilder.DropTable(
                name: "FoundationType");

            migrationBuilder.DropTable(
                name: "FramingType");

            migrationBuilder.DropTable(
                name: "HomeShape");

            migrationBuilder.DropTable(
                name: "SlopeOfSite");

            migrationBuilder.DropTable(
                name: "InspectionOrderProperty");

            migrationBuilder.DropTable(
                name: "PhotoTypeGroup");

            migrationBuilder.DropTable(
                name: "PrimaryExteriorWallCovering");

            migrationBuilder.DropTable(
                name: "SecondaryExteriorWallCovering");

            migrationBuilder.DropTable(
                name: "EavesType");

            migrationBuilder.DropTable(
                name: "PrimaryRoofCovering");

            migrationBuilder.DropTable(
                name: "RoofType");

            migrationBuilder.DropTable(
                name: "SecondaryRoofCovering");

            migrationBuilder.DropTable(
                name: "InspectionOrderWildfireAssessment");

            migrationBuilder.DropTable(
                name: "InspectionOrder");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
