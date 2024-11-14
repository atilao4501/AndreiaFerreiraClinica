using AndreiaFerreira.ClinicaApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AndreiaFerreira.ClinicaApi.Data;

public class IdentityPersonalizedDbContext : IdentityDbContext<User>
{
    public IdentityPersonalizedDbContext(DbContextOptions<IdentityPersonalizedDbContext> options) : base(options)
    {
    }
}
