namespace LegalCaseManagementSystem_BackEnd.DTOs.Hearings
{
    public class CreateHearingDTO
    {
        public DateTime HearingDate { get; set; }
        public string Venue { get; set; } = string.Empty;
    }
}
