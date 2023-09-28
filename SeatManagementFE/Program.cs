﻿using Newtonsoft.Json;
using SeatManagement2.Controllers;
using SeatManagement2.Models;
using SeatManagementFE.Interfaces;
using SeatManagementFE.Implementation;
using System.IO;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using SeatManagementFE;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Composition;
using SeatManagement2.Interfaces;
using SeatManagement2.Models.ReportViews;

namespace SeatManagementConsole
{

    public class Program
    {
        static void Main(string[] args)
        {
            OnboardItems onboardItems = new OnboardItems();
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
                        ManageEmployee();
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


        public static void ManageEmployee()
        {

            Console.WriteLine("Available Facilities: ");
            IEntityManager<Facility> fac = new EntityManager<Facility>("Facility/");
            var facilities = fac.Get();
            foreach (var c in facilities)
            {
                Console.WriteLine($"{c.FacilityId} {c.FacilityName}");
            }
            Console.WriteLine("Choose facilty to onboard employee");
            int facilityId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter employee id");
            var empid = Convert.ToInt32(Console.ReadLine());

            EmployeeManager manage = new EmployeeManager();


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
                    manage.AllocateToSeat(facilityId, empid);
                    break;
                case 2:
                    manage.AllocateToCabin(facilityId, empid);
                    break;
                case 3:
                    manage.DeallocateFromSeat(facilityId, empid);
                    break;
                case 4:
                    manage.DeallocateFromCabin(facilityId, empid);
                    break;
                case 0:
                    //Environment.Exit(0);
                    break;
            }
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
            Console.WriteLine("Apply Filters?" +
                 "\n 1-->Yes " +
                 "\n 2-->No ");
            int option = Convert.ToInt32(Console.ReadLine());

            

            if (option == 2)
            {
                switch (choice)
                {
                    case 1:
                        getreport.GetAllocatedSeatsReport();
                        //viewreport.ViewAllocatedSeatsReport(allocatedseatsreport);
                        break;
                    case 2:
                        getreport.GetFreeSeatsReport();
                        //viewreport.ViewUnallocatedSeatsReport(unallocatedseatsreport);
                        break;
                    case 3:
                        getreport.GetAllocatedCabinsReport();
                        //viewreport.ViewAllocatedCabinsReport(allocatedcabinsreport);
                        break;
                    case 4:
                         getreport.GetFreeCabinsReport();
                        //viewreport.ViewUnallocatedCabinsReport(unallocatedcabinsreport);
                        break;

                    case 0:
                        //Environment.Exit(0);
                        break;
                }
            }
            else if (option == 1)
            {
                ReportFilter filter = new ReportFilter();
                Console.WriteLine(
                "\n 1-->Filter by City " +
                "\n 2-->Filter by Building " +
                "\n 3-->Filter By Floor " +
                "\n 4-->Filter by facility Name" +
                "\n 0-->Exit");


                int filteroption = Convert.ToInt32(Console.ReadLine());
                switch (filteroption)
                {
                    case 1:
                        filter.CityFilter();
                        break;
                    case 2:
                        filter.BuildingFilter();
                        break;
                    case 3:
                        filter.FloorFilter();
                        break;
                    case 4:
                        filter.FacilityNameFilter();
                        break;
                    case 0:
                        //Environment.Exit(0);
                        break;
                }
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



/*switch (choice)
{
    case 1:
        var allocatedseatsreport = getreport.GetAllocatedSeatsReport();
        viewreport.ViewAllocatedSeatsReport(allocatedseatsreport);
        break;
    case 2:
        var unallocatedseatsreport = getreport.GetFreeSeatsReport();
        viewreport.ViewUnallocatedSeatsReport(unallocatedseatsreport);
        break;
    case 3:
        var allocatedcabinsreport = getreport.GetAllocatedCabinsReport();
        viewreport.ViewAllocatedCabinsReport(allocatedcabinsreport);
        break;
    case 4:
        var unallocatedcabinsreport = getreport.GetFreeCabinsReport();
        viewreport.ViewUnallocatedCabinsReport(unallocatedcabinsreport);
        break;

    case 0:
        //Environment.Exit(0);
        break;
}*/