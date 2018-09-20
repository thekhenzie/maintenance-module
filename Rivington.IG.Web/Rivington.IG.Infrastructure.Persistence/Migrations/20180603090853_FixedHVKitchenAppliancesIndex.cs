using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class FixedHVKitchenAppliancesIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyHighValueKitchenAppliances_ApplianceBrandId",
                table: "InspectionOrderPropertyHighValueKitchenAppliances");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyHighValueKitchenAppliances_ApplianceTypeId",
                table: "InspectionOrderPropertyHighValueKitchenAppliances");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHighValueKitchenAppliances_ApplianceBrandId",
                table: "InspectionOrderPropertyHighValueKitchenAppliances",
                column: "ApplianceBrandId",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHighValueKitchenAppliances_ApplianceTypeId",
                table: "InspectionOrderPropertyHighValueKitchenAppliances",
                column: "ApplianceTypeId",
                unique: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyHighValueKitchenAppliances_ApplianceBrandId",
                table: "InspectionOrderPropertyHighValueKitchenAppliances");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyHighValueKitchenAppliances_ApplianceTypeId",
                table: "InspectionOrderPropertyHighValueKitchenAppliances");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHighValueKitchenAppliances_ApplianceBrandId",
                table: "InspectionOrderPropertyHighValueKitchenAppliances",
                column: "ApplianceBrandId",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHighValueKitchenAppliances_ApplianceTypeId",
                table: "InspectionOrderPropertyHighValueKitchenAppliances",
                column: "ApplianceTypeId",
                unique: false);
        }
    }
}
