using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AndreiaFerreira.ClinicaApi.Models.DTO;
using AndreiaFerreira.ClinicaApi.Models.Entities;
using AndreiaFerreira.ClinicaApi.Models;
using AndreiaFerreira.ClinicaApi.Interfaces;
using AndreiaFerreira.ClinicaApi.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace AndreiaFerreira.ClinicaApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]/[action]")]
public class CustomerServiceController : ControllerBase
{
    private readonly ICustomerServiceService _customerServiceService;

    public CustomerServiceController(ICustomerServiceService customerServiceService)
    {
        _customerServiceService = customerServiceService;
    }

    [HttpGet]
    public async Task<ActionResult<DefaultOutput<List<CustomerServiceModel>>>> GetAll()
    {
        try
        {
            var result = await _customerServiceService.GetAll();

            if (result == null)
                return NotFound();

            return Ok(new DefaultOutput<List<CustomerServiceModel>>
            {
                Result = (List<CustomerServiceModel>)result,
                Message = "Consulta realizada com sucesso.",
                StatusHttp = 200
            });
        }
        catch (PersonalizedException ex)
        {
            return BadRequest(new DefaultOutput<List<CustomerServiceModel>>
            {
                Message = ex.Message
            });
        }
    }

    [HttpGet("{cpf}")]
    public async Task<ActionResult<DefaultOutput<CustomerServiceModel>>> GetByCpf(string cpf)
    {
        try
        {
            var result = await _customerServiceService.GetByClient(cpf);

            if (result == null)
                return NotFound();

            return Ok(new DefaultOutput<CustomerServiceModel>
            {
                Result = result,
                Message = "Consulta realizada com sucesso.",
                StatusHttp = 200
            });
        }
        catch (PersonalizedException ex)
        {
            return BadRequest(new DefaultOutput<CustomerServiceModel>
            {
                Message = ex.Message
            });
        }
    }
}

