using SeatManagement2.DTOs;
using SeatManagement2.Models;

namespace SeatManagement2.Interfaces
{
    public interface IFacilityService
    {
        List<Facility> IndexFacility();
        void AddFacility(FacilityDTO facilityDTO);
        void DeleteFacility(int facId);
    }
}
