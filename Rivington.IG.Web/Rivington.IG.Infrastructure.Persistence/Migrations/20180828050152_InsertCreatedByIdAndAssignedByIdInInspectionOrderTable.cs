using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class InsertCreatedByIdAndAssignedByIdInInspectionOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(SqlScripts.insert_CreatedByIdAndAssignedById);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
