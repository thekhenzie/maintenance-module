using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class ModifiedApplianceRelationToHVKitchen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionOrderPropertyHighValueKitchen_ApplianceBrand",
                table: "InspectionOrderPropertyHighValueKitchen");

          migrationBuilder.Sql(
            "IF EXISTS(SELECT * FROM sys.indexes WHERE object_id = object_id('dbo.InspectionOrderPropertyHighValueKitchen') AND NAME ='IX_InspectionOrderPropertyHighValueKitchen_ApplianceBrandId') DROP INDEX IX_InspectionOrderPropertyHighValueKitchen_ApplianceBrandId ON dbo.InspectionOrderPropertyHighValueKitchen;");

            migrationBuilder.DropColumn(
                name: "ApplianceBrandId",
                table: "InspectionOrderPropertyHighValueKitchen");

            migrationBuilder.DropColumn(
                name: "NumberofApplicance",
                table: "InspectionOrderPropertyHighValueKitchen");

            migrationBuilder.AddColumn<string>(
                name: "ApplianceBrandId",
                table: "InspectionOrderPropertyHighValueKitchenApplianceTypes",
                nullable: false,
                defaultValue: "");
          
            migrationBuilder.DropPrimaryKey(
              name: "PK_InspectionOrderPropertyHighValueKitchenApplianceTypes",
              table: "InspectionOrderPropertyHighValueKitchenApplianceTypes");

            migrationBuilder.AddPrimaryKey(
              name: "PK_InspectionOrderPropertyHighValueKitchenApplianceTypes",
              table: "InspectionOrderPropertyHighValueKitchenApplianceTypes",
              columns: new[] { "InspectionOrderPropertyHighValueKitchenId", "ApplianceTypeId", "ApplianceBrandId" });

            migrationBuilder.AddColumn<int>(
                name: "NumberofApplicance",
                table: "InspectionOrderPropertyHighValueKitchenApplianceTypes",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionOrderPropertyHighValueKitchenApplianceTypes_ApplianceBrand",
                table: "InspectionOrderPropertyHighValueKitchenApplianceTypes",
                column: "ApplianceBrandId",
                principalTable: "ApplianceBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHighValueKitchenApplianceTypes_ApplianceBrandId",
                table: "InspectionOrderPropertyHighValueKitchenApplianceTypes",
                column: "ApplianceBrandId",
                unique: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionOrderPropertyHighValueKitchenApplianceTypes_ApplianceBrand",
                table: "InspectionOrderPropertyHighValueKitchenApplianceTypes");
          
            migrationBuilder.DropPrimaryKey(
                name: "PK_InspectionOrderPropertyHighValueKitchenApplianceTypes",
                table: "InspectionOrderPropertyHighValueKitchenApplianceTypes");

            migrationBuilder.DropIndex(
              name: "IX_InspectionOrderPropertyHighValueKitchenApplianceTypes_ApplianceBrandId",
              table: "InspectionOrderPropertyHighValueKitchenApplianceTypes");

            migrationBuilder.DropColumn(
                name: "ApplianceBrandId",
                table: "InspectionOrderPropertyHighValueKitchenApplianceTypes");

            migrationBuilder.DropColumn(
                name: "NumberofApplicance",
                table: "InspectionOrderPropertyHighValueKitchenApplianceTypes");

            migrationBuilder.AddColumn<string>(
                name: "ApplianceBrandId",
                table: "InspectionOrderPropertyHighValueKitchen",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberofApplicance",
                table: "InspectionOrderPropertyHighValueKitchen",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InspectionOrderPropertyHighValueKitchenApplianceTypes",
                table: "InspectionOrderPropertyHighValueKitchenApplianceTypes",
                columns: new[] { "InspectionOrderPropertyHighValueKitchenId", "ApplianceTypeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionOrderPropertyHighValueKitchen_ApplianceBrand",
                table: "InspectionOrderPropertyHighValueKitchen",
                column: "ApplianceBrandId",
                principalTable: "ApplianceBrand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
