using LegalCaseManagementSystem_BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using api.Data;
using LegalCaseManagementSystem_BackEnd.DTOs.Documents;

namespace LegalCaseManagementSystem_BackEnd.Services
{
    public class DocumentService
    {
        private readonly ApplicationDBContext _context;
        private readonly IWebHostEnvironment _environment;

        public DocumentService(ApplicationDBContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<IEnumerable<DocumentDTO>> GetByCaseIdAsync(int caseId)
        {
            return await _context.Documents
                .Where(d => d.CaseId == caseId)
                .Select(d => new DocumentDTO
                {
                    DocumentId = d.DocumentId,
                    CaseId = d.CaseId,
                    Title = d.Title,
                    FilePath = d.FilePath,
                    UploadedAt = d.UploadedAt
                })
                .ToListAsync();
        }

        public async Task<DocumentDTO?> GetByIdAsync(int caseId, int documentId)
        {
            return await _context.Documents
                .Where(d => d.CaseId == caseId && d.DocumentId == documentId)
                .Select(d => new DocumentDTO
                {
                    DocumentId = d.DocumentId,
                    CaseId = d.CaseId,
                    Title = d.Title,
                    FilePath = d.FilePath,
                    UploadedAt = d.UploadedAt
                })
                .FirstOrDefaultAsync();
        }

        public async Task<DocumentDTO> CreateAsync(int caseId, CreateDocumentDTO documentDto)
        {
            var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var uniqueFileName = Guid.NewGuid().ToString() + "_" + documentDto.File.FileName;
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await documentDto.File.CopyToAsync(fileStream);
            }

            var document = new Document
            {
                CaseId = caseId,
                Title = documentDto.Title,
                FilePath = $"/uploads/{uniqueFileName}",
                UploadedAt = DateTime.UtcNow
            };

            _context.Documents.Add(document);
            await _context.SaveChangesAsync();

            return new DocumentDTO
            {
                DocumentId = document.DocumentId,
                CaseId = document.CaseId,
                Title = document.Title,
                FilePath = document.FilePath,
                UploadedAt = document.UploadedAt
            };
        }

        public async Task<bool> DeleteAsync(int caseId, int documentId)
        {
            var document = await _context.Documents
                .FirstOrDefaultAsync(d => d.CaseId == caseId && d.DocumentId == documentId);

            if (document == null) return false;

            // Delete the physical file
            var filePath = Path.Combine(_environment.WebRootPath, document.FilePath.TrimStart('/'));
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            _context.Documents.Remove(document);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}