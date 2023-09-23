﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SeatManagement2;

#nullable disable

namespace SeatManagement2.Migrations
{
    [DbContext(typeof(SeatManagementContext))]
    [Migration("20230923112656_Fourth")]
    partial class Fourth
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SeatManagement2.Models.AllocatedCabinsView", b =>
                {
                    b.Property<string>("FacilityName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CabinNumber")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("BuildingCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FloorNumber")
                        .HasColumnType("int");

                    b.HasKey("FacilityName", "CabinNumber", "EmployeeId");

                    b.ToView("AllocatedCabinsView");
                });

            modelBuilder.Entity("SeatManagement2.Models.AllocatedSeats", b =>
                {
                    b.Property<string>("FacilityName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("BuildingCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FloorNumber")
                        .HasColumnType("int");

                    b.HasKey("FacilityName", "SeatNumber", "EmployeeId");

                    b.ToView("AllocatedSeats");
                });

            modelBuilder.Entity("SeatManagement2.Models.AmenityLookUp", b =>
                {
                    b.Property<int>("AmenityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AmenityId"), 1L, 1);

                    b.Property<string>("AmenityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AmenityId");

                    b.ToTable("AmenityLookUp");
                });

            modelBuilder.Entity("SeatManagement2.Models.BuildingLookUp", b =>
                {
                    b.Property<int>("BuildingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BuildingId"), 1L, 1);

                    b.Property<string>("BuildingCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BuildingName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BuildingId");

                    b.HasIndex("BuildingCode")
                        .IsUnique()
                        .HasFilter("[BuildingCode] IS NOT NULL");

                    b.ToTable("BuildingLookUps");
                });

            modelBuilder.Entity("SeatManagement2.Models.CabinRoom", b =>
                {
                    b.Property<int>("CabinId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CabinId"), 1L, 1);

                    b.Property<int>("CabinNumber")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("FacilityId")
                        .HasColumnType("int");

                    b.HasKey("CabinId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("FacilityId");

                    b.ToTable("CabinRooms");
                });

            modelBuilder.Entity("SeatManagement2.Models.CityLookUp", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityId"), 1L, 1);

                    b.Property<string>("CityCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityId");

                    b.HasIndex("CityCode")
                        .IsUnique()
                        .HasFilter("[CityCode] IS NOT NULL");

                    b.ToTable("CityLookUps");
                });

            modelBuilder.Entity("SeatManagement2.Models.DepartmentLookUp", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"), 1L, 1);

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("DepartmentLookUps");
                });

            modelBuilder.Entity("SeatManagement2.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"), 1L, 1);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAllocated")
                        .HasColumnType("bit");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("SeatManagement2.Models.Facility", b =>
                {
                    b.Property<int>("FacilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FacilityId"), 1L, 1);

                    b.Property<int>("BuildingId")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("FacilityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FloorNumber")
                        .HasColumnType("int");

                    b.HasKey("FacilityId");

                    b.HasIndex("BuildingId");

                    b.HasIndex("CityId");

                    b.ToTable("Facilitys");
                });

            modelBuilder.Entity("SeatManagement2.Models.GeneralSeat", b =>
                {
                    b.Property<int>("SeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeatId"), 1L, 1);

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("FacilityId")
                        .HasColumnType("int");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int");

                    b.HasKey("SeatId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("FacilityId");

                    b.ToTable("GeneralSeats");
                });

            modelBuilder.Entity("SeatManagement2.Models.MeetingRoom", b =>
                {
                    b.Property<int>("MeetingRoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MeetingRoomId"), 1L, 1);

                    b.Property<int>("FacilityId")
                        .HasColumnType("int");

                    b.Property<int>("MeetingRoomNumber")
                        .HasColumnType("int");

                    b.Property<int>("SeatingCapacity")
                        .HasColumnType("int");

                    b.HasKey("MeetingRoomId");

                    b.HasIndex("FacilityId");

                    b.ToTable("MeetingRooms");
                });

            modelBuilder.Entity("SeatManagement2.Models.RoomAmenity", b =>
                {
                    b.Property<int>("RoomAmenityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomAmenityId"), 1L, 1);

                    b.Property<int>("AmenityId")
                        .HasColumnType("int");

                    b.Property<int>("FacilityId")
                        .HasColumnType("int");

                    b.Property<int?>("MeetingRoomId")
                        .HasColumnType("int");

                    b.HasKey("RoomAmenityId");

                    b.HasIndex("AmenityId");

                    b.HasIndex("FacilityId");

                    b.HasIndex("MeetingRoomId");

                    b.ToTable("RoomAmenities");
                });

            modelBuilder.Entity("SeatManagement2.Models.UnallocatedCabinsView", b =>
                {
                    b.Property<string>("FacilityName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CabinNumber")
                        .HasColumnType("int");

                    b.Property<string>("BuildingCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FloorNumber")
                        .HasColumnType("int");

                    b.HasKey("FacilityName", "CabinNumber");

                    b.ToView("UnallocatedCabinsView");
                });

            modelBuilder.Entity("SeatManagement2.Models.UnallocatedSeats", b =>
                {
                    b.Property<string>("FacilityName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int");

                    b.Property<string>("BuildingCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FloorNumber")
                        .HasColumnType("int");

                    b.HasKey("FacilityName", "SeatNumber");

                    b.ToView("UnallocatedSeats");
                });

            modelBuilder.Entity("SeatManagement2.Models.CabinRoom", b =>
                {
                    b.HasOne("SeatManagement2.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("SeatManagement2.Models.Facility", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Facility");
                });

            modelBuilder.Entity("SeatManagement2.Models.Employee", b =>
                {
                    b.HasOne("SeatManagement2.Models.DepartmentLookUp", "DepartmentLookUp")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DepartmentLookUp");
                });

            modelBuilder.Entity("SeatManagement2.Models.Facility", b =>
                {
                    b.HasOne("SeatManagement2.Models.BuildingLookUp", "BuildingLookUp")
                        .WithMany()
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeatManagement2.Models.CityLookUp", "CityLookUp")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BuildingLookUp");

                    b.Navigation("CityLookUp");
                });

            modelBuilder.Entity("SeatManagement2.Models.GeneralSeat", b =>
                {
                    b.HasOne("SeatManagement2.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("SeatManagement2.Models.Facility", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Facility");
                });

            modelBuilder.Entity("SeatManagement2.Models.MeetingRoom", b =>
                {
                    b.HasOne("SeatManagement2.Models.Facility", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Facility");
                });

            modelBuilder.Entity("SeatManagement2.Models.RoomAmenity", b =>
                {
                    b.HasOne("SeatManagement2.Models.AmenityLookUp", "AmenityLookUp")
                        .WithMany()
                        .HasForeignKey("AmenityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeatManagement2.Models.Facility", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeatManagement2.Models.MeetingRoom", "MeetingRoom")
                        .WithMany()
                        .HasForeignKey("MeetingRoomId");

                    b.Navigation("AmenityLookUp");

                    b.Navigation("Facility");

                    b.Navigation("MeetingRoom");
                });
#pragma warning restore 612, 618
        }
    }
}
