using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class IncludedNonWildfireInProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InspectionOrderNonWildfireAssessmentMitigationRecommendations");

            migrationBuilder.DropTable(
                name: "InspectionOrderNonWildfireAssessmentMitigationRequirements");

            migrationBuilder.DropTable(
                name: "InspectionOrderNonWildfireAssessmentMitigation");

            migrationBuilder.DropTable(
                name: "InspectionOrderNonWildfireAssessment");

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyNonWildfireAssessment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyNonWildfireAssessment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionOrderPropertyNonWildfireAssessment_InspectionOrder",
                        column: x => x.Id,
                        principalTable: "InspectionOrderProperty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyNonWildfireAssessmentMitigation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyNonWildfireAssessmentMitigation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionOrderNonWildfireAssessment_IoNwaMitigation",
                        column: x => x.Id,
                        principalTable: "InspectionOrderPropertyNonWildfireAssessment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    InspectionOrderPropertyNonWildfireId = table.Column<Guid>(nullable: false),
                    Photo = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IoNwaMitigationRecommendations_InspectionOrderPropertyNonWildfireAssessmentMitigation",
                        column: x => x.InspectionOrderPropertyNonWildfireId,
                        principalTable: "InspectionOrderPropertyNonWildfireAssessmentMitigation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    InspectionOrderPropertyNonWildfireAssessmentMitigationId = table.Column<Guid>(nullable: true),
                    Photo = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IoNwaMitigationRequirements_InspectionOrderPropertyNonWildfireAssessmentMitigation",
                        column: x => x.InspectionOrderPropertyNonWildfireAssessmentMitigationId,
                        principalTable: "InspectionOrderPropertyNonWildfireAssessmentMitigation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations_InspectionOrderPropertyNonWildfireId",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations",
                column: "InspectionOrderPropertyNonWildfireId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements_InspectionOrderPropertyNonWildfireAssessmentMitigationId",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements",
                column: "InspectionOrderPropertyNonWildfireAssessmentMitigationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyNonWildfireAssessmentMitigation");

            migrationBuilder.DropTable(
                name: "InspectionOrderPropertyNonWildfireAssessment");

            migrationBuilder.CreateTable(
                name: "InspectionOrderNonWildfireAssessment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderNonWildfireAssessment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionOrderNonWildfireAssessment_InspectionOrder",
                        column: x => x.Id,
                        principalTable: "InspectionOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderNonWildfireAssessmentMitigation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderNonWildfireAssessmentMitigation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionOrderNonWildfireAssessment_IoNwaMitigation",
                        column: x => x.Id,
                        principalTable: "InspectionOrderNonWildfireAssessment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderNonWildfireAssessmentMitigationRecommendations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    InspectionOrderNonWildfireAssessmentMitigationId = table.Column<Guid>(nullable: true),
                    Photo = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderNonWildfireAssessmentMitigationRecommendations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IoNwaMitigationRecommendations_InspectionOrderNonWildfireAssessmentMitigation",
                        column: x => x.InspectionOrderNonWildfireAssessmentMitigationId,
                        principalTable: "InspectionOrderNonWildfireAssessmentMitigation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionOrderNonWildfireAssessmentMitigationRequirements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    InspectionOrderNonWildfireAssessmentMitigationId = table.Column<Guid>(nullable: true),
                    Photo = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionOrderNonWildfireAssessmentMitigationRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IoNwaMitigationRequirements_InspectionOrderNonWildfireAssessmentMitigation",
                        column: x => x.InspectionOrderNonWildfireAssessmentMitigationId,
                        principalTable: "InspectionOrderNonWildfireAssessmentMitigation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderNonWildfireAssessmentMitigationRecommendations_InspectionOrderNonWildfireAssessmentMitigationId",
                table: "InspectionOrderNonWildfireAssessmentMitigationRecommendations",
                column: "InspectionOrderNonWildfireAssessmentMitigationId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderNonWildfireAssessmentMitigationRequirements_InspectionOrderNonWildfireAssessmentMitigationId",
                table: "InspectionOrderNonWildfireAssessmentMitigationRequirements",
                column: "InspectionOrderNonWildfireAssessmentMitigationId");
        }
    }
}
