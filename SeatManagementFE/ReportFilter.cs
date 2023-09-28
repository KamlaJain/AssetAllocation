namespace SeatManagementFE
{
    public class ReportFilter
    {
        public string CityFilter()
        {
            Console.WriteLine("Enter City Abbrevation to filter");
            string cityAbbr = Console.ReadLine().ToUpper();

            if (cityAbbr == "")
            {
                return null;
            }
            return cityAbbr;
        }
        public string BuildingFilter()
        {
            Console.WriteLine("Enter Building Abbrevation to filter");
            string buildingAbbr = Console.ReadLine().ToUpper();

            if (buildingAbbr == "")
            {
                return null;
            }
            return buildingAbbr;
        }
        public string FacilityNameFilter()
        {
            Console.WriteLine("Enter Facility Name to filter");
            string facilityName = Console.ReadLine();
            if (facilityName == "")
            {
                return null;
            }
            return facilityName;

        }
        public int FloorFilter()
        {
            Console.WriteLine("Enter Floor to filter");
            string floor = Console.ReadLine();
            if (floor == "")
            {
                return 0;
            }
            return Convert.ToInt32(floor);
        }
    }
}


