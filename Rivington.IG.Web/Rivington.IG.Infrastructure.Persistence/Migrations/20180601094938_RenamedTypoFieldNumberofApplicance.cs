using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class RenamedTypoFieldNumberofApplicance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberofApplicance",
                table: "InspectionOrderPropertyHighValueKitchenAppliances",
                newName: "NumberofAppliance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberofAppliance",
                table: "InspectionOrderPropertyHighValueKitchenAppliances",
                newName: "NumberofApplicance");
        }
    }
}
