using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SeatManagement2.Utility
{
    public class FilterProvider<T> where T : class
    {

        public IEnumerable<T> filter(IEnumerable<T> entities,string filterParam,Func<T,string> filterfun) {
            return entities.Where((entity) => filterfun(entity) == filterParam);
        }
    }
}

/* building, city => 
 * builiding => building.buildingcode
 * function (building) => buildingcode
 * function (city) => citycode
 * city => city.cityCode
 *  var filterP = new FilterProvider<>();
 *  _seats = Respository<Seat>().getall();
 *  filterP.filter(_allocatedseats,"TVM",seat => seat.citycode)*/