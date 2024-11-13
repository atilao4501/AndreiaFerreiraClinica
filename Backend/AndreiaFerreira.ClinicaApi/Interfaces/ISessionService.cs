using System.Collections.Generic;
using System.Threading.Tasks;
using AndreiaFerreira.ClinicaApi.Models.DTO;
using AndreiaFerreira.ClinicaApi.Models.Entities;

namespace AndreiaFerreira.ClinicaApi.Interfaces
{
    public interface ISessionService
    {
        Task<SessionModel> CreateSessionAsync(CreateSessionDTO createSessionDTO);
        Task<SessionModel> GetSessionAsync(int id);
        Task<IEnumerable<SessionModel>> GetAllSessionsAsync();
        Task<SessionModel> UpdateSessionAsync(UpdateSessionDTO updateSessionDTO);
        Task DeleteSessionAsync(int id);
        Task<List<SessionModel>> GetSessionsByClientAsync(string cpf);
        Task<List<SessionModel>> GetSessionsByDateAsync(DateTime? initialDate = null, DateTime? finalDate = null);
    }
}

