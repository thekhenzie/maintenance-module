using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class CityNotNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionOrderPropertyGeneral_City",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "InspectionOrderPropertyGeneral",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "InspectionOrderPropertyGeneral",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionOrderPropertyGeneral_City",
                table: "InspectionOrderPropertyGeneral",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
