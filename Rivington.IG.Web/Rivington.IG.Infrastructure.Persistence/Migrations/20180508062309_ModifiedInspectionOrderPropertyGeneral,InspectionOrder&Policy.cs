using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class ModifiedInspectionOrderPropertyGeneralInspectionOrderPolicy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BurglarAlarm",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropColumn(
                name: "DomesticHelp",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropColumn(
                name: "FireAlarm",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropColumn(
                name: "SmokeOnlyAlarm",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.AddColumn<string>(
                name: "BurglarAlarmId",
                table: "InspectionOrderPropertyGeneral",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DomesticHelpId",
                table: "InspectionOrderPropertyGeneral",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FireAlarmId",
                table: "InspectionOrderPropertyGeneral",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SmokeOnlyAlarmId",
                table: "InspectionOrderPropertyGeneral",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BurglarAlarm",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BurglarAlarm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DomesticHelp",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomesticHelp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FireAlarm",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireAlarm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmokeOnlyAlarm",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmokeOnlyAlarm", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyGeneral_BurglarAlarmId",
                table: "InspectionOrderPropertyGeneral",
                column: "BurglarAlarmId",
                unique: true,
                filter: "[BurglarAlarmId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyGeneral_DomesticHelpId",
                table: "InspectionOrderPropertyGeneral",
                column: "DomesticHelpId",
                unique: true,
                filter: "[DomesticHelpId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyGeneral_FireAlarmId",
                table: "InspectionOrderPropertyGeneral",
                column: "FireAlarmId",
                unique: true,
                filter: "[FireAlarmId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyGeneral_SmokeOnlyAlarmId",
                table: "InspectionOrderPropertyGeneral",
                column: "SmokeOnlyAlarmId",
                unique: true,
                filter: "[SmokeOnlyAlarmId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionOrderPropertyGeneral_BurglarAlarm",
                table: "InspectionOrderPropertyGeneral",
                column: "BurglarAlarmId",
                principalTable: "BurglarAlarm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionOrderPropertyGeneral_DomesticHelp",
                table: "InspectionOrderPropertyGeneral",
                column: "DomesticHelpId",
                principalTable: "DomesticHelp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionOrderPropertyGeneral_FireAlarm",
                table: "InspectionOrderPropertyGeneral",
                column: "FireAlarmId",
                principalTable: "FireAlarm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionOrderPropertyGeneral_SmokeOnlyAlarm",
                table: "InspectionOrderPropertyGeneral",
                column: "SmokeOnlyAlarmId",
                principalTable: "SmokeOnlyAlarm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.Sql(SqlScripts.insert_BurglarAlarm);
            migrationBuilder.Sql(SqlScripts.insert_DomesticHelp);
            migrationBuilder.Sql(SqlScripts.insert_FireAlarm);
            migrationBuilder.Sql(SqlScripts.insert_SmokeOnlyAlarm);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionOrderPropertyGeneral_BurglarAlarm",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectionOrderPropertyGeneral_DomesticHelp",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectionOrderPropertyGeneral_FireAlarm",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectionOrderPropertyGeneral_SmokeOnlyAlarm",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropTable(
                name: "BurglarAlarm");

            migrationBuilder.DropTable(
                name: "DomesticHelp");

            migrationBuilder.DropTable(
                name: "FireAlarm");

            migrationBuilder.DropTable(
                name: "SmokeOnlyAlarm");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyGeneral_BurglarAlarmId",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyGeneral_DomesticHelpId",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyGeneral_FireAlarmId",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyGeneral_SmokeOnlyAlarmId",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropColumn(
                name: "BurglarAlarmId",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropColumn(
                name: "DomesticHelpId",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropColumn(
                name: "FireAlarmId",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropColumn(
                name: "SmokeOnlyAlarmId",
                table: "InspectionOrderPropertyGeneral");

            migrationBuilder.AddColumn<bool>(
                name: "BurglarAlarm",
                table: "InspectionOrderPropertyGeneral",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DomesticHelp",
                table: "InspectionOrderPropertyGeneral",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FireAlarm",
                table: "InspectionOrderPropertyGeneral",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SmokeOnlyAlarm",
                table: "InspectionOrderPropertyGeneral",
                nullable: false,
                defaultValue: false);
        }
    }
}
