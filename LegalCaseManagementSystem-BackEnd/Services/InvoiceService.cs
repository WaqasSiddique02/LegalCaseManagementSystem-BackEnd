using LegalCaseManagementSystem_BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using api.Data;
using LegalCaseManagementSystem_BackEnd.DTOs.Invoices;

namespace LegalCaseManagementSystem_BackEnd.Services
{
    public class InvoiceService
    {
        private readonly ApplicationDBContext _context;

        public InvoiceService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InvoiceDTO>> GetByCaseIdAsync(int caseId)
        {
            return await _context.Invoices
                .Where(i => i.CaseId == caseId)
                .Select(i => new InvoiceDTO
                {
                    InvoiceId = i.InvoiceId,
                    CaseId = i.CaseId,
                    Amount = i.Amount,
                    IssuedDate = i.IssuedDate,
                    Status = i.Status
                })
                .ToListAsync();
        }

        public async Task<InvoiceDTO?> GetByIdAsync(int caseId, int invoiceId)
        {
            return await _context.Invoices
                .Where(i => i.CaseId == caseId && i.InvoiceId == invoiceId)
                .Select(i => new InvoiceDTO
                {
                    InvoiceId = i.InvoiceId,
                    CaseId = i.CaseId,
                    Amount = i.Amount,
                    IssuedDate = i.IssuedDate,
                    Status = i.Status
                })
                .FirstOrDefaultAsync();
        }

        public async Task<InvoiceDTO> CreateAsync(int caseId, CreateInvoiceDTO invoiceDto)
        {
            var invoice = new Invoice
            {
                CaseId = caseId,
                Amount = invoiceDto.Amount,
                IssuedDate = DateTime.UtcNow,
                Status = "Unpaid"
            };

            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();

            return new InvoiceDTO
            {
                InvoiceId = invoice.InvoiceId,
                CaseId = invoice.CaseId,
                Amount = invoice.Amount,
                IssuedDate = invoice.IssuedDate,
                Status = invoice.Status
            };
        }

        public async Task<bool> UpdateAsync(int caseId, int invoiceId, UpdateInvoiceDTO invoiceDto)
        {
            var invoice = await _context.Invoices
                .FirstOrDefaultAsync(i => i.CaseId == caseId && i.InvoiceId == invoiceId);

            if (invoice == null) return false;

            invoice.Status = invoiceDto.Status;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int caseId, int invoiceId)
        {
            var invoice = await _context.Invoices
                .FirstOrDefaultAsync(i => i.CaseId == caseId && i.InvoiceId == invoiceId);

            if (invoice == null) return false;

            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}