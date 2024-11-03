using System;
using AndreiaFerreira.ClinicaApi.Models;
using AndreiaFerreira.ClinicaApi.Models.DTO;

namespace AndreiaFerreira.ClinicaApi.Interfaces;

public interface IAuthService
{
    Task<LoginOutput> Login(LoginModel model);
    Task<bool> Register(RegisterModel model);

}
