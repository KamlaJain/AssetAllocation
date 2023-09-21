using SeatManagement2.Interfaces;
using SeatManagement2.Models;

namespace SeatManagement2.Services
{
    public class UnallocatedSeatService : IUnallocatedSeatsReport
    {
        private readonly IRepository<UnallocatedSeats> _repository;

        public UnallocatedSeatService(IRepository<UnallocatedSeats> repository)
        {
            _repository = repository;
        }
        public List<UnallocatedSeats> GetUnallocatedSeatsReport()
        {
            return _repository.GetAll().ToList();
        }
    }
   
}
