using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeatManagement2.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AmenityLookUp",
                columns: table => new
                {
                    AmenityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmenityName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmenityLookUp", x => x.AmenityId);
                });

            migrationBuilder.CreateTable(
                name: "BuildingLookUps",
                columns: table => new
                {
                    BuildingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingCode = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingLookUps", x => x.BuildingId);
                });

            migrationBuilder.CreateTable(
                name: "CityLookUps",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityCode = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityLookUps", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentLookUps",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentLookUps", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Facilitys",
                columns: table => new
                {
                    FacilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FloorNumber = table.Column<int>(type: "int", nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilitys", x => x.FacilityId);
                    table.ForeignKey(
                        name: "FK_Facilitys_BuildingLookUps_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "BuildingLookUps",
                        principalColumn: "BuildingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Facilitys_CityLookUps_CityId",
                        column: x => x.CityId,
                        principalTable: "CityLookUps",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAllocated = table.Column<bool>(type: "bit", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_DepartmentLookUps_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "DepartmentLookUps",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeetingRooms",
                columns: table => new
                {
                    MeetingRoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingRoomNumber = table.Column<int>(type: "int", nullable: false),
                    SeatingCapacity = table.Column<int>(type: "int", nullable: false),
                    FacilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingRooms", x => x.MeetingRoomId);
                    table.ForeignKey(
                        name: "FK_MeetingRooms_Facilitys_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilitys",
                        principalColumn: "FacilityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CabinRooms",
                columns: table => new
                {
                    CabinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CabinNumber = table.Column<int>(type: "int", nullable: false),
                    FacilityId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabinRooms", x => x.CabinId);
                    table.ForeignKey(
                        name: "FK_CabinRooms_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_CabinRooms_Facilitys_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilitys",
                        principalColumn: "FacilityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneralSeats",
                columns: table => new
                {
                    SeatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatNumber = table.Column<int>(type: "int", nullable: false),
                    FacilityId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralSeats", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_GeneralSeats_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_GeneralSeats_Facilitys_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilitys",
                        principalColumn: "FacilityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomAmenities",
                columns: table => new
                {
                    RoomAmenityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmenityId = table.Column<int>(type: "int", nullable: false),
                    FacilityId = table.Column<int>(type: "int", nullable: false),
                    MeetingRoomId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAmenities", x => x.RoomAmenityId);
                    table.ForeignKey(
                        name: "FK_RoomAmenities_AmenityLookUp_AmenityId",
                        column: x => x.AmenityId,
                        principalTable: "AmenityLookUp",
                        principalColumn: "AmenityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomAmenities_Facilitys_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilitys",
                        principalColumn: "FacilityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomAmenities_MeetingRooms_MeetingRoomId",
                        column: x => x.MeetingRoomId,
                        principalTable: "MeetingRooms",
                        principalColumn: "MeetingRoomId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildingLookUps_BuildingCode",
                table: "BuildingLookUps",
                column: "BuildingCode",
                unique: true,
                filter: "[BuildingCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CabinRooms_EmployeeId",
                table: "CabinRooms",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CabinRooms_FacilityId",
                table: "CabinRooms",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_CityLookUps_CityCode",
                table: "CityLookUps",
                column: "CityCode",
                unique: true,
                filter: "[CityCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Facilitys_BuildingId",
                table: "Facilitys",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Facilitys_CityId",
                table: "Facilitys",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralSeats_EmployeeId",
                table: "GeneralSeats",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralSeats_FacilityId",
                table: "GeneralSeats",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingRooms_FacilityId",
                table: "MeetingRooms",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenities_AmenityId",
                table: "RoomAmenities",
                column: "AmenityId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenities_FacilityId",
                table: "RoomAmenities",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenities_MeetingRoomId",
                table: "RoomAmenities",
                column: "MeetingRoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CabinRooms");

            migrationBuilder.DropTable(
                name: "GeneralSeats");

            migrationBuilder.DropTable(
                name: "RoomAmenities");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "AmenityLookUp");

            migrationBuilder.DropTable(
                name: "MeetingRooms");

            migrationBuilder.DropTable(
                name: "DepartmentLookUps");

            migrationBuilder.DropTable(
                name: "Facilitys");

            migrationBuilder.DropTable(
                name: "BuildingLookUps");

            migrationBuilder.DropTable(
                name: "CityLookUps");
        }
    }
}
