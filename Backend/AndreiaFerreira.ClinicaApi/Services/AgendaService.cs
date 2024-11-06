using System;
using System.Net;
using AndreiaFerreira.ClinicaApi.Interfaces;
using AndreiaFerreira.ClinicaApi.Models;
using AndreiaFerreira.ClinicaApi.Models.DTO;
using AndreiaFerreira.ClinicaApi.Models.Entities;

namespace AndreiaFerreira.ClinicaApi.Services;

public class AgendaService : IAgendaService
{
    private readonly IAgendaRepository _agendaRepository;
    private readonly IClientRepository _clientRepository;

    public AgendaService(IAgendaRepository agendaRepository, IClientRepository clientRepository)
    {
        _agendaRepository = agendaRepository;
        _clientRepository = clientRepository;
    }

    public async Task<AgendaModel> CreateAgendaAsync(CreateAgendaDTO createAgendaDTO)
    {
        var paciente = await _clientRepository.GetClientAsync(createAgendaDTO.PacienteId);

        if (paciente == null)
            throw new PersonalizedException("Paciente inexistente", HttpStatusCode.BadRequest);

        var agenda = new AgendaModel
        {
            DataCadastro = DateTime.Now,
            DataAgendamento = createAgendaDTO.DataAgendamento,
            Observacoes = createAgendaDTO.Observacoes,
            Profissional = createAgendaDTO.Profissional,
            Paciente = paciente,
            Tipo_de_servico = createAgendaDTO.Tipo_de_servico
        };

        return await _agendaRepository.CreateAgendaAsync(agenda);
    }
    public async Task<bool> DeleteAgendaAsync(int id)
    {
        return await _agendaRepository.DeleteAgendaAsync(id);
    }


    public async Task<List<AgendaModel>> GetScheduleByDateAsync(DateTime initialDate, DateTime finalDate)
    {
        return await _agendaRepository.GetScheduleByDateAsync(initialDate, finalDate);
    }

    public async Task<List<AgendaModel>> SearchScheduleByPatientCPFAsync(string patientCPF)
    {
        return await _agendaRepository.SearchScheduleByPatientCPFAsync(patientCPF);
    }

    public async Task<List<AgendaModel>> SearchScheduleByPatientIdAsync(int patientId)
    {
        return await _agendaRepository.SearchScheduleByPatientIdAsync(patientId);
    }

    public async Task<AgendaModel> UpdateAgendaAsync(UpdateAgendaDTO agendaUpdate)
    {
        return await _agendaRepository.UpdateAgendaAsync(agendaUpdate);

    }


}

