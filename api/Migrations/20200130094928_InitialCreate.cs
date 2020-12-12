using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ShipmentNumber = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    VehicleSize = table.Column<string>(nullable: true),
                    VehicleBuildUp = table.Column<string>(nullable: true),
                    PickupLocationName = table.Column<string>(nullable: true),
                    PickupDateTime = table.Column<long>(nullable: false),
                    DeliveryLocationName = table.Column<string>(nullable: true),
                    DeliveryDateTime = table.Column<long>(nullable: false),
                    LoadDetail1 = table.Column<string>(nullable: true),
                    LoadDetail2 = table.Column<string>(nullable: true),
                    LoadDetail3 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offers");
        }
    }
}
