using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AndreiaFerreira.ClinicaApi.Interfaces;
using AndreiaFerreira.ClinicaApi.Models;
using AndreiaFerreira.ClinicaApi.Models.DTO;
using AndreiaFerreira.ClinicaApi.Models.Entities;
using AndreiaFerreira.ClinicaApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AndreiaFerreira.ClinicaApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[Authorize]
public class SessionController : ControllerBase
{
    private readonly ISessionService _sessionService;

    public SessionController(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    [HttpGet]
    public async Task<ActionResult<DefaultOutput<IEnumerable<SessionModel>>>> GetAllSessions()
    {
        try
        {
            var result = await _sessionService.GetAllSessionsAsync();
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

    [HttpGet("{id:int}")]
    public async Task<ActionResult<DefaultOutput<SessionModel>>> GetSessionById(int id)
    {
        try
        {
            var result = await _sessionService.GetSessionAsync(id);
            return Ok(new DefaultOutput<SessionModel>
            {
                Message = "Sessão recuperada com sucesso",
                StatusHttp = 200,
                Result = result
            });
        }
        catch (PersonalizedException ex)
        {
            return StatusCode((int)ex.StatusCode, new DefaultOutput<SessionModel>
            {
                Message = ex.Message,
                StatusHttp = (int)ex.StatusCode,
            });
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new DefaultOutput<SessionModel>
            {
                Message = "Erro interno do servidor",
                StatusHttp = (int)HttpStatusCode.InternalServerError,
            });
        }
    }

    [HttpPost]
    public async Task<ActionResult<DefaultOutput<SessionModel>>> CreateSession([FromBody] CreateSessionDTO sessionModel)
    {
        try
        {
            var result = await _sessionService.CreateSessionAsync(sessionModel);
            return Ok(new DefaultOutput<SessionModel>()
            {
                Message = "Sucesso ao criar sessão",
                StatusHttp = 200,
                Result = result
            });
        }
        catch (PersonalizedException ex)
        {
            return StatusCode((int)ex.StatusCode, new DefaultOutput<SessionModel>
            {
                Message = ex.Message,
                StatusHttp = (int)ex.StatusCode,
            });
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new DefaultOutput<SessionModel>
            {
                Message = "Erro interno do servidor",
                StatusHttp = (int)HttpStatusCode.InternalServerError,
            });
        }
    }

    [HttpPut]
    public async Task<ActionResult<DefaultOutput<SessionModel>>> UpdateSession([FromBody] UpdateSessionDTO updateSessionDTO)
    {
        try
        {
            var result = await _sessionService.UpdateSessionAsync(updateSessionDTO);
            return Ok(new DefaultOutput<SessionModel>
            {
                Message = "Sessão atualizada com sucesso",
                StatusHttp = 200,
                Result = result
            });
        }
        catch (PersonalizedException ex)
        {
            return StatusCode((int)ex.StatusCode, new DefaultOutput<SessionModel>
            {
                Message = ex.Message,
                StatusHttp = (int)ex.StatusCode,
            });
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new DefaultOutput<SessionModel>
            {
                Message = "Erro interno do servidor",
                StatusHttp = (int)HttpStatusCode.InternalServerError,
            });
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<DefaultOutput<object>>> DeleteSession(int id)
    {
        try
        {
            await _sessionService.DeleteSessionAsync(id);
            return Ok(new DefaultOutput<object>
            {
                Message = "Sessão deletada com sucesso",
                StatusHttp = 204,
            });
        }
        catch (PersonalizedException ex)
        {
            return StatusCode((int)ex.StatusCode, new DefaultOutput<object>
            {
                Message = ex.Message,
                StatusHttp = (int)ex.StatusCode,
            });
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new DefaultOutput<object>
            {
                Message = "Erro interno do servidor",
                StatusHttp = (int)HttpStatusCode.InternalServerError,
            });
        }
    }
}

