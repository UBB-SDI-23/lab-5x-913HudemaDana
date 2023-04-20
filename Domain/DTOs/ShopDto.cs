using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class ShopDto
    {
        public int? Id { get; set; }
        public string? Town { get; set; }
        public string? Address { get; set; }
    }
}
