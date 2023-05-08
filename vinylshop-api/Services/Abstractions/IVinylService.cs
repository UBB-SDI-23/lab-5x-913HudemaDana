using Domain.DTOs;
using Domain.Helpers;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IVinylService
    {
        public Task<PaginationResult<VinylDto>> GetAllVinyls(PaginationOptions paginationOptions);
        public Task<IList<VinylDto>> GetAllVinyls();
        public Task<Vinyl?> GetVinylById(int id);
        public Task AddVinyl(VinylDto vinyl);
        public Task RemoveVinyl(int id);
        public Task UpdateVinyl(int id, VinylDto newVinyl);
    }
}
