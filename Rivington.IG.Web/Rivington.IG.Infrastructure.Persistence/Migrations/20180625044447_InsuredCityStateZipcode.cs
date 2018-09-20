using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class InsuredCityStateZipcode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InsuredCity",
                table: "Policy",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsuredState",
                table: "Policy",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsuredZipCode",
                table: "Policy",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsuredCity",
                table: "Policy");

            migrationBuilder.DropColumn(
                name: "InsuredState",
                table: "Policy");

            migrationBuilder.DropColumn(
                name: "InsuredZipCode",
                table: "Policy");
        }
    }
}
