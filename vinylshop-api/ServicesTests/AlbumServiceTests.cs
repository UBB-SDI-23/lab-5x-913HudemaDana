using DataAccess.Data;
using Domain.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using NHibernate.Mapping;
using NHibernate.Util;
using Services;
using Services.Abstractions;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace ServicesTests
{
    [TestClass]
    public class AlbumServiceTests
    {
        private readonly AlbumService _albumService;
        private readonly Mock<ApplicationDbContext> _context = new Mock<ApplicationDbContext>();

        public AlbumServiceTests()
        {
            _albumService = new AlbumService(_context.Object);
        }

        [TestMethod]
        public async Task GetAllAlbumByAvgVinylSize_Test()
        {
            //arrange
            var albums = new List<Album>
            {
                new Album(){Id = 1, Name = "Back in Black",     Lyrics = "You Shook Me All Night Long",RealiseDate = null,   ArtistId = 2 },
                new Album(){Id = 2, Name = "Thriller",          Lyrics = "You Shook Me All Night Long",RealiseDate = null,   ArtistId = 3 },
                new Album(){Id = 3, Name = "Rumours",           Lyrics = "You Shook Me All Night Long",RealiseDate = null,ArtistId = 4 },
                new Album(){Id = 4, Name = "The Joshua Tree",   Lyrics = "You Shook Me All Night Long",RealiseDate = null,   ArtistId = null },
                new Album(){Id = 5, Name = "Nevermind",         Lyrics = "You Shook Me All Night Long",RealiseDate = null,   ArtistId = 7 },
                new Album(){Id = 6, Name = "Abbey Road",        Lyrics = "You Shook Me All Night Long",RealiseDate = null,   ArtistId = null },
                new Album(){Id = 7, Name = "Purple Rain",       Lyrics = "You Shook Me All Night Long",RealiseDate = null,   ArtistId = 9 },
                new Album(){Id = 8, Name = "The Chronic",       Lyrics = "You Shook Me All Night Long",RealiseDate = null,ArtistId = 9 },
                new Album(){Id = 12,Name = "In Utero",          Lyrics = "You Shook Me All Night Long",RealiseDate = null,   ArtistId = 11 },
                new Album(){Id = 13,Name = "Blonde on Blonde",  Lyrics = "You Shook Me All Night Long",RealiseDate = null,  ArtistId = null }
            };
            var vinyls = new List<Vinyl>
            {
                new Vinyl(){ Id = 1  , Edition = "1", AlbumId = 1 , Condition = "Mint",     Durablility=8,Groove="",Material="Vinyl",Size=12,   Speed="45 RPM"},
                new Vinyl(){ Id = 2  , Edition = "2", AlbumId = 2 , Condition = "Very Good",Durablility=6,Groove="",Material="Vinyl",Size=12,   Speed="45 RPM"},
                new Vinyl(){ Id = 3  , Edition = "3", AlbumId = 3 , Condition = "Near Mint",Durablility=7,Groove="",Material="Vinyl",Size=10,   Speed="45 RPM"},
                new Vinyl(){ Id = 4  , Edition = "4", AlbumId = 4 , Condition = "Good",     Durablility=5,Groove="",Material="Vinyl",Size=12,   Speed="45 RPM"},
                new Vinyl(){ Id = 5  , Edition = "5", AlbumId = 5 , Condition = "Very Good",Durablility=7,Groove="",Material="Vinyl",Size=12,   Speed="45 RPM"},
                new Vinyl(){ Id = 6  , Edition = "7", AlbumId = 6 , Condition = "Near Mint",Durablility=8,Groove="",Material="Vinyl",Size=12,   Speed="45 RPM"},
                new Vinyl(){ Id = 7  , Edition = "8", AlbumId = 7 , Condition = "Mint",     Durablility=9,Groove="",Material="Vinyl",Size=7,    Speed="45 RPM"},
                new Vinyl(){ Id = 8  , Edition = "6", AlbumId = 8 , Condition = "Good",     Durablility=6,Groove="",Material="Vinyl",Size=12,   Speed="45 RPM"},
                new Vinyl(){ Id = 9  , Edition = "9", AlbumId = 12, Condition = "Very Good",Durablility=4,Groove="",Material="Vinyl",Size=12,   Speed="45 RPM"},
                new Vinyl(){ Id = 10 , Edition = "10",AlbumId = 13, Condition = "Near Mint",Durablility=7,Groove="",Material="Vinyl",Size=10,   Speed="45 RPM"},
                new Vinyl(){ Id = 11 , Edition = "11",AlbumId = 1 , Condition = "Good",     Durablility=3,Groove="",Material="Vinyl",Size=7,    Speed="45 RPM"},
                new Vinyl(){ Id = 12 , Edition = "12",AlbumId = 1 , Condition = "Not Good", Durablility=2,Groove="",Material="Vinyl",Size=7,    Speed="45 RPM"}
            };
            _context.Setup(x => x.Albums).ReturnsDbSet(albums);
            _context.Setup(x => x.Vinyls).ReturnsDbSet(vinyls);
            
            //
            var filteredAlbums = await _albumService.GetAllAlbumByAvgVinylSize();
            var expectedList = new List<int?>() { 2, 4, 5, 6, 8, 12, 3, 13, 1, 7 };
            //2 4 5 6 8 12 3 13 1 7

            //assert
            Assert.AreEqual(2, filteredAlbums.FirstOrDefault().Id);
        }

        [TestMethod]
        public async Task GetAllAlbumsGroupedBy_Test()
        {
            //arrange
            var albums = new List<Album>
            {
                new Album(){Id = 1, Name = "Back in Black",     Lyrics = "You Shook Me All Night Long",RealiseDate = null,   ArtistId = 2 },
                new Album(){Id = 2, Name = "Thriller",          Lyrics = "You Shook Me All Night Long",RealiseDate = null,  ArtistId = 3 },
                new Album(){Id = 3, Name = "Rumours",           Lyrics = "You Shook Me All Night Long",RealiseDate = null,ArtistId = 4 },
                new Album(){Id = 4, Name = "The Joshua Tree",   Lyrics = "You Shook Me All Night Long",RealiseDate = null,   ArtistId = null },
                new Album(){Id = 5, Name = "Nevermind",         Lyrics = "You Shook Me All Night Long",RealiseDate = null,   ArtistId = 7 },
                new Album(){Id = 6, Name = "Abbey Road",        Lyrics = "You Shook Me All Night Long",RealiseDate = null,   ArtistId = null },
                new Album(){Id = 7, Name = "Purple Rain",       Lyrics = "You Shook Me All Night Long",RealiseDate = null,   ArtistId = 9 },
                new Album(){Id = 8, Name = "The Chronic",       Lyrics = "You Shook Me All Night Long",RealiseDate = null,ArtistId = 9 },
                new Album(){Id = 12,Name = "In Utero",          Lyrics = "You Shook Me All Night Long",RealiseDate = null,   ArtistId = 11 },
                new Album(){Id = 13,Name = "Blonde on Blonde",  Lyrics = "You Shook Me All Night Long",RealiseDate = null,  ArtistId = null }
            };

            var vinyls = new List<Vinyl>
            {
                new Vinyl(){ Id = 1  , Edition = "1", AlbumId = 1 , Condition = "Mint",     Durablility=8,Groove="",Material="Vinyl",Size=12,   Speed="45 RPM"},
                new Vinyl(){ Id = 2  , Edition = "2", AlbumId = 2 , Condition = "Very Good",Durablility=6,Groove="",Material="Vinyl",Size=12,   Speed="45 RPM"},
                new Vinyl(){ Id = 3  , Edition = "3", AlbumId = 3 , Condition = "Near Mint",Durablility=7,Groove="",Material="Vinyl",Size=10,   Speed="45 RPM"},
                new Vinyl(){ Id = 4  , Edition = "4", AlbumId = 4 , Condition = "Good",     Durablility=5,Groove="",Material="Vinyl",Size=12,   Speed="45 RPM"},
                new Vinyl(){ Id = 5  , Edition = "5", AlbumId = 5 , Condition = "Very Good",Durablility=7,Groove="",Material="Vinyl",Size=12,   Speed="45 RPM"},
                new Vinyl(){ Id = 6  , Edition = "7", AlbumId = 6 , Condition = "Near Mint",Durablility=8,Groove="",Material="Vinyl",Size=12,   Speed="45 RPM"},
                new Vinyl(){ Id = 7  , Edition = "8", AlbumId = 7 , Condition = "Mint",     Durablility=9,Groove="",Material="Vinyl",Size=7,    Speed="45 RPM"},
                new Vinyl(){ Id = 8  , Edition = "6", AlbumId = 8 , Condition = "Good",     Durablility=6,Groove="",Material="Vinyl",Size=12,   Speed="45 RPM"},
                new Vinyl(){ Id = 9  , Edition = "9", AlbumId = 12, Condition = "Very Good",Durablility=4,Groove="",Material="Vinyl",Size=12,   Speed="45 RPM"},
                new Vinyl(){ Id = 10 , Edition = "10",AlbumId = 13, Condition = "Near Mint",Durablility=7,Groove="",Material="Vinyl",Size=10,   Speed="45 RPM"},
                new Vinyl(){ Id = 11 , Edition = "11",AlbumId = 1 , Condition = "Good",     Durablility=3,Groove="",Material="Vinyl",Size=7,    Speed="45 RPM"},
                new Vinyl(){ Id = 12 , Edition = "12",AlbumId = 1 , Condition = "Not Good", Durablility=2,Groove="",Material="Vinyl",Size=7,    Speed="45 RPM"}
            };
        
            _context.Setup(x => x.Albums).ReturnsDbSet(albums);
            _context.Setup(x => x.Vinyls).ReturnsDbSet(vinyls);

            //
            var filteredAlbums = await _albumService.GetAllAlbumsGroupedBy();

            //assert
            Assert.AreEqual(1, filteredAlbums.LastOrDefault().Id);
        }

    }
}