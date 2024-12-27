using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Impl
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll() => _dbSet.AsNoTracking().ToList();

       
        public T GetById(int id) => _dbSet.Find(id);

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            SaveChanges(); 
        }

        
        public void Update(T entity)
        {
            _dbSet.Update(entity);
            SaveChanges(); 
        }

        
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            SaveChanges(); 
        }

       
        public void SaveChanges() => _context.SaveChanges();
    }
}
