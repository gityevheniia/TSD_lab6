using DAL.Repositories.Interfaces;
using System;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IPassRepository PassRepository { get; }
        IAccessRequestRepository AccessRequestRepository { get; }
        void Save();
    }
}