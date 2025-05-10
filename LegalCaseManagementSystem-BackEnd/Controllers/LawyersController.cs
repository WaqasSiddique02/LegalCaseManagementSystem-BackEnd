using Microsoft.AspNetCore.Mvc;
using LegalCaseManagementSystem_BackEnd.Services;
using LegalCaseManagementSystem_BackEnd.DTOs.Lawyers;

namespace LegalCaseManagementSystem_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LawyersController : ControllerBase
    {
        private readonly LawyerService _lawyerService;

        public LawyersController(LawyerService lawyerService)
        {
            _lawyerService = lawyerService;
        }

        // GET: api/lawyers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LawyerDTO>>> GetLawyers()
        {
            var lawyers = await _lawyerService.GetAllAsync();
            return Ok(lawyers);
        }

        // GET: api/lawyers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LawyerDTO>> GetLawyer(int id)
        {
            var lawyer = await _lawyerService.GetByIdAsync(id);
            if (lawyer == null)
            {
                return NotFound();
            }
            return Ok(lawyer);
        }

        // POST: api/lawyers
        [HttpPost]
        public async Task<ActionResult<LawyerDTO>> PostLawyer([FromBody] CreateLawyerDTO lawyerDto)
        {
            try
            {
                var createdLawyer = await _lawyerService.CreateAsync(lawyerDto);
                return CreatedAtAction(nameof(GetLawyer), new { id = createdLawyer.LawyerId }, createdLawyer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/lawyers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLawyer(int id, [FromBody] UpdateLawyerDTO lawyerDto)
        {
            var result = await _lawyerService.UpdateAsync(id, lawyerDto);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/lawyers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLawyer(int id)
        {
            var result = await _lawyerService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}