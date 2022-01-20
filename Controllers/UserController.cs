using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Raw5MovieDb_WebApi.Model;
using Raw5MovieDb_WebApi.Services;
using Raw5MovieDb_WebApi.ViewModels;

namespace Raw5MovieDb_WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IDataService _dataService;
        public UserController(IDataService dataService)
        {
            _dataService = dataService;
        }

        /// <summary>
        /// Returns all user accounts present in the database
        /// </summary>
        /// <returns>201</returns>
        [Authorize]
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_dataService.GetAllUsers());
        }

        /// <summary>
        /// Returns a single user
        /// </summary>
        /// <param name="uconst"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{uconst}")]
        public IActionResult GetUser(string uconst)
        {
            var user = _dataService.GetUser(uconst);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Registers a new user account in the database
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        [HttpPost("Register")]
        public IActionResult RegisterUser([FromQuery] UserAccount newUser)
        {
            var _user = new UserAccount
            {
                Email = newUser.Email,
                UserName = newUser.UserName,
                Password = newUser.Password,
                Birthdate = newUser.Birthdate
            };
            return Created(nameof(GetUser), _dataService.RegisterUser(_user));
        }

        /// <summary>
        /// Deletes a single user account
        /// </summary>
        /// <param name="uconst"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("{uconst}")]
        public IActionResult DeleteUser(string uconst)
        {

            var result = _dataService.DeleteUser(uconst);

            if (!result)
            {
                return NotFound($"There is no user corresponding to uconst: {uconst}");
            }
            else return Ok($"User with id {uconst} was deleted successfully");
        }

        /// <summary>
        /// Updates a single user account
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("Update")]
        public IActionResult UpdateUser([FromQuery] UserAccount model)
        {
            var result = _dataService.UpdateUser(model);

            if (!result)
            {
                return NotFound($"User not found! There is no user corresponding to uconst: {model.Uconst}");
            }
            else return Ok($"{model.UserName} updated successfully");
        }
    }
}