using Microsoft.AspNetCore.Mvc;
using SeatManagement2.DTOs;
using SeatManagement2.Models;
using SeatManagement2.Interfaces;

namespace SeatManagement2.Services
{
    public class AllocatedSeatService: IAllocatedSeatsReport
    {
        private readonly IRepository<AllocatedSeats> _repository;

        public AllocatedSeatService(IRepository<AllocatedSeats> repository)
        {
            _repository = repository;
        }
        public IEnumerable<AllocatedSeats> GetAllocatedSeatsReport ()
        {
            return _repository.GetAll();
        }
    }
}
