using SeatManagement2.DTOs;
using SeatManagement2.Exceptions;
using SeatManagement2.Interfaces;
using SeatManagement2.Models;

namespace SeatManagement2.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly IRepository<BuildingLookUp> _repository;

        public BuildingService(IRepository<BuildingLookUp> repository)
        {
            _repository = repository;
        }

        public List<BuildingLookUp> GetAllBuildings()
        {
            return _repository.GetAll().ToList();
        }

        public void AddBuilding(BuildingLookUpDTO buildingLookUpDTO)
        {
            var reqBuilding = _repository.GetAll().Any(b => b.BuildingName == buildingLookUpDTO.BuildingName && b.BuildingCode == buildingLookUpDTO.BuildingCode);
            if (!reqBuilding)
            {
                throw new BadRequestException("Building already exists");
            }
            var item = new BuildingLookUp
            {
                BuildingName = buildingLookUpDTO.BuildingName,
                BuildingCode = buildingLookUpDTO.BuildingCode,
            };
            _repository.Add(item);
            _repository.Save();
        }
    }
}

