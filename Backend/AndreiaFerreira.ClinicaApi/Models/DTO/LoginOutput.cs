using System;

namespace AndreiaFerreira.ClinicaApi.Models.DTO;

public class LoginOutput
{
    public string Message { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
}
