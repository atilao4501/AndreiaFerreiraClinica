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
                Message = "Client created successfully",
                StatusHttp = 200,
                Result = result
            });
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(new DefaultOutput<ClientModel>
            {
                Message = ex.Message,
                StatusHttp = 400,
            });
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new DefaultOutput<ClientModel>
            {
                Message = "Server Error",
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
                Message = "Client deleted successfully",
                StatusHttp = 200,
                Result = result
            });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new DefaultOutput<bool>
            {
                Message = ex.Message,
                StatusHttp = 404,
            });
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new DefaultOutput<bool>
            {
                Message = "Server Error",
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
                Message = "Clients retrieved successfully",
                StatusHttp = 200,
                Result = result
            });
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new DefaultOutput<IEnumerable<ClientModel>>
            {
                Message = "Server Error",
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
                Message = "Client retrieved successfully",
                StatusHttp = 200,
                Result = result
            });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new DefaultOutput<ClientModel>
            {
                Message = ex.Message,
                StatusHttp = 404,
            });
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new DefaultOutput<ClientModel>
            {
                Message = "Server Error",
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
                Message = "Client updated successfully",
                StatusHttp = 200,
                Result = result
            });
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(new DefaultOutput<ClientModel>
            {
                Message = ex.Message,
                StatusHttp = 400,
            });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new DefaultOutput<ClientModel>
            {
                Message = ex.Message,
                StatusHttp = 404,
            });
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new DefaultOutput<ClientModel>
            {
                Message = "Server Error",
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
                Message = "Client with anamnese retrieved successfully",
                StatusHttp = 200,
                Result = result
            });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new DefaultOutput<ClientModel>
            {
                Message = ex.Message,
                StatusHttp = 404,
            });
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new DefaultOutput<ClientModel>
            {
                Message = "Server Error",
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
                Message = "All clients with anamnese retrieved successfully",
                StatusHttp = 200,
                Result = result
            });
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new DefaultOutput<IEnumerable<ClientModel>>
            {
                Message = "Server Error",
                StatusHttp = (int)HttpStatusCode.InternalServerError,

            });
        }
    }
}

