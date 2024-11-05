using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using AndreiaFerreira.ClinicaApi.Interfaces;
using AndreiaFerreira.ClinicaApi.Models;
using AndreiaFerreira.ClinicaApi.Models.DTO;
using AndreiaFerreira.ClinicaApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AndreiaFerreira.ClinicaApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _AuthService;

    public AuthController(IAuthService AuthService)
    {
        _AuthService = AuthService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginModel model)
    {
        try
        {
            var output = await _AuthService.Login(model);

            return Ok(new DefaultOutput<string>()
            {
                Message = "Login Sucessful",
                StatusHttp = 200,
                Result = output
            });
        }
        catch (HttpRequestException ex)
        {
            return StatusCode((int)ex.StatusCode, new DefaultOutput<string>
            {
                Message = ex.Message,
                StatusHttp = (int)ex.StatusCode,
            });
        }
        catch (System.Exception ex)
        {

            return StatusCode((int)HttpStatusCode.InternalServerError, new DefaultOutput<string>
            { Message = "Server Error", StatusHttp = (int)HttpStatusCode.InternalServerError, Result = null });
        }
    }

    [HttpPost("register")]
    [Authorize]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        try
        {
            var output = await _AuthService.Register(model);

            return Ok(new DefaultOutput<bool>()
            {
                Message = "User created",
                StatusHttp = 200,
                Result = output
            });
        }
        catch (HttpRequestException ex)
        {
            return StatusCode((int)ex.StatusCode, new DefaultOutput<bool>
            {
                Message = ex.Message,
                StatusHttp = (int)ex.StatusCode,
                Result = false
            });
        }
        catch (System.Exception ex)
        {

            return StatusCode((int)HttpStatusCode.InternalServerError, new DefaultOutput<bool>
            {
                Message = "Server Error",
                StatusHttp = (int)HttpStatusCode.InternalServerError,
                Result = false
            });
        }
    }
}

