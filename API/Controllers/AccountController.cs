using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController(DataContext context, ITokenService tokenService) : BaseApiController
    {
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDTO registerDTO)
        {
            if(await UserExist(registerDTO.UserName)) return BadRequest("User is taken");
            return Ok();
            // using var hmac = new HMACSHA512();

            // var user = new AppUser 
            // {
            //     UserName = registerDTO.UserName.ToLower(),
            //     PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.Password)),
            //     PasswordSalt = hmac.Key
            // };

            // context.Users.Add(user);
            // await context.SaveChangesAsync();

            // return new UserDto{
            //     UserName = user.UserName,
            //     Token = tokenService.CreateToken(user)
            // };

        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> LogIn(LoginDto loginDto)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserName.ToLower());

            if(user == null) return Unauthorized("Invalid username");

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var ComputeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < ComputeHash.Length; i++)
            {
                if(ComputeHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
            }

            return new UserDto{
                UserName = user.UserName,
                Token = tokenService.CreateToken(user)
            };

        }

        public async Task<bool> UserExist(string username)
        {
            return await context.Users.AnyAsync(x => x.UserName.ToLower() == username.ToLower());
        }
    }
}