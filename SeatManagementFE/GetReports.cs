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
        public List<AllocatedSeatsView> GetAllocatedSeatsReport()
        {
            IEntityManager<AllocatedSeatsView> alseat = new EntityManager<AllocatedSeatsView>("AllocatedSeat/");
            var report = alseat.Get();
            
            return report;
        }
        public List<UnallocatedSeatsView> GetFreeSeatsReport()
        {
            IEntityManager<UnallocatedSeatsView> unalseat = new EntityManager<UnallocatedSeatsView>("UnallocatedSeat/");
            var report = unalseat.Get();
          
            return report;
        }
    }
}
