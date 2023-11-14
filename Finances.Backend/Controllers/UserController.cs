﻿using Finances.Backend.Data.Dtos;
using Finances.Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Finances.Backend.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> NewUser(NewUserDto dto)
        {
            try
            {
                await _userService.CreateUser(dto);
                return Ok("Usuário cadastrado com sucesso!");
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}