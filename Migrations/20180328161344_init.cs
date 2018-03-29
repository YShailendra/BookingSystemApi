using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookingSystemApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    AmountPaid = table.Column<int>(nullable: true),
                    BookingNumber = table.Column<string>(nullable: false),
                    BusID = table.Column<Guid>(nullable: true),
                    CancelationCharge = table.Column<int>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Destination = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    JourneyDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    PhoneNo = table.Column<string>(nullable: false),
                    Source = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    TotalAmount = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BusDetail",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    BusDescription = table.Column<string>(nullable: true),
                    BusNo = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    SeatingSeats = table.Column<int>(nullable: false),
                    SleeperSeatsLB = table.Column<int>(nullable: false),
                    SleeperSeatsUB = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusDetail", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RouteName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Station",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StationName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Station", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Addr = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    PhoneNo = table.Column<string>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SeatDetails",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    BookingID = table.Column<Guid>(nullable: true),
                    Gender = table.Column<string>(nullable: false),
                    SeatId = table.Column<string>(nullable: true),
                    SeatType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SeatDetails_Booking_BookingID",
                        column: x => x.BookingID,
                        principalTable: "Booking",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusRoute",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BusID = table.Column<Guid>(nullable: false),
                    RouteID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusRoute", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BusRoute_BusDetail_BusID",
                        column: x => x.BusID,
                        principalTable: "BusDetail",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusRoute_Route_RouteID",
                        column: x => x.RouteID,
                        principalTable: "Route",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RouteStation",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<int>(nullable: false),
                    RouteID = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    StationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteStation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RouteStation_Route_RouteID",
                        column: x => x.RouteID,
                        principalTable: "Route",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RouteStation_Station_StationID",
                        column: x => x.StationID,
                        principalTable: "Station",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusRoute_BusID",
                table: "BusRoute",
                column: "BusID");

            migrationBuilder.CreateIndex(
                name: "IX_BusRoute_RouteID",
                table: "BusRoute",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "IX_RouteStation_RouteID",
                table: "RouteStation",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "IX_RouteStation_StationID",
                table: "RouteStation",
                column: "StationID");

            migrationBuilder.CreateIndex(
                name: "IX_SeatDetails_BookingID",
                table: "SeatDetails",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_PhoneNo",
                table: "User",
                column: "PhoneNo",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusRoute");

            migrationBuilder.DropTable(
                name: "RouteStation");

            migrationBuilder.DropTable(
                name: "SeatDetails");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "BusDetail");

            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.DropTable(
                name: "Station");

            migrationBuilder.DropTable(
                name: "Booking");
        }
    }
}
