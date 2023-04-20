using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext()  { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Band> Bands { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<RecordLabel> RecordLabels { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<Vinyl> Vinyls { get; set; }
    }
}
