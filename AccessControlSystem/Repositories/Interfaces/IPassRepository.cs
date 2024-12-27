using DAL.Entities;

namespace DAL.Repositories.Interfaces
{
    public interface IPassRepository : IRepository<Pass>
    {
        Pass? GetByPassNumber(string passNumber);
        IEnumerable<Pass> GetActivePasses();
        void DeactivatePass(int passId);
    }
}
