using LegalCaseManagementSystem_BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using api.Data;
using LegalCaseManagementSystem_BackEnd.DTOs.CaseTasks;

namespace LegalCaseManagementSystem_BackEnd.Services
{
    public class CaseTaskService
    {
        private readonly ApplicationDBContext _context;

        public CaseTaskService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CaseTaskDTO>> GetByCaseIdAsync(int caseId)
        {
            return await _context.CaseTasks
                .Where(t => t.CaseId == caseId)
                .Select(t => new CaseTaskDTO
                {
                    TaskId = t.TaskId,
                    CaseId = t.CaseId,
                    AssignedToLawyerId = t.AssignedToLawyerId,
                    Title = t.Title,
                    Description = t.Description,
                    Status = t.Status,
                    CreatedAt = t.CreatedAt,
                    CompletedAt = t.CompletedAt
                })
                .ToListAsync();
        }

        public async Task<CaseTaskDTO?> GetByIdAsync(int caseId, int taskId)
        {
            return await _context.CaseTasks
                .Where(t => t.CaseId == caseId && t.TaskId == taskId)
                .Select(t => new CaseTaskDTO
                {
                    TaskId = t.TaskId,
                    CaseId = t.CaseId,
                    AssignedToLawyerId = t.AssignedToLawyerId,
                    Title = t.Title,
                    Description = t.Description,
                    Status = t.Status,
                    CreatedAt = t.CreatedAt,
                    CompletedAt = t.CompletedAt
                })
                .FirstOrDefaultAsync();
        }

        public async Task<CaseTaskDTO> CreateAsync(int caseId, CreateCaseTaskDTO taskDto)
        {
            var task = new CaseTask
            {
                CaseId = caseId,
                AssignedToLawyerId = taskDto.AssignedToLawyerId,
                Title = taskDto.Title,
                Description = taskDto.Description,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow
            };

            _context.CaseTasks.Add(task);
            await _context.SaveChangesAsync();

            return new CaseTaskDTO
            {
                TaskId = task.TaskId,
                CaseId = task.CaseId,
                AssignedToLawyerId = task.AssignedToLawyerId,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                CreatedAt = task.CreatedAt,
                CompletedAt = task.CompletedAt
            };
        }

        public async Task<bool> UpdateAsync(int caseId, int taskId, UpdateCaseTaskDTO taskDto)
        {
            var task = await _context.CaseTasks
                .FirstOrDefaultAsync(t => t.CaseId == caseId && t.TaskId == taskId);

            if (task == null) return false;

            task.Title = taskDto.Title;
            task.Description = taskDto.Description;
            task.Status = taskDto.Status;
            task.AssignedToLawyerId = taskDto.AssignedToLawyerId;
            task.CompletedAt = taskDto.Status == "Completed" ? DateTime.UtcNow : null;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int caseId, int taskId)
        {
            var task = await _context.CaseTasks
                .FirstOrDefaultAsync(t => t.CaseId == caseId && t.TaskId == taskId);

            if (task == null) return false;

            _context.CaseTasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}