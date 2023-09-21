using SeatManagement2.Models;

namespace SeatManagement2.Interfaces
{
    public interface IAllocatedSeatsReport
    {
        IEnumerable<AllocatedSeats> GetAllocatedSeatsReport();

    }
}
