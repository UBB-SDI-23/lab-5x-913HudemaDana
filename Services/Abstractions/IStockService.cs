using Domain.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IStockService
    {
        public Task<IList<StockDto>> GetAllStocks();
        public Task<StockDto?> GetStockById(int id);
        public Task<IList<StockDto>> GetAllStocksGreaterThan(int stockNumber);
        public Task AddStock(StockDto stock);
        public Task RemoveStock(int id);
        public Task UpdateStock(int id, StockDto newStock);
    }
}
