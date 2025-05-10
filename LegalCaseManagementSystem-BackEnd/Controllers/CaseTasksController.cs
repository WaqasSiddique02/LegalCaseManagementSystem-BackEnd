using Microsoft.AspNetCore.Mvc;
using LegalCaseManagementSystem_BackEnd.DTOs;
using LegalCaseManagementSystem_BackEnd.Services;
using LegalCaseManagementSystem_BackEnd.DTOs.CaseTasks;

namespace LegalCaseManagementSystem_BackEnd.Controllers
{
    [Route("api/cases/{caseId}/[controller]")]
    [ApiController]
    public class CaseTasksController : ControllerBase
    {
        private readonly CaseTaskService _caseTaskService;

        public CaseTasksController(CaseTaskService caseTaskService)
        {
            _caseTaskService = caseTaskService;
        }

        // GET: api/cases/5/tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CaseTaskDTO>>> GetCaseTasks(int caseId)
        {
            var tasks = await _caseTaskService.GetByCaseIdAsync(caseId);
            return Ok(tasks);
        }

        // GET: api/cases/5/tasks/3
        [HttpGet("{taskId}")]
        public async Task<ActionResult<CaseTaskDTO>> GetCaseTask(int caseId, int taskId)
        {
            var task = await _caseTaskService.GetByIdAsync(caseId, taskId);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        // POST: api/cases/5/tasks
        [HttpPost]
        public async Task<ActionResult<CaseTaskDTO>> PostCaseTask(int caseId, [FromBody] CreateCaseTaskDTO taskDto)
        {
            try
            {
                var createdTask = await _caseTaskService.CreateAsync(caseId, taskDto);
                return CreatedAtAction(nameof(GetCaseTask),
                    new { caseId, taskId = createdTask.TaskId }, createdTask);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/cases/5/tasks/3
        [HttpPut("{taskId}")]
        public async Task<IActionResult> PutCaseTask(int caseId, int taskId, [FromBody] UpdateCaseTaskDTO taskDto)
        {
            var result = await _caseTaskService.UpdateAsync(caseId, taskId, taskDto);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/cases/5/tasks/3
        [HttpDelete("{taskId}")]
        public async Task<IActionResult> DeleteCaseTask(int caseId, int taskId)
        {
            var result = await _caseTaskService.DeleteAsync(caseId, taskId);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}