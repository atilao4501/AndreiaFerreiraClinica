using System;
using System.Threading.Tasks;
using AndreiaFerreira.ClinicaApi.Models.DTO;
using AndreiaFerreira.ClinicaApi.Models.Entities;

namespace AndreiaFerreira.ClinicaApi.Interfaces
{
    public interface IAgendaService
    {
        Task<List<AgendaModel>> GetScheduleByDateAsync(DateTime initialDate, DateTime finalDate);
        Task<List<AgendaModel>> SearchScheduleByPatientIdAsync(int patientId);
        Task<List<AgendaModel>> SearchScheduleByPatientCPFAsync(string patientCPF);
        Task<AgendaModel> CreateAgendaAsync(CreateAgendaDTO agenda);
        Task<AgendaModel> UpdateAgendaAsync(UpdateAgendaDTO agendaUpdate);
        Task<bool> DeleteAgendaAsync(int id);
    }
}