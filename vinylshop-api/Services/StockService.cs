using DataAccess.Data;
using Domain.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions;

namespace Services
{
    public class StockService : IStockService
    {
        private readonly ApplicationDbContext _context;
        public StockService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IList<StockDto>> GetAllStocks()
        {
            var stockList = await _context.Stocks.ToListAsync();
            var stockListDto = stockList.Select(stock => new StockDto()
            {
                Id = stock.Id,
                AvailableVinyls = stock.AvailableVinyls,
                Price = stock.Price,
                ShopId = stock.ShopId,
                VinylId = stock.VinylId
            });

            return stockListDto.ToList() ?? new List<StockDto>();
        }
        public async Task<StockDto?> GetStockById(int id)
        {
            var stock = await _context.Stocks.SingleOrDefaultAsync(a => a.Id == id);
            return (stock != null ? new StockDto()
            {
                Id = stock.Id,
                AvailableVinyls = stock.AvailableVinyls,
                Price = stock.Price,
                VinylId = stock.VinylId,
                ShopId = stock.ShopId

            } : null);
        }

        public async Task<IList<StockDto>> GetAllStocksGreaterThan(int stockNumber)
        {
            var stockList = await _context.Stocks.Where(stock => stock.AvailableVinyls > stockNumber).ToListAsync();

            var stockListDto = stockList.Select(stock => new StockDto()
            {
                Id = stock.Id,
                AvailableVinyls = stock.AvailableVinyls,
                Price = stock.Price,
                ShopId = stock.ShopId,
                VinylId = stock.VinylId
            });

            return stockListDto.ToList() ?? new List<StockDto>();
        }
        public async Task AddStock(StockDto stock)
        {
            var shop = await _context.Shops.FindAsync(stock.ShopId);
            var vinyl = await _context.Vinyls.FindAsync(stock.VinylId);
            if (shop == null || vinyl == null)
                throw new Exception("Invalid data entered when creating a new Stock : verify input for shop or vinyl");

            var existentStockField = await _context.Stocks.FindAsync(stock.VinylId, stock.ShopId);
            if (existentStockField != null)
            {
                existentStockField.AvailableVinyls += stock.AvailableVinyls;
                _context.Stocks.Update(existentStockField);
            }
            else
            {
                var newStock = new Stock()
                {
                    AvailableVinyls = stock.AvailableVinyls,
                    Price = stock.Price,
                    Shop = shop,
                    Vinyl = vinyl
                };
                await _context.Stocks.AddAsync(newStock);
            }
            await _context.SaveChangesAsync();
        }
        public async Task RemoveStock(int id)
        {
            var Stock = _context.Stocks.Find(id);
            if (Stock != null)
            {
                _context.Stocks.Remove(Stock);
            }

            await _context.SaveChangesAsync();
        }
        public async Task UpdateStock(int id, StockDto newStock)
        {
            var shop = await _context.Shops.FindAsync(newStock.ShopId);
            var vinyl = await _context.Vinyls.FindAsync(newStock.VinylId);
            if (shop == null || vinyl == null)
                throw new Exception("Invalid data entered whentrying to update a Stock : verify input for shop or vinyl");

            var stock = _context.Stocks.Find(id);
            if (stock != null)
            {
                stock.AvailableVinyls = newStock.AvailableVinyls;
                stock.Price = newStock.Price;
                stock.Vinyl = vinyl;
                stock.Shop = shop;

                _context.Stocks.Update(stock);
            }
            await _context.SaveChangesAsync();
        }

    }
}
