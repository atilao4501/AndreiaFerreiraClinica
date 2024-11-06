using System;
using System.ComponentModel.DataAnnotations;

namespace AndreiaFerreira.ClinicaApi.Models.DTO;

public class CreateAgendaDTO
{
    public int PacienteId { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
    public DateTime DataAgendamento { get; set; }
    public string Tipo_de_servico { get; set; }
    public string Profissional { get; set; }
    public string? Observacoes { get; set; }
}
