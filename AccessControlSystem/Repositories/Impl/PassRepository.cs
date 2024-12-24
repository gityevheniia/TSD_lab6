using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Impl
{
    public class PassRepository : BaseRepository<Pass>, IPassRepository
    {
        public PassRepository(DbContext context) : base(context) { }

        public Pass GetByPassNumber(string passNumber)
        {
            return _dbSet.FirstOrDefault(p => p.PassNumber == passNumber);
        }
    }
}
