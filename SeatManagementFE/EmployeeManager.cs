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
    public class EmployeeManager
    {
        public void AllocateToSeat(int facilityId, int empid)
        {
            Console.WriteLine("Available seats in Facilty:");
            IEntityManager<GeneralSeat> seat = new EntityManager<GeneralSeat>("GeneralSeat/");
            var gseat = seat.Get();

            var seatsinfacility = gseat.Where(b => b.FacilityId == facilityId);

            foreach (var c in seatsinfacility)
            {
                Console.WriteLine($"{c.SeatNumber}");
            }
            Console.WriteLine("Choose seat to onboard employee");
            int seatnumber = Convert.ToInt32(Console.ReadLine());

            IEntityManager<GeneralSeat> empallocation = new EntityManager<GeneralSeat>($"GeneralSeat?toAllocate={true}");
            var allocation = new GeneralSeat
            {
                FacilityId = facilityId,
                EmployeeId = empid,
                SeatNumber = seatnumber,
            };
            empallocation.Patch(allocation);
            Console.WriteLine("Employee Allocated");
        }
        public void AllocateToCabin(int facilityId, int empid)
        {
            Console.WriteLine("Available cabins in facility:");
            IEntityManager<CabinRoom> cabin = new EntityManager<CabinRoom>($"CabinRoom?toAllocate={true}");
            var cab = cabin.Get();

            var cabsinfacility = cab.Where(b => b.FacilityId == facilityId);

            foreach (var c in cabsinfacility)
            {
                Console.WriteLine($" {c.CabinNumber}");
            }
            Console.WriteLine("Choose cabin to onboard employee");
            int cabinnumber = Convert.ToInt32(Console.ReadLine());


            IEntityManager<CabinRoom> empallocation = new EntityManager<CabinRoom>($"CabinRoom?toAllocate={true}");
            var allocation = new CabinRoom
            {
                FacilityId = facilityId,
                EmployeeId = empid,
                CabinNumber = cabinnumber,
            };
            empallocation.Patch(allocation);
        }
        public void DeallocateFromSeat(int facilityId, int empid)
        {
            IEntityManager<GeneralSeat> empdeallocation = new EntityManager<GeneralSeat>($"GeneralSeat?toAllocate=false");
            Console.WriteLine("Enter seatnumber from which employee has to be removed ");
            int seatnum = Convert.ToInt32(Console.ReadLine());
            var deallocatedseat = new GeneralSeat
            {
                FacilityId = facilityId,
                SeatNumber = seatnum,
                EmployeeId = empid
            };
            empdeallocation.Patch(deallocatedseat);
        }
        public void DeallocateFromCabin(int facilityId, int empid)
        {
            IEntityManager<CabinRoom> empdeallocation = new EntityManager<CabinRoom>($"CabinRoom?toAllocate={false}");
            Console.WriteLine("Enter CabinRoom number from which employee has to be removed ");
            int cabinnum = Convert.ToInt32(Console.ReadLine());
            var deallocatedcabin = new CabinRoom
            {
                FacilityId = facilityId,
                EmployeeId = empid,
                CabinNumber = cabinnum,
            };
            empdeallocation.Patch(deallocatedcabin);
        }
    }
}
