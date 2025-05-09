namespace LegalCaseManagementSystem_BackEnd.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int CaseId { get; set; }
        public decimal Amount { get; set; }
        public DateTime IssuedDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Unpaid";

        public Case Case { get; set; } = null!;
    }
}
