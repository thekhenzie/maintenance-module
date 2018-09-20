using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class AllowNullsCityId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionOrderPropertyGeneral_City",
                table: "InspectionOrderPropertyGeneral");

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
