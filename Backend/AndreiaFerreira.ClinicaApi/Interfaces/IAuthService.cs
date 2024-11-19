using System;
using AndreiaFerreira.ClinicaApi.Models;

namespace AndreiaFerreira.ClinicaApi.Interfaces;

public interface IAuthService
{
    Task<string> Login(LoginModel model);
    Task<bool> Register(RegisterModel model);

}
