using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace VinylShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandsController : ControllerBase
    {
        private readonly ILogger<BandsController> _logger;
        private readonly IBandService _service;
        public BandsController(ILogger<BandsController> logger, IBandService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IList<BandDto>>> GetAllBands()
        {
            try
            {
                var bands = await _service.GetAllBands();
                return Ok(bands);
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside GetAllBands:" + ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BandDto>> GetBandById(int id)
        {
            try
            {
                var band = await _service.GetBandById(id);
                return Ok(band);
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside GetBandById:" + ex.Message);
                return BadRequest();
            }
        }

        [HttpPost("addBand")]
        public async Task<IActionResult> AddNewBand([FromBody] BandDto band)
        {
            try
            {
                await _service.AddBand(band);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside AddNewBand:" + ex.Message);
                return BadRequest();
            }
        }

        [HttpDelete("deleteBand/{id:int}")]
        public async Task<IActionResult> RemoveBand(int id)
        {
            try
            {
                await _service.RemoveBand(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside RemoveBand:" + ex.Message);
                return BadRequest();
            }
        }

        [HttpPut("updateBand/{id:int}")]
        public async Task<IActionResult> UpdateBand(int id, [FromBody] BandDto newBand)
        {
            try
            {
                await _service.UpdateBand(id, newBand);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside UpdateBand:" + ex.Message);
                return BadRequest();
            }
        }

    }
}
