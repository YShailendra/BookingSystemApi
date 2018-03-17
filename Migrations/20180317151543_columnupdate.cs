using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookingSystemApi.Migrations
{
    public partial class columnupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SleeperSeats",
                table: "BusDetail",
                newName: "SleeperSeatsUB");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "User",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "BusDetail",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<int>(
                name: "SleeperSeatsLB",
                table: "BusDetail",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "Booking",
                nullable: true,
                oldClrType: typeof(Guid));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SleeperSeatsLB",
                table: "BusDetail");

            migrationBuilder.RenameColumn(
                name: "SleeperSeatsUB",
                table: "BusDetail",
                newName: "SleeperSeats");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "User",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "BusDetail",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "Booking",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }
    }
}
