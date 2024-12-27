using DAL.Entities;

namespace DAL.Repositories.Interfaces
{
    public interface IAccessRequestRepository : IRepository<AccessRequest>
    {
        IEnumerable<AccessRequest> GetRequestsByPassId(int passId);
        void UpdateRequestStatus(int requestId, bool isApproved, string? denialReason = null);
    }
}
