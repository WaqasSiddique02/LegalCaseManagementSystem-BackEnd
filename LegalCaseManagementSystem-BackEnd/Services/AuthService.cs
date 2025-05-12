using LegalCaseManagementSystem_BackEnd.DTOs;
using api.Data;
using Microsoft.EntityFrameworkCore;

namespace LegalCaseManagementSystem_BackEnd.Services
{
    public class AuthService
    {
        private readonly ApplicationDBContext _context;
        private readonly TokenService _tokenService;

        public AuthService(ApplicationDBContext context, TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<AuthResponseDTO?> Login(LoginDTO loginDto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == loginDto.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
            {
                return null;
            }

            var token = _tokenService.GenerateToken(user);

            return new AuthResponseDTO
            {
                Token = token,
                Expiration = DateTime.UtcNow.AddMinutes(60),
                Role = user.Role,
                UserId = user.UserId
            };
        }
    }
}