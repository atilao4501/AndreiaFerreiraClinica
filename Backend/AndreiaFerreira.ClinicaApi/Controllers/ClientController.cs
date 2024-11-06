using System;
using System.Net;
using AndreiaFerreira.ClinicaApi.Interfaces;
using AndreiaFerreira.ClinicaApi.Models.DTO;
using AndreiaFerreira.ClinicaApi.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AndreiaFerreira.ClinicaApi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]/[action]")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpPost]
    public async Task<ActionResult<DefaultOutput<ClientModel>>> Create(ClientModel client)
    {
        try
        {
            var result = await _clientService.CreateClientAsync(client);
            return Ok(new DefaultOutput<ClientModel>
            {
                Message = "Cliente criado com sucesso",
                StatusHttp = 200,
                Result = result
            });
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(new DefaultOutput<ClientModel>
            {
                Message = "Informe os dados do cliente",
                StatusHttp = 400,
            });
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new DefaultOutput<ClientModel>
            {
                Message = "Erro interno do servidor",
                StatusHttp = (int)HttpStatusCode.InternalServerError,
            });
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DefaultOutput<bool>>> Delete(int id)
    {
        try
        {
            var result = await _clientService.DeleteClientAsync(id);
            return Ok(new DefaultOutput<bool>
            {
                Message = "Cliente deletado com sucesso",
                StatusHttp = 200,
                Result = result
            });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new DefaultOutput<bool>
            {
                Message = "Cliente não encontrado",
                StatusHttp = 404,
            });
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new DefaultOutput<bool>
            {
                Message = "Erro interno do servidor",
                StatusHttp = (int)HttpStatusCode.InternalServerError,
            });
        }
    }

    [HttpGet]
    public async Task<ActionResult<DefaultOutput<IEnumerable<ClientModel>>>> GetAll()
    {
        try
        {
            var result = await _clientService.GetAllClientsAsync();
            return Ok(new DefaultOutput<IEnumerable<ClientModel>>
            {
                Message = "Clientes recuperados com sucesso",
                StatusHttp = 200,
                Result = result
            });
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new DefaultOutput<IEnumerable<ClientModel>>
            {
                Message = "Erro interno do servidor",
                StatusHttp = (int)HttpStatusCode.InternalServerError,
            });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DefaultOutput<ClientModel>>> GetById(int id)
    {
        try
        {
            var result = await _clientService.GetClientAsync(id);
            return Ok(new DefaultOutput<ClientModel>
            {
                Message = "Cliente recuperado com sucesso",
                StatusHttp = 200,
                Result = result
            });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new DefaultOutput<ClientModel>
            {
                Message = "Cliente n o encontrado",
                StatusHttp = 404,
            });
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new DefaultOutput<ClientModel>
            {
                Message = "Erro interno do servidor",
                StatusHttp = (int)HttpStatusCode.InternalServerError,
            });
        }
    }

    [HttpPut]
    public async Task<ActionResult<DefaultOutput<ClientModel>>> Update(ClientModel client)
    {
        try
        {
            var result = await _clientService.UpdateClientAsync(client);
            return Ok(new DefaultOutput<ClientModel>
            {
                Message = "Cliente atualizado com sucesso",
                StatusHttp = 200,
                Result = result
            });
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(new DefaultOutput<ClientModel>
            {
                Message = "Informe os dados do cliente",
                StatusHttp = 400,
            });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new DefaultOutput<ClientModel>
            {
                Message = "Cliente n o encontrado",
                StatusHttp = 404,
            });
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new DefaultOutput<ClientModel>
            {
                Message = "Erro interno do servidor",
                StatusHttp = (int)HttpStatusCode.InternalServerError,
            });
        }
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<DefaultOutput<ClientModel>>> GetClientWithAnamnese(int id)
    {
        try
        {
            var result = await _clientService.GetClientWithAnamneseAsync(id);
            return Ok(new DefaultOutput<ClientModel>
            {
                Message = "Cliente com anamnese recuperado com sucesso",
                StatusHttp = 200,
                Result = result
            });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new DefaultOutput<ClientModel>
            {
                Message = "Cliente n o encontrado",
                StatusHttp = 404,
            });
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new DefaultOutput<ClientModel>
            {
                Message = "Erro interno do servidor",
                StatusHttp = (int)HttpStatusCode.InternalServerError,
            });
        }
    }

    [HttpGet]
    public async Task<ActionResult<DefaultOutput<IEnumerable<ClientModel>>>> GetAllClientsWithAnamnese()
    {
        try
        {
            var result = await _clientService.GetAllClientsWithAnamneseAsync();
            return Ok(new DefaultOutput<IEnumerable<ClientModel>>
            {
                Message = "Todos os clientes com anamnese recuperados com sucesso",
                StatusHttp = 200,
                Result = result
            });
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new DefaultOutput<IEnumerable<ClientModel>>
            {
                Message = "Erro interno do servidor",
                StatusHttp = (int)HttpStatusCode.InternalServerError,

            });
        }
    }
}

