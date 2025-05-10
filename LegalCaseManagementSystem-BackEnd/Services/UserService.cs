using LegalCaseManagementSystem_BackEnd.Models;
using api.Data;
using LegalCaseManagementSystem_BackEnd.DTOs.Users;
using Microsoft.EntityFrameworkCore;

namespace LegalCaseManagementSystem_BackEnd.Services
{
    public class UserService
    {
        private readonly ApplicationDBContext _context;

        public UserService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            return await _context.Users
                .Select(u => new UserDTO
                {
                    UserId = u.UserId,
                    Username = u.Username,
                    Email = u.Email,
                    Role = u.Role
                })
                .ToListAsync();
        }

        public async Task<UserDTO?> GetByIdAsync(int id)
        {
            return await _context.Users
                .Where(u => u.UserId == id)
                .Select(u => new UserDTO
                {
                    UserId = u.UserId,
                    Username = u.Username,
                    Email = u.Email,
                    Role = u.Role
                })
            .FirstOrDefaultAsync();
        }

        public async Task<UserDTO> CreateAsync(CreateUserDto userDto)
        {
            var user = new User
            {
                Username = userDto.Username,
                Email = userDto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password),
                Role = userDto.Role
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserDTO
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdateUserDto userDto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            user.Username = userDto.Username;
            user.Email = userDto.Email;
            user.Role = userDto.Role;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}