using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AndreiaFerreira.ClinicaApi.Models.Entities;

public class AgendaModel
{
    [JsonIgnore]
    public int Id { get; set; }
    public ClientModel Paciente { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
    public DateTime DataAgendamento { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
    public DateTime DataCadastro { get; set; }
    public string Tipo_de_servico { get; set; }
    public string Profissional { get; set; }
    public string? Observacoes { get; set; }
}
