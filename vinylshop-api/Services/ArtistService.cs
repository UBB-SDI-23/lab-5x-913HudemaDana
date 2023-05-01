using DataAccess.Data;
using Domain.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions;
using System.Collections.ObjectModel;
using System.Reflection.Metadata.Ecma335;

namespace Services
{
    public class ArtistService : IArtistService
    {
        private readonly ApplicationDbContext _context;
        public ArtistService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IList<ArtistDto>> GetAllArtists()
        {
            var artistList = await _context.Artists.ToListAsync();
            var artistListDto = artistList.Select(artist => new ArtistDto
            {
                Id = artist.Id,
                FirstName = artist.FirstName,
                LastName = artist.LastName,
                Age = artist.Age,
                Nationality = artist.Nationality,
                ActiveYears = artist.ActiveYears
            });

            return artistListDto.ToList() ?? new List<ArtistDto>();
        }
        public async Task<Artist?> GetArtistById(int id)
        {
            var artist = await _context.Artists.SingleOrDefaultAsync(a => a.Id == id);
            var albums = await _context.Albums.Where(c => c.ArtistId == id).ToListAsync();
            

            return (artist != null ? (new Artist()
            {
                Id = id,
                FirstName = artist.FirstName,
                LastName = artist.LastName,
                Age = artist.Age,
                Nationality = artist.Nationality,
                ActiveYears = artist.ActiveYears,
                Albums = albums
            }) : null);
        }
        public async Task AddArtist(ArtistDto artist)  
        {
            var newArtist = new Artist()
            {
                FirstName = artist.FirstName,
                LastName = artist.LastName,
                Age = artist.Age,
                Nationality = artist.Nationality,
                ActiveYears = artist.ActiveYears
            };
            await _context.Artists.AddAsync(newArtist);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveArtist(int id)
        {
            var artist = _context.Artists.Find(id);
            if (artist != null)
            {
                _context.Artists.Remove(artist);
            }

            await _context.SaveChangesAsync();
        }
        public async Task UpdateArtist(int id, ArtistDto newArtist)
        {
            var artist = _context.Artists.Find(id);
            if (artist != null)
            {
                artist.FirstName = newArtist.FirstName;
                artist.LastName = newArtist.LastName;
                artist.Age = newArtist.Age;
                artist.Nationality = newArtist.Nationality;
                artist.ActiveYears = newArtist.ActiveYears;

                _context.Artists.Update(artist);
            }
            await _context.SaveChangesAsync();
        }

    }
}
