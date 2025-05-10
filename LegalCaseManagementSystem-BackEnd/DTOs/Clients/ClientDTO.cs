namespace LegalCaseManagementSystem_BackEnd.DTOs.Clients
{
    public class ClientDTO
    {
        public int ClientId { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string ContactInfo { get; set; } = string.Empty;
    }
}
