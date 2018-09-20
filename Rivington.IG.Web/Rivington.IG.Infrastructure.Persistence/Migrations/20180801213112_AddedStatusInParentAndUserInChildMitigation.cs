using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class AddedStatusInParentAndUserInChildMitigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "InspectionOrderWildfireAssessmentMitigationRequirements",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "InspectionOrderWildfireAssessmentMitigationRecommendations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "InspectionOrderWildfireAssessmentChildMitigationRequirements",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "InspectionOrderWildfireAssessmentChildMitigationRecommendations",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "InspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirements",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "InspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendations",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentChildMitigationRequirements_UserId",
                table: "InspectionOrderWildfireAssessmentChildMitigationRequirements",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentChildMitigationRecommendations_UserId",
                table: "InspectionOrderWildfireAssessmentChildMitigationRecommendations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirements_UserId",
                table: "InspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirements",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendations_UserId",
                table: "InspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendations_User_UserId",
                table: "InspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendations",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirements_User_UserId",
                table: "InspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirements",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionOrderWildfireAssessmentChildMitigationRecommendations_User_UserId",
                table: "InspectionOrderWildfireAssessmentChildMitigationRecommendations",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionOrderWildfireAssessmentChildMitigationRequirements_User_UserId",
                table: "InspectionOrderWildfireAssessmentChildMitigationRequirements",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendations_User_UserId",
                table: "InspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendations");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirements_User_UserId",
                table: "InspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirements");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectionOrderWildfireAssessmentChildMitigationRecommendations_User_UserId",
                table: "InspectionOrderWildfireAssessmentChildMitigationRecommendations");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectionOrderWildfireAssessmentChildMitigationRequirements_User_UserId",
                table: "InspectionOrderWildfireAssessmentChildMitigationRequirements");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderWildfireAssessmentChildMitigationRequirements_UserId",
                table: "InspectionOrderWildfireAssessmentChildMitigationRequirements");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderWildfireAssessmentChildMitigationRecommendations_UserId",
                table: "InspectionOrderWildfireAssessmentChildMitigationRecommendations");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirements_UserId",
                table: "InspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirements");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendations_UserId",
                table: "InspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendations");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "InspectionOrderWildfireAssessmentMitigationRequirements");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "InspectionOrderWildfireAssessmentMitigationRecommendations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "InspectionOrderWildfireAssessmentChildMitigationRequirements");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "InspectionOrderWildfireAssessmentChildMitigationRecommendations");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "InspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirements");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "InspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendations");
        }
    }
}
