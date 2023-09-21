using Microsoft.AspNetCore.Mvc;
using SeatManagement2.DTOs;
using SeatManagement2.Models;
using SeatManagement2.Interfaces;



namespace SeatManagement2.Services
{
    public class FacilityService: IFacilityService
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
        [HttpGet]
        public List<Facility> IndexFacility()
        {
            return _repository.GetAll().ToList();
        }
        [HttpPost]
        public void AddFacility(FacilityDTO facilityDTO)
        {
            var cityExist = _cityrepository.GetById(facilityDTO.CityId);
            var buildingExist = _buildingrepository.GetById(facilityDTO.BuildingId);
            if (buildingExist == null || cityExist == null)
            {
                throw new Exception("Could not find building/city");
            }
            else
            {
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
        }

        [HttpDelete]
        public void DeleteFacility(int facId)
        {
            var item = _repository.GetById(facId);
            if (item == null)
            {
                throw new Exception("Coud not find building/city");
            }
            else
            {
                _repository.Delete(item);
                _repository.Save();
            }
        }

    }
}
