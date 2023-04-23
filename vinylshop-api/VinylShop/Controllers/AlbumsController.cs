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
    public class AlbumsController : ControllerBase
    {
        private readonly ILogger<AlbumsController> _logger;
        private readonly IAlbumService _service;
        public AlbumsController(ILogger<AlbumsController> logger, IAlbumService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IList<AlbumDto>>> GetAllAlbums()
        {
            try
            {
                var albums = await _service.GetAllAlbums();
                return Ok(albums);
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside GetAllAlbums:" + ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AlbumDto>> GetAlbumById(int id)
        {
            try
            {
                var album = await _service.GetAlbumById(id);
                return Ok(album);
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside GetAlbumById:" + ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("filterAlbumsByVinylSize")]
        public async Task<ActionResult<IList<AlbumAndAvegSizeVinylDto>>> GetAllAlbumByAvgVinylSize()
        {
            try
            {
                var albums = await _service.GetAllAlbumByAvgVinylSize();
                return Ok(albums);
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside GetAllAlbums:" + ex.Message);
                return BadRequest();
            }
        }


        [HttpGet("filterAlbumsGroupedBy")]
        public async Task<ActionResult<IList<AlbumAndAvegSizeVinylDto>>> GetAllAlbumsGroupedBy()
        {
            try
            {
                var albums = await _service.GetAllAlbumsGroupedBy();
                return Ok(albums);
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside GetAllAlbums:" + ex.Message);
                return BadRequest();
            }
        }

        [HttpPost("addAlbum")]
        public async Task<IActionResult> AddNewAlbum([FromBody] AlbumDto Album)
        {
            try
            {
                await _service.AddAlbum(Album);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside AddNewAlbum:" + ex.Message);
                return BadRequest();
            }
        }

        [HttpPost("{id:int}/vinyls")]
        public async Task<IActionResult> AddVinylForAnAlbum(int id, [FromBody] List<VinylDto> vinyls)
        {
            try
            {

                await _service.AddVinylForAnAlbum(id,vinyls);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside AddVinylForAnAlbum:" + ex.Message);
                return BadRequest();
            }
        }

        [HttpDelete("deleteAlbum/{id:int}")]
        public async Task<IActionResult> RemoveAlbum(int id)
        {
            try
            {
                await _service.RemoveAlbum(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside RemoveAlbum:" + ex.Message);
                return BadRequest();
            }
        }

        [HttpPut("updateAlbum/{id:int}")]
        public async Task<IActionResult> UpdateAlbum(int id, [FromBody] AlbumDto newAlbum)
        {
            try
            {
                await _service.UpdateAlbum(id, newAlbum);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside UpdateAlbum:" + ex.Message);
                return BadRequest();
            }
        }
    }
}
