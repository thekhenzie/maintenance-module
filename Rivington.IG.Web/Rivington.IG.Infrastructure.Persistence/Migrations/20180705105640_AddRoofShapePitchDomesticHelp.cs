using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class AddRoofShapePitchDomesticHelp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DomesticHelp",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.AddColumn<string>(
                name: "RoofPitchId",
                table: "InspectionOrderWildfireAssessmentRoof",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoofShapeId",
                table: "InspectionOrderWildfireAssessmentRoof",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoofPitchId",
                table: "InspectionOrderPropertyHomeDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoofShapeId",
                table: "InspectionOrderPropertyHomeDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DomesticHelpTypeId",
                table: "InspectionOrderPropertyGeneral",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DomesticHelp",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomesticHelp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoofPitch",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoofPitch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoofShape",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoofShape", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentRoof_RoofPitchId",
                table: "InspectionOrderWildfireAssessmentRoof",
                column: "RoofPitchId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentRoof_RoofShapeId",
                table: "InspectionOrderWildfireAssessmentRoof",
                column: "RoofShapeId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_RoofPitchId",
                table: "InspectionOrderPropertyHomeDetail",
                column: "RoofPitchId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_RoofShapeId",
                table: "InspectionOrderPropertyHomeDetail",
                column: "RoofShapeId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyGeneral_DomesticHelpTypeId",
                table: "InspectionOrderPropertyGeneral",
                column: "DomesticHelpTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionOrderPropertyGeneral_DomesticHelp",
                table: "InspectionOrderPropertyGeneral",
                column: "DomesticHelpTypeId",
                principalTable: "DomesticHelp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionOrderPropertyHomeDetail_RoofPitch",
                table: "InspectionOrderPropertyHomeDetail",
                column: "RoofPitchId",
                principalTable: "RoofPitch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionOrderPropertyHomeDetail_RoofShape",
                table: "InspectionOrderPropertyHomeDetail",
                column: "RoofShapeId",
                principalTable: "RoofShape",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IoWaRoof_RoofPitch",
                table: "InspectionOrderWildfireAssessmentRoof",
                column: "RoofPitchId",
                principalTable: "RoofPitch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IoWaRoof_RoofShape",
                table: "InspectionOrderWildfireAssessmentRoof",
                column: "RoofShapeId",
                principalTable: "RoofShape",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionOrderPropertyGeneral_DomesticHelp",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectionOrderPropertyHomeDetail_RoofPitch",
                table: "InspectionOrderPropertyHomeDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectionOrderPropertyHomeDetail_RoofShape",
                table: "InspectionOrderPropertyHomeDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_IoWaRoof_RoofPitch",
                table: "InspectionOrderWildfireAssessmentRoof");

            migrationBuilder.DropForeignKey(
                name: "FK_IoWaRoof_RoofShape",
                table: "InspectionOrderWildfireAssessmentRoof");

            migrationBuilder.DropTable(
                name: "DomesticHelp");

            migrationBuilder.DropTable(
                name: "RoofPitch");

            migrationBuilder.DropTable(
                name: "RoofShape");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderWildfireAssessmentRoof_RoofPitchId",
                table: "InspectionOrderWildfireAssessmentRoof");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderWildfireAssessmentRoof_RoofShapeId",
                table: "InspectionOrderWildfireAssessmentRoof");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_RoofPitchId",
                table: "InspectionOrderPropertyHomeDetail");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyHomeDetail_RoofShapeId",
                table: "InspectionOrderPropertyHomeDetail");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyGeneral_DomesticHelpTypeId",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropColumn(
                name: "RoofPitchId",
                table: "InspectionOrderWildfireAssessmentRoof");

            migrationBuilder.DropColumn(
                name: "RoofShapeId",
                table: "InspectionOrderWildfireAssessmentRoof");

            migrationBuilder.DropColumn(
                name: "RoofPitchId",
                table: "InspectionOrderPropertyHomeDetail");

            migrationBuilder.DropColumn(
                name: "RoofShapeId",
                table: "InspectionOrderPropertyHomeDetail");

            migrationBuilder.DropColumn(
                name: "DomesticHelpTypeId",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.AddColumn<bool>(
                name: "DomesticHelp",
                table: "InspectionOrderPropertyGeneral",
                nullable: false,
                defaultValue: false);
        }
    }
}
