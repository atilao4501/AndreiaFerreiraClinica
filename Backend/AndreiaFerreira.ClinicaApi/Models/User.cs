using Microsoft.AspNetCore.Identity;

namespace AndreiaFerreira.ClinicaApi.Models;

public class User : IdentityUser
{
    public string Document { get; set; } = string.Empty;
}

