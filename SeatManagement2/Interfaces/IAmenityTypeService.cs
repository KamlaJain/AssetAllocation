using SeatManagement2.Models;

namespace SeatManagement2.Interfaces
{
    public interface IAmenityTypeService
    {
        List<AmenityType> GetAllAmenities();
        void AddAmenity(string amenityName);
    }
}
