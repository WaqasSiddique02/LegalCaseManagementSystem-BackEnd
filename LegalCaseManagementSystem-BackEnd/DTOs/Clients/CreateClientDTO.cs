using LegalCaseManagementSystem_BackEnd.DTOs.Users;

namespace LegalCaseManagementSystem_BackEnd.DTOs.Clients
{
    public class CreateClientDTO
    {
        public string FullName { get; set; } = string.Empty;
        public string ContactInfo { get; set; } = string.Empty;
        public CreateUserDto User { get; set; } = null!;
    }
}
