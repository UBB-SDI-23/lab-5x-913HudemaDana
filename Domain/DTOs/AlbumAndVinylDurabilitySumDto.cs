using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class AlbumAndVinylDurabilitySumDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Lyrics { get; set; }
        public DateTime? RealiseDate { get; set; } = DateTime.Now;
        public int? BandId { get; set; }
        public int? ArtistId { get; set; }

        public int? Durability { get; set; }
        public IEnumerable<IGrouping<int?,Vinyl>>? Vinyls { get; set; }
    }
}
