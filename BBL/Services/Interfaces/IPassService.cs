using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface IPassService
    {
        IEnumerable<PassDTO> GetActivePasses(int pageNumber);
        void DeactivatePass(int passId);
    }
}