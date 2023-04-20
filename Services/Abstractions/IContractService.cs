using Domain.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IContractService
    {
        public Task<IList<ContractDto>> GetAllContracts();
        public Task<Contract?> GetContractById(int id);
        public Task AddContract(ContractDto contract);
        public Task RemoveContract(int id);
        public Task UpdateContract(int id, ContractDto newContract);
    }
}
