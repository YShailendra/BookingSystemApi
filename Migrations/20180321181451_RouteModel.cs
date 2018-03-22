using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookingSystemApi.Migrations
{
    public partial class RouteModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusRoute");

            migrationBuilder.DropTable(
                name: "RouteStation");

            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.DropTable(
                name: "Station");
        }
    }
}
