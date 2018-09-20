using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class UpdatedTypeCentalToCentralData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          migrationBuilder.Sql("UPDATE FireAlarmType SET [Name] = 'Central' WHERE [Id] = 'C'");
          migrationBuilder.Sql("UPDATE SmokeOnlyAlarmType SET [Name] = 'Central' WHERE [Id] = 'C'");
          migrationBuilder.Sql("UPDATE BurglarAlarmType SET [Name] = 'Central' WHERE [Id] = 'C'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          migrationBuilder.Sql("UPDATE FireAlarmType SET [Name] = 'Cental' WHERE [Id] = 'C'");
          migrationBuilder.Sql("UPDATE SmokeOnlyAlarmType SET [Name] = 'Cental' WHERE [Id] = 'C'");
          migrationBuilder.Sql("UPDATE BurglarAlarmType SET [Name] = 'Cental' WHERE [Id] = 'C'");
        }
    }
}
