using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeatManagement2.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
           @"CREATE OR ALTER VIEW UnallocatedSeats AS
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
            migrationBuilder.Sql("DROP VIEW IF EXISTS UnallocatedSeats;");

        }
    }
}
