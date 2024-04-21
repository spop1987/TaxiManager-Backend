﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaxiManagerInfrastructure;

#nullable disable

namespace TaxiManagerInfrastructure.Data.Migrations
{
    [DbContext(typeof(TaxiManagerContext))]
    [Migration("20240421034907_FirstMigration")]
    partial class FirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaxiManagerDomain.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AutoPartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("dateTime");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("dateTime");

                    b.Property<Guid?>("MaintenanceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PlaceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("dateTime");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Zipcode")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("AutoPartId")
                        .IsUnique()
                        .HasFilter("[AutoPartId] IS NOT NULL");

                    b.HasIndex("MaintenanceId")
                        .IsUnique()
                        .HasFilter("[MaintenanceId] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.ToTable("Address", (string)null);
                });

            modelBuilder.Entity("TaxiManagerDomain.Entities.AutoPart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AutoPartName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("MaintenanceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MaintenanceId");

                    b.ToTable("AutoPart", (string)null);
                });

            modelBuilder.Entity("TaxiManagerDomain.Entities.Enrollment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DriverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("dateTime");

                    b.Property<string>("Observations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("dateTime");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("VehicleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Enrollment", (string)null);
                });

            modelBuilder.Entity("TaxiManagerDomain.Entities.Maintenance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime?>("EndDate")
                        .IsRequired()
                        .HasColumnType("dateTime");

                    b.Property<bool>("IsRepair")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("dateTime");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("VehicleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("VehicleMileage")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("Maintenance", (string)null);
                });

            modelBuilder.Entity("TaxiManagerDomain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("dateTime");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("dateTime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("NationalId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telephone")
                        .HasColumnType("varchar(12)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("dateTime");

                    b.Property<string>("UserType")
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("TaxiManagerDomain.Entities.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Brand")
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("dateTime");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("dateTime");

                    b.Property<string>("Model")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Nickname")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Registration")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("dateTime");

                    b.Property<string>("VehicleType")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Year")
                        .HasColumnType("varchar(4)");

                    b.HasKey("Id");

                    b.ToTable("Vehicle", (string)null);
                });

            modelBuilder.Entity("TaxiManagerDomain.Entities.Address", b =>
                {
                    b.HasOne("TaxiManagerDomain.Entities.AutoPart", "AutoPart")
                        .WithOne("WhereItWasPurchased")
                        .HasForeignKey("TaxiManagerDomain.Entities.Address", "AutoPartId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("TaxiManagerDomain.Entities.Maintenance", "Maintenance")
                        .WithOne("WhereItWasMade")
                        .HasForeignKey("TaxiManagerDomain.Entities.Address", "MaintenanceId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("TaxiManagerDomain.Entities.User", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("AutoPart");

                    b.Navigation("Maintenance");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TaxiManagerDomain.Entities.AutoPart", b =>
                {
                    b.HasOne("TaxiManagerDomain.Entities.Maintenance", "Maintenance")
                        .WithMany("AutoParts")
                        .HasForeignKey("MaintenanceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("TaxiManagerDomain.Shared.Money", "Price", b1 =>
                        {
                            b1.Property<Guid>("AutoPartId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<string>("Currency")
                                .HasColumnType("varchar(3)");

                            b1.HasKey("AutoPartId");

                            b1.ToTable("AutoPart");

                            b1.WithOwner()
                                .HasForeignKey("AutoPartId");
                        });

                    b.Navigation("Maintenance");

                    b.Navigation("Price");
                });

            modelBuilder.Entity("TaxiManagerDomain.Entities.Enrollment", b =>
                {
                    b.HasOne("TaxiManagerDomain.Entities.User", "Driver")
                        .WithMany("Enrollments")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TaxiManagerDomain.Entities.Vehicle", "Vehicle")
                        .WithMany("Enrollments")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Driver");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("TaxiManagerDomain.Entities.Maintenance", b =>
                {
                    b.HasOne("TaxiManagerDomain.Entities.Vehicle", "Vehicle")
                        .WithMany("Maintenances")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("TaxiManagerDomain.Shared.Money", "LaborPrice", b1 =>
                        {
                            b1.Property<Guid>("MaintenanceId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<string>("Currency")
                                .HasColumnType("varchar(3)");

                            b1.HasKey("MaintenanceId");

                            b1.ToTable("Maintenance");

                            b1.WithOwner()
                                .HasForeignKey("MaintenanceId");
                        });

                    b.OwnsOne("TaxiManagerDomain.Shared.Money", "TotalPrice", b1 =>
                        {
                            b1.Property<Guid>("MaintenanceId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<string>("Currency")
                                .HasColumnType("varchar(3)");

                            b1.HasKey("MaintenanceId");

                            b1.ToTable("Maintenance");

                            b1.WithOwner()
                                .HasForeignKey("MaintenanceId");
                        });

                    b.Navigation("LaborPrice");

                    b.Navigation("TotalPrice");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("TaxiManagerDomain.Entities.AutoPart", b =>
                {
                    b.Navigation("WhereItWasPurchased");
                });

            modelBuilder.Entity("TaxiManagerDomain.Entities.Maintenance", b =>
                {
                    b.Navigation("AutoParts");

                    b.Navigation("WhereItWasMade");
                });

            modelBuilder.Entity("TaxiManagerDomain.Entities.User", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("TaxiManagerDomain.Entities.Vehicle", b =>
                {
                    b.Navigation("Enrollments");

                    b.Navigation("Maintenances");
                });
#pragma warning restore 612, 618
        }
    }
}