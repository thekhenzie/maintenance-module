using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class RemovedStatusDateOnIOTableAndAddedInceptionDateOnPolicyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusDate",
                table: "InspectionOrder");

            migrationBuilder.AddColumn<DateTime>(
                name: "InceptionDate",
                table: "Policy",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.Sql(SqlScripts.InspectionOrderListView_201807301032);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "InceptionDate",
                table: "Policy");

            migrationBuilder.AddColumn<DateTime>(
                name: "StatusDate",
                table: "InspectionOrder",
                nullable: true);

            migrationBuilder.Sql(SqlScripts.InspectionOrderListView_201807090811);
        }
    }
}
