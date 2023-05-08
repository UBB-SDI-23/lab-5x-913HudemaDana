using Domain.DTOs;
using Domain.Helpers;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Abstractions;

namespace VinylShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VinylsController : ControllerBase
    {
        private readonly ILogger<VinylsController> _logger;
        private readonly IVinylService _service;
        public VinylsController(ILogger<VinylsController> logger, IVinylService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("paginated")]
        public async Task<ActionResult<PaginationResult<VinylDto>>> GetAllVinyls([FromQuery] PaginationOptions paginationOptions)
        {
            try
            {
                var vinylsPaginatedResult = await _service.GetAllVinyls(paginationOptions);
                return Ok(vinylsPaginatedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside GetAllVinyls Pagignated:" + ex.Message);
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IList<VinylDto>>> GetAllVinyls()
        {
            try
            {
                var bands = await _service.GetAllVinyls();
                return Ok(bands);
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside GetAllVinyls:" + ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<VinylDto>> GetVinylById(int id)
        {
            try
            {
                var band = await _service.GetVinylById(id);
                return Ok(band);
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside GetVinylById:" + ex.Message);
                return BadRequest();
            }
        }

        [HttpPost("addVinyl")]
        public async Task<IActionResult> AddNewVinyl([FromBody] VinylDto Vinyl)
        {
            try
            {
                await _service.AddVinyl(Vinyl);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside AddNewVinyl:" + ex.Message);
                return BadRequest();
            }
        }

        [HttpDelete("deleteVinyl/{id:int}")]
        public async Task<IActionResult> RemoveVinyl(int id)
        {
            try
            {
                await _service.RemoveVinyl(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside RemoveVinyl:" + ex.Message);
                return BadRequest();
            }
        }

        [HttpPut("updateVinyl/{id:int}")]
        public async Task<IActionResult> UpdateVinyl(int id, [FromBody] VinylDto newVinyl)
        {
            try
            {
                await _service.UpdateVinyl(id, newVinyl);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside UpdateVinyl:" + ex.Message);
                return BadRequest();
            }
        }
    }
}
