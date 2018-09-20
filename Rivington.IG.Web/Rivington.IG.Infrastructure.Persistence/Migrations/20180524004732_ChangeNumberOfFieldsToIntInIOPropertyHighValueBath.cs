using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class ChangeNumberOfFieldsToIntInIOPropertyHighValueBath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NumberofHalfBath",
                table: "InspectionOrderPropertyHighValueBath",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "NumberofFullBath",
                table: "InspectionOrderPropertyHighValueBath",
                nullable: true,
                oldClrType: typeof(bool));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "NumberofHalfBath",
                table: "InspectionOrderPropertyHighValueBath",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "NumberofFullBath",
                table: "InspectionOrderPropertyHighValueBath",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
