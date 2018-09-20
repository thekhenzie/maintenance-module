using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class ChangeCityStringToEntityInGeneral : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "InspectionOrderPropertyGeneral",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyGeneral_CityId",
                table: "InspectionOrderPropertyGeneral",
                column: "CityId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionOrderPropertyGeneral_City",
                table: "InspectionOrderPropertyGeneral",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionOrderPropertyGeneral_City",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyGeneral_CityId",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "InspectionOrderPropertyGeneral",
                nullable: true);
        }
    }
}
