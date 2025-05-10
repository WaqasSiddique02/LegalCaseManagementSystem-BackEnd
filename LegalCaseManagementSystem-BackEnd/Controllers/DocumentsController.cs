using Microsoft.AspNetCore.Mvc;
using LegalCaseManagementSystem_BackEnd.DTOs;
using LegalCaseManagementSystem_BackEnd.Services;
using LegalCaseManagementSystem_BackEnd.DTOs.Documents;

namespace LegalCaseManagementSystem_BackEnd.Controllers
{
    [Route("api/cases/{caseId}/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly DocumentService _documentService;

        public DocumentsController(DocumentService documentService)
        {
            _documentService = documentService;
        }

        // GET: api/cases/5/documents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentDTO>>> GetDocuments(int caseId)
        {
            var documents = await _documentService.GetByCaseIdAsync(caseId);
            return Ok(documents);
        }

        // GET: api/cases/5/documents/3
        [HttpGet("{documentId}")]
        public async Task<ActionResult<DocumentDTO>> GetDocument(int caseId, int documentId)
        {
            var document = await _documentService.GetByIdAsync(caseId, documentId);
            if (document == null)
            {
                return NotFound();
            }
            return Ok(document);
        }

        // POST: api/cases/5/documents
        [HttpPost]
        public async Task<ActionResult<DocumentDTO>> PostDocument(int caseId, [FromForm] CreateDocumentDTO documentDto)
        {
            try
            {
                var createdDocument = await _documentService.CreateAsync(caseId, documentDto);
                return CreatedAtAction(nameof(GetDocument),
                    new { caseId, documentId = createdDocument.DocumentId }, createdDocument);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/cases/5/documents/3
        [HttpDelete("{documentId}")]
        public async Task<IActionResult> DeleteDocument(int caseId, int documentId)
        {
            var result = await _documentService.DeleteAsync(caseId, documentId);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}