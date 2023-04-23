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
    public class ShopsController : ControllerBase
    {
        private readonly ILogger<ShopsController> _logger;
        private readonly IShopService _service;
        public ShopsController(ILogger<ShopsController> logger, IShopService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IList<ShopDto>>> GetAllShops()
        {
            try
            {
                var bands = await _service.GetAllShops();
                return Ok(bands);
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside GetAllShops:" + ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ShopDto>> GetShopById(int id)
        {
            try
            {
                var band = await _service.GetShopById(id);
                return Ok(band);
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside GetShopById:" + ex.Message);
                return BadRequest();
            }
        }

        [HttpPost("addShop")]
        public async Task<IActionResult> AddNewShop([FromBody] ShopDto shop)
        {
            try
            {
                await _service.AddShop(shop);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside AddNewShop:" + ex.Message);
                return BadRequest();
            }
        }

        [HttpDelete("deleteShop/{id:int}")]
        public async Task<IActionResult> RemoveShop(int id)
        {
            try
            {
                await _service.RemoveShop(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside RemoveShop:" + ex.Message);
                return BadRequest();
            }
        }

        [HttpPut("updateShop/{id:int}")]
        public async Task<IActionResult> UpdateShop(int id, [FromBody] ShopDto newShop)
        {
            try
            {
                await _service.UpdateShop(id, newShop);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside UpdateShop:" + ex.Message);
                return BadRequest();
            }
        }
    }
}
