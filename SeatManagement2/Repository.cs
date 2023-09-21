namespace SeatManagement2
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SeatManagementContext _context;
        public Repository(SeatManagementContext context)
        {
            _context = context;
        }


        public void Add(T classobj)
        {
            _context.Set<T>().Add(classobj);
        }
        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public void Update(T classobj)
        {
            _context.Set<T>().Update(classobj);

        }
        public void Delete(T classobj)
        {
            _context.Set<T>().Remove(classobj);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

