using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeatManagement2.Migrations
{
    public partial class AddViews : Migration
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
                    GeneralSeats S ON F.FacilityId=S.FacilityId
                INNER JOIN
                    Employees E ON E.EmployeeId=S.EmployeeId
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


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS UnallocatedSeatsView;");
            migrationBuilder.Sql("DROP VIEW IF EXISTS AllocatedSeatsView;");

        }
    }
}
