using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class AddedImageInApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProfilePhotoId",
                table: "User",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_ProfilePhotoId",
                table: "User",
                column: "ProfilePhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Image_ProfilePhotoId",
                table: "User",
                column: "ProfilePhotoId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.Sql(SqlScripts.UserManagementListView_201806261158);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Image_ProfilePhotoId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ProfilePhotoId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ProfilePhotoId",
                table: "User");

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePhoto",
                table: "User",
                nullable: true);

            migrationBuilder.Sql(SqlScripts.UserManagementListView_201806221654);
        }
    }
}
