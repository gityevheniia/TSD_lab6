using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Impl
{
    public class AccessRequestRepository : BaseRepository<AccessRequest>, IAccessRequestRepository
    {
        public AccessRequestRepository(DbContext context) : base(context) { }

        public IEnumerable<AccessRequest> GetRequestsByPassId(int passId)
        {
            return _dbSet.AsNoTracking().Where(r => r.PassId == passId).ToList();
        }

        public void UpdateRequestStatus(int requestId, bool isApproved, string? denialReason = null)
        {
            var request = _dbSet.FirstOrDefault(r => r.Id == requestId);
            if (request != null)
            {
                request.IsApproved = isApproved;
                request.DenialReason = denialReason;
                SaveChanges();
            }
        }

        
        public void Add(AccessRequest entity)
        {
            _dbSet.Add(entity);
            SaveChanges(); 
        }

        
        public AccessRequest GetById(int id)
        {
            return _dbSet.Find(id);
        }

       
        public void Update(AccessRequest entity)
        {
            _dbSet.Update(entity);
            SaveChanges(); 
        }

        
        public void Delete(AccessRequest entity)
        {
            _dbSet.Remove(entity);
            SaveChanges(); 
        }
    }
}
