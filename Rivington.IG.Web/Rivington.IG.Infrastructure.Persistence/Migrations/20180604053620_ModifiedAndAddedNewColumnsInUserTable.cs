using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class ModifiedAndAddedNewColumnsInUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
               name: "ProfilePhoto",
               table: "User",
               nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobileNumber",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetAddress1",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetAddress2",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "User",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "User",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ProfilePhoto",
                table: "User");

            migrationBuilder.DropColumn(
               name: "City",
               table: "User");

            migrationBuilder.DropColumn(
                name: "MobileNumber",
                table: "User");

            migrationBuilder.DropColumn(
                name: "State",
                table: "User");

            migrationBuilder.DropColumn(
                name: "StreetAddress1",
                table: "User");

            migrationBuilder.DropColumn(
                name: "StreetAddress2",
                table: "User");

            migrationBuilder.DropColumn(
               name: "ZipCode",
               table: "User");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDate",
                table: "User",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

        }
    }
}
