using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class InsertNewPhotoTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO PhotoType(Id, GroupId, Name) VALUES ('AR','MIS','Aerial View')");
            migrationBuilder.Sql("INSERT INTO PhotoType(Id, GroupId, Name) VALUES ('HS','MIS','Home Sketch')");
            migrationBuilder.Sql("INSERT INTO PhotoType(Id, GroupId, Name) VALUES ('RC','MIS','Report Cover')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM PhotoType WHERE Id = 'AR'");
            migrationBuilder.Sql("DELETE FROM PhotoType WHERE Id = 'HS'");
            migrationBuilder.Sql("DELETE FROM PhotoType WHERE Id = 'RC'");
        }
    }
}
