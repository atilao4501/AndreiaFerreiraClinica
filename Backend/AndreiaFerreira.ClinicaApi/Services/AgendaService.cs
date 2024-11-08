using System.Net;
using AndreiaFerreira.ClinicaApi.Interfaces;
using AndreiaFerreira.ClinicaApi.Models;
using AndreiaFerreira.ClinicaApi.Models.Entities;

public class AgendaService : IAgendaService
{
    private readonly ISessionRepository _sessionRepository;

    public AgendaService(ISessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public async Task<List<SessionModel>> GetAllSchedulesAsync()
    {
        return (List<SessionModel>)await _sessionRepository.GetAllSessionsAsync();
    }

    public async Task<List<SessionModel>> GetScheduleByClientAsync(int clientId)
    {
        return await _sessionRepository.GetSessionsByClientAsync(clientId);
    }

    public async Task<List<SessionModel>> GetScheduleByDateAsync(DateTime? initialDate = null, DateTime? finalDate = null)
    {
        return await _sessionRepository.GetSessionsByDateAsync(initialDate, finalDate);
    }
}
