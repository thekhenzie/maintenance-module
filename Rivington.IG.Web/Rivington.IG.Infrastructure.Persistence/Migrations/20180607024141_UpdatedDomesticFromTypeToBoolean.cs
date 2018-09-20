using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class UpdatedDomesticFromTypeToBoolean : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionOrderPropertyGeneral_DomesticHelp",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropTable(
                name: "DomesticHelp");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyGeneral_DomesticHelpId",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropColumn(
                name: "DomesticHelpId",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.AddColumn<bool>(
                name: "DomesticHelp",
                table: "InspectionOrderPropertyGeneral",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DomesticHelp",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.AddColumn<string>(
                name: "DomesticHelpId",
                table: "InspectionOrderPropertyGeneral",
                nullable: true,
                maxLength: 450);

            migrationBuilder.CreateTable(
                name: "DomesticHelp",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false, maxLength: 450),
                    Name = table.Column<string>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomesticHelp", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyGeneral_DomesticHelpId",
                table: "InspectionOrderPropertyGeneral",
                column: "DomesticHelpId");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionOrderPropertyGeneral_DomesticHelp",
                table: "InspectionOrderPropertyGeneral",
                column: "DomesticHelpId",
                principalTable: "DomesticHelp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
