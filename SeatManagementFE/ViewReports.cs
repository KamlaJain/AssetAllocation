/*using SeatManagement2.DTOs;
using SeatManagement2.DTOs.ReportDTOs;
using SeatManagement2.Interfaces;
using SeatManagement2.Models;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementFE
{
    public class ViewReports
    {
        public void ViewAllocatedSeatsReport(List<SeatsViewDTO> report)
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
        public void ViewUnallocatedSeatsReport(List<SeatsViewDTO> report)
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
        public void ViewAllocatedCabinsReport(List<CabinsViewDTO> report)
        {
            if (report.ToList().Count != 0)
            {

                Console.WriteLine("Unallocated Cabins:\n");
                foreach (var c in report)
                {
                    Console.WriteLine($"{c.CityCode}- {c.BuildingCode}-{c.FloorNumber}-{c.FacilityName}- S{c.CabinNumber} - EmployeeId: {c.EmployeeId}");
                }
            }
            else
            {
                Console.WriteLine("No Unallocated Cabins");
            }
        }
        public void ViewUnallocatedCabinsReport(List<CabinsViewDTO> report)
        {
            if (report.ToList().Count != 0)
            {

                Console.WriteLine("Unallocated Cabins:\n");
                foreach (var c in report)
                {
                    Console.WriteLine($"{c.CityCode}- {c.BuildingCode}-{c.FloorNumber}-{c.FacilityName}- S{c.CabinNumber}");
                }
            }
            else
            {
                Console.WriteLine("No Unallocated Cabins");
            }
        }
    }
}
*/