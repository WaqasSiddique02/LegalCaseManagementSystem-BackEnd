namespace LegalCaseManagementSystem_BackEnd.Models
{
    public class Lawyer
    {
        public int LawyerId { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;

        public User User { get; set; } = null!;
        public ICollection<Case> AssignedCases { get; set; } = new List<Case>();
    }
}
