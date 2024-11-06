using System;
using AndreiaFerreira.ClinicaApi.Models;
using AndreiaFerreira.ClinicaApi.Interfaces;
using AndreiaFerreira.ClinicaApi.Models.DTO;
using AndreiaFerreira.ClinicaApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using AndreiaFerreira.ClinicaApi.Data;
using System.Net;

namespace AndreiaFerreira.ClinicaApi.Repositories;

public class AgendaRepository : IAgendaRepository
{
    private readonly ClinicDbContext _context;

    public AgendaRepository(ClinicDbContext context)
    {
        _context = context;
    }

    public async Task<AgendaModel> CreateAgendaAsync(AgendaModel agenda)
    {
        if (agenda == null)
        {
            throw new PersonalizedException("Agenda não pode ser nula", HttpStatusCode.BadRequest);
        }

        try
        {
            await _context.Agendas.AddAsync(agenda);
            await _context.SaveChangesAsync();

            return agenda;
        }
        catch (DbUpdateException ex)
        {
            throw new PersonalizedException("Ocorreu um erro ao tentar adicionar a agenda", HttpStatusCode.InternalServerError);
        }
    }

    public async Task<List<AgendaModel>> GetScheduleByDateAsync(DateTime initialDate, DateTime finalDate)
    {
        try
        {
            return await _context.Agendas
                .Include(x => x.Paciente)
                .Where(x =>
                    (initialDate == DateTime.MinValue || x.DataAgendamento >= initialDate.Date) &&
                    (finalDate == DateTime.MinValue || x.DataAgendamento <= finalDate.Date.AddDays(1))
                )
                .ToListAsync();
        }
        catch (Exception ex)
        {
            throw new PersonalizedException("Ocorreu um erro ao tentar obter a agenda", HttpStatusCode.InternalServerError);
        }
    }

    public async Task<List<AgendaModel>> SearchScheduleByPatientIdAsync(int patientId)
    {
        try
        {
            return await _context.Agendas
                .Include(x => x.Paciente)
                .Where(x => x.Paciente.Id == patientId)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            throw new PersonalizedException("Ocorreu um erro ao tentar buscar a agenda pelo id do paciente", HttpStatusCode.InternalServerError);
        }
    }

    public async Task<List<AgendaModel>> SearchScheduleByPatientCPFAsync(string patientCPF)
    {
        try
        {
            return await _context.Agendas
                .Include(x => x.Paciente)
                .Where(x => x.Paciente.CPF == patientCPF)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            throw new PersonalizedException("Ocorreu um erro ao tentar buscar a agenda pelo CPF do paciente", HttpStatusCode.InternalServerError);
        }
    }

    public async Task<AgendaModel> UpdateAgendaAsync(UpdateAgendaDTO agendaUpdate)
    {
        if (agendaUpdate == null)
        {
            throw new PersonalizedException("Agenda não pode ser nula", HttpStatusCode.BadRequest);
        }

        try
        {
            var existingAgenda = await _context.Agendas.FindAsync(agendaUpdate.Id);
            if (existingAgenda == null)
            {
                throw new PersonalizedException("Agenda não encontrada", HttpStatusCode.NotFound);
            }

            existingAgenda.Profissional = agendaUpdate.Profissional ?? existingAgenda.Profissional;
            existingAgenda.DataAgendamento = agendaUpdate.DataAgendamento ?? existingAgenda.DataAgendamento;
            existingAgenda.Observacoes = agendaUpdate.Observacoes ?? existingAgenda.Observacoes;
            existingAgenda.Tipo_de_servico = agendaUpdate.Tipo_de_servico ?? existingAgenda.Tipo_de_servico;

            await _context.SaveChangesAsync();

            return existingAgenda;
        }
        catch (DbUpdateException ex)
        {
            throw new PersonalizedException("Ocorreu um erro ao tentar atualizar a agenda", HttpStatusCode.InternalServerError);
        }
    }
}

