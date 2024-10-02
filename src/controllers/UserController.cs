using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Catedra1AlbertoLyons.src.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catedra1AlbertoLyons.src.controllers
{
    [Route("/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("")]
        public async Task<IResult> GetUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return TypedResults.Ok(users);
        }
    }
}