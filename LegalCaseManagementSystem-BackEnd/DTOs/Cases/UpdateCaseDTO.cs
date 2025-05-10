namespace LegalCaseManagementSystem_BackEnd.DTOs.Cases
{
    public class UpdateCaseDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime? EndDate { get; set; }
    }
}
