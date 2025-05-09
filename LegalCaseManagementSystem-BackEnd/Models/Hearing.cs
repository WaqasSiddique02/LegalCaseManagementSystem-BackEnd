namespace LegalCaseManagementSystem_BackEnd.Models
{
    public class Hearing
    {
        public int HearingId { get; set; }
        public int CaseId { get; set; }
        public DateTime HearingDate { get; set; }
        public string Venue { get; set; } = string.Empty;
        public string Outcome { get; set; } = string.Empty;

        public Case Case { get; set; } = null!;
    }
}
