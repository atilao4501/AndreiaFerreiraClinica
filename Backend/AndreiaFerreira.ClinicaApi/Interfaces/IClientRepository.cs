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
    Task<ClientModel> UpdateClientAsync(int id, ClientModel client);

    // Implementar endpoint DELETE para remover paciente
    Task<bool> DeleteClientAsync(int id);
    // Implementar endpoint GET para obter um paciente pelo ID
    Task<ClientModel> GetClientAsync(int id);
    // Implementar endpoint GET para obter um paciente com as rela es
    // de anamnese
    Task<ClientModel> GetClientWithAnamneseAsync(int id);

    // Implementar endpoint GET para obter todos os pacientes com as
    // rela es de anamnese
    Task<IEnumerable<ClientModel>> GetAllClientsWithAnamneseAsync();
}
