
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementFE.Interfaces
{
    public interface IApiCall<T> where T : class
    {
        int PostData(T data);
        List<T> GetData();
        bool UpdateData(T data);

    }
}