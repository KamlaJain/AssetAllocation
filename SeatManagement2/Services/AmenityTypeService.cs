using SeatManagement2.Interfaces;
using SeatManagement2.Models;

namespace SeatManagement2.Services
{
    public class AmenityTypeService : IAmenityTypeService
    {
        private readonly IRepository<AmenityType> _repository;

        public AmenityTypeService(IRepository<AmenityType> repository)
        {
            _repository = repository;
        }

        public List<AmenityType> GetAllAmenities()
        {
            return _repository.GetAll().ToList();
        }

        public void AddAmenity(string amenityName)
        {
            var item = new AmenityType
            {
                AmenityName = amenityName
            };
            _repository.Add(item);
            _repository.Save();
        }
    }
}






