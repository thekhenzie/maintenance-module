using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class NullableUserInChildMitigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "InspectionOrderWildfireAssessmentChildMitigationRequirements",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "InspectionOrderWildfireAssessmentChildMitigationRecommendations",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "InspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirements",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "InspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendations",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendations_User_UserId",
                table: "InspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendations",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirements_User_UserId",
                table: "InspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirements",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionOrderWildfireAssessmentChildMitigationRecommendations_User_UserId",
                table: "InspectionOrderWildfireAssessmentChildMitigationRecommendations",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionOrderWildfireAssessmentChildMitigationRequirements_User_UserId",
                table: "InspectionOrderWildfireAssessmentChildMitigationRequirements",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
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

            // Drop Index
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

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "InspectionOrderWildfireAssessmentChildMitigationRequirements",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "InspectionOrderWildfireAssessmentChildMitigationRecommendations",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "InspectionOrderPropertyNonWildfireAssessmentChildMitigationRequirements",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "InspectionOrderPropertyNonWildfireAssessmentChildMitigationRecommendations",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            // Create Index
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
    }
}
