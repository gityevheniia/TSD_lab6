using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly AccessControlContext _context;
        public IPassRepository PassRepository { get; }
        public IAccessRequestRepository AccessRequestRepository { get; }

        public EFUnitOfWork(AccessControlContext context)
        {
            _context = context;
            PassRepository = new PassRepository(context);
            AccessRequestRepository = new AccessRequestRepository(context);
        }

        public void Save() => _context.SaveChanges();

        public void Dispose() => _context.Dispose();
    }
}
