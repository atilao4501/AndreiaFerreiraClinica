using System;

namespace AndreiaFerreira.ClinicaApi.Models.Entities;

public class CustomerServiceModel
{
    public string NomePaciente { get; set; }
    public List<SessionModel> Sessoes { get; set; } = new List<SessionModel>();
    public int TotalSessoes => Sessoes.Count;
}
