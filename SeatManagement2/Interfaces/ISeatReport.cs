using SeatManagement2.DTOs.ReportDTOs;

namespace SeatManagement2.Interfaces
{
    public interface ISeatReport
    {
        public IQueryable<SeatsViewDTO> GetSeatsReport();
    }
}
