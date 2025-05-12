namespace LegalCaseManagementSystem_BackEnd.DTOs
{
    public class LoginDTO
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class AuthResponseDTO
    {
        public string Token { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
        public string Role { get; set; } = string.Empty;
        public int UserId { get; set; }
    }
}