namespace LegalCaseManagementSystem_BackEnd.DTOs.Invoices
{
    public class InvoiceDTO
    {
        public int InvoiceId { get; set; }
        public int CaseId { get; set; }
        public decimal Amount { get; set; }
        public DateTime IssuedDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
