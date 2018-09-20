﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rivington.IG.Infrastructure.Persistence.Migrations
{
    public partial class AddedInspectorIdInInspectionOrderView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(SqlScripts.InspectionOrderListView_201807310946);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(SqlScripts.InspectionOrderListView_201807301032);
        }
    }
}
