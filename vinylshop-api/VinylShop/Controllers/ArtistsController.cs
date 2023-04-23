using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace VinylShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly ILogger<ArtistsController> _logger;
        private readonly IArtistService _service;
        public ArtistsController(ILogger<ArtistsController> logger, IArtistService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IList<ArtistDto>>> GetAllArtistsAsync()
        {
            try
            {
                var artists = await _service.GetAllArtists();
                return Ok(artists);
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside GetAllArtists:" + ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ArtistDto>> GetArtistByIdAsync(int id)
        {
            try
            {
                var artist = await _service.GetArtistById(id);
                return Ok(artist);
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside GetArtistById:" + ex.Message);
                return BadRequest();
            }
        }

        [HttpPost("addArtist")]
        public async Task<IActionResult> AddNewArtist([FromBody] ArtistDto artist)
        {
            try
            {
                await _service.AddArtist(artist);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside AddNewArtist:" + ex.Message);
                return BadRequest();
            }
        }

        [HttpDelete("deleteArtist/{id:int}")]
        public async Task<IActionResult> RemoveArtist(int id)
        {
            try
            {
                await _service.RemoveArtist(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside RemoveArtist:" + ex.Message);
                return BadRequest();
            }
        }

        [HttpPut("updateArtist/{id:int}")]
        public async Task<IActionResult> UpdateArtist(int id, [FromBody] ArtistDto newArtist)
        {
            try
            {
                await _service.UpdateArtist(id, newArtist);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside UpdateArtist:" + ex.Message);
                return BadRequest();
            }
        }


    }
}
