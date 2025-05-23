﻿// <auto-generated />
using System;
using Backend.Data.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Data.Migrations
{
    [DbContext(typeof(MainDBContext))]
    partial class MainDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Backend.Data.Entities.AdminEntity", b =>
                {
                    b.Property<int>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminID"));

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminID");

                    b.HasIndex("CityID");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Backend.Data.Entities.CityEntity", b =>
                {
                    b.Property<int>("CityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityID"));

                    b.Property<double?>("Area")
                        .HasColumnType("float");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Population")
                        .HasColumnType("int");

                    b.Property<int>("RegionID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("CityID");

                    b.HasIndex("RegionID");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Backend.Data.Entities.CountryEntity", b =>
                {
                    b.Property<int>("CountryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CountryID"));

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Population")
                        .HasColumnType("int");

                    b.HasKey("CountryID");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Backend.Data.Entities.DriverEntity", b =>
                {
                    b.Property<int>("DriverID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DriverID"));

                    b.Property<DateTime?>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LicenceID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DriverID");

                    b.HasIndex("LicenceID");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("Backend.Data.Entities.EdgeEntity", b =>
                {
                    b.Property<int>("EdgeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EdgeID"));

                    b.Property<double?>("Distance")
                        .HasColumnType("float");

                    b.Property<double?>("ExpectedSpeed")
                        .HasColumnType("float");

                    b.Property<double?>("ExpectedTime")
                        .HasColumnType("float");

                    b.Property<int>("StopA")
                        .HasColumnType("int");

                    b.Property<int?>("StopARefStopID")
                        .HasColumnType("int");

                    b.Property<int>("StopB")
                        .HasColumnType("int");

                    b.Property<int?>("StopBRefStopID")
                        .HasColumnType("int");

                    b.HasKey("EdgeID");

                    b.HasIndex("StopARefStopID");

                    b.HasIndex("StopBRefStopID");

                    b.ToTable("Edges");
                });

            modelBuilder.Entity("Backend.Data.Entities.GNSSSystemEntity", b =>
                {
                    b.Property<int>("GNSSSystemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GNSSSystemID"));

                    b.Property<int>("CountryID")
                        .HasColumnType("int");

                    b.Property<string>("FrequencyBand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GNSSSystemID");

                    b.HasIndex("CountryID");

                    b.ToTable("GNSSSystems");
                });

            modelBuilder.Entity("Backend.Data.Entities.GPSEntity", b =>
                {
                    b.Property<int>("GpsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GpsID"));

                    b.Property<int>("GPSModelID")
                        .HasColumnType("int");

                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GpsID");

                    b.HasIndex("GPSModelID");

                    b.ToTable("GPSDevices");
                });

            modelBuilder.Entity("Backend.Data.Entities.GPSModelEntity", b =>
                {
                    b.Property<int>("GPSModelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GPSModelID"));

                    b.Property<double>("AccuracyMeters")
                        .HasColumnType("float");

                    b.Property<int>("ApiSupportLevel")
                        .HasColumnType("int");

                    b.Property<int>("ManufacturerID")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("UpdateIntervalSec")
                        .HasColumnType("float");

                    b.HasKey("GPSModelID");

                    b.HasIndex("ManufacturerID");

                    b.ToTable("GPSModels");
                });

            modelBuilder.Entity("Backend.Data.Entities.GpsModelGNSSEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("GNSSSystemEntityGNSSSystemID")
                        .HasColumnType("int");

                    b.Property<int>("GNSSSystemID")
                        .HasColumnType("int");

                    b.Property<int?>("GPSModelEntityGPSModelID")
                        .HasColumnType("int");

                    b.Property<int>("GPSModelID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("GNSSSystemEntityGNSSSystemID");

                    b.HasIndex("GNSSSystemID");

                    b.HasIndex("GPSModelEntityGPSModelID");

                    b.HasIndex("GPSModelID");

                    b.ToTable("GpsModelGNSS");
                });

            modelBuilder.Entity("Backend.Data.Entities.LicenceEntity", b =>
                {
                    b.Property<int>("LicenceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LicenceID"));

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryID")
                        .HasColumnType("int");

                    b.Property<string>("IDNum")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LicenceID");

                    b.HasIndex("CountryID");

                    b.ToTable("Licences");
                });

            modelBuilder.Entity("Backend.Data.Entities.ManufacturerEntity", b =>
                {
                    b.Property<int>("ManufacturerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ManufacturerID"));

                    b.Property<int>("CountryID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ManufacturerID");

                    b.HasIndex("CountryID");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("Backend.Data.Entities.RegionEntity", b =>
                {
                    b.Property<int>("RegionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RegionID"));

                    b.Property<double?>("Area")
                        .HasColumnType("float");

                    b.Property<int>("CountryID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Population")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("RegionID");

                    b.HasIndex("CountryID");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("Backend.Data.Entities.RouteEdgeEntity", b =>
                {
                    b.Property<int>("REID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("REID"));

                    b.Property<bool>("Direction")
                        .HasColumnType("bit");

                    b.Property<int>("EdgeID")
                        .HasColumnType("int");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("RouteID")
                        .HasColumnType("int");

                    b.HasKey("REID");

                    b.HasIndex("EdgeID");

                    b.HasIndex("RouteID");

                    b.ToTable("RouteEdges");
                });

            modelBuilder.Entity("Backend.Data.Entities.RouteEntity", b =>
                {
                    b.Property<int>("RouteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RouteID"));

                    b.Property<string>("EndHour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RouteNum")
                        .HasColumnType("int");

                    b.Property<string>("StartHour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RouteID");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("Backend.Data.Entities.StopEntity", b =>
                {
                    b.Property<int>("StopID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StopID"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsTerminal")
                        .HasColumnType("bit");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("StopAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StopName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StopID");

                    b.ToTable("Stops");
                });

            modelBuilder.Entity("Backend.Data.Entities.TripEntity", b =>
                {
                    b.Property<int>("TripID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TripID"));

                    b.Property<int>("EndStopID")
                        .HasColumnType("int");

                    b.Property<int?>("EndStopWaitSecs")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("StartStopID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("VehicleID")
                        .HasColumnType("int");

                    b.HasKey("TripID");

                    b.HasIndex("EndStopID");

                    b.HasIndex("StartStopID");

                    b.HasIndex("VehicleID");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("Backend.Data.Entities.UserEntity", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<int?>("CityID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ConnectionTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DisconnectionTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("IP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.HasKey("UserID");

                    b.HasIndex("CityID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Backend.Data.Entities.UserFeedbackEntity", b =>
                {
                    b.Property<int>("UserFeedbackID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserFeedbackID"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<DateTime>("SubmitDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("UserFeedbackID");

                    b.HasIndex("UserID");

                    b.ToTable("UserFeedbacks");
                });

            modelBuilder.Entity("Backend.Data.Entities.VehicleEntity", b =>
                {
                    b.Property<int>("VehicleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleID"));

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<int?>("DriverID")
                        .HasColumnType("int");

                    b.Property<int?>("GpsID")
                        .HasColumnType("int");

                    b.Property<string>("PlateNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RouteID")
                        .HasColumnType("int");

                    b.Property<int>("VehicleTypeID")
                        .HasColumnType("int");

                    b.HasKey("VehicleID");

                    b.HasIndex("CityID");

                    b.HasIndex("DriverID");

                    b.HasIndex("GpsID");

                    b.HasIndex("RouteID");

                    b.HasIndex("VehicleTypeID");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Backend.Data.Entities.VehicleTypeEntity", b =>
                {
                    b.Property<int>("VehicleTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleTypeID"));

                    b.Property<bool>("IsElectric")
                        .HasColumnType("bit");

                    b.Property<int>("ManufacturerID")
                        .HasColumnType("int");

                    b.Property<int>("MaxCapacity")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sits")
                        .HasColumnType("int");

                    b.HasKey("VehicleTypeID");

                    b.HasIndex("ManufacturerID");

                    b.ToTable("VehicleTypes");
                });

            modelBuilder.Entity("Backend.Data.Entities.AdminEntity", b =>
                {
                    b.HasOne("Backend.Data.Entities.CityEntity", "City")
                        .WithMany()
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Backend.Data.Entities.CityEntity", b =>
                {
                    b.HasOne("Backend.Data.Entities.RegionEntity", "Region")
                        .WithMany()
                        .HasForeignKey("RegionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Backend.Data.Entities.DriverEntity", b =>
                {
                    b.HasOne("Backend.Data.Entities.LicenceEntity", "Licence")
                        .WithMany()
                        .HasForeignKey("LicenceID");

                    b.Navigation("Licence");
                });

            modelBuilder.Entity("Backend.Data.Entities.EdgeEntity", b =>
                {
                    b.HasOne("Backend.Data.Entities.StopEntity", "StopARef")
                        .WithMany()
                        .HasForeignKey("StopARefStopID");

                    b.HasOne("Backend.Data.Entities.StopEntity", "StopBRef")
                        .WithMany()
                        .HasForeignKey("StopBRefStopID");

                    b.Navigation("StopARef");

                    b.Navigation("StopBRef");
                });

            modelBuilder.Entity("Backend.Data.Entities.GNSSSystemEntity", b =>
                {
                    b.HasOne("Backend.Data.Entities.CountryEntity", "Country")
                        .WithMany("GNSSSystems")
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Backend.Data.Entities.GPSEntity", b =>
                {
                    b.HasOne("Backend.Data.Entities.GPSModelEntity", "GPSModel")
                        .WithMany()
                        .HasForeignKey("GPSModelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GPSModel");
                });

            modelBuilder.Entity("Backend.Data.Entities.GPSModelEntity", b =>
                {
                    b.HasOne("Backend.Data.Entities.ManufacturerEntity", "Manufacturer")
                        .WithMany("GPSModels")
                        .HasForeignKey("ManufacturerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("Backend.Data.Entities.GpsModelGNSSEntity", b =>
                {
                    b.HasOne("Backend.Data.Entities.GNSSSystemEntity", null)
                        .WithMany("GpsModelGNSS")
                        .HasForeignKey("GNSSSystemEntityGNSSSystemID");

                    b.HasOne("Backend.Data.Entities.GNSSSystemEntity", "GNSSSystem")
                        .WithMany()
                        .HasForeignKey("GNSSSystemID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Backend.Data.Entities.GPSModelEntity", null)
                        .WithMany("GNSSSystems")
                        .HasForeignKey("GPSModelEntityGPSModelID");

                    b.HasOne("Backend.Data.Entities.GPSModelEntity", "GPSModel")
                        .WithMany()
                        .HasForeignKey("GPSModelID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("GNSSSystem");

                    b.Navigation("GPSModel");
                });

            modelBuilder.Entity("Backend.Data.Entities.LicenceEntity", b =>
                {
                    b.HasOne("Backend.Data.Entities.CountryEntity", "Country")
                        .WithMany("Licences")
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Backend.Data.Entities.ManufacturerEntity", b =>
                {
                    b.HasOne("Backend.Data.Entities.CountryEntity", "Country")
                        .WithMany("Manufacturers")
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Backend.Data.Entities.RegionEntity", b =>
                {
                    b.HasOne("Backend.Data.Entities.CountryEntity", "Country")
                        .WithMany("Regions")
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Backend.Data.Entities.RouteEdgeEntity", b =>
                {
                    b.HasOne("Backend.Data.Entities.EdgeEntity", "Edge")
                        .WithMany()
                        .HasForeignKey("EdgeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Data.Entities.RouteEntity", "Route")
                        .WithMany("RouteEdges")
                        .HasForeignKey("RouteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Edge");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("Backend.Data.Entities.TripEntity", b =>
                {
                    b.HasOne("Backend.Data.Entities.StopEntity", "EndStop")
                        .WithMany()
                        .HasForeignKey("EndStopID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Data.Entities.StopEntity", "StartStop")
                        .WithMany()
                        .HasForeignKey("StartStopID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Backend.Data.Entities.VehicleEntity", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EndStop");

                    b.Navigation("StartStop");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Backend.Data.Entities.UserEntity", b =>
                {
                    b.HasOne("Backend.Data.Entities.CityEntity", "City")
                        .WithMany()
                        .HasForeignKey("CityID");

                    b.Navigation("City");
                });

            modelBuilder.Entity("Backend.Data.Entities.UserFeedbackEntity", b =>
                {
                    b.HasOne("Backend.Data.Entities.UserEntity", "User")
                        .WithMany("Feedbacks")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Backend.Data.Entities.VehicleEntity", b =>
                {
                    b.HasOne("Backend.Data.Entities.CityEntity", "City")
                        .WithMany()
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Backend.Data.Entities.DriverEntity", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverID");

                    b.HasOne("Backend.Data.Entities.GPSEntity", "GPS")
                        .WithMany()
                        .HasForeignKey("GpsID");

                    b.HasOne("Backend.Data.Entities.RouteEntity", "Route")
                        .WithMany("Vehicles")
                        .HasForeignKey("RouteID");

                    b.HasOne("Backend.Data.Entities.VehicleTypeEntity", "VehicleType")
                        .WithMany()
                        .HasForeignKey("VehicleTypeID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Driver");

                    b.Navigation("GPS");

                    b.Navigation("Route");

                    b.Navigation("VehicleType");
                });

            modelBuilder.Entity("Backend.Data.Entities.VehicleTypeEntity", b =>
                {
                    b.HasOne("Backend.Data.Entities.ManufacturerEntity", "Manufacturer")
                        .WithMany("VehicleTypes")
                        .HasForeignKey("ManufacturerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("Backend.Data.Entities.CountryEntity", b =>
                {
                    b.Navigation("GNSSSystems");

                    b.Navigation("Licences");

                    b.Navigation("Manufacturers");

                    b.Navigation("Regions");
                });

            modelBuilder.Entity("Backend.Data.Entities.GNSSSystemEntity", b =>
                {
                    b.Navigation("GpsModelGNSS");
                });

            modelBuilder.Entity("Backend.Data.Entities.GPSModelEntity", b =>
                {
                    b.Navigation("GNSSSystems");
                });

            modelBuilder.Entity("Backend.Data.Entities.ManufacturerEntity", b =>
                {
                    b.Navigation("GPSModels");

                    b.Navigation("VehicleTypes");
                });

            modelBuilder.Entity("Backend.Data.Entities.RouteEntity", b =>
                {
                    b.Navigation("RouteEdges");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Backend.Data.Entities.UserEntity", b =>
                {
                    b.Navigation("Feedbacks");
                });
#pragma warning restore 612, 618
        }
    }
}
