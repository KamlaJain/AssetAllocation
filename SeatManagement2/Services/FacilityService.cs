using SeatManagement2.DTOs;
using SeatManagement2.Exceptions;
using SeatManagement2.Interfaces;
using SeatManagement2.Models;

namespace SeatManagement2.Services
{
    public class FacilityService : IFacilityService
    {
        private readonly IRepository<Facility> _repository;
        private readonly IRepository<BuildingLookUp> _buildingrepository;
        private readonly IRepository<CityLookUp> _cityrepository;

        public FacilityService(IRepository<Facility> repository, IRepository<BuildingLookUp> brepository, IRepository<CityLookUp> crepository)
        {
            _repository = repository;
            _buildingrepository = brepository;
            _cityrepository = crepository;
        }
        public List<Facility> IndexFacility()
        {
            return _repository.GetAll().ToList();
        }
        public void AddFacility(FacilityDTO facilityDTO)
        {
            var cityExist = _cityrepository.GetById(facilityDTO.CityId);
            var buildingExist = _buildingrepository.GetById(facilityDTO.BuildingId);
            if (cityExist == null)
            {
                throw new ResourceNotFoundException("Could not find city");
            }
            if (buildingExist == null)
            {
                throw new ResourceNotFoundException("Could not find building");
            }
            var reqFacility = _repository.GetAll().FirstOrDefault(c => c.FacilityName == facilityDTO.FacilityName && c.FloorNumber == facilityDTO.FloorNumber);
            if (reqFacility != null)
            {
                throw new BadRequestException("Facility with the same Name exist in the same floor");
            }

            var item = new Facility
            {
                FacilityName = facilityDTO.FacilityName,
                FloorNumber = facilityDTO.FloorNumber,
                BuildingId = facilityDTO.BuildingId,
                CityId = facilityDTO.CityId,
            };
            _repository.Add(item);
            _repository.Save();

        }

        public void DeleteFacility(int facId)
        {
            var item = _repository.GetById(facId);
            if (item == null)
            {
                throw new ResourceNotFoundException("Coud not find building/city");
            }
            else
            {
                _repository.Delete(item);
                _repository.Save();
            }
        }

    }
}
