namespace LegalCaseManagementSystem_BackEnd.DTOs.Lawyers
{
    public class LawyerDTO
    {
        public int LawyerId { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
    }
}
