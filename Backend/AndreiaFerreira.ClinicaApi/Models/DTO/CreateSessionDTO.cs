using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AndreiaFerreira.ClinicaApi.Models.DTO;

public class CreateSessionDTO
{
    public string Cpf { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
    public DateTime DataHoraSessao { get; set; }
    public string TipoDeServico { get; set; }
    public string Profissional { get; set; }
    public string? Observacoes { get; set; }
}
