using SeatManagement2.Models;

namespace SeatManagement2.Interfaces
{
    public interface IUnallocatedSeatsReport
    {
        List<UnallocatedSeats> GetUnallocatedSeatsReport();

    }
}
