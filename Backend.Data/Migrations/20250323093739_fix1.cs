using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class fix1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Admin_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Admin_id);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Route_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Route_id);
                });

            migrationBuilder.CreateTable(
                name: "Stops",
                columns: table => new
                {
                    Stop_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stops", x => x.Stop_id);
                });

            migrationBuilder.CreateTable(
                name: "Buses",
                columns: table => new
                {
                    Bus_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Capasity_standing = table.Column<int>(type: "int", nullable: false),
                    Capasity_sitting = table.Column<int>(type: "int", nullable: false),
                    Route_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buses", x => x.Bus_id);
                    table.ForeignKey(
                        name: "FK_Buses_Routes_Route_id",
                        column: x => x.Route_id,
                        principalTable: "Routes",
                        principalColumn: "Route_id");
                });

            migrationBuilder.CreateTable(
                name: "Edges",
                columns: table => new
                {
                    Edge_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start_stop_id = table.Column<int>(type: "int", nullable: false),
                    End_stop_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edges", x => x.Edge_id);
                    table.ForeignKey(
                        name: "FK_Edges_Stops_End_stop_id",
                        column: x => x.End_stop_id,
                        principalTable: "Stops",
                        principalColumn: "Stop_id");
                    table.ForeignKey(
                        name: "FK_Edges_Stops_Start_stop_id",
                        column: x => x.Start_stop_id,
                        principalTable: "Stops",
                        principalColumn: "Stop_id");
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Driver_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Bus_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Driver_id);
                    table.ForeignKey(
                        name: "FK_Drivers_Buses_Bus_id",
                        column: x => x.Bus_id,
                        principalTable: "Buses",
                        principalColumn: "Bus_id");
                });

            migrationBuilder.CreateTable(
                name: "RouteEdges",
                columns: table => new
                {
                    RouteEdge_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Route_id = table.Column<int>(type: "int", nullable: false),
                    Edge_id = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<float>(type: "real", nullable: false),
                    Distance = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteEdges", x => x.RouteEdge_id);
                    table.ForeignKey(
                        name: "FK_RouteEdges_Edges_Edge_id",
                        column: x => x.Edge_id,
                        principalTable: "Edges",
                        principalColumn: "Edge_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RouteEdges_Routes_Route_id",
                        column: x => x.Route_id,
                        principalTable: "Routes",
                        principalColumn: "Route_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buses_Route_id",
                table: "Buses",
                column: "Route_id");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_Bus_id",
                table: "Drivers",
                column: "Bus_id");

            migrationBuilder.CreateIndex(
                name: "IX_Edges_End_stop_id",
                table: "Edges",
                column: "End_stop_id");

            migrationBuilder.CreateIndex(
                name: "IX_Edges_Start_stop_id",
                table: "Edges",
                column: "Start_stop_id");

            migrationBuilder.CreateIndex(
                name: "IX_RouteEdges_Edge_id",
                table: "RouteEdges",
                column: "Edge_id");

            migrationBuilder.CreateIndex(
                name: "IX_RouteEdges_Route_id",
                table: "RouteEdges",
                column: "Route_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "RouteEdges");

            migrationBuilder.DropTable(
                name: "Buses");

            migrationBuilder.DropTable(
                name: "Edges");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Stops");
        }
    }
}
