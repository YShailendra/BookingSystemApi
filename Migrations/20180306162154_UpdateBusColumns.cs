using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookingSystemApi.Migrations
{
    public partial class UpdateBusColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpperSeats",
                table: "BusDetail",
                newName: "SleeperSeats");

            migrationBuilder.RenameColumn(
                name: "LowerSeats",
                table: "BusDetail",
                newName: "SeatingSeats");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SleeperSeats",
                table: "BusDetail",
                newName: "UpperSeats");

            migrationBuilder.RenameColumn(
                name: "SeatingSeats",
                table: "BusDetail",
                newName: "LowerSeats");
        }
    }
}
