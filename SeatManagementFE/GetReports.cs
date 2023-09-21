using SeatManagement2.Models;
using SeatManagementFE.Implementation;
using SeatManagementFE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementFE
{
    public class GetReports
    {
        public List<AllocatedSeats> GetAllocatedSeatsReport()
        {
            IEntityManager<AllocatedSeats> alseat = new EntityManager<AllocatedSeats>("AllocatedSeat/");
            var report = alseat.Get();
            
            return report;
        }
        public List<UnallocatedSeats> GetFreeSeatsReport()
        {
            IEntityManager<UnallocatedSeats> unalseat = new EntityManager<UnallocatedSeats>("UnallocatedSeat/");
            var report = unalseat.Get();
          
            return report;
        }
    }
}
