using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessControl.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Impl
{
    public class AccessRequestRepository : BaseRepository<AccessRequest>, IAccessRequestRepository
    {
        public AccessRequestRepository(DbContext context) : base(context) { }

        public IEnumerable<AccessRequest> GetRequestsByPassId(int passId)
        {
            return _dbSet.Where(r => r.PassId == passId).ToList();
        }
    }
}
