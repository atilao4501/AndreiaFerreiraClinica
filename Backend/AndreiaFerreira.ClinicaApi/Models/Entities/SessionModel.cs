using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AndreiaFerreira.ClinicaApi.Models.Entities;

public class SessionModel
{
    [JsonIgnore]
    public int Id { get; set; }
    [JsonIgnore]
    public ClientModel Paciente { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
    public DateTime DataHoraSessao { get; set; }
    public string TipoDeServico { get; set; }
    public string Profissional { get; set; }
    public string? Observacoes { get; set; }
}
