using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class StockDto
    {
        public int? Id { get; set; }
        public int AvailableVinyls { get; set; } = 0;
        public int Price { get; set; } = 0;
        public int VinylId { get; set; }
        public int ShopId { get; set; }
    }
}
