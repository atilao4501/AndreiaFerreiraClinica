using System;
using System.ComponentModel.DataAnnotations;

namespace AndreiaFerreira.ClinicaApi.Models;

public class LoginModel
{
    [Required]
    public string UserName { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

}
