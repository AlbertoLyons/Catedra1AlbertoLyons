using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Catedra1AlbertoLyons.src.interfaces;
using Catedra1AlbertoLyons.src.models;
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
        [HttpPost("")]
        public async Task<IResult> CreateProductAsync(User user) 
        {
            bool exists = await _userRepository.ExistsByRut(user.Rut);
            if (exists)
            {
                return TypedResults.Conflict("El rut del usuario ya existe");
            } else {
                bool added = await _userRepository.AddUserAsync(user);
                if (!added)
                {
                    return TypedResults.Conflict("Error al crear el usuario");
                }
                return TypedResults.Ok("Usuario creado exitosamente");
            }
        }
        [HttpGet("")]
        public async Task<IResult> GetUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return TypedResults.Ok(users);
        }
        [HttpGet("{gender}")]
        public async Task<IResult> GetByGenderAsync(string gender)
        {
            var users = await _userRepository.GetByGender(gender);
            if (users == null || users.Count() == 0)
            {
                return TypedResults.NotFound("Usuarios no encontrados");
            }
            return TypedResults.Ok(users);
        }
    }
}