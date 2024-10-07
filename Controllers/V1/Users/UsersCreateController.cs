using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PruebaDempeño.DTOs.Request;
using PruebaDempeño.Models;


namespace PruebaDempeño.Controllers.V1.Users
{
    public partial class UsersController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<User>> Create(UserDTO inputUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newUser = new User
            {
                Username = inputUser.Username,
                Email = inputUser.Email,
                Password = inputUser.Password, 
                Role = inputUser.Role 
            };

            try
            {
                await _userRepository.Add(newUser);
                return Ok(newUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocurrió un error al crear el usuario: {ex.Message}");
            }
        }
    }
}