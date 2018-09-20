using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class WithManyPhotoType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyPhotoPhotos_PhotoTypeId",
                table: "InspectionOrderPropertyPhotoPhotos");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyPhotoPhotos_PhotoTypeId",
                table: "InspectionOrderPropertyPhotoPhotos",
                column: "PhotoTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InspectionOrderPropertyPhotoPhotos_PhotoTypeId",
                table: "InspectionOrderPropertyPhotoPhotos");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionOrderPropertyPhotoPhotos_PhotoTypeId",
                table: "InspectionOrderPropertyPhotoPhotos",
                column: "PhotoTypeId",
                unique: true,
                filter: "[PhotoTypeId] IS NOT NULL");
        }
    }
}
