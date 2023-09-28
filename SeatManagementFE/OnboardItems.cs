using SeatManagement2.DTOs;
using SeatManagement2.Models;
using SeatManagementFE.Implementation;
using SeatManagementFE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementFE
{
    public class OnboardItems
    {
       
        public void OnboardFacility()
        {

            Console.WriteLine("Available Cities: ");
            IEntityManager<CityLookUp> city = new EntityManager<CityLookUp>("City/");
            var cities = city.Get();
            foreach (var c in cities)
            {
                Console.WriteLine($"{c.CityId} {c.CityName}");
            }
            Console.WriteLine("Choose city to add your facility ");
            int cityId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Available Buildings: "); 
            IEntityManager<BuildingLookUp> building = new EntityManager<BuildingLookUp>("Building/");
            var buildings = building.Get();
          

            foreach (var b in buildings)
            {
                Console.WriteLine($"{b.BuildingId} {b.BuildingName}");
            }
            Console.WriteLine("Choose building ");
            int buildingId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Floor Number");
            int floorNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter name of facility");
            string facilityName = Console.ReadLine();

            IEntityManager<Facility> facility = new EntityManager<Facility>("Facility/");
            var fac = new Facility
            {
                FacilityName = facilityName,
                FloorNumber = floorNumber,
                CityId = cityId,
                BuildingId = buildingId
            };
            facility.Add(fac);
            Console.WriteLine("Facility successfully added");
        }
        public void OnboardMeetingRoom()
        {
            Console.WriteLine("Available Facilities: ");
            IEntityManager<Facility> fac = new EntityManager<Facility>("Facility/");
            var facilities = fac.Get();
            foreach (var c in facilities)
            {
                Console.WriteLine($"{c.FacilityId} {c.FacilityName}");
            }
            Console.WriteLine("Choose facilty to onboard meeting room ");
            int facilityId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Meeting Room Number");
            int meetingroomNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter required seating capacity");
            int seatingCap = Convert.ToInt32(Console.ReadLine());

            IEntityManager<MeetingRoom> meetingRoom = new EntityManager<MeetingRoom>("MeetingRoom/");
            var mroom = new MeetingRoom
            {
                MeetingRoomNumber = meetingroomNumber,
                SeatingCapacity = seatingCap,
                FacilityId = facilityId,
            };
            meetingRoom.Add(mroom);
            Console.WriteLine("Successfully added meeting room");
        }
        public void OnboardCabin()
        {
            Console.WriteLine("Available Facilities: ");
            IEntityManager<Facility> fac = new EntityManager<Facility>("Facility/");
            var facilities = fac.Get();
            foreach (var c in facilities)
            {
                Console.WriteLine($"{c.FacilityId} {c.FacilityName}");
            }
            Console.WriteLine("Choose facilty to onboard cabin");
            int facilityId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Cabin Number");
            int cabinnumber = Convert.ToInt32(Console.ReadLine());

            IEntityManager<CabinRoomDTO> cabin = new EntityManager<CabinRoomDTO>("CabinRoom/");
            var croom = new CabinRoomDTO()
            {
                CabinNumber = cabinnumber,
                FacilityId = facilityId,
            };
            cabin.Add(croom); 
            Console.WriteLine("Cabin Added");
        }

        public void OnboardSeat()
        {
            Console.WriteLine("Available Facilities: ");
            IEntityManager<Facility> fac = new EntityManager<Facility>("Facility/");
            var facilities = fac.Get();
            foreach (var c in facilities)
            {
                Console.WriteLine($"{c.FacilityId} {c.FacilityName}");
            }
            Console.WriteLine("Choose facilty to onboard seat");
            int facilityId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Seat Number");
            int seatnumber = Convert.ToInt32(Console.ReadLine());

            IEntityManager<GeneralSeatDTO> seat = new EntityManager<GeneralSeatDTO>("GeneralSeat/");
            var gseat = new GeneralSeatDTO()
            {
                SeatNumber = seatnumber,
                FacilityId = facilityId,
            };
            seat.Add(gseat); 
            Console.WriteLine("Seat added");
        }

        public void OnboardEmployee()
        {
            Console.WriteLine("Enter Name of Employee");
            string name = Console.ReadLine();

            Console.WriteLine("Available Departments: ");
            IEntityManager<DepartmentLookUp> fac = new EntityManager<DepartmentLookUp>("Department/");
            var dept = fac.Get();
            foreach (var c in dept)
            {
                Console.WriteLine($"{c.DepartmentId} {c.DepartmentName}");
            }
            Console.WriteLine("Choose department to add employee");
            int deptid = Convert.ToInt32(Console.ReadLine());


            IEntityManager<Employee> employee = new EntityManager<Employee>("Employee/");
            var emp = new Employee
            {
                DepartmentId = deptid,
                EmployeeName = name,
            };
            employee.Add(emp);
            Console.WriteLine("Successfully added Employee");
        }
    }
}
