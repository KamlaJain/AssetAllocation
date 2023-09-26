using Humanizer;
using Microsoft.EntityFrameworkCore.Migrations;
using SeatManagement2.Models;
using System.Diagnostics.Metrics;

#nullable disable

namespace SeatManagement2.Migrations
{
    public partial class addSeatsView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
            @"CREATE OR ALTER VIEW AllocatedSeatsView AS
                SELECT
                    C.CityCode,
	                B.BuildingCode,
	                F.FloorNumber,
	                F.FacilityName,
	                S.SeatNumber,
	                E.EmployeeId
                FROM
                    CityLookUps C
                INNER JOIN
                    Facilitys F ON F.CityId = C.CityId
                INNER JOIN

                    BuildingLookUps B ON F.BuildingId = B.BuildingId
                INNER JOIN
                    GeneralSeats S ON F.FacilityId = S.FacilityId
                INNER JOIN
                    Employees E ON E.EmployeeId = S.EmployeeId
                AND S.EmployeeId IS NOT NULL");
            migrationBuilder.Sql(
            @"CREATE OR ALTER VIEW UnallocatedSeatsView AS
                SELECT
                    C.CityCode,
	                B.BuildingCode,
	                F.FloorNumber,
	                F.FacilityName,
	                S.SeatNumber
                FROM
                    CityLookUps C
                INNER JOIN
                    Facilitys F ON F.CityId = C.CityId
                INNER JOIN
	                BuildingLookUps B ON F.BuildingId = B.BuildingId
                INNER JOIN
                    GeneralSeats S ON F.FacilityId=S.FacilityId
                AND S.EmployeeId IS NULL"
            );

            migrationBuilder.Sql(
            @"CREATE OR ALTER VIEW AllocatedCabinsView AS
            SELECT 
            C.CityCode,
            B.BuildingCode,
            F.FacilityName,
            F.FloorNumber,
            CR.CabinNumber,
            E.EmployeeId

            FROM CityLookUps C
            INNER JOIN Facilitys F ON F.CityId = C.CityId
            INNER JOIN BuildingLookUps B ON B.BuildingId = F.BuildingId
            INNER JOIN CabinRooms CR ON CR.FacilityId =F.FacilityId
            INNER JOIN Employees E ON E.EmployeeId= CR.EmployeeId

            AND E.EmployeeId IS NOT NULL");

            migrationBuilder.Sql(
            @"CREATE OR ALTER VIEW UnallocatedCabinsView AS
                SELECT
                    C.CityCode,
	                B.BuildingCode,
	                F.FloorNumber,
	                F.FacilityName,
	                CR.CabinNumber
                FROM
                    CityLookUps C
                INNER JOIN
                    Facilitys F ON F.CityId = C.CityId
                INNER JOIN
	                BuildingLookUps B ON F.BuildingId = B.BuildingId
                INNER JOIN
                    CabinRooms CR ON F.FacilityId = CR.FacilityId
                AND CR.EmployeeId IS NULL"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS AllocatedSeatsView;");
            migrationBuilder.Sql("DROP VIEW IF EXISTS UnallocatedSeatsView;");
            migrationBuilder.Sql("DROP VIEW IF EXISTS AllocatedCabinsView;");
            migrationBuilder.Sql("DROP VIEW IF EXISTS UnallocatedCabinsView;");
        }
    }
}
