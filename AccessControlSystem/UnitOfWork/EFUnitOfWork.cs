using DAL.EF;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;

namespace DAL.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly AccessControlContext _dbContext;

        public IPassRepository PassRepository { get; }
        public IAccessRequestRepository AccessRequestRepository { get; }

        public EFUnitOfWork(AccessControlContext dbContext)
        {
            _dbContext = dbContext;
            PassRepository = new PassRepository(dbContext);
            AccessRequestRepository = new AccessRequestRepository(dbContext);
        }

        public void Save() => _dbContext.SaveChanges();

        public void Dispose() => _dbContext.Dispose();
    }
}
