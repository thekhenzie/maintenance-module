using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class ReplacedPhotoWithDescriptionWithImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_InspectionOrderWildfireAssessmentMitigationRequirements",
                table: "InspectionOrderWildfireAssessmentMitigationRequirements");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderWildfireAssessmentMitigationRequirements_InspectionOrderWildfireAssessmentMitigationId",
                table: "InspectionOrderWildfireAssessmentMitigationRequirements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InspectionOrderWildfireAssessmentMitigationRecommendations",
                table: "InspectionOrderWildfireAssessmentMitigationRecommendations");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderWildfireAssessmentMitigationRecommendations_InspectionOrderWildfireAssessmentMitigationId",
                table: "InspectionOrderWildfireAssessmentMitigationRecommendations");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_InspectionOrderPropertyPhotoPhotos_Id",
                table: "InspectionOrderPropertyPhotoPhotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InspectionOrderPropertyPhotoPhotos",
                table: "InspectionOrderPropertyPhotoPhotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements_InspectionOrderPropertyNonWildfireAssessmentMitigationId",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations_InspectionOrderPropertyNonWildfireId",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "InspectionOrderWildfireAssessmentMitigationRequirements");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "InspectionOrderWildfireAssessmentMitigationRequirements");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "InspectionOrderWildfireAssessmentMitigationRecommendations");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "InspectionOrderWildfireAssessmentMitigationRecommendations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "InspectionOrderPropertyPhotoPhotos");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "InspectionOrderPropertyPhotoPhotos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations");

            migrationBuilder.AlterColumn<Guid>(
                name: "InspectionOrderWildfireAssessmentMitigationId",
                table: "InspectionOrderWildfireAssessmentMitigationRequirements",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "InspectionOrderWildfireAssessmentMitigationRequirements",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "InspectionOrderWildfireAssessmentMitigationId",
                table: "InspectionOrderWildfireAssessmentMitigationRecommendations",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "InspectionOrderWildfireAssessmentMitigationRecommendations",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "InspectionOrderPropertyPhotoPhotos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "InspectionOrderPropertyNonWildfireAssessmentMitigationId",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_InspectionOrderWildfireAssessmentMitigationRequirements",
                table: "InspectionOrderWildfireAssessmentMitigationRequirements",
                columns: new[] { "InspectionOrderWildfireAssessmentMitigationId", "ImageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_InspectionOrderWildfireAssessmentMitigationRecommendations",
                table: "InspectionOrderWildfireAssessmentMitigationRecommendations",
                columns: new[] { "InspectionOrderWildfireAssessmentMitigationId", "ImageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_InspectionOrderPropertyPhotoPhotos",
                table: "InspectionOrderPropertyPhotoPhotos",
                columns: new[] { "InspectionOrderPropertyPhotoId", "ImageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements",
                columns: new[] { "InspectionOrderPropertyNonWildfireAssessmentMitigationId", "ImageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations",
                columns: new[] { "InspectionOrderPropertyNonWildfireId", "ImageId" });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    File = table.Column<byte[]>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    Thumbnail = table.Column<byte[]>(nullable: true),
                    ThumbnailPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentMitigationRequirements_ImageId",
                table: "InspectionOrderWildfireAssessmentMitigationRequirements",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentMitigationRecommendations_ImageId",
                table: "InspectionOrderWildfireAssessmentMitigationRecommendations",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyPhotoPhotos_ImageId",
                table: "InspectionOrderPropertyPhotoPhotos",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyNonWildfireAssessmentMitigation_ImageId",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations_ImageId",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_FilePath",
                table: "Image",
                column: "FilePath",
                unique: true,
                filter: "[FilePath] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Image_ThumbnailPath",
                table: "Image",
                column: "ThumbnailPath",
                unique: true,
                filter: "[ThumbnailPath] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations_Image",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionOrderPropertyNonWildfireAssessmentMitigation_Image",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionOrderPropertyPhotoPhotos_Image",
                table: "InspectionOrderPropertyPhotoPhotos",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionOrderWildfireAssessmentMitigationRecommendations_Image",
                table: "InspectionOrderWildfireAssessmentMitigationRecommendations",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionOrderWildfireAssessmentMitigationRequirements_Image",
                table: "InspectionOrderWildfireAssessmentMitigationRequirements",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations_Image",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectionOrderPropertyNonWildfireAssessmentMitigation_Image",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectionOrderPropertyPhotoPhotos_Image",
                table: "InspectionOrderPropertyPhotoPhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectionOrderWildfireAssessmentMitigationRecommendations_Image",
                table: "InspectionOrderWildfireAssessmentMitigationRecommendations");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectionOrderWildfireAssessmentMitigationRequirements_Image",
                table: "InspectionOrderWildfireAssessmentMitigationRequirements");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InspectionOrderWildfireAssessmentMitigationRequirements",
                table: "InspectionOrderWildfireAssessmentMitigationRequirements");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderWildfireAssessmentMitigationRequirements_ImageId",
                table: "InspectionOrderWildfireAssessmentMitigationRequirements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InspectionOrderWildfireAssessmentMitigationRecommendations",
                table: "InspectionOrderWildfireAssessmentMitigationRecommendations");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderWildfireAssessmentMitigationRecommendations_ImageId",
                table: "InspectionOrderWildfireAssessmentMitigationRecommendations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InspectionOrderPropertyPhotoPhotos",
                table: "InspectionOrderPropertyPhotoPhotos");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyPhotoPhotos_ImageId",
                table: "InspectionOrderPropertyPhotoPhotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyNonWildfireAssessmentMitigation_ImageId",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations");

            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations_ImageId",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "InspectionOrderWildfireAssessmentMitigationRequirements");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "InspectionOrderWildfireAssessmentMitigationRecommendations");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "InspectionOrderPropertyPhotoPhotos");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations");

            migrationBuilder.AlterColumn<Guid>(
                name: "InspectionOrderWildfireAssessmentMitigationId",
                table: "InspectionOrderWildfireAssessmentMitigationRequirements",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "InspectionOrderWildfireAssessmentMitigationRequirements",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "InspectionOrderWildfireAssessmentMitigationRequirements",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "InspectionOrderWildfireAssessmentMitigationId",
                table: "InspectionOrderWildfireAssessmentMitigationRecommendations",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "InspectionOrderWildfireAssessmentMitigationRecommendations",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "InspectionOrderWildfireAssessmentMitigationRecommendations",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "InspectionOrderPropertyPhotoPhotos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "InspectionOrderPropertyPhotoPhotos",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "InspectionOrderPropertyNonWildfireAssessmentMitigationId",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InspectionOrderWildfireAssessmentMitigationRequirements",
                table: "InspectionOrderWildfireAssessmentMitigationRequirements",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InspectionOrderWildfireAssessmentMitigationRecommendations",
                table: "InspectionOrderWildfireAssessmentMitigationRecommendations",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_InspectionOrderPropertyPhotoPhotos_Id",
                table: "InspectionOrderPropertyPhotoPhotos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InspectionOrderPropertyPhotoPhotos",
                table: "InspectionOrderPropertyPhotoPhotos",
                columns: new[] { "InspectionOrderPropertyPhotoId", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentMitigationRequirements_InspectionOrderWildfireAssessmentMitigationId",
                table: "InspectionOrderWildfireAssessmentMitigationRequirements",
                column: "InspectionOrderWildfireAssessmentMitigationId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderWildfireAssessmentMitigationRecommendations_InspectionOrderWildfireAssessmentMitigationId",
                table: "InspectionOrderWildfireAssessmentMitigationRecommendations",
                column: "InspectionOrderWildfireAssessmentMitigationId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements_InspectionOrderPropertyNonWildfireAssessmentMitigationId",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRequirements",
                column: "InspectionOrderPropertyNonWildfireAssessmentMitigationId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations_InspectionOrderPropertyNonWildfireId",
                table: "InspectionOrderPropertyNonWildfireAssessmentMitigationRecommendations",
                column: "InspectionOrderPropertyNonWildfireId");
        }
    }
}
