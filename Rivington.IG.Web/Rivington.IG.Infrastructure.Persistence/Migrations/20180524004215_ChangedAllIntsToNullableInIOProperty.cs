using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class ChangedAllIntsToNullableInIOProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
              name: "FK_InspectionOrderPropertyGeneral_City",
              table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropIndex(
              name: "IX_InspectionOrderPropertyGeneral_CityId",
              table: "InspectionOrderPropertyGeneral");

            migrationBuilder.AlterColumn<int>(
              name: "CityId",
              table: "InspectionOrderPropertyGeneral",
              nullable: true,
              oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
              name: "IX_InspectionOrderPropertyGeneral_CityId",
              table: "InspectionOrderPropertyGeneral",
              column: "CityId",
              unique: true,
              filter: "[CityId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
              name: "FK_InspectionOrderPropertyGeneral_City",
              table: "InspectionOrderPropertyGeneral",
              column: "CityId",
              principalTable: "City",
              principalColumn: "Id",
              onDelete: ReferentialAction.Restrict);

            migrationBuilder.AlterColumn<int>(
                name: "YearBuilt",
                table: "InspectionOrderPropertyGeneral",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "WaterHeaterAge",
                table: "InspectionOrderPropertyGeneral",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "RoofAge",
                table: "InspectionOrderPropertyGeneral",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MajorSystemAge",
                table: "InspectionOrderPropertyGeneral",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "EstimatedSquareFootage",
                table: "InspectionOrderPropertyGeneral",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "NumberofStories",
                table: "InspectionOrderPropertyHomeDetail",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "NumberofApplicance",
                table: "InspectionOrderPropertyHighValueKitchen",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "NumberofFireplace",
                table: "InspectionOrderPropertyHighValueInteriorFeature",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "NumberofChimney",
                table: "InspectionOrderPropertyHighValueFloorToCeiling",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "NumberofDog",
                table: "InspectionOrderPropertyAdditionalExposure",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "HorsesFarmAnimalCount",
                table: "InspectionOrderPropertyAdditionalExposure",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
              name: "FK_InspectionOrderPropertyGeneral_City",
              table: "InspectionOrderPropertyGeneral");

            migrationBuilder.DropIndex(
              name: "IX_InspectionOrderPropertyGeneral_CityId",
              table: "InspectionOrderPropertyGeneral");

            migrationBuilder.AlterColumn<int>(
              name: "CityId",
              table: "InspectionOrderPropertyGeneral",
              nullable: false,
              oldClrType: typeof(int),
              oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "YearBuilt",
                table: "InspectionOrderPropertyGeneral",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WaterHeaterAge",
                table: "InspectionOrderPropertyGeneral",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RoofAge",
                table: "InspectionOrderPropertyGeneral",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MajorSystemAge",
                table: "InspectionOrderPropertyGeneral",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EstimatedSquareFootage",
                table: "InspectionOrderPropertyGeneral",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NumberofStories",
                table: "InspectionOrderPropertyHomeDetail",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NumberofApplicance",
                table: "InspectionOrderPropertyHighValueKitchen",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NumberofFireplace",
                table: "InspectionOrderPropertyHighValueInteriorFeature",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NumberofChimney",
                table: "InspectionOrderPropertyHighValueFloorToCeiling",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NumberofDog",
                table: "InspectionOrderPropertyAdditionalExposure",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HorsesFarmAnimalCount",
                table: "InspectionOrderPropertyAdditionalExposure",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
