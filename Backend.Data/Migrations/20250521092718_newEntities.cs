using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Data.Migrations
{
    /// <inheritdoc />
    public partial class newEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Population = table.Column<int>(type: "int", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    RouteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteNum = table.Column<int>(type: "int", nullable: false),
                    StartHour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndHour = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.RouteID);
                });

            migrationBuilder.CreateTable(
                name: "Stops",
                columns: table => new
                {
                    StopID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StopName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StopAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    IsTerminal = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stops", x => x.StopID);
                });

            migrationBuilder.CreateTable(
                name: "GNSSSystems",
                columns: table => new
                {
                    GNSSSystemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrequencyBand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GNSSSystems", x => x.GNSSSystemID);
                    table.ForeignKey(
                        name: "FK_GNSSSystems_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Licences",
                columns: table => new
                {
                    LicenceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryID = table.Column<int>(type: "int", nullable: false),
                    IDNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licences", x => x.LicenceID);
                    table.ForeignKey(
                        name: "FK_Licences_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    ManufacturerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.ManufacturerID);
                    table.ForeignKey(
                        name: "FK_Manufacturers_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Population = table.Column<int>(type: "int", nullable: true),
                    Area = table.Column<double>(type: "float", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CountryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionID);
                    table.ForeignKey(
                        name: "FK_Regions_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Edges",
                columns: table => new
                {
                    EdgeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StopA = table.Column<int>(type: "int", nullable: false),
                    StopB = table.Column<int>(type: "int", nullable: false),
                    Distance = table.Column<double>(type: "float", nullable: true),
                    ExpectedTime = table.Column<double>(type: "float", nullable: true),
                    ExpectedSpeed = table.Column<double>(type: "float", nullable: true),
                    StopARefStopID = table.Column<int>(type: "int", nullable: true),
                    StopBRefStopID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edges", x => x.EdgeID);
                    table.ForeignKey(
                        name: "FK_Edges_Stops_StopARefStopID",
                        column: x => x.StopARefStopID,
                        principalTable: "Stops",
                        principalColumn: "StopID");
                    table.ForeignKey(
                        name: "FK_Edges_Stops_StopBRefStopID",
                        column: x => x.StopBRefStopID,
                        principalTable: "Stops",
                        principalColumn: "StopID");
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    DriverID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LicenceID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.DriverID);
                    table.ForeignKey(
                        name: "FK_Drivers_Licences_LicenceID",
                        column: x => x.LicenceID,
                        principalTable: "Licences",
                        principalColumn: "LicenceID");
                });

            migrationBuilder.CreateTable(
                name: "GPSModels",
                columns: table => new
                {
                    GPSModelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManufacturerID = table.Column<int>(type: "int", nullable: false),
                    ApiSupportLevel = table.Column<int>(type: "int", nullable: false),
                    AccuracyMeters = table.Column<double>(type: "float", nullable: false),
                    UpdateIntervalSec = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPSModels", x => x.GPSModelID);
                    table.ForeignKey(
                        name: "FK_GPSModels_Manufacturers_ManufacturerID",
                        column: x => x.ManufacturerID,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufacturerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    VehicleTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sits = table.Column<int>(type: "int", nullable: false),
                    MaxCapacity = table.Column<int>(type: "int", nullable: false),
                    IsElectric = table.Column<bool>(type: "bit", nullable: false),
                    ManufacturerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.VehicleTypeID);
                    table.ForeignKey(
                        name: "FK_VehicleTypes_Manufacturers_ManufacturerID",
                        column: x => x.ManufacturerID,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufacturerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Population = table.Column<int>(type: "int", nullable: true),
                    Area = table.Column<double>(type: "float", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityID);
                    table.ForeignKey(
                        name: "FK_Cities_Regions_RegionID",
                        column: x => x.RegionID,
                        principalTable: "Regions",
                        principalColumn: "RegionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RouteEdges",
                columns: table => new
                {
                    REID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteID = table.Column<int>(type: "int", nullable: false),
                    EdgeID = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Direction = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteEdges", x => x.REID);
                    table.ForeignKey(
                        name: "FK_RouteEdges_Edges_EdgeID",
                        column: x => x.EdgeID,
                        principalTable: "Edges",
                        principalColumn: "EdgeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RouteEdges_Routes_RouteID",
                        column: x => x.RouteID,
                        principalTable: "Routes",
                        principalColumn: "RouteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GPSDevices",
                columns: table => new
                {
                    GpsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GPSModelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPSDevices", x => x.GpsID);
                    table.ForeignKey(
                        name: "FK_GPSDevices_GPSModels_GPSModelID",
                        column: x => x.GPSModelID,
                        principalTable: "GPSModels",
                        principalColumn: "GPSModelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GpsModelGNSS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GPSModelID = table.Column<int>(type: "int", nullable: false),
                    GNSSSystemID = table.Column<int>(type: "int", nullable: false),
                    GNSSSystemEntityGNSSSystemID = table.Column<int>(type: "int", nullable: true),
                    GPSModelEntityGPSModelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GpsModelGNSS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GpsModelGNSS_GNSSSystems_GNSSSystemEntityGNSSSystemID",
                        column: x => x.GNSSSystemEntityGNSSSystemID,
                        principalTable: "GNSSSystems",
                        principalColumn: "GNSSSystemID");
                    table.ForeignKey(
                        name: "FK_GpsModelGNSS_GNSSSystems_GNSSSystemID",
                        column: x => x.GNSSSystemID,
                        principalTable: "GNSSSystems",
                        principalColumn: "GNSSSystemID");
                    table.ForeignKey(
                        name: "FK_GpsModelGNSS_GPSModels_GPSModelEntityGPSModelID",
                        column: x => x.GPSModelEntityGPSModelID,
                        principalTable: "GPSModels",
                        principalColumn: "GPSModelID");
                    table.ForeignKey(
                        name: "FK_GpsModelGNSS_GPSModels_GPSModelID",
                        column: x => x.GPSModelID,
                        principalTable: "GPSModels",
                        principalColumn: "GPSModelID");
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminID);
                    table.ForeignKey(
                        name: "FK_Admins_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConnectionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    DisconnectionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CityID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "CityID");
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlateNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleTypeID = table.Column<int>(type: "int", nullable: false),
                    DriverID = table.Column<int>(type: "int", nullable: true),
                    GpsID = table.Column<int>(type: "int", nullable: true),
                    CityID = table.Column<int>(type: "int", nullable: false),
                    RouteID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleID);
                    table.ForeignKey(
                        name: "FK_Vehicles_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "CityID");
                    table.ForeignKey(
                        name: "FK_Vehicles_Drivers_DriverID",
                        column: x => x.DriverID,
                        principalTable: "Drivers",
                        principalColumn: "DriverID");
                    table.ForeignKey(
                        name: "FK_Vehicles_GPSDevices_GpsID",
                        column: x => x.GpsID,
                        principalTable: "GPSDevices",
                        principalColumn: "GpsID");
                    table.ForeignKey(
                        name: "FK_Vehicles_Routes_RouteID",
                        column: x => x.RouteID,
                        principalTable: "Routes",
                        principalColumn: "RouteID");
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleTypes_VehicleTypeID",
                        column: x => x.VehicleTypeID,
                        principalTable: "VehicleTypes",
                        principalColumn: "VehicleTypeID");
                });

            migrationBuilder.CreateTable(
                name: "UserFeedbacks",
                columns: table => new
                {
                    UserFeedbackID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    SubmitDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFeedbacks", x => x.UserFeedbackID);
                    table.ForeignKey(
                        name: "FK_UserFeedbacks_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    TripID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VehicleID = table.Column<int>(type: "int", nullable: false),
                    StartStopID = table.Column<int>(type: "int", nullable: false),
                    EndStopID = table.Column<int>(type: "int", nullable: false),
                    EndStopWaitSecs = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.TripID);
                    table.ForeignKey(
                        name: "FK_Trips_Stops_EndStopID",
                        column: x => x.EndStopID,
                        principalTable: "Stops",
                        principalColumn: "StopID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trips_Stops_StartStopID",
                        column: x => x.StartStopID,
                        principalTable: "Stops",
                        principalColumn: "StopID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trips_Vehicles_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_CityID",
                table: "Admins",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_RegionID",
                table: "Cities",
                column: "RegionID");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_LicenceID",
                table: "Drivers",
                column: "LicenceID");

            migrationBuilder.CreateIndex(
                name: "IX_Edges_StopARefStopID",
                table: "Edges",
                column: "StopARefStopID");

            migrationBuilder.CreateIndex(
                name: "IX_Edges_StopBRefStopID",
                table: "Edges",
                column: "StopBRefStopID");

            migrationBuilder.CreateIndex(
                name: "IX_GNSSSystems_CountryID",
                table: "GNSSSystems",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_GPSDevices_GPSModelID",
                table: "GPSDevices",
                column: "GPSModelID");

            migrationBuilder.CreateIndex(
                name: "IX_GpsModelGNSS_GNSSSystemEntityGNSSSystemID",
                table: "GpsModelGNSS",
                column: "GNSSSystemEntityGNSSSystemID");

            migrationBuilder.CreateIndex(
                name: "IX_GpsModelGNSS_GNSSSystemID",
                table: "GpsModelGNSS",
                column: "GNSSSystemID");

            migrationBuilder.CreateIndex(
                name: "IX_GpsModelGNSS_GPSModelEntityGPSModelID",
                table: "GpsModelGNSS",
                column: "GPSModelEntityGPSModelID");

            migrationBuilder.CreateIndex(
                name: "IX_GpsModelGNSS_GPSModelID",
                table: "GpsModelGNSS",
                column: "GPSModelID");

            migrationBuilder.CreateIndex(
                name: "IX_GPSModels_ManufacturerID",
                table: "GPSModels",
                column: "ManufacturerID");

            migrationBuilder.CreateIndex(
                name: "IX_Licences_CountryID",
                table: "Licences",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_CountryID",
                table: "Manufacturers",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_CountryID",
                table: "Regions",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_RouteEdges_EdgeID",
                table: "RouteEdges",
                column: "EdgeID");

            migrationBuilder.CreateIndex(
                name: "IX_RouteEdges_RouteID",
                table: "RouteEdges",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_EndStopID",
                table: "Trips",
                column: "EndStopID");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_StartStopID",
                table: "Trips",
                column: "StartStopID");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_VehicleID",
                table: "Trips",
                column: "VehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_UserFeedbacks_UserID",
                table: "UserFeedbacks",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CityID",
                table: "Users",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CityID",
                table: "Vehicles",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_DriverID",
                table: "Vehicles",
                column: "DriverID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_GpsID",
                table: "Vehicles",
                column: "GpsID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_RouteID",
                table: "Vehicles",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleTypeID",
                table: "Vehicles",
                column: "VehicleTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTypes_ManufacturerID",
                table: "VehicleTypes",
                column: "ManufacturerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "GpsModelGNSS");

            migrationBuilder.DropTable(
                name: "RouteEdges");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "UserFeedbacks");

            migrationBuilder.DropTable(
                name: "GNSSSystems");

            migrationBuilder.DropTable(
                name: "Edges");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Stops");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "GPSDevices");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "VehicleTypes");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Licences");

            migrationBuilder.DropTable(
                name: "GPSModels");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
