using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Impl
{
    public class PassRepository : BaseRepository<Pass>, IPassRepository
    {
        public PassRepository(DbContext context) : base(context) { }

       
        public Pass GetById(int id)
        {
            return _dbSet.Find(id);
        }

      
        public Pass? GetByPassNumber(string passNumber)
        {
            return _dbSet.AsNoTracking().FirstOrDefault(p => p.PassNumber == passNumber);
        }

        
        public IEnumerable<Pass> GetActivePasses()
        {
            return _dbSet.AsNoTracking().Where(p => p.IsActive).ToList();
        }

        
        public void DeactivatePass(int passId)
        {
            var pass = _dbSet.FirstOrDefault(p => p.Id == passId);
            if (pass != null)
            {
                pass.IsActive = false;
                SaveChanges(); 
            }
        }

        
        public void Add(Pass entity)
        {
            _dbSet.Add(entity);
            SaveChanges(); 
        }

       
        public void Update(Pass entity)
        {
            _dbSet.Update(entity);
            SaveChanges(); 
        }

        
        public void Delete(Pass entity)
        {
            _dbSet.Remove(entity);
            SaveChanges(); 
        }
    }
}
