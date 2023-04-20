using DataAccess.Data;
using Domain.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class VinylService : IVinylService
    {

        private readonly ApplicationDbContext _context;
        public VinylService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IList<VinylDto>> GetAllVinyls()
        {
            var vinylList = await _context.Vinyls.ToListAsync();
            var vinylListDto = vinylList.Select(vinyl => new VinylDto()
            {
                Id = vinyl.Id,
                Edition = vinyl.Edition,
                AlbumId = vinyl.AlbumId,
                Durablility = vinyl.Durablility,
                Size = vinyl.Size,
                Groove = vinyl.Groove,
                Speed = vinyl.Speed,
                Condition = vinyl.Condition
            });

            return vinylListDto.ToList() ?? new List<VinylDto>();
        }
        public async Task<Vinyl?> GetVinylById(int id)
        {
            var vinyl = await _context.Vinyls.Include(x => x.Album).SingleOrDefaultAsync(a => a.Id == id);
            var stocks = await _context.Stocks.Where(s => s.VinylId == id).ToListAsync();

            return (vinyl != null ? new Vinyl()
            {
                Id = vinyl.Id,
                Edition = vinyl.Edition,
                AlbumId = vinyl.AlbumId,
                Album = vinyl.Album,
                Durablility = vinyl.Durablility,
                Size = vinyl.Size,
                Groove = vinyl.Groove,
                Speed = vinyl.Speed,
                Condition = vinyl.Condition,
                Stocks = stocks

            } : null);
        }
        public async Task AddVinyl(VinylDto vinyl)
        {
            var Album = await _context.Albums.FindAsync(vinyl.AlbumId);
            if (Album == null)
                throw new Exception("Invalid data entered when creating a new Vinyl : verify input for Album");

            var newVinyl = new Vinyl()
            {
                Edition = vinyl.Edition,
                Album = Album,
                Durablility = vinyl.Durablility,
                Size = vinyl.Size,
                Groove = vinyl.Groove,
                Speed = vinyl.Speed,
                Condition = vinyl.Condition
            };
            await _context.Vinyls.AddAsync(newVinyl);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveVinyl(int id)
        {
            var vinyl = _context.Vinyls.Find(id);
            if (vinyl != null)
            {
                _context.Vinyls.Remove(vinyl);
            }

            await _context.SaveChangesAsync();
        }
        public async Task UpdateVinyl(int id, VinylDto newVinyl)
        {
            var Album = await _context.Albums.FindAsync(newVinyl);
            if (Album == null)
                throw new Exception("Invalid data entered when trying to update a Vinyl : verify input for Album");

            var vinyl = _context.Vinyls.Find(id);
            if (vinyl != null)
            {
                vinyl.Edition = newVinyl.Edition;
                vinyl.Album = Album;
                vinyl.Durablility = newVinyl.Durablility;
                vinyl.Size = newVinyl.Size;
                vinyl.Material = newVinyl.Material;
                vinyl.Groove = newVinyl.Groove;
                vinyl.Speed = newVinyl.Speed;
                vinyl.Condition = newVinyl.Condition;

                _context.Vinyls.Update(vinyl);
            }
            await _context.SaveChangesAsync();
        }

    }
}
