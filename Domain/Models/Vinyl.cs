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
    public class Vinyl
    {
        [Key]
        public int Id { get; set; }
        public string? Edition { get; set; }
        public int? Durablility { get; set; }
        public long? Size { get; set; } = 10;
        public string? Material { get; set; }
        public string? Groove { get; set; }
        public string? Speed { get; set; } 
        public string? Condition { get; set; }

        public virtual Album Album { get; set; }
        public int AlbumId { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
