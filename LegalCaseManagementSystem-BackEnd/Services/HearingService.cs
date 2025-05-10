using LegalCaseManagementSystem_BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using api.Data;
using LegalCaseManagementSystem_BackEnd.DTOs.Hearings;

namespace LegalCaseManagementSystem_BackEnd.Services
{
    public class HearingService
    {
        private readonly ApplicationDBContext _context;

        public HearingService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HearingDTO>> GetByCaseIdAsync(int caseId)
        {
            return await _context.Hearings
                .Where(h => h.CaseId == caseId)
                .Select(h => new HearingDTO
                {
                    HearingId = h.HearingId,
                    CaseId = h.CaseId,
                    HearingDate = h.HearingDate,
                    Venue = h.Venue,
                    Outcome = h.Outcome
                })
                .ToListAsync();
        }

        public async Task<HearingDTO?> GetByIdAsync(int caseId, int hearingId)
        {
            return await _context.Hearings
                .Where(h => h.CaseId == caseId && h.HearingId == hearingId)
                .Select(h => new HearingDTO
                {
                    HearingId = h.HearingId,
                    CaseId = h.CaseId,
                    HearingDate = h.HearingDate,
                    Venue = h.Venue,
                    Outcome = h.Outcome
                })
                .FirstOrDefaultAsync();
        }

        public async Task<HearingDTO> CreateAsync(int caseId, CreateHearingDTO hearingDto)
        {
            var hearing = new Hearing
            {
                CaseId = caseId,
                HearingDate = hearingDto.HearingDate,
                Venue = hearingDto.Venue,
                Outcome = "Scheduled"
            };

            _context.Hearings.Add(hearing);
            await _context.SaveChangesAsync();

            return new HearingDTO
            {
                HearingId = hearing.HearingId,
                CaseId = hearing.CaseId,
                HearingDate = hearing.HearingDate,
                Venue = hearing.Venue,
                Outcome = hearing.Outcome
            };
        }

        public async Task<bool> UpdateAsync(int caseId, int hearingId, UpdateHearingDTO hearingDto)
        {
            var hearing = await _context.Hearings
                .FirstOrDefaultAsync(h => h.CaseId == caseId && h.HearingId == hearingId);

            if (hearing == null) return false;

            hearing.HearingDate = hearingDto.HearingDate;
            hearing.Venue = hearingDto.Venue;
            hearing.Outcome = hearingDto.Outcome;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int caseId, int hearingId)
        {
            var hearing = await _context.Hearings
                .FirstOrDefaultAsync(h => h.CaseId == caseId && h.HearingId == hearingId);

            if (hearing == null) return false;

            _context.Hearings.Remove(hearing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}