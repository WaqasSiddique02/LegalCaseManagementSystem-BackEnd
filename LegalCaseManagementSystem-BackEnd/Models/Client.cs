namespace LegalCaseManagementSystem_BackEnd.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string ContactInfo { get; set; } = string.Empty;

        public User User { get; set; } = null!;
        public ICollection<Case> Cases { get; set; } = [];
    }
}
