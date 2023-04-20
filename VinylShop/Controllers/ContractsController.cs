using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace VinylShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private readonly ILogger<ContractsController> _logger;
        private readonly IContractService _service;
        public ContractsController(ILogger<ContractsController> logger, IContractService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IList<ContractDto>>> GetAllContracts()
        {
            try
            {
                var bands = await _service.GetAllContracts();
                return Ok(bands);
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside GetAllContracts:" + ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ContractDto>> GetContractById(int id)
        {
            try
            {
                var band = await _service.GetContractById(id);
                return Ok(band);
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside GetContractById:" + ex.Message);
                return BadRequest();
            }
        }

        [HttpPost("addContract")]
        public async Task<IActionResult> AddNewContract([FromBody] ContractDto contract)
        {
            try
            {
                await _service.AddContract(contract);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside AddNewContract:" + ex.Message);
                return BadRequest();
            }
        }

        [HttpDelete("deleteContract/{id:int}")]
        public async Task<IActionResult> RemoveContract(int id)
        {
            try
            {
                await _service.RemoveContract(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside RemoveContract:" + ex.Message);
                return BadRequest();
            }
        }

        [HttpPut("updateContract/{id:int}")]
        public async Task<IActionResult> UpdateContract(int id, [FromBody] ContractDto newContract)
        {
            try
            {
                await _service.UpdateContract(id, newContract);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong inside UpdateContract:" + ex.Message);
                return BadRequest();
            }
        }
    }
}
