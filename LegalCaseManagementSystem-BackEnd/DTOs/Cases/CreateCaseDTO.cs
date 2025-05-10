using LegalCaseManagementSystem_BackEnd.DTOs.Clients;
using LegalCaseManagementSystem_BackEnd.DTOs.Lawyers;

namespace LegalCaseManagementSystem_BackEnd.DTOs.Cases
{
    public class CreateCaseDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public int ClientId { get; set; }
        public int LawyerId { get; set; }
    }
}
