using Microsoft.AspNetCore.Mvc;
using LegalCaseManagementSystem_BackEnd.DTOs;
using LegalCaseManagementSystem_BackEnd.Services;
using LegalCaseManagementSystem_BackEnd.DTOs.Invoices;

namespace LegalCaseManagementSystem_BackEnd.Controllers
{
    [Route("api/cases/{caseId}/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly InvoiceService _invoiceService;

        public InvoicesController(InvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        // GET: api/cases/5/invoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceDTO>>> GetInvoices(int caseId)
        {
            var invoices = await _invoiceService.GetByCaseIdAsync(caseId);
            return Ok(invoices);
        }

        // GET: api/cases/5/invoices/3
        [HttpGet("{invoiceId}")]
        public async Task<ActionResult<InvoiceDTO>> GetInvoice(int caseId, int invoiceId)
        {
            var invoice = await _invoiceService.GetByIdAsync(caseId, invoiceId);
            if (invoice == null)
            {
                return NotFound();
            }
            return Ok(invoice);
        }

        // POST: api/cases/5/invoices
        [HttpPost]
        public async Task<ActionResult<InvoiceDTO>> PostInvoice(int caseId, [FromBody] CreateInvoiceDTO invoiceDto)
        {
            try
            {
                var createdInvoice = await _invoiceService.CreateAsync(caseId, invoiceDto);
                return CreatedAtAction(nameof(GetInvoice),
                    new { caseId, invoiceId = createdInvoice.InvoiceId }, createdInvoice);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/cases/5/invoices/3
        [HttpPut("{invoiceId}")]
        public async Task<IActionResult> PutInvoice(int caseId, int invoiceId, [FromBody] UpdateInvoiceDTO invoiceDto)
        {
            var result = await _invoiceService.UpdateAsync(caseId, invoiceId, invoiceDto);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/cases/5/invoices/3
        [HttpDelete("{invoiceId}")]
        public async Task<IActionResult> DeleteInvoice(int caseId, int invoiceId)
        {
            var result = await _invoiceService.DeleteAsync(caseId, invoiceId);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}