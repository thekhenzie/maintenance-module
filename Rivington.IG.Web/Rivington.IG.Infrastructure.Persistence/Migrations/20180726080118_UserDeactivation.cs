using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class UserDeactivation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActivated",
                table: "User",
                nullable: false,
                defaultValue: true);

            migrationBuilder.Sql(SqlScripts.UserManagementListView_201807261547);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActivated",
                table: "User");

            migrationBuilder.Sql(SqlScripts.UserManagementListView_201806221654);
        }
    }
}
