using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Album
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Lyrics { get; set; }
        public DateTime? RealiseDate { get; set; } = DateTime.Now;

        public virtual Artist Artist { get; set; }
        public int? ArtistId { get; set;}

        public virtual ICollection<Vinyl> Vinyls { get; set; }

    }
}
