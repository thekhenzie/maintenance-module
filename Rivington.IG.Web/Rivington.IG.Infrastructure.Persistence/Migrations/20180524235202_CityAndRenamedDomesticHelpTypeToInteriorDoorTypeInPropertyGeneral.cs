using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class CityAndRenamedDomesticHelpTypeToInteriorDoorTypeInPropertyGeneral : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionOrderPropertyGeneral_City",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.RenameColumn(
                name: "DomesticHelpTypeIdId",
                table: "InspectionOrderPropertyHighValueInteriorFeatureInteriorDoorTypes",
                newName: "InteriorDoorTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_InspectionOrderPropertyHighValueInteriorFeatureInteriorDoorTypes_DomesticHelpTypeIdId",
                table: "InspectionOrderPropertyHighValueInteriorFeatureInteriorDoorTypes",
                newName: "IX_InspectionOrderPropertyHighValueInteriorFeatureInteriorDoorTypes_InteriorDoorTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionOrderPropertyGeneral_City",
                table: "InspectionOrderPropertyGeneral",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionOrderPropertyGeneral_City",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.RenameColumn(
                name: "InteriorDoorTypeId",
                table: "InspectionOrderPropertyHighValueInteriorFeatureInteriorDoorTypes",
                newName: "DomesticHelpTypeIdId");

            migrationBuilder.RenameIndex(
                name: "IX_InspectionOrderPropertyHighValueInteriorFeatureInteriorDoorTypes_InteriorDoorTypeId",
                table: "InspectionOrderPropertyHighValueInteriorFeatureInteriorDoorTypes",
                newName: "IX_InspectionOrderPropertyHighValueInteriorFeatureInteriorDoorTypes_DomesticHelpTypeIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionOrderPropertyGeneral_City",
                table: "InspectionOrderPropertyGeneral",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
