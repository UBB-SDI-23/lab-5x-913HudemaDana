using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Artist
    {

        [Key]
        public int Id { get; set; }
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "FirstName must contain only letters and a single word.")]
        public string? FirstName { get; set; }
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "LastName must contain only letters and a single word.")]
        public string? LastName { get; set; }

        [Range(1, 100, ErrorMessage = "Please enter a value between 1 and 100")]
        public int? Age { get; set; }
        public string? Nationality { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int ActiveYears { get; set; } = 0;
        public virtual ICollection<Album>? Albums { get; set; } = null!;

    }
}
