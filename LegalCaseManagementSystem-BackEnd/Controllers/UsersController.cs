using Microsoft.AspNetCore.Mvc;
using LegalCaseManagementSystem_BackEnd.DTOs;
using LegalCaseManagementSystem_BackEnd.Services;
using LegalCaseManagementSystem_BackEnd.DTOs.Users;

namespace LegalCaseManagementSystem_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> Create([FromBody] CreateUserDto userDto)
        {
            var createdUser = await _userService.CreateAsync(userDto);
            return CreatedAtAction(nameof(GetById), new { id = createdUser.UserId }, createdUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserDto userDto)
        {
            var result = await _userService.UpdateAsync(id, userDto);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}