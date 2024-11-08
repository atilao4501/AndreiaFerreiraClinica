using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AndreiaFerreira.ClinicaApi.Models.DTO;
using AndreiaFerreira.ClinicaApi.Models.Entities;

namespace AndreiaFerreira.ClinicaApi.Interfaces
{
    public interface IAgendaService
    {
        Task<List<SessionModel>> GetAllSchedulesAsync();
        Task<List<SessionModel>> GetScheduleByClientAsync(int clientId);
        Task<List<SessionModel>> GetScheduleByDateAsync(DateTime? initialDate = null, DateTime? finalDate = null);
    }
}

