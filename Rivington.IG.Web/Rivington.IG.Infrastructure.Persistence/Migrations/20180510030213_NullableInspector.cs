using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class NullableInspector : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionOrder_User_InspectorId",
                table: "InspectionOrder");

            migrationBuilder.AlterColumn<Guid>(
                name: "InspectorId",
                table: "InspectionOrder",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionOrder_User_InspectorId",
                table: "InspectionOrder",
                column: "InspectorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionOrder_User_InspectorId",
                table: "InspectionOrder");

            migrationBuilder.AlterColumn<Guid>(
                name: "InspectorId",
                table: "InspectionOrder",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionOrder_User_InspectorId",
                table: "InspectionOrder",
                column: "InspectorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
