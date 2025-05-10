namespace LegalCaseManagementSystem_BackEnd.DTOs.Hearings
{
    public class UpdateHearingDTO
    {
        public DateTime HearingDate { get; set; }
        public string Venue { get; set; } = string.Empty;
        public string Outcome { get; set; } = string.Empty;
    }
}
