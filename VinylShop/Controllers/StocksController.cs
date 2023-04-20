using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Abstractions;

namespace VinylShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly ILogger<StocksController> _logger;
        private readonly IStockService _service;
        public StocksController(ILogger<StocksController> logger, IStockService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IList<StockDto>>> GetAllStocks()
        {
            try
            {
                var stocks = await _service.GetAllStocks();
                return Ok(stocks);
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside GetAllStocks:" + ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<StockDto>> GetStockById(int id)
        {
            try
            {
                var stock = await _service.GetStockById(id);
                return Ok(stock);
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside GetStockById:" + ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("getStocksGreater/{stockNumber:int}")]
        public async Task<ActionResult<IList<StockDto>>> GetAllStocksGreaterThan(int stockNumber)
        {
            var stock = await _service.GetAllStocksGreaterThan(stockNumber);
            return Ok(stock);
        }

        [HttpPost("addStock")]
        public async Task<IActionResult> AddNewStock([FromBody] StockDto stock)
        {
            try
            {
                await _service.AddStock(stock);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside AddNewStock:" + ex.Message);
                return BadRequest();
            }
        }

        [HttpDelete("deleteStock/{id:int}")]
        public async Task<IActionResult> RemoveStock(int id)
        {
            try
            {
                await _service.RemoveStock(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside RemoveStock:" + ex.Message);
                return BadRequest();
            }
        }

        [HttpPut("updateStock/{id:int}")]
        public async Task<IActionResult> UpdateStock(int id, [FromBody] StockDto newStock)
        {
            try
            {
                await _service.UpdateStock(id, newStock);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside UpdateStock:" + ex.Message);
                return BadRequest();
            }
        }
    }
}
