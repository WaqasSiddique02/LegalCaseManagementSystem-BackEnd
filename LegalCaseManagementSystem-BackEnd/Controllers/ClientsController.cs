using Microsoft.AspNetCore.Mvc;
using LegalCaseManagementSystem_BackEnd.DTOs;
using LegalCaseManagementSystem_BackEnd.Services;
using LegalCaseManagementSystem_BackEnd.DTOs.Clients;

namespace LegalCaseManagementSystem_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ClientService _clientService;

        public ClientsController(ClientService clientService)
        {
            _clientService = clientService;
        }

        // GET: api/clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDTO>>> GetClients()
        {
            var clients = await _clientService.GetAllAsync();
            return Ok(clients);
        }

        // GET: api/clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDTO>> GetClient(int id)
        {
            var client = await _clientService.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        // POST: api/clients
        [HttpPost]
        public async Task<ActionResult<ClientDTO>> PostClient([FromBody] CreateClientDTO clientDto)
        {
            try
            {
                var createdClient = await _clientService.CreateAsync(clientDto);
                return CreatedAtAction(nameof(GetClient), new { id = createdClient.ClientId }, createdClient);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/clients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, [FromBody] UpdateClientDTO clientDto)
        {
            var result = await _clientService.UpdateAsync(id, clientDto);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var result = await _clientService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}