using System;
using AndreiaFerreira.ClinicaApi.Interfaces;
using AndreiaFerreira.ClinicaApi.Models.Entities;
using AndreiaFerreira.ClinicaApi.Repositories;

namespace AndreiaFerreira.ClinicaApi.Services;

public class ClientService : IClientService
{
    private readonly IConfiguration _configuration;
    private readonly IClientRepository _clientRepository;

    public ClientService(IConfiguration configuration, IClientRepository clientRepository)
    {
        _configuration = configuration;
        _clientRepository = clientRepository;
    }

    public async Task<ClientModel> CreateClientAsync(ClientModel client)
    {
        return await _clientRepository.CreateClientAsync(client);
    }

    public async Task<bool> DeleteClientAsync(string cpf)
    {
        return await _clientRepository.DeleteClientAsync(cpf);
    }

    public async Task<IEnumerable<ClientModel>> GetAllClientsAsync()
    {
        return await _clientRepository.GetAllClientsAsync();
    }

    public async Task<IEnumerable<ClientModel>> GetAllClientsWithAnamneseAsync()
    {
        return await _clientRepository.GetAllClientsWithAnamneseAsync();
    }

    public async Task<ClientModel> GetClientAsync(string cpf)
    {
        return await _clientRepository.GetClientAsync(cpf);
    }

    public async Task<ClientModel> GetClientWithAnamneseAsync(string cpf)
    {
        return await _clientRepository.GetClientWithAnamneseAsync(cpf);

    }

    public async Task<ClientModel> UpdateClientAsync(ClientModel client)
    {
        return await _clientRepository.UpdateClientAsync(client.CPF, client);
    }
}

