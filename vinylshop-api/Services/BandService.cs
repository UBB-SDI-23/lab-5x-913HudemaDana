using DataAccess.Data;
using Domain.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BandService : IBandService
    {

        private readonly ApplicationDbContext _context;
        public BandService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IList<BandDto>> GetAllBands()
        {
            var bandList = await _context.Bands.ToListAsync();
            var bandListDto = bandList.Select(band => new BandDto()
            {
                Id = band.Id,
                Name = band.Name,
                Description = band.Description,
                StartDate = band.StartDate,
                NumberOfMembers = band.NumberOfMembers,
                NumberOfAwards = band.NumberOfAwards
            });

            return bandListDto.ToList() ?? new List<BandDto>();
        }
        public async Task<Band?> GetBandById(int id)
        {
            var band = await _context.Bands.SingleOrDefaultAsync(a => a.Id == id);
            var albums = await _context.Albums.Where(a => a.BandId == id).ToListAsync();
            var contracts = await _context.Contracts.Where(c => c.BandId == id).ToListAsync();
            
            return (band != null ? (new Band()
            {
                Id = id,
                Name = band.Name,
                Description = band.Description,
                StartDate = band.StartDate,
                NumberOfMembers = band.NumberOfMembers,
                NumberOfAwards = band.NumberOfAwards,
                Albums = albums,
                Contracts = contracts
            }) : null);
        }
        public async Task AddBand(BandDto band)
        {
            var newBand = new Band()
            {
                Name = band.Name,
                Description = band.Description,
                StartDate = band.StartDate,
                NumberOfMembers = band.NumberOfMembers,
                NumberOfAwards = band.NumberOfAwards
            };
            await _context.Bands.AddAsync(newBand);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveBand(int id)
        {
            var band = _context.Bands.Find(id);
            if (band != null)
            {
                _context.Bands.Remove(band);
            }

            await _context.SaveChangesAsync();
        }
        public async Task UpdateBand(int id, BandDto newBand)
        {
            var band = _context.Bands.Find(id);
            if (band != null)
            {
                band.Name = newBand.Name;
                band.Description = newBand.Description;
                band.StartDate = newBand.StartDate;
                band.NumberOfMembers = newBand.NumberOfMembers;
                band.NumberOfAwards = newBand.NumberOfAwards;

                _context.Bands.Update(band);
            }
            await _context.SaveChangesAsync();
        }

    }
}
