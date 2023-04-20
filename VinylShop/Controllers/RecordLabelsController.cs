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
    public class RecordLabelsController : ControllerBase
    {
        private readonly ILogger<RecordLabelsController> _logger;
        private readonly IRecordLabelService _service;
        public RecordLabelsController(ILogger<RecordLabelsController> logger, IRecordLabelService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IList<RecordLabelDto>>> GetAllRecordLabels()
        {
            try
            {
                var bands = await _service.GetAllRecordLabels();
                return Ok(bands);
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside GetAllRecordLabels:" + ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<RecordLabelDto>> GetRecordLabelById(int id)
        {
            try
            {
                var band = await _service.GetRecordLabelById(id);
                return Ok(band);
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside GetRecordLabelById:" + ex.Message);
                return BadRequest();
            }
        }

        [HttpPost("addRecordLabel")]
        public async Task<IActionResult> AddNewRecordLabel([FromBody] RecordLabelDto recordLabel)
        {
            try
            {
                await _service.AddRecordLabel(recordLabel);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside AddNewRecordLabel:" + ex.Message);
                return BadRequest();
            }
        }

        [HttpDelete("deleteRecordLabel/{id:int}")]
        public async Task<IActionResult> RemoveRecordLabel(int id)
        {
            try
            {
                await _service.RemoveRecordLabel(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside RemoveRecordLabel:" + ex.Message);
                return BadRequest();
            }
        }

        [HttpPut("updateRecordLabel/{id:int}")]
        public async Task<IActionResult> UpdateRecordLabel(int id, [FromBody] RecordLabelDto newRecordLabel)
        {
            try
            {
                await _service.UpdateRecordLabel(id, newRecordLabel);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside UpdateRecordLabel:" + ex.Message);
                return BadRequest();
            }
        }
    }
}
