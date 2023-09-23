using System.Collections.Generic;
using SeatManagement2.DTOs;
using SeatManagement2.Models;

namespace SeatManagement2.Interfaces
{
    public interface IGeneralSeatService
    {
        List<GeneralSeat> GetAllGeneralSeats();
        void AddGeneralSeat(GeneralSeatDTO generalSeatDTO);
        void DeleteGeneralSeat(int seatId);
        void UpdateEmployeeSeatAllocationStatus(GeneralSeatDTO seat);
        IEnumerable<Object> GenerateSeatsReport(bool isallocatedreport, int filterChoice, FilterDTO filterType);

        /*List<UnallocatedSeats> UnallocatedSeatsReport();
        List<AllocatedSeats> AllocatedSeatsReport();*/
    }
}
