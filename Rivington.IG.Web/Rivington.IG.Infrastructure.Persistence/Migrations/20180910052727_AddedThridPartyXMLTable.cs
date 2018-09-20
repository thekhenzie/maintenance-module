using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class AddedThridPartyXMLTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ThirdPartyXML",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    E2ValueXML = table.Column<string>(nullable: true),
                    InspectionOrderId = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    PolicyXML = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThirdPartyXML", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThirdPartyXML_InspectionOrder_InspectionOrderId",
                        column: x => x.InspectionOrderId,
                        principalTable: "InspectionOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThirdPartyXML_InspectionOrderId",
                table: "ThirdPartyXML",
                column: "InspectionOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThirdPartyXML");
        }
    }
}
