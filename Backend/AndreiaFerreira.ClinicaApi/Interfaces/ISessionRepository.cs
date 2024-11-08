using System.Collections.Generic;
using System.Threading.Tasks;
using AndreiaFerreira.ClinicaApi.Models.Entities;
using System;
using AndreiaFerreira.ClinicaApi.Models.DTO;

namespace AndreiaFerreira.ClinicaApi.Interfaces;

public interface ISessionRepository
{
    Task<List<SessionModel>> GetAllSessionsAsync();
    Task<SessionModel> GetSessionAsync(int id);
    Task<SessionModel> CreateSessionAsync(SessionModel session);
    Task<SessionModel> UpdateSessionAsync(UpdateSessionDTO updateSessionDTO);
    Task DeleteSessionAsync(int id);
    Task<List<SessionModel>> GetSessionsByClientAsync(int id);
    Task<List<SessionModel>> GetSessionsByDateAsync(DateTime? initialDate = null, DateTime? finalDate = null);
}

