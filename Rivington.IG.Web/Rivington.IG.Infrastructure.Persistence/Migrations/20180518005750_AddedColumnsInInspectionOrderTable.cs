using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class addedcolumnsininspectionordertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAssigned",
                table: "InspectionOrder",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<Guid>(
                name: "AssignedById",
                table: "InspectionOrder",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "InspectionOrder",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InspectionDate",
                table: "InspectionOrder",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StatusDate",
                table: "InspectionOrder",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrder_AssignedById",
                table: "InspectionOrder",
                column: "AssignedById");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrder_CreatedById",
                table: "InspectionOrder",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionOrder_User_AssignedById",
                table: "InspectionOrder",
                column: "AssignedById",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionOrder_User_CreatedById",
                table: "InspectionOrder",
                column: "CreatedById",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "InspectionOrder",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "DateAssigned",
                table: "InspectionOrder",
                newName: "AssignedDate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StatusDate",
                table: "InspectionOrder",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InspectionDate",
                table: "InspectionOrder",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionOrder_User_AssignedById",
                table: "InspectionOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectionOrder_User_CreatedById",
                table: "InspectionOrder");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrder_AssignedById",
                table: "InspectionOrder");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrder_CreatedById",
                table: "InspectionOrder");

            migrationBuilder.DropColumn(
                name: "AssignedById",
                table: "InspectionOrder");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "InspectionOrder");

            migrationBuilder.DropColumn(
                name: "InspectionDate",
                table: "InspectionOrder");

            migrationBuilder.DropColumn(
                name: "StatusDate",
                table: "InspectionOrder");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAssigned",
                table: "InspectionOrder",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "InspectionOrder",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "AssignedDate",
                table: "InspectionOrder",
                newName: "DateAssigned");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StatusDate",
                table: "InspectionOrder",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InspectionDate",
                table: "InspectionOrder",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
