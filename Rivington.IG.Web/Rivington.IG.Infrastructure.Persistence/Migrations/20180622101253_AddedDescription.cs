using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class AddedDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations");
        }
    }
}
