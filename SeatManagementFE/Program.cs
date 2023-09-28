using SeatManagement2.Models;
using SeatManagementFE;
using SeatManagementFE.Implementation;
using SeatManagementFE.Interfaces;

namespace SeatManagementConsole
{

    public class Program
    {
        static void Main(string[] args)
        {
            OnboardItems onboardItems = new OnboardItems();
            EmployeeManager manage = new EmployeeManager();
            Console.WriteLine("Welcome to Asset management system\n");
            int choice;
            do
            {
                Console.WriteLine("\nPlease enter an option: " +
                    "\n1. Onboard a facility" +
                    "\n2. Onboard meeting room" +
                    "\n3. Onboard cabin" +
                    "\n4. Onboard seats" +
                    "\n5. Onboard Employee" +
                    "\n6. Allocate seats" +
                    "\n7. View Reports" +
                    "\n8. Manage Amenities" +
                    "\n0. EXIT");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        onboardItems.OnboardFacility();
                        break;
                    case 2:
                        onboardItems.OnboardMeetingRoom();
                        break;
                    case 3:
                        onboardItems.OnboardCabin();
                        break;
                    case 4:
                        onboardItems.OnboardSeat();
                        break;
                    case 5:
                        onboardItems.OnboardEmployee();
                        break;
                    case 6:
                        manage.ManageEmployee();
                        break;
                    case 7:
                        ViewReports();
                        break;
                    case 8:
                        ManageAmenities();
                        break;
                    case 0:
                        //Environment.Exit(0);
                        break;
                }

            } while (choice != 0);

        }
       public static void ViewReports()
        {

            GetReports getreport = new GetReports();

            Console.WriteLine("View Reports of " +
               "\n 1-->Allocated Seats " +
               "\n 2-->Unallocated Seats " +
               "\n 3-->Allocated Cabins " +
               "\n 4-->Unallocated Cabins " +
               "\n 0-->exit");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    getreport.GetAllocatedSeatsReport();
                    break;
                case 2:
                    getreport.GetFreeSeatsReport();
                    break;
                case 3:
                    getreport.GetAllocatedCabinsReport();
                    break;
                case 4:
                    getreport.GetFreeCabinsReport();
                    break;

                case 0:
                    //Environment.Exit(0);
                    break;
            }


        }

        public static void ManageAmenities()
        {
            Console.WriteLine("Available meeting Rooms");
            EntityManager<MeetingRoom> meetingroom = new EntityManager<MeetingRoom>("MeetingRoom/");
            var meetingrooms = meetingroom.Get();
            foreach (var m in meetingrooms)
            {
                Console.WriteLine($"RoomId: {m.MeetingRoomId}--Facility Id: {m.FacilityId} --Meeting Room Number: {m.MeetingRoomNumber} -- Seating Capacity: {m.SeatingCapacity}");
            }
            Console.WriteLine("Enter meeting room Id to add/remove Amenity");
            int meetingroomId = Convert.ToInt32(Console.ReadLine());
            var requiredMeetingRoom = meetingrooms.FirstOrDefault(x => x.MeetingRoomId == meetingroomId);
            int facilityId = requiredMeetingRoom.FacilityId;

            Console.WriteLine("Choose Action: \n 1--> Add Amenity to meetingRoom \n 2--> Remove Amenity From MeetingRoom");
            int choice = Convert.ToInt32(Console.ReadLine());

            AmenityManager manageAmenities = new AmenityManager();
            switch (choice)
            {
                case 1:
                    manageAmenities.AddAmenityToMeetingRoom(meetingroomId, facilityId);
                    break;
                case 2:
                    manageAmenities.RemoveAmenityFromMeetingRoom(meetingroomId, facilityId);
                    break;
                case 0:
                    //Environment.Exit(0);
                    break;
            }
        }
    }
}
