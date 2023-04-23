using DataAccess.Data;
using Domain.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ShopService : IShopService
    {

        private readonly ApplicationDbContext _context;
        public ShopService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IList<ShopDto>> GetAllShops()
        {
            var shopList = await _context.Shops.ToListAsync();
            var shopListDto = shopList.Select(shop => new ShopDto()
            {
                Id = shop.Id,
                Town = shop.Town,
                Address = shop.Address
            });

            return shopListDto.ToList() ?? new List<ShopDto>();
        }
        public async Task<Shop?> GetShopById(int id)
        {
            var shop = await _context.Shops.SingleOrDefaultAsync(a => a.Id == id);
            var stocks = await _context.Stocks.Where(s => s.ShopId == id).ToListAsync();

            return (shop != null ? new Shop()
            {
                Id = shop.Id,
                Address = shop.Address,
                Town = shop.Town,
                Stocks = stocks
            } : null);
        }
        public async Task AddShop(ShopDto shop)
        {
            var newShop = new Shop()
            {
                Address = shop.Address,
                Town = shop.Town
            };
            await _context.Shops.AddAsync(newShop);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveShop(int id)
        {
            var shop = _context.Shops.Find(id);
            if (shop != null)
            {
                _context.Shops.Remove(shop);
            }

            await _context.SaveChangesAsync();
        }
        public async Task UpdateShop(int id, ShopDto newShop)
        {
            var shop = _context.Shops.Find(id);
            if (shop != null)
            {
                shop.Address = newShop.Address;
                shop.Town = newShop.Town;

                _context.Shops.Update(shop);
            }
            await _context.SaveChangesAsync();
        }

    }
}
