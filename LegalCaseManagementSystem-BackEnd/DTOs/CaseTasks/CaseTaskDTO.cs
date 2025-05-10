namespace LegalCaseManagementSystem_BackEnd.DTOs.CaseTasks
{
    public class CaseTaskDTO
    {
        public int TaskId { get; set; }
        public int CaseId { get; set; }
        public int? AssignedToLawyerId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
