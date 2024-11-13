using System;
using AndreiaFerreira.ClinicaApi.Models.Entities;

namespace AndreiaFerreira.ClinicaApi.Interfaces;

public interface IClientService
{
    Task<ClientModel> CreateClientAsync(ClientModel client);
    Task<ClientModel> UpdateClientAsync(ClientModel client);
    Task<bool> DeleteClientAsync(string cpf);
    Task<IEnumerable<ClientModel>> GetAllClientsAsync();
    Task<ClientModel> GetClientAsync(string cpf);
    Task<ClientModel> GetClientWithAnamneseAsync(string cpf);
    Task<IEnumerable<ClientModel>> GetAllClientsWithAnamneseAsync();
}
