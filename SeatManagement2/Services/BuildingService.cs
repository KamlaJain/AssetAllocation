using Microsoft.AspNetCore.Mvc;
using SeatManagement2.DTOs;
using SeatManagement2.Models;
using SeatManagement2.Interfaces;

namespace SeatManagement2.Services
{
    public class BuildingService: IBuildingService
    {
        private readonly IRepository<BuildingLookUp> _repository;

        public BuildingService(IRepository<BuildingLookUp> repository)
        {
            _repository = repository;
        }

        public List<BuildingLookUp> IndexBuilding()
        {
            return _repository.GetAll().ToList();
        }

        public void AddBuilding(BuildingLookUpDTO buildingLookUpDTO)
        {

            var item = new BuildingLookUp
            {
                BuildingName = buildingLookUpDTO.BuildingName,
                BuildingCode = buildingLookUpDTO.BuildingCode,
            };
            _repository.Add(item);
            _repository.Save();
        }

        public void DeleteBuilding(BuildingLookUpDTO buildingLookUpDTO)
        {
            var item = _repository.GetAll().FirstOrDefault(c => c.BuildingCode == buildingLookUpDTO.BuildingCode);
            if (item == null)
            {
                throw new Exception("Invalid Building");
            }
            else
            {
                _repository.Delete(item);
                _repository.Save();
            }
        }
        public void EditBuilding(string buildingcode, BuildingLookUpDTO updatedBuilding)
        {
            var item = _repository.GetAll().FirstOrDefault(c => c.BuildingCode == buildingcode);
            if (item == null)
            {
                throw new Exception("Invalid Building");
            }
            else
            {
                item.BuildingName = updatedBuilding.BuildingName;
                item.BuildingCode = updatedBuilding.BuildingCode;

                _repository.Update(item);
                _repository.Save();
            }
        }

    }

}

