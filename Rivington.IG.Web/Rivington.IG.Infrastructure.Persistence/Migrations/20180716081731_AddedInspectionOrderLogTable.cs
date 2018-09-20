using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class AddedInspectionOrderLogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InspectionOrderLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InspectionOrder = table.Column<string>(nullable: true),
                    InspectionOrderId = table.Column<Guid>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    ActionDescription = table.Column<string>(nullable: true),
                    CreatedById = table.Column<Guid>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderLogs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderLogs_CreatedById",
                table: "InspectionOrderLogs",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderLogs_InspectionOrderId",
                table: "InspectionOrderLogs",
                column: "InspectionOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionOrderLogs_User_CreatedById",
                table: "InspectionOrderLogs",
                column: "CreatedById",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionOrderLogs_InspectionOrder_InspectionOrderId",
                table: "InspectionOrderLogs",
                column: "InspectionOrderId",
                principalTable: "InspectionOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InspectionOrderLogs");
        }
    }
}
