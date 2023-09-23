using SeatManagement2.Models;

namespace SeatManagement2.Interfaces
{
    public interface IAmenityService
    {
        List<AmenityLookUp> GetAllAmenities();
        void AddAmenity(string amenityName);
        void DeleteAmenity(int amenityId);
    }
}
