using System;

namespace AndreiaFerreira.ClinicaApi.Models.Entities;

public class CustomerTreatmentModel
{
    public int Id { get; set; }
    public ClientModel Paciente { get; set; }
    public List<bool> Sessoes { get; set; }
    public int TotalSessoes => Sessoes?.Count ?? 0;
}
