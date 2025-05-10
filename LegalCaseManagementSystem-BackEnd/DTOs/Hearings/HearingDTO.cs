namespace LegalCaseManagementSystem_BackEnd.DTOs.Hearings
{
    public class HearingDTO
    {
        public int HearingId { get; set; }
        public int CaseId { get; set; }
        public DateTime HearingDate { get; set; }
        public string Venue { get; set; } = string.Empty;
        public string Outcome { get; set; } = string.Empty;
    }
}
