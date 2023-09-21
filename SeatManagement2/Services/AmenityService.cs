using SeatManagement2.Models;
using SeatManagement2.Interfaces;



namespace SeatManagement2.Services
{
    public class AmenityService:IAmenityService
    {
        private readonly IRepository<AmenityLookUp> _repository;

        public AmenityService(IRepository<AmenityLookUp> repository)
        {
            _repository = repository;
        }

        public List<AmenityLookUp> GetAllAmenities()
        {
            return _repository.GetAll().ToList();
        }

        public void AddAmenity(string amenityName)
        {
            var amenities = _repository.GetAll().FirstOrDefault(a => a.AmenityName == amenityName);

            var item = new AmenityLookUp
            {
                AmenityName = amenityName
            };
            _repository.Add(item);
            _repository.Save();
        }

        public void DeleteAmenity(int amenityId)
        {
            var item = _repository.GetById(amenityId);
            if (item == null)
            {
                throw new Exception("Could not find amenity");
            }
            else
            {
                _repository.Delete(item);
                _repository.Save();
            }
        }
    }
}






