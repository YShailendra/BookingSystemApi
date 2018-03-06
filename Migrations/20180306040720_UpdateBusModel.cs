using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookingSystemApi.Migrations
{
    public partial class UpdateBusModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BusID",
                table: "Booking",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BusDetail",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    BusDescription = table.Column<string>(nullable: true),
                    BusNo = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LowerSeats = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpperSeats = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusDetail", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusDetail");

            migrationBuilder.DropColumn(
                name: "BusID",
                table: "Booking");
        }
    }
}
