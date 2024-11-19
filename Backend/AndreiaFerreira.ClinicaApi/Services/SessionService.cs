using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AndreiaFerreira.ClinicaApi.Interfaces;
using AndreiaFerreira.ClinicaApi.Models.DTO;
using AndreiaFerreira.ClinicaApi.Models.Entities;
using AndreiaFerreira.ClinicaApi.Repositories;

namespace AndreiaFerreira.ClinicaApi.Services;

public class SessionService : ISessionService
{
    private readonly ISessionRepository _sessionRepository;
    private readonly IClientRepository _clientRepository;

    public SessionService(ISessionRepository sessionRepository, IClientRepository clientRepository)
    {
        _sessionRepository = sessionRepository;
        _clientRepository = clientRepository;
    }

    public async Task<SessionModel> CreateSessionAsync(CreateSessionDTO createSessionDTO)
    {
        var client = await _clientRepository.GetClientAsync(createSessionDTO.Cpf);

        var session = new SessionModel()
        {
            DataHoraSessao = createSessionDTO.DataHoraSessao,
            Paciente = client,
            Observacoes = createSessionDTO.Observacoes,
            Profissional = createSessionDTO.Profissional,
            TipoDeServico = createSessionDTO.TipoDeServico
        };

        session.Paciente.Id = client.Id;
        return await _sessionRepository.CreateSessionAsync(session);
    }

    public async Task DeleteSessionAsync(int id)
    {
        await _sessionRepository.DeleteSessionAsync(id);
    }

    public async Task<IEnumerable<SessionModel>> GetAllSessionsAsync()
    {
        return await _sessionRepository.GetAllSessionsAsync();
    }

    public async Task<SessionModel> GetSessionAsync(int id)
    {
        return await _sessionRepository.GetSessionAsync(id);
    }
    public async Task<List<SessionModel>> GetSessionsByClientAsync(string cpf)
    {
        return await _sessionRepository.GetSessionsByClientAsync(cpf);
    }

    public async Task<List<SessionModel>> GetSessionsByDateAsync(DateTime? initialDate = null, DateTime? finalDate = null)
    {
        return await _sessionRepository.GetSessionsByDateAsync(initialDate, finalDate);
    }

    public async Task<SessionModel> UpdateSessionAsync(UpdateSessionDTO updateSessionDTO)
    {
        return await _sessionRepository.UpdateSessionAsync(updateSessionDTO);
    }

}


