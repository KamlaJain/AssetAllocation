using SeatManagementFE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementFE.Implementation
{
    public class EntityManager<T> : IEntityManager<T> where T : class
    {
        private readonly IApiCall<T> _apiCall;
        public EntityManager(string endPoint)
        {
            _apiCall = new ApiCall<T>(endPoint);
        }

        public int Add(T obj)
        {
            return _apiCall.PostData(obj);
        }

        public List<T> Get()
        {
            var response = _apiCall.GetData();
            return response;
        }

        public bool Patch(T obj)
        {
            return _apiCall.UpdateData(obj);
        }
    }
}
