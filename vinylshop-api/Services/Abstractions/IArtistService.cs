using Domain.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IArtistService
    {
        public Task<IList<ArtistDto>> GetAllArtists();
        public Task<Artist?> GetArtistById(int id);
        public Task AddArtist(ArtistDto artist);
        public Task RemoveArtist(int id);
        public Task UpdateArtist(int id, ArtistDto newArtist);
    }
}
