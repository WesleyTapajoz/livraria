﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Livraria.Domain;
using Livraria.Repository;
using Livraria.WebAPI.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Livraria.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IRepository _repo;

        public UserController(IConfiguration config,
                              UserManager<User> userManager,
                              SignInManager<User> signInManager,
                              IMapper mapper,
                              IRepository repo)
        {
            _signInManager = signInManager;
            _mapper = mapper;
            _config = config;
            _userManager = userManager;
            _repo = repo;
        }

        [HttpGet("GetAllUser")]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            try
            {
                var users = await _repo.GetAllAsync<User>(true);
                var results = _mapper.Map<UserDto[]>(users);
                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }


        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser(UserDto userDto)
        {
            return Ok(userDto);
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]UserDto userDto)
        {
            try
            {
                userDto.Ativo = true;
                var user = _mapper.Map<User>(userDto);

                var result = await _userManager.CreateAsync(user, userDto.Password);

                var userToReturn = _mapper.Map<UserDto>(user);

                if (result.Succeeded)
                {
                    return Created("GetUser", userToReturn);
                }

                return BadRequest(result.Errors);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }

        [HttpPut("UserEdit")]
        [AllowAnonymous]
        public async Task<IActionResult> UserEdit([FromBody]UserDto userDto)
        {
            try
            {
                //var user = _mapper.Map<User>(userDto);

                var user = await _userManager.FindByIdAsync(userDto.Id.ToString());

                //var userEdit = _mapper.Map<User>(user);

                user.Telefone = userDto.Telefone;
                user.FullName = userDto.FullName;
                user.Endereco = userDto.Endereco;
                user.Email = userDto.Email;
                user.PasswordHash = userDto.Password;
                user.CPF = userDto.CPF;

                var result = await _userManager.UpdateSecurityStampAsync(user);

                var userToReturn = _mapper.Map<UserDto>(user);

                if (result.Succeeded)
                {
                    return Accepted();
                }

                return BadRequest(result.Errors);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }

        [HttpPut("UserDisable")]
        [AllowAnonymous]
        public async Task<IActionResult> UserDisable([FromBody]UserDto userDto)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userDto.Id.ToString());
                user.Ativo = false;
                var result = await _userManager.UpdateSecurityStampAsync(user);
                var userToReturn = _mapper.Map<UserDto>(user);

                if (result.Succeeded)
                {
                    return Ok();
                }

                return BadRequest(result.Errors);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto userLogin)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(userLogin.UserName);
                if (user == null)
                    return Unauthorized();


                var result = await _signInManager.CheckPasswordSignInAsync(user, userLogin.Password, false);

                if (result.Succeeded)
                {
                    var appUser = await _userManager.Users
                        .FirstOrDefaultAsync(u => u.NormalizedUserName == userLogin.UserName.ToUpper());

                    var userToReturn = _mapper.Map<UserLoginDto>(appUser);

                    return Ok(new
                    {
                        token = GenerateJWToken(appUser).Result,
                        user = userToReturn
                    });
                }

                return Unauthorized();
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }

        private async Task<string> GenerateJWToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.ASCII
                .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);


            }
            catch (System.Exception ex)
            {
                return $"Banco Dados Falhou {ex.Message}";
            }

            //return tokenHandler.WriteToken(token);
        }
    }
}
