using SeatManagement2.DTOs;
using SeatManagement2.Models;

namespace SeatManagement2.Interfaces
{
    public interface IBuildingService
    {
        List<BuildingLookUp> GetAllBuildings();
        void AddBuilding(BuildingLookUpDTO buildingLookUpDTO);
        void EditBuilding(string buildingCode, BuildingLookUpDTO updatedBuilding);
    }


}
