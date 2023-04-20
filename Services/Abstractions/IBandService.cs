using Domain.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IBandService
    {
        public Task<IList<BandDto>> GetAllBands();
        public Task<Band?> GetBandById(int id);
        public Task AddBand(BandDto band);
        public Task RemoveBand(int id);
        public Task UpdateBand(int id, BandDto newBand);
    }
}
