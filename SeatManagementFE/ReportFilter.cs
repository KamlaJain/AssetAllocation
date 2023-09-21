using SeatManagement2.Models;
using SeatManagementFE.Implementation;
using SeatManagementFE.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementFE
{
    public class ReportFilter
    {
        public void BuildingFilter(int choice)
        {
            GetReports getreports = new GetReports();
            ViewReports viewreports = new ViewReports();
            Console.WriteLine("Available Buildings: ");
            IEntityManager<BuildingLookUp> building = new EntityManager<BuildingLookUp>("BuildingLookUp/");
            var buildings = building.Get();
            foreach (var b in buildings)
            {
                Console.WriteLine($"{b.BuildingId} {b.BuildingName}");
            }
            Console.WriteLine("Choose building ");
            int buildingId = Convert.ToInt32(Console.ReadLine());
            var buildingtofilter = buildings.First(b => b.BuildingId == buildingId);

            if (buildingtofilter == null)
            {
                Console.WriteLine("Enter Valid BuildingId");
            }
            else
            {
                if (choice == 1)
                {
                    var reports = getreports.GetAllocatedSeatsReport().Where(r => r.BuildingCode == buildingtofilter.BuildingCode);
                    viewreports.ViewAllocatedReport(reports.ToList());
                }
                if(choice == 2)
                {
                    var reports = getreports.GetFreeSeatsReport().Where(r => r.BuildingCode == buildingtofilter.BuildingCode);
                    viewreports.ViewUnallocatedReport(reports.ToList());
                }
            }
        }
        public void FloorFilter(int choice)
        {
            GetReports getreports = new GetReports();
            ViewReports viewreports = new ViewReports();
            Console.WriteLine("Enter floor ");
            int floornumber = Convert.ToInt32(Console.ReadLine());

            IEntityManager<Facility> fac = new EntityManager<Facility>("Facility/");
            var facility = fac.Get(); 

            var floortofilter= facility.Where(b => b.FloorNumber == floornumber);

            if (floortofilter == null)
            {
                Console.WriteLine("Enter Valid Floor Number");
            }
            else
            {
                if (choice == 1)
                {
                    var reports = getreports.GetAllocatedSeatsReport().Where(r => r.FloorNumber == floornumber);
                    viewreports.ViewAllocatedReport(reports.ToList());
                }
                if (choice == 2)
                {
                    var reports = getreports.GetFreeSeatsReport().Where(r => r.FloorNumber == floornumber);
                    viewreports.ViewUnallocatedReport(reports.ToList());
                }
            }
        }
        public void FacilityNameFilter(int choice)
        {
            GetReports getreports = new GetReports();
            ViewReports viewreports = new ViewReports();
            Console.WriteLine("Enter Facility Name ");
            string facilitynameinput = Console.ReadLine();

            IEntityManager<Facility> fac = new EntityManager<Facility>("Facility/");
            var facility = fac.Get();

            var facilitytofilter = facility.Where(b => b.FacilityName == facilitynameinput);

            if (facilitytofilter == null)
            {
                Console.WriteLine("Enter Valid Facility Name");
            }
            else
            {
                if (choice == 1)
                {
                    var reports = getreports.GetAllocatedSeatsReport().Where(r => r.FacilityName == facilitynameinput);
                    viewreports.ViewAllocatedReport(reports.ToList());
                }
                if (choice == 2)
                {
                    var reports = getreports.GetFreeSeatsReport().Where(r => r.FacilityName == facilitynameinput);
                    viewreports.ViewUnallocatedReport(reports.ToList());
                }
            }

        }
    }
}


