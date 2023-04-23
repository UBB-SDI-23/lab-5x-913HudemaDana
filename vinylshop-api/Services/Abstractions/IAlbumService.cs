using Domain.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IAlbumService
    {
        public Task<IList<AlbumDto>> GetAllAlbums();
        public Task<Album?> GetAlbumById(int id);
        public Task<IList<AlbumAndAvegSizeVinylDto>> GetAllAlbumByAvgVinylSize();
        public Task<IList<AlbumAndVinylDurabilitySumDto>> GetAllAlbumsGroupedBy();
        public Task AddAlbum(AlbumDto Album);
        public Task AddVinylForAnAlbum(int id, List<VinylDto> vinyls);
        public Task RemoveAlbum(int id);
        public Task UpdateAlbum(int id, AlbumDto newAlbum);
    }
}
