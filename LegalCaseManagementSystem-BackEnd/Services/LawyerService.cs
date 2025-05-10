using LegalCaseManagementSystem_BackEnd.Models;
using api.Data;
using LegalCaseManagementSystem_BackEnd.DTOs.Lawyers;
using Microsoft.EntityFrameworkCore;

namespace LegalCaseManagementSystem_BackEnd.Services
{
    public class LawyerService
    {
        private readonly ApplicationDBContext _context;

        public LawyerService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LawyerDTO>> GetAllAsync()
        {
            return await _context.Lawyers
                .Include(l => l.User)
                .Select(l => new LawyerDTO
                {
                    LawyerId = l.LawyerId,
                    UserId = l.UserId,
                    FullName = l.FullName,
                    Specialization = l.Specialization
                })
                .ToListAsync();
        }

        public async Task<LawyerDTO?> GetByIdAsync(int id)
        {
            return await _context.Lawyers
                .Include(l => l.User)
                .Where(l => l.LawyerId == id)
                .Select(l => new LawyerDTO
                {
                    LawyerId = l.LawyerId,
                    UserId = l.UserId,
                    FullName = l.FullName,
                    Specialization = l.Specialization
                })
                .FirstOrDefaultAsync();
        }

        public async Task<LawyerDTO> CreateAsync(CreateLawyerDTO lawyerDto)
        {
            var user = new User
            {
                Username = lawyerDto.User.Username,
                Email = lawyerDto.User.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(lawyerDto.User.Password),
                Role = "Lawyer"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var lawyer = new Lawyer
            {
                UserId = user.UserId,
                FullName = lawyerDto.FullName,
                Specialization = lawyerDto.Specialization
            };

            _context.Lawyers.Add(lawyer);
            await _context.SaveChangesAsync();

            return new LawyerDTO
            {
                LawyerId = lawyer.LawyerId,
                UserId = lawyer.UserId,
                FullName = lawyer.FullName,
                Specialization = lawyer.Specialization
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdateLawyerDTO lawyerDto)
        {
            var lawyer = await _context.Lawyers.FindAsync(id);
            if (lawyer == null) return false;

            lawyer.FullName = lawyerDto.FullName;
            lawyer.Specialization = lawyerDto.Specialization;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var lawyer = await _context.Lawyers.FindAsync(id);
            if (lawyer == null) return false;

            _context.Lawyers.Remove(lawyer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}