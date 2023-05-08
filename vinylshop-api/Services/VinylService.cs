using DataAccess.Data;
using Domain.DTOs;
using Domain.Helpers;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using NHibernate.Criterion;
using Services.Abstractions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public async Task<PaginationResult<VinylDto>> GetAllVinyls(PaginationOptions paginationOptions)
        {
            var vinyls = _context.Vinyls
                .Select(vinyl => new VinylDto()
                {
                    Id = vinyl.Id,
                    Edition = vinyl.Edition,
                    AlbumId = vinyl.AlbumId,
                    Durablility = vinyl.Durablility,
                    Size = vinyl.Size,
                    Groove = vinyl.Groove,
                    Speed = vinyl.Speed,
                    Condition = vinyl.Condition,
                    Material = vinyl.Material
                })
                .AsQueryable();
 
            // apply pagination
            var pagedVinyls = await vinyls
                .Skip((paginationOptions.PageNumber - 1) * paginationOptions.PageSize)
                .Take(paginationOptions.PageSize)
                .ToListAsync();

            var totalRecords = await vinyls.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalRecords / paginationOptions.PageSize);

            var paginationResult = new PaginationResult<VinylDto>
            {
                PageNumber = paginationOptions.PageNumber,
                PageSize = paginationOptions.PageSize,
                TotalPages = totalPages,
                TotalRecords = totalRecords,
                Results = pagedVinyls
            };

            return paginationResult;
        }

        public async Task<IList<VinylDto>> GetAllVinyls()
        {
            var vinylList = _context.Vinyls
                .Select(vinyl => new VinylDto()
            {
                Id = vinyl.Id,
                Edition = vinyl.Edition,
                AlbumId = vinyl.AlbumId,
                Durablility = vinyl.Durablility,
                Size = vinyl.Size,
                Groove = vinyl.Groove,
                Speed = vinyl.Speed,
                Condition = vinyl.Condition,
                Material = vinyl.Material
            });

            return vinylList.ToList() ?? new List<VinylDto>();
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
                Stocks = stocks,
                Material = vinyl.Material

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
                Condition = vinyl.Condition,
                Material = vinyl?.Material
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
