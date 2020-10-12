using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Rental.Data;
using Rental.DTO;
using Rental.Models;

namespace Rental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;

        private readonly IConfiguration _config;
        public AuthController( IAuthRepository repo , IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {


            if (await _repo.EmailExists(userForRegisterDto.Email))
                return BadRequest("User already exists");

            var userToCreate = new TBL_USER
            {
                A_EMAIL = userForRegisterDto.Email,
                A_FIRST_NAME= userForRegisterDto.firstname,
                A_LAST_NAME= userForRegisterDto.lastname

            };

            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);
            
        }



        [HttpPost("login")]

        public async Task<IActionResult> Login (UserForLoginDto userForLoginDto)
        {
            
                var userFromRepo = await _repo.Login(userForLoginDto.Email, 
                                                        userForLoginDto.Password,
                                                            userForLoginDto.firstname,
                                                            userForLoginDto.isadmin);

                if (userFromRepo == null)
                    return Unauthorized();

                var claims = new[]
                {
                new Claim(ClaimTypes.NameIdentifier , userFromRepo.A_ID.ToString()),
                new Claim(ClaimTypes.Email ,userFromRepo.A_EMAIL),
                new Claim(ClaimTypes.Name , userFromRepo.A_FIRST_NAME),
                new Claim(ClaimTypes.Role , userFromRepo.A_IS_ADMIN.ToString())
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8
                    .GetBytes(_config.GetSection("AppSettings:Token").Value));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = creds
                };

                var tokenHandler = new JwtSecurityTokenHandler();

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return Ok(new
                {
                    token = tokenHandler.WriteToken(token)
                });
            

           

        }
    }
}
