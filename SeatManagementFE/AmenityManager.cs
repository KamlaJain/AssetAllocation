using SeatManagement2.DTOs;
using SeatManagement2.Models;
using SeatManagementFE.Implementation;
using SeatManagementFE.Interfaces;

namespace SeatManagementFE
{
    public class AmenityManager
    {
        public void AddAmenityToMeetingRoom(int meetingroomId, int facilityId)
        {
            Console.WriteLine("Available amenities:");
            IEntityManager<AmenityType> amenity = new EntityManager<AmenityType>("AmenityType/");
            var amenities = amenity.Get();
            foreach (var am in amenities)
            {
                Console.WriteLine($"AmenityId: {am.AmenityId} -- Amenity: {am.AmenityName}");
            }
            Console.WriteLine("Choose amenity id");
            int amenityId = Convert.ToInt32(Console.ReadLine());

            IEntityManager<RoomAmenityDTO> roomAmenity = new EntityManager<RoomAmenityDTO>("Amenity/");
            var amenityToRoom = new RoomAmenityDTO()
            {
                MeetingRoomId = meetingroomId,
                FacilityId = facilityId,
                AmenityId = amenityId
            };
            roomAmenity.Patch(amenityToRoom);
        }
        public void RemoveAmenityFromMeetingRoom(int meetingroomId, int facilityId)
        {
            Console.WriteLine("Alloted amenities in rooms");
            IEntityManager<RoomAmenity> roomAmenities = new EntityManager<RoomAmenity>("Amenity");
            var amenitiesInRoom = roomAmenities.Get();
            var requiredAmenities = amenitiesInRoom.Where(r => r.MeetingRoomId == meetingroomId && r.FacilityId == facilityId);
            foreach (var am in requiredAmenities)
            {
                Console.WriteLine($"Facility Id: {am.FacilityId} || Meeting roomId: {am.MeetingRoomId} || Ameninty Id: {am.AmenityId}");
            };
            IEntityManager<RoomAmenityDTO> amenity = new EntityManager<RoomAmenityDTO>("Amenity");
            if (requiredAmenities.Count() != 0)
            {
                Console.WriteLine("Choose id of Amenity to removed");
                var amenityId = Convert.ToInt32(Console.ReadLine());
                var roomAmenity = new RoomAmenityDTO()
                {
                    FacilityId = facilityId,
                    AmenityId = amenityId
                };
                amenity.Patch(roomAmenity);
            }
            else
            {
                Console.WriteLine("No amenities in room");
            }
        }
    }
}
