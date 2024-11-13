using System;
using AndreiaFerreira.ClinicaApi.Models.Entities;

namespace AndreiaFerreira.ClinicaApi.Interfaces;

public interface IClientRepository
{
    // Implementar endpoint GET para listar pacientes
    Task<IEnumerable<ClientModel>> GetAllClientsAsync();

    // Implementar endpoint POST para criar novo paciente
    Task<ClientModel> CreateClientAsync(ClientModel client);

    // Implementar endpoint PUT para atualizar dados do paciente
    Task<ClientModel> UpdateClientAsync(string cpf, ClientModel client);

    // Implementar endpoint DELETE para remover paciente
    Task<bool> DeleteClientAsync(string cpf);
    // Implementar endpoint GET para obter um paciente pelo ID
    Task<ClientModel> GetClientAsync(string cpf);
    // Implementar endpoint GET para obter um paciente com as rela es
    // de anamnese
    Task<IEnumerable<ClientModel>> GetAllClientsWithAnamneseAsync();
    public Task<ClientModel> GetClientWithAnamneseAsync(string cpf);
}
