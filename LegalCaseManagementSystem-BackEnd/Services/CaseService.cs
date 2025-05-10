using LegalCaseManagementSystem_BackEnd.DTOs;
using LegalCaseManagementSystem_BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using api.Data;
using LegalCaseManagementSystem_BackEnd.DTOs.Cases;
using LegalCaseManagementSystem_BackEnd.DTOs.Clients;
using LegalCaseManagementSystem_BackEnd.DTOs.Lawyers;

namespace LegalCaseManagementSystem_BackEnd.Services
{
    public class CaseService
    {
        private readonly ApplicationDBContext _context;

        public CaseService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CaseDTO>> GetAllAsync()
        {
            return await _context.Cases
                .Select(c => new CaseDTO
                {
                    CaseId = c.CaseId,
                    Title = c.Title,
                    Description = c.Description,
                    Status = c.Status.ToString(),
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                    ClientId = c.ClientId,
                    LawyerId = c.LawyerId
                })
                .ToListAsync();
        }

        public async Task<CaseDetailsDTO?> GetByIdAsync(int id)
        {
            return await _context.Cases
                .Include(c => c.Client)
                .Include(c => c.Lawyer)
                .Where(c => c.CaseId == id)
                .Select(c => new CaseDetailsDTO
                {
                    CaseId = c.CaseId,
                    Title = c.Title,
                    Description = c.Description,
                    Status = c.Status.ToString(),
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                    ClientId = c.ClientId,
                    LawyerId = c.LawyerId,
                    Client = new ClientDTO
                    {
                        ClientId = c.Client.ClientId,
                        UserId = c.Client.UserId,
                        FullName = c.Client.FullName,
                        ContactInfo = c.Client.ContactInfo
                    },
                    Lawyer = new LawyerDTO
                    {
                        LawyerId = c.Lawyer.LawyerId,
                        UserId = c.Lawyer.UserId,
                        FullName = c.Lawyer.FullName,
                        Specialization = c.Lawyer.Specialization
                    }
                })
                .FirstOrDefaultAsync();
        }

        public async Task<CaseDTO> CreateAsync(CreateCaseDTO caseDto)
        {
            var caseEntity = new Case
            {
                Title = caseDto.Title,
                Description = caseDto.Description,
                Status = CaseStatus.Open,
                StartDate = caseDto.StartDate,
                ClientId = caseDto.ClientId,
                LawyerId = caseDto.LawyerId
            };

            _context.Cases.Add(caseEntity);
            await _context.SaveChangesAsync();

            return new CaseDTO
            {
                CaseId = caseEntity.CaseId,
                Title = caseEntity.Title,
                Description = caseEntity.Description,
                Status = caseEntity.Status.ToString(),
                StartDate = caseEntity.StartDate,
                EndDate = caseEntity.EndDate,
                ClientId = caseEntity.ClientId,
                LawyerId = caseEntity.LawyerId
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdateCaseDTO caseDto)
        {
            var caseEntity = await _context.Cases.FindAsync(id);
            if (caseEntity == null) return false;

            caseEntity.Title = caseDto.Title;
            caseEntity.Description = caseDto.Description;

            if (Enum.TryParse<CaseStatus>(caseDto.Status, out var status))
            {
                caseEntity.Status = status;
            }

            caseEntity.EndDate = caseDto.EndDate;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var caseEntity = await _context.Cases.FindAsync(id);
            if (caseEntity == null) return false;

            _context.Cases.Remove(caseEntity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}