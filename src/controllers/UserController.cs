using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Catedra1AlbertoLyons.src.dtos;
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
        public async Task<IResult> CreateUserAsync(UserDto createUserDto) 
        {
            bool exists = await _userRepository.ExistsByRut(createUserDto.Rut);
            if (exists)
            {
                return TypedResults.Conflict("El rut del usuario ya existe");
            } else {
                if (createUserDto.Birthdate > DateTime.Now)
                {
                    return TypedResults.BadRequest("La fecha de nacimiento no puede ser mayor a la fecha actual");
                }
                User user = new User
                {
                    Rut = createUserDto.Rut,
                    Name = createUserDto.Name,
                    Email = createUserDto.Email,
                    Gender = createUserDto.Gender,
                    Birthdate = createUserDto.Birthdate
                };
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
        [HttpGet("asc")]
        public async Task<IResult> GetUsersAscAsync()
        {
            var users = await _userRepository.GetAscSorted();
            return TypedResults.Ok(users);
        }
        [HttpGet("desc")]
        public async Task<IResult> GetUsersDescAsync()
        {
            var users = await _userRepository.GetDescSorted();
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
        [HttpPut("{id}")]
        public async Task<IResult> EditUserAsync(int id, UserDto editUserDto)
        {
            bool exists = await _userRepository.ExistsById(id);
            if (!exists)
            {
                return TypedResults.NotFound("Usuario no encontrado");
            }
            exists = await _userRepository.ExistsByRut(editUserDto.Rut);
            if (exists)
            {
                return TypedResults.Conflict("El rut del usuario ya existe");
            } else {
                if (editUserDto.Birthdate > DateTime.Now)
                {
                    return TypedResults.BadRequest("La fecha de nacimiento no puede ser mayor a la fecha actual");
                }
                User user = new User
                {
                    Rut = editUserDto.Rut,
                    Name = editUserDto.Name,
                    Email = editUserDto.Email,
                    Gender = editUserDto.Gender,
                    Birthdate = editUserDto.Birthdate
                };
                bool edited = await _userRepository.EditUserAsync(id, user);
                if (edited)
                {
                    return TypedResults.Ok("Usuario editado correctamente");
                }
            }
            return TypedResults.Conflict("Error al editar el usuario");
        }
        [HttpDelete("{id}")]
        public async Task<IResult> DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
            {
                return TypedResults.NotFound("Usuario no encontrado");
            }
            bool deleted = await _userRepository.DeleteUserAsync(user);
            if (deleted)
            {
                return TypedResults.Ok("Usuario eliminado correctamente");
            }
            return TypedResults.Conflict("Error al eliminar el usuario");
        }
    }
}