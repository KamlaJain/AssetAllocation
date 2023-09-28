using Microsoft.CodeAnalysis;
using SeatManagement2.Models;
using SeatManagementFE.Implementation;
using SeatManagementFE.Interfaces;
using System;

namespace SeatManagementFE
{
    public class EmployeeManager
    {
        public void ManageEmployee()

        {
            Console.WriteLine(
                "\n 1--> Allocate employee to  Seat " +
                "\n 2--> Allocate employee to  Cabin " +
                "\n 3--> Deallocate employee From Seat " +
                "\n 4--> Deallocate employee From Cabin " +
                "\n 0-->exit");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AllocateToSeat();
                    break;
                case 2:
                    AllocateToCabin();
                    break;
                case 3:
                    DeallocateFromSeat();
                    break;
                case 4:
                    DeallocateFromCabin();
                    break;
                case 0:
                    //Environment.Exit(0);
                    break;
            }
        }

        public static void AllocateToSeat()
        {
            Console.WriteLine("Available Seats: ");
            IEntityManager<GeneralSeat> seat = new EntityManager<GeneralSeat>("GeneralSeat/");
            var seats = seat.Get();
            var reqSeats = seats.Where(s => s.EmployeeId == null);
            foreach (var c in reqSeats)
            {
                Console.WriteLine($"{c.SeatId} {c.SeatNumber}");
            }
            Console.WriteLine("Choose seat id");
            int seatId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter employee id");
            int empid = Convert.ToInt32(Console.ReadLine());

            IEntityManager<GeneralSeat> empallocation = new EntityManager<GeneralSeat>($"GeneralSeat/{seatId}?employeeId={empid}");
            var response = empallocation.PatchEmployeeDetails(seatId,empid);
            Console.WriteLine( response == true ? "Success" : "Failed");

        }
        public static void AllocateToCabin()
        {
            Console.WriteLine("Available Cabins: ");
            IEntityManager<CabinRoom> cabin = new EntityManager<CabinRoom>("CabinRoom/");
            var cabins = cabin.Get();
            var reqCabins= cabins.Where(s=>s.EmployeeId== null);
            foreach (var c in reqCabins)
            {
                Console.WriteLine($"{c.CabinId} {c.CabinNumber}");
            }
            Console.WriteLine("Choose cabin id");
            int cabinId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter employee id");
            int empid = Convert.ToInt32(Console.ReadLine());

            IEntityManager<CabinRoom> empallocation = new EntityManager<CabinRoom>($"CabinRoom/{cabinId}?employeeId={empid}");
            var response = empallocation.PatchEmployeeDetails(cabinId, empid);
            Console.WriteLine(response == true ? "Success" : "Failed");

        }
        public static void DeallocateFromSeat()
        {
            Console.WriteLine("Available Seats: ");
            IEntityManager<GeneralSeat> seat = new EntityManager<GeneralSeat>("GeneralSeat/");
            var seats = seat.Get();
            var reqSeats = seats.Where(s => s.EmployeeId != null);
            foreach (var c in reqSeats)
            {
                Console.WriteLine($"{c.SeatId} {c.SeatNumber}");
            }
            Console.WriteLine("Choose seat id");
            int seatId = Convert.ToInt32(Console.ReadLine());
            int? empId = null;

            IEntityManager<GeneralSeat> empdeallocation = new EntityManager<GeneralSeat>($"GeneralSeat/{seatId}");
            var response = empdeallocation.PatchEmployeeDetails(seatId, empId);
            Console.WriteLine(response == true ? "Success" : "Failed");
        }
        public static void DeallocateFromCabin()
        {
            Console.WriteLine("Available Cabins: ");
            IEntityManager<CabinRoom> cabin = new EntityManager<CabinRoom>("CabinRoom/");
            var cabins = cabin.Get();
            var reqCabins = cabins.Where(s => s.EmployeeId != null);
            foreach (var c in reqCabins)
            {
                Console.WriteLine($"{c.CabinId} {c.CabinNumber}");
            }
            Console.WriteLine("Choose cabin id");
            int cabinId = Convert.ToInt32(Console.ReadLine());
            int? empId = null;

            IEntityManager<CabinRoom> empdeallocation = new EntityManager<CabinRoom>($"CabinRoom/{cabinId}");
            var response = empdeallocation.PatchEmployeeDetails(cabinId, empId);
            Console.WriteLine(response == true ? "Success" : "Failed");
        }
    }
}
