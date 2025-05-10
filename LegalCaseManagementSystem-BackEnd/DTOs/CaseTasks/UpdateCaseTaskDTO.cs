namespace LegalCaseManagementSystem_BackEnd.DTOs.CaseTasks
{
    public class UpdateCaseTaskDTO
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Status { get; set; } = string.Empty;
        public int? AssignedToLawyerId { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
