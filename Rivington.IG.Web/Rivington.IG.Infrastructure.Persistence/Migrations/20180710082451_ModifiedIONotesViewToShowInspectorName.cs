using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class ModifiedIONotesViewToShowInspectorName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(SqlScripts.InspectionOrderNotesView_201807101609);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(SqlScripts.InspectionOrderNotesView);
        }
    }
}
