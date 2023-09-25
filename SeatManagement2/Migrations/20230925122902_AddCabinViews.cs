using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeatManagement2.Migrations
{
    public partial class AddCabinViews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
            migrationBuilder.Sql("DROP VIEW IF EXISTS UnallocatedCabinsView;");
            migrationBuilder.Sql("DROP VIEW IF EXISTS AllocatedCabinsView;");
        }
    }
}
