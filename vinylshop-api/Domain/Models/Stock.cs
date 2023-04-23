using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }
        [Range(-1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        public int AvailableVinyls { get; set; } = 0;
        [Range(-1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        public int Price { get; set; } = 0;

        public virtual Shop Shop { get; set; }
        public int ShopId { get; set; }

        public virtual Vinyl Vinyl { get; set; }
        public int VinylId { get; set; }
    }
}
