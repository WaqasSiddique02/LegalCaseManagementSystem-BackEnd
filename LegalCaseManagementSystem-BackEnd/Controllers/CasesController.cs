using Microsoft.AspNetCore.Mvc;
using LegalCaseManagementSystem_BackEnd.DTOs;
using LegalCaseManagementSystem_BackEnd.Services;
using LegalCaseManagementSystem_BackEnd.DTOs.Cases;

namespace LegalCaseManagementSystem_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasesController : ControllerBase
    {
        private readonly CaseService _caseService;

        public CasesController(CaseService caseService)
        {
            _caseService = caseService;
        }

        // GET: api/cases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CaseDTO>>> GetCases()
        {
            var cases = await _caseService.GetAllAsync();
            return Ok(cases);
        }

        // GET: api/cases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CaseDetailsDTO>> GetCase(int id)
        {
            var caseDetails = await _caseService.GetByIdAsync(id);
            if (caseDetails == null)
            {
                return NotFound();
            }
            return Ok(caseDetails);
        }

        // POST: api/cases
        [HttpPost]
        public async Task<ActionResult<CaseDTO>> PostCase([FromBody] CreateCaseDTO caseDto)
        {
            try
            {
                var createdCase = await _caseService.CreateAsync(caseDto);
                return CreatedAtAction(nameof(GetCase), new { id = createdCase.CaseId }, createdCase);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/cases/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCase(int id, [FromBody] UpdateCaseDTO caseDto)
        {
            var result = await _caseService.UpdateAsync(id, caseDto);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/cases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCase(int id)
        {
            var result = await _caseService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}