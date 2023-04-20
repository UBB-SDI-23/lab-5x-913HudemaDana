using Domain.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IShopService
    {
        public Task<IList<ShopDto>> GetAllShops();
        public Task<Shop?> GetShopById(int id);
        public Task AddShop(ShopDto shop);
        public Task RemoveShop(int id);
        public Task UpdateShop(int id, ShopDto newShop);
    }
}
