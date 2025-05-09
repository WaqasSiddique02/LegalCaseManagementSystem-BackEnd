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
        public ICollection<CaseTask> Tasks { get; set; } = new List<CaseTask>();
        public ICollection<Document> Documents { get; set; } = new List<Document>();
        public ICollection<Hearing> Hearings { get; set; } = new List<Hearing>();
        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}
