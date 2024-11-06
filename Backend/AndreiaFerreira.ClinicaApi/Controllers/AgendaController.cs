using System.Net;
using AndreiaFerreira.ClinicaApi.Interfaces;
using AndreiaFerreira.ClinicaApi.Models;
using AndreiaFerreira.ClinicaApi.Models.DTO;
using AndreiaFerreira.ClinicaApi.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Authorize]
[Route("api/[controller]/[action]")]
public class AgendaController : ControllerBase
{
    private readonly IAgendaService _agendaService;

    public AgendaController(IAgendaService agendaService)
    {
        _agendaService = agendaService;
    }

    [HttpPost]
    public async Task<ActionResult<DefaultOutput<AgendaModel>>> CreateAgenda(CreateAgendaDTO agenda)
    {
        try
        {
            var result = await _agendaService.CreateAgendaAsync(agenda);
            return Ok(new DefaultOutput<AgendaModel>
            {
                Message = "Agenda criada com sucesso",
                StatusHttp = 200,
                Result = result
            });
        }
        catch (PersonalizedException ex)
        {
            return StatusCode((int)ex.StatusCode, new DefaultOutput<AgendaModel>
            {
                Message = ex.Message,
                StatusHttp = (int)ex.StatusCode
            });
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new DefaultOutput<AgendaModel>
            {
                Message = "Ocorreu um erro inesperado",
                StatusHttp = (int)HttpStatusCode.InternalServerError
            });
        }
    }

    [HttpGet]
    public async Task<ActionResult<DefaultOutput<List<AgendaModel>>>> GetScheduleByDate(DateTime initialDate, DateTime finalDate)
    {
        try
        {
            var result = await _agendaService.GetScheduleByDateAsync(initialDate, finalDate);
            return Ok(new DefaultOutput<List<AgendaModel>>
            {
                Message = "Agenda obtida com sucesso",
                StatusHttp = 200,
                Result = result
            });
        }
        catch (PersonalizedException ex)
        {
            return StatusCode((int)ex.StatusCode, new DefaultOutput<List<AgendaModel>>
            {
                Message = ex.Message,
                StatusHttp = (int)ex.StatusCode
            });
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new DefaultOutput<List<AgendaModel>>
            {
                Message = "Ocorreu um erro ao tentar obter a agenda",
                StatusHttp = (int)HttpStatusCode.InternalServerError
            });
        }
    }

    [HttpGet]
    public async Task<ActionResult<DefaultOutput<List<AgendaModel>>>> SearchScheduleByPatientId(int patientId)
    {
        try
        {
            var result = await _agendaService.SearchScheduleByPatientIdAsync(patientId);
            return Ok(new DefaultOutput<List<AgendaModel>>
            {
                Message = "Agenda obtida com sucesso",
                StatusHttp = 200,
                Result = result
            });
        }
        catch (PersonalizedException ex)
        {
            return StatusCode((int)ex.StatusCode, new DefaultOutput<List<AgendaModel>>
            {
                Message = ex.Message,
                StatusHttp = (int)ex.StatusCode
            });
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new DefaultOutput<List<AgendaModel>>
            {
                Message = "Ocorreu um erro ao tentar buscar a agenda",
                StatusHttp = (int)HttpStatusCode.InternalServerError
            });
        }
    }

    [HttpGet]
    public async Task<ActionResult<DefaultOutput<List<AgendaModel>>>> SearchScheduleByPatientCPF(string patientCPF)
    {
        try
        {
            var result = await _agendaService.SearchScheduleByPatientCPFAsync(patientCPF);
            return Ok(new DefaultOutput<List<AgendaModel>>
            {
                Message = "Agenda obtida com sucesso",
                StatusHttp = 200,
                Result = result
            });
        }
        catch (PersonalizedException ex)
        {
            return StatusCode((int)ex.StatusCode, new DefaultOutput<List<AgendaModel>>
            {
                Message = ex.Message,
                StatusHttp = (int)ex.StatusCode
            });
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new DefaultOutput<List<AgendaModel>>
            {
                Message = "Ocorreu um erro ao tentar buscar a agenda",
                StatusHttp = (int)HttpStatusCode.InternalServerError
            });
        }
    }

    [HttpPut]
    public async Task<ActionResult<DefaultOutput<AgendaModel>>> UpdateAgenda(UpdateAgendaDTO agendaUpdate)
    {
        try
        {
            var result = await _agendaService.UpdateAgendaAsync(agendaUpdate);
            return Ok(new DefaultOutput<AgendaModel>
            {
                Message = "Agenda atualizada com sucesso",
                StatusHttp = 200,
                Result = result
            });
        }
        catch (PersonalizedException ex)
        {
            return StatusCode((int)ex.StatusCode, new DefaultOutput<AgendaModel>
            {
                Message = ex.Message,
                StatusHttp = (int)ex.StatusCode
            });
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new DefaultOutput<AgendaModel>
            {
                Message = "Ocorreu um erro inesperado",
                StatusHttp = (int)HttpStatusCode.InternalServerError
            });
        }
    }
}
