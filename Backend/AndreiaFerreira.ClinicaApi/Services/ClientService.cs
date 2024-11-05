using System;
using AndreiaFerreira.ClinicaApi.Interfaces;
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



}
