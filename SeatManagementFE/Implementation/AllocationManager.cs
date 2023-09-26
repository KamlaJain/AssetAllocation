using SeatManagementFE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementFE.Implementation
{
    public class AllocationManager<T> : IAllocationManager<T> where T : class
    {
        private readonly string _endPoint;

        public AllocationManager(string endPoint)
        {
            _endPoint = endPoint;
        }
        public void Allocate(T obj)
        {
            IApiCall<T> aPICall = new ApiCall<T>(_endPoint);
            aPICall.UpdateData(obj);
        }

        public void Deallocate(T obj)
        {
            IApiCall<T> aPICall = new ApiCall<T>(_endPoint);
            aPICall.UpdateData(obj);
        }
    }
}