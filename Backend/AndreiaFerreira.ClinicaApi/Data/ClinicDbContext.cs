using System;
using AndreiaFerreira.ClinicaApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AndreiaFerreira.ClinicaApi.Data;

public class ClinicDbContext : DbContext
{
    public ClinicDbContext(DbContextOptions<ClinicDbContext> options) : base(options)
    {
    }
    public DbSet<ClientModel> Pacientes { get; set; }
    public DbSet<AnamneseModel> Anamneses { get; set; }
    public DbSet<AgendaModel> Agendas { get; set; }
    public DbSet<CustomerTreatmentModel> Atendimentos { get; set; }
}
