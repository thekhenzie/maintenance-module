using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class AddedIsLockedColumnInInspectionOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "InspectionOrder",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "IsLockedById",
                table: "InspectionOrder",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrder_IsLockedById",
                table: "InspectionOrder",
                column: "IsLockedById");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionOrder_User_IsLockedById",
                table: "InspectionOrder",
                column: "IsLockedById",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "InspectionOrder");

            migrationBuilder.DropForeignKey(
               name: "FK_InspectionOrder_User_IsLockedById",
               table: "InspectionOrder");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrder_IsLockedById",
                table: "InspectionOrder");

            migrationBuilder.DropColumn(
                name: "IsLockedById",
                table: "InspectionOrder");
        }
    }
}
