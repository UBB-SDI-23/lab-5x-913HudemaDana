using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }
        public string? Town { get; set; }

        [StringLength(100, ErrorMessage = "The address must be no more than 100 characters long.")]

        public string? Address { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
