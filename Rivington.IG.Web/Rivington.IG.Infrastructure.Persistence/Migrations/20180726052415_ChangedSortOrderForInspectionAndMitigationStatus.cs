using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class ChangedSortOrderForInspectionAndMitigationStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(SqlScripts.insert_InspectionStatus_SortOrder);
            migrationBuilder.Sql(SqlScripts.insert_MitigationStatus_SortOrder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE InspectionStatus SET SortOrder = 1");
            migrationBuilder.Sql("UPDATE MitigationStatus SET SortOrder = 1");
        }
    }
}
