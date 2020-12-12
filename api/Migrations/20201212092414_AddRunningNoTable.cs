using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class AddRunningNoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RunningNo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TodayDate = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    referenceNo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunningNo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RunningNo");
        }
    }
}
