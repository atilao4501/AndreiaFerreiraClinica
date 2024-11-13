using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AndreiaFerreira.ClinicaApi.Interfaces;
using AndreiaFerreira.ClinicaApi.Models.Entities;
using AndreiaFerreira.ClinicaApi.Repositories;

namespace AndreiaFerreira.ClinicaApi.Services;

public class CustomerServiceService : ICustomerServiceService
{
    private readonly ISessionRepository _sessionRepository;

    public CustomerServiceService(ISessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public async Task<IEnumerable<CustomerServiceModel>> GetAll()
    {
        var allSessions = await _sessionRepository.GetAllSessionsAsync();
        var customerServiceReturn = new List<CustomerServiceModel>();
        foreach (var session in allSessions)
        {
            customerServiceReturn.Add(new CustomerServiceModel
            {
                NomePaciente = session.Paciente.Nome_completo,
                Sessoes = (allSessions.Where(x => x.Paciente.Nome_completo == session.Paciente.Nome_completo).ToList())
            });
        }
        return customerServiceReturn;
    }

    public async Task<CustomerServiceModel> GetByClient(string cpf)
    {
        var sessions = await _sessionRepository.GetSessionsByClientAsync(cpf);
        CustomerServiceModel customerServiceReturn;

        customerServiceReturn = new CustomerServiceModel
        {
            NomePaciente = sessions[0].Paciente.Nome_completo,
            Sessoes = sessions
        };

        return customerServiceReturn;
    }
}

