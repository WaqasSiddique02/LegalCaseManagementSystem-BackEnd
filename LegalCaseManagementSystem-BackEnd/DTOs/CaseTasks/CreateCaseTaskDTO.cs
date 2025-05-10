namespace LegalCaseManagementSystem_BackEnd.DTOs.CaseTasks
{
    public class CreateCaseTaskDTO
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int? AssignedToLawyerId { get; set; }
    }
}
