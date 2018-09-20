using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class MadeIntWildfireFieldsToNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ExternalFuelSourceDistanceFromHome",
                table: "InspectionOrderWildfireAssessmentExternalFuelSource",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "FireDepartmentTravelTimetoHome",
                table: "InspectionOrderWildfireAssessmentAccessAndFireProtection",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ExternalFuelSourceDistanceFromHome",
                table: "InspectionOrderWildfireAssessmentExternalFuelSource",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FireDepartmentTravelTimetoHome",
                table: "InspectionOrderWildfireAssessmentAccessAndFireProtection",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
