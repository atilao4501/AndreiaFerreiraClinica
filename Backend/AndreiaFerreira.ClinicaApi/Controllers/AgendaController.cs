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


    [HttpGet]
    public async Task<IActionResult> GetAllSessionAgendaAsync()
    {
        try
        {
            var result = await _agendaService.GetAllSchedulesAsync();

            return Ok(new DefaultOutput<IEnumerable<SessionModel>>
            {
                Message = "Todas as sessões recuperadas com sucesso",
                StatusHttp = 200,
                Result = result
            });
        }
        catch (PersonalizedException ex)
        {
            return StatusCode((int)ex.StatusCode, new DefaultOutput<IEnumerable<SessionModel>>
            {
                Message = ex.Message,
                StatusHttp = (int)ex.StatusCode,
            });
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new DefaultOutput<IEnumerable<SessionModel>>
            {
                Message = "Erro interno do servidor",
                StatusHttp = (int)HttpStatusCode.InternalServerError,
            });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAgendaByClientAsync(string cpf)
    {
        try
        {
            var result = await _agendaService.GetScheduleByClientAsync(cpf);

            return Ok(new DefaultOutput<IEnumerable<SessionModel>>
            {
                Message = "Sessões do cliente recuperadas com sucesso",
                StatusHttp = 200,
                Result = result
            });
        }
        catch (PersonalizedException ex)
        {
            return StatusCode((int)ex.StatusCode, new DefaultOutput<IEnumerable<SessionModel>>
            {
                Message = ex.Message,
                StatusHttp = (int)ex.StatusCode,
            });
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new DefaultOutput<IEnumerable<SessionModel>>
            {
                Message = "Erro interno do servidor",
                StatusHttp = (int)HttpStatusCode.InternalServerError,
            });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAgendaByDateAsync([FromQuery] DateTime? initialDate = null, [FromQuery] DateTime? finalDate = null)
    {
        try
        {
            var result = await _agendaService.GetScheduleByDateAsync(initialDate, finalDate);

            return Ok(new DefaultOutput<IEnumerable<SessionModel>>
            {
                Message = "Sessões por data recuperadas com sucesso",
                StatusHttp = 200,
                Result = result
            });
        }
        catch (PersonalizedException ex)
        {
            return StatusCode((int)ex.StatusCode, new DefaultOutput<IEnumerable<SessionModel>>
            {
                Message = ex.Message,
                StatusHttp = (int)ex.StatusCode,
            });
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new DefaultOutput<IEnumerable<SessionModel>>
            {
                Message = "Erro interno do servidor",
                StatusHttp = (int)HttpStatusCode.InternalServerError,
            });
        }
    }

}

