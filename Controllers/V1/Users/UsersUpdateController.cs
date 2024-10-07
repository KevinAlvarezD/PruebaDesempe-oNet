using Microsoft.AspNetCore.Mvc;
using PruebaDempeño.Helpers;

using PruebaDempeño.DTOs.Request;
using Microsoft.AspNetCore.Authorization;

namespace PruebaDempeño.Controllers.V1.Users
{
    public partial class UsersController : ControllerBase
    {
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserDTO updatedUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var checkUser = await _userRepository.CheckExistence(id);
            if (checkUser == false)
            {
                return NotFound();
            }

            var user = await _userRepository.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            user.Username = updatedUser.Username;
            user.Email = updatedUser.Email;
            user.Password = updatedUser.Password = PasswordHasher.HashPassword(updatedUser.Password);
            user.Role = updatedUser.Role;


            await _userRepository.Update(user);
            return NoContent();
        }
    }


}