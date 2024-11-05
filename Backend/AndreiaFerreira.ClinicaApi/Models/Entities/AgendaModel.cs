using System;

namespace AndreiaFerreira.ClinicaApi.Models.Entities;

public class AgendaModel
{
    public int Id { get; set; }
    public ClientModel Paciente { get; set; }
    public DateTime DataHora { get; set; }
    public string Tipo_de_servico { get; set; }
    public string Profissional { get; set; }
    public string? Observacoes { get; set; }
}
