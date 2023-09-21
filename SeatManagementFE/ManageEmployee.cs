using Microsoft.CodeAnalysis;
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
    public class ManageEmployee
    {
        public void AllocateToSeat(int facilityId, int empid)
        {
            Console.WriteLine("Available seats:");
            IEntityManager<GeneralSeat> seat = new EntityManager<GeneralSeat>("GeneralSeat/");
            var gseat = seat.Get();

            var seatsinfacility = gseat.Where(b => b.FacilityId == facilityId);

            foreach (var c in seatsinfacility)
            {
                Console.WriteLine($"{c.SeatId} {c.SeatNumber}");
            }
            Console.WriteLine("Choose seat to onboard employee");
            int seatnumber = Convert.ToInt32(Console.ReadLine());

            IAllocationManager<GeneralSeat> empallocation = new AllocationManager<GeneralSeat>("GeneralSeat/");
            var allocation = new GeneralSeat
            {
                FacilityId = facilityId,
                EmployeeId = empid,
                SeatNumber = seatnumber,
            };
            empallocation.Allocate(allocation);
            Console.WriteLine("Employee Allocated");
        }
        public void AllocateToCabin(int facilityId, int empid)
        {
            Console.WriteLine("Available cabins:");
            IEntityManager<CabinRoom> cabin = new EntityManager<CabinRoom>("CabinRoom/");
            var cab = cabin.Get();

            var cabsinfacility = cab.Where(b => b.FacilityId == facilityId);

            foreach (var c in cabsinfacility)
            {
                Console.WriteLine($"{c.CabinId} {c.CabinNumber}");
            }
            Console.WriteLine("Choose cabin to onboard employee");
            int cabinnumber = Convert.ToInt32(Console.ReadLine());


            IAllocationManager<CabinRoom> empallocation = new AllocationManager<CabinRoom>("CabinRoom/");
            var allocation = new CabinRoom
            {
                FacilityId = facilityId,
                EmployeeId = empid,
                CabinNumber = cabinnumber,
            };
            empallocation.Allocate(allocation);
            Console.WriteLine("Employee Allocated");
        }
        public void DeallocateFromSeat(int facilityId)
        {
            IAllocationManager<GeneralSeat> empdeallocation = new AllocationManager<GeneralSeat>("GeneralSeat/");
            Console.WriteLine("Enter seatnumber from which employee has to be removed ");
            int seatnum = Convert.ToInt32(Console.ReadLine());
            var deallocatedseat = new GeneralSeat
            {
                FacilityId = facilityId,
                SeatNumber = seatnum,
            };
            empdeallocation.Deallocate(deallocatedseat);
        }
        public void DeallocateFromCabin(int facilityId)
        {
            IAllocationManager<CabinRoom> empdeallocation = new AllocationManager<CabinRoom>("CabinRoom/");
            Console.WriteLine("Enter CabinRoom number from which employee has to be removed ");
            int cabinnum = Convert.ToInt32(Console.ReadLine());
            var deallocatedcabin = new CabinRoom
            {
                FacilityId = facilityId,
                CabinNumber = cabinnum,
            };
            empdeallocation.Deallocate(deallocatedcabin);
        }
    }
}
