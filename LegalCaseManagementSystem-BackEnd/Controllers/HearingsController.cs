using Microsoft.AspNetCore.Mvc;
using LegalCaseManagementSystem_BackEnd.Services;
using LegalCaseManagementSystem_BackEnd.DTOs.Hearings;

namespace LegalCaseManagementSystem_BackEnd.Controllers
{
    [Route("api/cases/{caseId}/[controller]")]
    [ApiController]
    public class HearingsController : ControllerBase
    {
        private readonly HearingService _hearingService;

        public HearingsController(HearingService hearingService)
        {
            _hearingService = hearingService;
        }

        // GET: api/cases/5/hearings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HearingDTO>>> GetHearings(int caseId)
        {
            var hearings = await _hearingService.GetByCaseIdAsync(caseId);
            return Ok(hearings);
        }

        // GET: api/cases/5/hearings/3
        [HttpGet("{hearingId}")]
        public async Task<ActionResult<HearingDTO>> GetHearing(int caseId, int hearingId)
        {
            var hearing = await _hearingService.GetByIdAsync(caseId, hearingId);
            if (hearing == null)
            {
                return NotFound();
            }
            return Ok(hearing);
        }

        // POST: api/cases/5/hearings
        [HttpPost]
        public async Task<ActionResult<HearingDTO>> PostHearing(int caseId, [FromBody] CreateHearingDTO hearingDto)
        {
            try
            {
                var createdHearing = await _hearingService.CreateAsync(caseId, hearingDto);
                return CreatedAtAction(nameof(GetHearing),
                    new { caseId, hearingId = createdHearing.HearingId }, createdHearing);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/cases/5/hearings/3
        [HttpPut("{hearingId}")]
        public async Task<IActionResult> PutHearing(int caseId, int hearingId, [FromBody] UpdateHearingDTO hearingDto)
        {
            var result = await _hearingService.UpdateAsync(caseId, hearingId, hearingDto);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/cases/5/hearings/3
        [HttpDelete("{hearingId}")]
        public async Task<IActionResult> DeleteHearing(int caseId, int hearingId)
        {
            var result = await _hearingService.DeleteAsync(caseId, hearingId);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}