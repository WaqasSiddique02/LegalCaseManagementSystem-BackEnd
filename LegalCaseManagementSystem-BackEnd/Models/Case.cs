using System.Reflection.Metadata;

namespace LegalCaseManagementSystem_BackEnd.Models
{
    public class Case
    {
        public int CaseId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = "Open";
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int ClientId { get; set; }
        public int LawyerId { get; set; }

        public Client Client { get; set; } = null!;
        public Lawyer Lawyer { get; set; } = null!;
        public ICollection<CaseTask> Tasks { get; set; } = [];
        public ICollection<Document> Documents { get; set; } = [];
        public ICollection<Hearing> Hearings { get; set; } = [];
        public ICollection<Invoice> Invoices { get; set; } = [];
    }
}
