using NuGet.ContentModel;
using SeatManagement2.Models;

namespace SeatManagementFE.Interfaces
{
    public interface IApiCall<T> where T : class
    {
        int PostData(T data);
        List<T> GetData();
        bool UpdateData(T data);
        bool UpdateAssetData(int assetId, int? employeeId);
    }
}