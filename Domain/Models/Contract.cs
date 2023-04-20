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
    public class Contract
    {
        [Key]
        public int Id { get; set; }
        public string? Duration { get; set; } = "indefinite";
        public DateTime? StartDate { get; set; } = DateTime.Now;

        public virtual Artist Artist { get; set; } = null!;
        public int ArtistId { get; set; }

        public virtual Band Band { get; set; } = null!;
        public int? BandId { get; set; }
        public virtual RecordLabel RecordLabel { get; set; } = null!;
        public int? RecordLabelId { get; set; }

    }
}
