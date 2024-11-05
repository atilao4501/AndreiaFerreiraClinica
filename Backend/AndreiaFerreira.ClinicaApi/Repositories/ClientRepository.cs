using System;
using AndreiaFerreira.ClinicaApi.Data;
using AndreiaFerreira.ClinicaApi.Interfaces;
using AndreiaFerreira.ClinicaApi.Models.Entities;
using AndreiaFerreira.ClinicaApi.Services;
using Microsoft.EntityFrameworkCore;

namespace AndreiaFerreira.ClinicaApi.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly IConfiguration _configuration;
    private readonly ClinicDbContext _context;

    public ClientRepository(IConfiguration configuration, ClinicDbContext context)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<ClientModel> CreateClientAsync(ClientModel client)
    {
        if (client == null)
        {
            throw new ArgumentNullException(nameof(client), "Client cannot be null");
        }

        await _context.Pacientes.AddAsync(client);
        await _context.SaveChangesAsync();
        return client;
    }

    public async Task<bool> DeleteClientAsync(int id)
    {
        var client = await _context.Pacientes.FindAsync(id);
        if (client == null)
        {
            throw new KeyNotFoundException("Client not found");
        }

        _context.Pacientes.Remove(client);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<ClientModel>> GetAllClientsAsync()
    {
        return await _context.Pacientes.AsNoTracking().ToListAsync();
    }

    public async Task<ClientModel> UpdateClientAsync(int id, ClientModel client)
    {
        if (client == null)
        {
            throw new ArgumentNullException(nameof(client), "Client cannot be null");
        }

        var clientFromDb = await _context.Pacientes.FindAsync(id);
        if (clientFromDb == null)
        {
            throw new KeyNotFoundException("Client not found");
        }

        _context.Entry(clientFromDb).CurrentValues.SetValues(client);
        await _context.SaveChangesAsync();
        return clientFromDb;
    }

    public async Task<ClientModel> GetClientAsync(int id)
    {
        var client = await _context.Pacientes.FindAsync(id);
        if (client == null)
        {
            throw new KeyNotFoundException("Client not found");
        }
        return client;
    }

    public async Task<ClientModel> GetClientWithAnamneseAsync(int id)
    {
        var client = await _context.Pacientes.Include(c => c.Anamnese).FirstOrDefaultAsync(c => c.Id == id);
        if (client == null)
        {
            throw new KeyNotFoundException("Client not found");
        }
        return client;
    }

    public async Task<IEnumerable<ClientModel>> GetAllClientsWithAnamneseAsync()
    {
        return await _context.Pacientes.Include(c => c.Anamnese).ToListAsync();
    }
}

