using LegalCaseManagementSystem_BackEnd.DTOs.Users;

namespace LegalCaseManagementSystem_BackEnd.DTOs.Lawyers
{
    public class CreateLawyerDTO
    {
        public string FullName { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public CreateUserDto User { get; set; } = null!;
    }
}
