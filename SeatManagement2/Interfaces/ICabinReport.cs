using SeatManagement2.DTOs;
using SeatManagement2.DTOs.ReportDTOs;

namespace SeatManagement2.Interfaces
{
    public interface ICabinReport
    {
        public IQueryable<CabinsViewDTO> GetCabinsReport();
    }
}
