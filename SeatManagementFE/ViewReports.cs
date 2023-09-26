using SeatManagement2.Models;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementFE
{
    internal class ViewReports
    {
        public void ViewAllocatedReport(List<AllocatedSeatsView> report)
        {
            if (report.ToList().Count != 0)
            {

                Console.WriteLine("Allocated Seats:\n");
                foreach (var c in report)
                {
                    Console.WriteLine($"{c.CityCode}- {c.BuildingCode}-{c.FloorNumber}-{c.FacilityName}- S{c.SeatNumber} - EmployeeId: {c.EmployeeId}");
                }
            }
            else
            {
                Console.WriteLine("No Allocated Seats");
            }
        }
        public void ViewUnallocatedReport(List<UnallocatedSeatsView> report)
        {
            if (report.ToList().Count != 0)
            {

                Console.WriteLine("Unallocated Seats:\n");
                foreach (var c in report)
                {
                    Console.WriteLine($"{c.CityCode}- {c.BuildingCode}-{c.FloorNumber}-{c.FacilityName}- S{c.SeatNumber}");
                }
            }
            else
            {
                Console.WriteLine("No Unallocated Seats");
            }
        }

    }
}
