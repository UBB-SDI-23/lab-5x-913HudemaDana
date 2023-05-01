using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>().HasData(
                new Album() { Id = 1, Name = "Back in Black", Lyrics = "You Shook Me All Night Long", RealiseDate = null, ArtistId = 2 },
                new Album() { Id = 2, Name = "Thriller", Lyrics = "You Shook Me All Night Long", RealiseDate = null, ArtistId = 3 },
                new Album() { Id = 3, Name = "Rumours", Lyrics = "You Shook Me All Night Long", RealiseDate = null, ArtistId = 4 },
                new Album() { Id = 4, Name = "The Joshua Tree", Lyrics = "You Shook Me All Night Long", RealiseDate = null, ArtistId = 2 },
                new Album() { Id = 5, Name = "Nevermind", Lyrics = "You Shook Me All Night Long", RealiseDate = null, ArtistId = 7 },
                new Album() { Id = 6, Name = "Abbey Road", Lyrics = "You Shook Me All Night Long", RealiseDate = null, ArtistId = 8},
                new Album() { Id = 7, Name = "Purple Rain", Lyrics = "You Shook Me All Night Long", RealiseDate = null, ArtistId = 9 },
                new Album() { Id = 8, Name = "The Chronic", Lyrics = "You Shook Me All Night Long", RealiseDate = null, ArtistId = 9 },
                new Album() { Id = 12, Name = "In Utero", Lyrics = "You Shook Me All Night Long", RealiseDate = null, ArtistId = 5 },
                new Album() { Id = 13, Name = "Blonde on Blonde", Lyrics = "You Shook Me All Night Long", RealiseDate = null, ArtistId = 1 }
    );
            modelBuilder.Entity<Artist>().HasData(
                            new Artist
                            {
                                Id = 1,
                                FirstName = "Vincent",
                                LastName = "van Gogh",
                                Age = 37,
                                Nationality = "Dutch",
                                ActiveYears = 1880
                            },
            new Artist
            {
                Id =2,
                FirstName = "Pablo",
                LastName = "Picasso",
                Age = 91,
                Nationality = "Spanish",
                ActiveYears = 1890
            },
            new Artist
            {
                Id = 3,
                FirstName = "Claude",
                LastName = "Monet",
                Age = 86,
                Nationality = "French",
                ActiveYears = 1858
            },
            new Artist
            {
                Id = 4,
                FirstName = "Leonardo",
                LastName = "da Vinci",
                Age = 67,
                Nationality = "Italian",
                ActiveYears = 1472
            },
            new Artist
            {
                Id = 5,
                FirstName = "Michelangelo",
                LastName = "Buonarroti",
                Age = 88,
                Nationality = "Italian",
                ActiveYears = 1494
            },
            new Artist
            {
                Id = 6,
                FirstName = "Salvador",
                LastName = "Dali",
                Age = 84,
                Nationality = "Spanish",
                ActiveYears = 1919
            },
            new Artist
            {
                Id = 7,
                FirstName = "Rembrandt",
                LastName = "van Rijn",
                Age = 63,
                Nationality = "Dutch",
                ActiveYears = 1625
            },
            new Artist
            {
                Id = 8,
                FirstName = "Edvard",
                LastName = "Munch",
                Age = 80,
                Nationality = "Norwegian",
                ActiveYears = 1880
            },
            new Artist
            {
                Id = 9,
                FirstName = "Jackson",
                LastName = "Pollock",
                Age = 44,
                Nationality = "American",
                ActiveYears = 1947
            },
            new Artist
            {
                Id = 10,
                FirstName = "Gustav",
                LastName = "Klimt",
                Age = 55,
                Nationality = "Austrian",
                ActiveYears = 1880
            }
    );
            modelBuilder.Entity<Stock>().HasData(
                            new Stock
                            {
                                Id = 1,
                                AvailableVinyls = 10,
                                Price = 1299,
                                ShopId = 1,
                                VinylId = 1
                            },
            new Stock
            {
                Id = 2,
                AvailableVinyls = 5,
                Price = 899,
                ShopId = 2,
                VinylId = 3
            },
            new Stock
            {
                Id = 3,
                AvailableVinyls = 7,
                Price = 1999,
                ShopId = 3,
                VinylId = 2
            },
            new Stock
            {
                Id = 4,
                AvailableVinyls = 20,
                Price = 1499,
                ShopId = 4,
                VinylId = 4
            },
            new Stock
            {
                Id = 5,
                AvailableVinyls = 12,
                Price = 499,
                ShopId = 5,
                VinylId = 5
            },
            new Stock
            {
                Id = 6,
                AvailableVinyls = 8,
                Price = 799,
                ShopId = 6,
                VinylId = 6
            },
            new Stock
            {
                Id = 7,
                AvailableVinyls = 15,
                Price = 1099,
                ShopId = 7,
                VinylId = 7
            },
            new Stock
            {
                Id = 8,
                AvailableVinyls = 3,
                Price = 599,
                ShopId = 8,
                VinylId = 8
            },
            new Stock
            {
                Id = 9,
                AvailableVinyls = 18,
                Price = 2499,
                ShopId = 9,
                VinylId = 9
            },
            new Stock
            {
                Id = 10,
                AvailableVinyls = 25,
                Price = 1699,
                ShopId = 10,
                VinylId = 10
            }
    );
            modelBuilder.Entity<Shop>().HasData(
                            new Shop
                            {
                                Id = 1,
                                Town = "New York",
                                Address = "123 Main St"
                            },
            new Shop
            {
                Id = 2,
                Town = "Los Angeles",
                Address = "456 Elm St"
            },
            new Shop
            {
                Id = 3,
                Town = "Chicago",
                Address = "789 Oak St"
            },
            new Shop
            {
                Id = 4,
                Town = "Houston",
                Address = "1011 Maple St"
            },
            new Shop
            {
                Id = 5,
                Town = "Phoenix",
                Address = "1213 Pine St"
            },
            new Shop
            {
                Id = 6,
                Town = "Philadelphia",
                Address = "1415 Birch St"
            },
            new Shop
            {
                Id = 7,
                Town = "San Antonio",
                Address = "1617 Cedar St"
            },
            new Shop
            {
                Id = 8,
                Town = "San Diego",
                Address = "1819 Walnut St"
            },
            new Shop
            {
                Id = 9,
                Town = "Dallas",
                Address = "2021 Chestnut St"
            },
            new Shop
            {
                Id = 10,
                Town = "San Jose",
                Address = "2223 Maple St"
            }

    );
            modelBuilder.Entity<Vinyl>().HasData(
                new Vinyl() { Id = 1, Edition = "1", AlbumId = 1, Condition = "Mint", Durablility = 8, Groove = "", Material = "Vinyl", Size = 12, Speed = "45 RPM" },
                new Vinyl() { Id = 2, Edition = "2", AlbumId = 2, Condition = "Very Good", Durablility = 6, Groove = "", Material = "Vinyl", Size = 12, Speed = "45 RPM" },
                new Vinyl() { Id = 3, Edition = "3", AlbumId = 3, Condition = "Near Mint", Durablility = 7, Groove = "", Material = "Vinyl", Size = 10, Speed = "45 RPM" },
                new Vinyl() { Id = 4, Edition = "4", AlbumId = 4, Condition = "Good", Durablility = 5, Groove = "", Material = "Vinyl", Size = 12, Speed = "45 RPM" },
                new Vinyl() { Id = 5, Edition = "5", AlbumId = 5, Condition = "Very Good", Durablility = 7, Groove = "", Material = "Vinyl", Size = 12, Speed = "45 RPM" },
                new Vinyl() { Id = 6, Edition = "7", AlbumId = 6, Condition = "Near Mint", Durablility = 8, Groove = "", Material = "Vinyl", Size = 12, Speed = "45 RPM" },
                new Vinyl() { Id = 7, Edition = "8", AlbumId = 7, Condition = "Mint", Durablility = 9, Groove = "", Material = "Vinyl", Size = 7, Speed = "45 RPM" },
                new Vinyl() { Id = 8, Edition = "6", AlbumId = 8, Condition = "Good", Durablility = 6, Groove = "", Material = "Vinyl", Size = 12, Speed = "45 RPM" },
                new Vinyl() { Id = 9, Edition = "9", AlbumId = 12, Condition = "Very Good", Durablility = 4, Groove = "", Material = "Vinyl", Size = 12, Speed = "45 RPM" },
                new Vinyl() { Id = 10, Edition = "10", AlbumId = 13, Condition = "Near Mint", Durablility = 7, Groove = "", Material = "Vinyl", Size = 10, Speed = "45 RPM" },
                new Vinyl() { Id = 11, Edition = "11", AlbumId = 1, Condition = "Good", Durablility = 3, Groove = "", Material = "Vinyl", Size = 7, Speed = "45 RPM" },
                new Vinyl() { Id = 12, Edition = "12", AlbumId = 1, Condition = "Not Good", Durablility = 2, Groove = "", Material = "Vinyl", Size = 7, Speed = "45 RPM" }
                );
        }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<Vinyl> Vinyls { get; set; }
    }
}
