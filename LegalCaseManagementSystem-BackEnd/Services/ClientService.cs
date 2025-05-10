using LegalCaseManagementSystem_BackEnd.DTOs;
using LegalCaseManagementSystem_BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using api.Data;
using LegalCaseManagementSystem_BackEnd.DTOs.Clients;

namespace LegalCaseManagementSystem_BackEnd.Services
{
    public class ClientService
    {
        private readonly ApplicationDBContext _context;

        public ClientService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClientDTO>> GetAllAsync()
        {
            return await _context.Clients
                .Include(c => c.User)
                .Select(c => new ClientDTO
                {
                    ClientId = c.ClientId,
                    UserId = c.UserId,
                    FullName = c.FullName,
                    ContactInfo = c.ContactInfo
                })
                .ToListAsync();
        }

        public async Task<ClientDTO?> GetByIdAsync(int id)
        {
            return await _context.Clients
                .Include(c => c.User)
                .Where(c => c.ClientId == id)
                .Select(c => new ClientDTO
                {
                    ClientId = c.ClientId,
                    UserId = c.UserId,
                    FullName = c.FullName,
                    ContactInfo = c.ContactInfo
                })
                .FirstOrDefaultAsync();
        }

        public async Task<ClientDTO> CreateAsync(CreateClientDTO clientDto)
        {
            var user = new User
            {
                Username = clientDto.User.Username,
                Email = clientDto.User.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(clientDto.User.Password),
                Role = "Client"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var client = new Client
            {
                UserId = user.UserId,
                FullName = clientDto.FullName,
                ContactInfo = clientDto.ContactInfo
            };

            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            return new ClientDTO
            {
                ClientId = client.ClientId,
                UserId = client.UserId,
                FullName = client.FullName,
                ContactInfo = client.ContactInfo
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdateClientDTO clientDto)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null) return false;

            client.FullName = clientDto.FullName;
            client.ContactInfo = clientDto.ContactInfo;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null) return false;

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}