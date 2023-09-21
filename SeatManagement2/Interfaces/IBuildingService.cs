using SeatManagement2.DTOs;
using SeatManagement2.Models;

namespace SeatManagement2.Interfaces
{
    public interface IBuildingService
    {
        List<BuildingLookUp> IndexBuilding();
        void AddBuilding(BuildingLookUpDTO buildingLookUpDTO);
        void DeleteBuilding(BuildingLookUpDTO buildingLookUpDTO);
        void EditBuilding(string buildingCode, BuildingLookUpDTO updatedBuilding);
    }


}
