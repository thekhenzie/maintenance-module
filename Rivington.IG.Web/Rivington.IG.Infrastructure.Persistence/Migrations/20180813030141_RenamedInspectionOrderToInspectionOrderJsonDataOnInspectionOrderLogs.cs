using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class RenamedInspectionOrderToInspectionOrderJsonDataOnInspectionOrderLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InspectionOrder",
                table: "InspectionOrderLogs",
                newName: "InspectionOrderJsonData");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InspectionOrderJsonData",
                table: "InspectionOrderLogs",
                newName: "InspectionOrder");
        }
    }
}
