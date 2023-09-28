using SeatManagement2.DTOs.ReportDTOs;
using SeatManagement2.Models;

namespace SeatManagement2.Interfaces
{
    public interface ISeatReport
    {
        public IQueryable<SeatsViewDTO> GetSeatsReport();
    }
}
