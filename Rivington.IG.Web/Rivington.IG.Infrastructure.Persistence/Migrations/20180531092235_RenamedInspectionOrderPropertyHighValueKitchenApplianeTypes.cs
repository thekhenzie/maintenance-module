using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class RenamedInspectionOrderPropertyHighValueKitchenApplianeTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
              name: "InspectionOrderPropertyHighValueKitchenApplianceTypes");

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyHighValueKitchenAppliances",
                columns: table => new
                {
                    InspectionOrderPropertyHighValueKitchenId = table.Column<Guid>(nullable: false),
                    ApplianceTypeId = table.Column<string>(nullable: false),
                    ApplianceBrandId = table.Column<string>(nullable: false),
                    NumberofApplicance = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyHighValueKitchenAppliances", x => new { x.InspectionOrderPropertyHighValueKitchenId, x.ApplianceTypeId, x.ApplianceBrandId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueKitchenAppliances_ApplianceBrand",
                        column: x => x.ApplianceBrandId,
                        principalTable: "ApplianceBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueKitchenAppliances_ApplianceType",
                        column: x => x.ApplianceTypeId,
                        principalTable: "ApplianceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueKitchenAppliances_InspectionOrderPropertyHighValueKitchen",
                        column: x => x.InspectionOrderPropertyHighValueKitchenId,
                        principalTable: "InspectionOrderPropertyHighValueKitchen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHighValueKitchenAppliances_ApplianceBrandId",
                table: "InspectionOrderPropertyHighValueKitchenAppliances",
                column: "ApplianceBrandId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHighValueKitchenAppliances_ApplianceTypeId",
                table: "InspectionOrderPropertyHighValueKitchenAppliances",
                column: "ApplianceTypeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyHighValueKitchenAppliances");

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyHighValueKitchenApplianceTypes",
                columns: table => new
                {
                    InspectionOrderPropertyHighValueKitchenId = table.Column<Guid>(nullable: false),
                    ApplianceTypeId = table.Column<string>(nullable: false, maxLength: 450),
                    ApplianceBrandId = table.Column<string>(nullable: false, maxLength: 450),
                    NumberofApplicance = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyHighValueKitchenApplianceTypes", x => new { x.InspectionOrderPropertyHighValueKitchenId, x.ApplianceTypeId, x.ApplianceBrandId });
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyHighValueKitchenApplianceTypes_ApplianceBrand",
                        column: x => x.ApplianceBrandId,
                        principalTable: "ApplianceBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHighValueKitchenApplianceTypes_ApplianceBrandId",
                table: "InspectionOrderPropertyHighValueKitchenApplianceTypes",
                column: "ApplianceBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHighValueKitchenApplianceTypes_ApplianceTypeId",
                table: "InspectionOrderPropertyHighValueKitchenApplianceTypes",
                column: "ApplianceTypeId");
        }
    }
}
