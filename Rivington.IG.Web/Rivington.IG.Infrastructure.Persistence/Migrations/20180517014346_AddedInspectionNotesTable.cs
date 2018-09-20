using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class addedinspectionnotestable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InspectionOrderNotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Datemodified = table.Column<DateTime>(nullable: false),
                    InspectionOrderId = table.Column<Guid>(nullable: false),
                    ModifiedById = table.Column<Guid>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionOrderNotes_InspectionOrder_InspectionOrderId",
                        column: x => x.InspectionOrderId,
                        principalTable: "InspectionOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspectionOrderNotes_User_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderNotes_InspectionOrderId",
                table: "InspectionOrderNotes",
                column: "InspectionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderNotes_ModifiedById",
                table: "InspectionOrderNotes",
                column: "ModifiedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InspectionOrderNotes");
        }
    }
}
