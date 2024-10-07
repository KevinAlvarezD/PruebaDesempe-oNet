using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaDempeño.Models;


namespace PruebaDempeño.Controllers.V1.Users
{
    public partial class UsersController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var user = await _userRepository.GetAll();
            if (user == null || !user.Any())
            {
                return NotFound();
            }

            return Ok(user);
        }


        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }
    }

    
}