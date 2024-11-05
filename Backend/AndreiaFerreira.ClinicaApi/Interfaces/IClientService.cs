using System;
using AndreiaFerreira.ClinicaApi.Models.Entities;

namespace AndreiaFerreira.ClinicaApi.Interfaces;

public interface IClientService
{
    Task<ClientModel> CreateClientAsync(ClientModel client);
    Task<ClientModel> UpdateClientAsync(ClientModel client);
    Task<bool> DeleteClientAsync(int id);
    Task<IEnumerable<ClientModel>> GetAllClientsAsync();
    Task<ClientModel> GetClientAsync(int id);
    Task<ClientModel> GetClientWithAnamneseAsync(int id);
    Task<IEnumerable<ClientModel>> GetAllClientsWithAnamneseAsync();
}
