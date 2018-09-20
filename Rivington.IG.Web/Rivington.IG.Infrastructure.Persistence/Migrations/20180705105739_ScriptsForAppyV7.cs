using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class ScriptsForAppyV7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(SqlScripts.Update_Occupancy_Type_Values);
            migrationBuilder.Sql(SqlScripts.insert_DomesticHelpv7);
            migrationBuilder.Sql(SqlScripts.insert_RoofShape);
            migrationBuilder.Sql(SqlScripts.insert_RoofPitch);
            migrationBuilder.Sql(SqlScripts.insert_NoneValue);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE [dbo].[OccupancyType] SET [Name] = 'Primary' WHERE[ID] = 'P'");
            migrationBuilder.Sql("UPDATE [dbo].[OccupancyType] SET [Name] = 'Secondary' WHERE[ID] = 'S'");
        }
    }
}
