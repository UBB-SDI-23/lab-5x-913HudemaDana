using DataAccess.Data;
using Domain.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ContractService : IContractService
    {
        private readonly ApplicationDbContext _context;
        public ContractService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IList<ContractDto>> GetAllContracts()
        {
            var contractList = await _context.Contracts.ToListAsync();
            var contractListDto = contractList.Select(contract => new ContractDto()
            {
                Id = contract.Id,
                Duration = contract.Duration,
                StartDate = contract.StartDate,
                ArtistId = contract.ArtistId,
                BandId = contract.BandId,
                RecordLabelId = contract.RecordLabelId
            });

            return contractListDto.ToList() ?? new List<ContractDto>();
        }
        public async Task<Contract?> GetContractById(int id)
        {
            var contract = await _context.Contracts
                .Include(x => x.Artist)
                .Include(x => x.Band)
                .Include (x => x.RecordLabel)
                .SingleOrDefaultAsync(a => a.Id == id);

            return (contract != null) ? (new Contract()
            {
                Id = contract.Id,
                Duration = contract.Duration,
                StartDate = contract.StartDate,
                ArtistId = contract.ArtistId,
                BandId = contract.BandId,
                RecordLabelId = contract.RecordLabelId,
                Artist = contract.Artist,
                Band = contract.Band,
                RecordLabel = contract.RecordLabel
            }) : null;
        }
        public async Task AddContract(ContractDto contract)
        {
            var artist = await _context.Artists.FindAsync(contract.ArtistId);
            var band = await _context.Bands.FindAsync(contract.BandId);
            var recordLabel = await _context.RecordLabels.FindAsync(contract.RecordLabelId);
            if ((artist == null && band == null) || recordLabel == null)
                throw new Exception("Invalid data entered when creating a new Contract: verify input for artist, band or recordLabel");

            var newContract = new Contract()
            {
                Artist = artist,
                Band = band,
                RecordLabel = recordLabel
            };
            await _context.Contracts.AddAsync(newContract);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveContract(int id)
        {
            var contract = _context.Contracts.Find(id);
            if (contract != null)
            {
                _context.Contracts.Remove(contract);
            }

            await _context.SaveChangesAsync();
        }
        public async Task UpdateContract(int id, ContractDto newContract)
        {
            var artist = await _context.Artists.FindAsync(newContract.ArtistId);
            var band = await _context.Bands.FindAsync(newContract.BandId);
            var recordLabel = await _context.RecordLabels.FindAsync(newContract.RecordLabelId);
            if ((artist == null && band == null) || recordLabel == null)
                throw new Exception("Invalid data entered when trying to update a Contract: verify input for artist, band or recordLabel");


            var contract = _context.Contracts.Find(id);
            if (contract != null)
            {
                contract.Duration = newContract.Duration;
                contract.StartDate = newContract.StartDate;
                contract.Artist = artist;
                contract.Band = band;
                contract.RecordLabel = recordLabel;

                _context.Contracts.Update(contract);
            }
            await _context.SaveChangesAsync();
        }
    }
}
