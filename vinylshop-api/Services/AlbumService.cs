using DataAccess.Data;
using Domain.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions;
using System.Linq;

namespace Services
{
    public class AlbumService : IAlbumService
    {

        private readonly ApplicationDbContext _context;
        public AlbumService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IList<AlbumDto>> GetAllAlbums()
        {
            var AlbumList = await _context.Albums.ToListAsync();
            var AlbumListDto = AlbumList.Select(Album => new AlbumDto()
            {
                Id = Album.Id,
                Name = Album.Name,
                Lyrics = Album.Lyrics,
                ArtistId = Album.ArtistId
            });

            return AlbumListDto.ToList() ?? new List<AlbumDto>();
        }
        public async Task<Album?> GetAlbumById(int id)
        {
            var album = await _context.Albums
                .Include(x => x.Artist)
                .SingleOrDefaultAsync(a => a.Id == id);
            var vinyls = await _context.Vinyls.Where(v => v.AlbumId == id).ToListAsync();

            return (album != null ? new Album()
            {
                Id = album.Id,
                Name = album.Name,
                Lyrics = album.Lyrics,
                RealiseDate = album.RealiseDate,
                Artist = album.Artist,
                ArtistId = album.ArtistId,
                Vinyls = vinyls

            } : null);
        }

        public async Task<IList<AlbumAndAvegSizeVinylDto>> GetAllAlbumByAvgVinylSize()
        {
            var AlbumList = await _context.Albums.ToListAsync();
            var AverageList = new List<AlbumAndAvegSizeVinylDto>();
            foreach (var Album in AlbumList) {
                var vinyls = await _context.Vinyls.Where(v => v.AlbumId == Album.Id).ToListAsync();
                var avg = vinyls.Sum(v => v.Size) / vinyls.Count();
                AverageList.Add(new AlbumAndAvegSizeVinylDto()
                {
                    Id = Album.Id,
                    Name = Album.Name,
                    Lyrics = Album.Lyrics,
                    ArtistId = Album.ArtistId,
                    AvgSize = avg
                });
            }

            AverageList = AverageList.OrderByDescending(v => v.AvgSize).ToList();

            return AverageList;
        }

        public async Task<IList<AlbumAndVinylDurabilitySumDto>> GetAllAlbumsGroupedBy()
        {
            var AlbumList = await _context.Albums.ToListAsync();
            var AverageList = new List<AlbumAndVinylDurabilitySumDto>();
            foreach (var Album in AlbumList)
            {
                var vinyls = await _context.Vinyls.Where(v => v.AlbumId == Album.Id).ToListAsync();
                var groupedVinyls = vinyls.GroupBy(v => v.Durablility);
                AverageList.Add(new AlbumAndVinylDurabilitySumDto()
                {
                    Id = Album.Id,
                    Name = Album.Name,
                    Lyrics = Album.Lyrics,
                    ArtistId = Album.ArtistId,
                    Durability = groupedVinyls.Count(),
                    Vinyls = groupedVinyls
                }) ;
            }

            return AverageList.OrderBy(v => v.Durability).ToList();
        }
        public async Task AddAlbum(AlbumDto Album)
        {
            var artist = await _context.Artists.FindAsync(Album.ArtistId);
            if (artist == null)
                throw new Exception("Invalid data entered when creating a new Album : verify input for artist");

            var newAlbum = new Album()
            {
                Name = Album.Name,
                Lyrics = Album.Lyrics,
                RealiseDate = Album.RealiseDate,
                Artist = artist
            };
            await _context.Albums.AddAsync(newAlbum);
            await _context.SaveChangesAsync();
        }


            public async Task AddVinylForAnAlbum(int id, List<VinylDto> vinyls)
        {
            var album = await _context.Albums.FindAsync(id);
            if (vinyls == null)
                throw new Exception("Invalid data entered when creating Vinyls : verify input for vinyl");

            foreach (var vinyl in vinyls)
            {
                var newVinyl = new Vinyl()
                {
                    Edition = vinyl.Edition,
                    AlbumId = id,
                    Album = album,
                    Durablility = vinyl.Durablility,
                    Size = vinyl.Size,
                    Groove = vinyl.Groove,
                    Speed = vinyl.Speed,
                    Condition = vinyl.Condition,

                };
            await _context.Vinyls.AddAsync(newVinyl);
            }
            await _context.SaveChangesAsync();
        }
        public async Task RemoveAlbum(int id)
        {
            var Album = _context.Albums.Find(id);
            if (Album != null)
            {
                _context.Albums.Remove(Album);
            }

            await _context.SaveChangesAsync();
        }
        public async Task UpdateAlbum(int id, AlbumDto newAlbum)
        {
            var artist = await _context.Artists.FindAsync(newAlbum.ArtistId);
            if (artist == null)
                throw new Exception("Invalid data entered when trying to update a Album : verify input for artist");

            var Album = _context.Albums.Find(id);
            if (Album != null)
            {
                Album.Name = newAlbum.Name;
                Album.Lyrics = newAlbum.Lyrics;
                Album.RealiseDate = newAlbum.RealiseDate;
                Album.Artist = artist;

                _context.Albums.Update(Album);
            }
            await _context.SaveChangesAsync();
        }

    }
}
