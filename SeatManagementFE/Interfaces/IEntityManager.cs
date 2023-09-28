namespace SeatManagementFE.Interfaces
{
    public interface IEntityManager<T> where T : class
    {
        public int Add(T dto);
        public List<T> Get();
        public bool Patch(T dto);
    }
}
