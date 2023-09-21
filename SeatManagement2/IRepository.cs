using SeatManagement2.DTOs;

namespace SeatManagement2
{
    public interface IRepository<T> where T: class
    {
        void Add(T classObj);
        List<T> GetAll();
        T GetById(int id);
        void Update(T classObj);
        void Delete(T classobj);
        void Save();
    }
}
