using LegalCaseManagementSystem_BackEnd.DTOs.Clients;

namespace LegalCaseManagementSystem_BackEnd.DTOs.Cases
{
    public class CaseDTO
    {
        public int CaseId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int ClientId { get; set; }
        public ClientDTO? Client { get; set; }
        public int LawyerId { get; set; }
    }
}
