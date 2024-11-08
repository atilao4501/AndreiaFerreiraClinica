using System.Collections.Generic;
using System.Threading.Tasks;
using AndreiaFerreira.ClinicaApi.Models.Entities;

namespace AndreiaFerreira.ClinicaApi.Interfaces;

public interface ICustomerServiceService
{
    Task<IEnumerable<CustomerServiceModel>> GetAll();
    Task<CustomerServiceModel> GetByClient(int clientId);
}


