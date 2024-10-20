using Microsoft.AspNetCore.Mvc;
using AllsWellHealthMate.Models;
using AllsWellHealthMate.Services;
using AllsWellHealthMate.DTOs;
using System.Collections.Generic;

namespace AllsWellHealthMate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("GetUsersByRole/{role}")]
        public ActionResult<IEnumerable<User>> GetUsersByRole(int role)
        {
            var users = _userService.GetListOfUsersByRole(role);
            return Ok(users);
        }
       
        [HttpPost]
        [Route("CreateUser")]
        public IActionResult CreateUser([FromBody] UserWrapperDTO userWrapperDTO)
        {  
            var createdUser = _userService.CreateUser(userWrapperDTO.userCreateDTO);

            if(userWrapperDTO.userCreateDTO.UserRole == (int)UserRoleEnum.Doctor)
            {
                var createdProvider = _userService.CreateProvider(createdUser.Id, userWrapperDTO);
            }            

            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
        }

        [HttpPost]
        [Route("UpdateUser")]
        public IActionResult UpdateUser(int id ,UserDTO userDTO)
        {
            _userService.UpdateUser(id,userDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return NoContent();
        }
    }
}