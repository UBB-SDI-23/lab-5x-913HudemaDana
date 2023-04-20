using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class ContractDto
    {
        public int? Id { get; set; }
        public string? Duration { get; set; }
        public DateTime? StartDate { get; set; } = DateTime.Now;
        public int ArtistId { get; set; }
        public int? BandId { get; set; }
        public int? RecordLabelId { get; set; }
    }
}
