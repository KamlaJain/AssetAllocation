using SeatManagement2.DTOs;
using SeatManagement2.Models;

namespace SeatManagement2.Interfaces
{
    public interface IReportService
    {
        IEnumerable<Object> GenerateSeatsReport(bool isallocatedreport, int filterChoice, FilterDTO filterType);
    }
}
