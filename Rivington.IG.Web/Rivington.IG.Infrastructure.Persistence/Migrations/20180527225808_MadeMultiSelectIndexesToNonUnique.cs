using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class MadeMultiSelectIndexesToNonUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          migrationBuilder.Sql(SqlScripts.MultiSelectIndexesToNonUnique_UP);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          migrationBuilder.Sql(SqlScripts.MultiSelectIndexesToNonUnique_DOWN);
        }
    }
}
