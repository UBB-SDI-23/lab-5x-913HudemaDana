using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Band
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; } = DateTime.Now;

        [Range(0,int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int? NumberOfMembers { get; set; } = 1;
        [Range(-1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        public int? NumberOfAwards { get; set; } = 0;

        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
    }
}
