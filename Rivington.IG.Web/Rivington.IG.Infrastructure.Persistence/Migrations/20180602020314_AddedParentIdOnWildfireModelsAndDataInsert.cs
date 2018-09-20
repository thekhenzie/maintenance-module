using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class AddedParentIdOnWildfireModelsAndDataInsert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          migrationBuilder.Sql(SqlScripts.insert_ExteriorWindowCoveringType);
          migrationBuilder.Sql(SqlScripts.insert_OtherRoofCovering);
          migrationBuilder.Sql(SqlScripts.insert_OtherWallCovering);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          migrationBuilder.Sql("DELETE FROM ExteriorWindowCoveringType");
          migrationBuilder.Sql("DELETE FROM OtherRoofCovering");
          migrationBuilder.Sql("DELETE FROM OtherWallCovering");
        }
    }
}
