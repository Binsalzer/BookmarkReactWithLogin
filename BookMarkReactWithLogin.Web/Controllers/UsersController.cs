﻿using BookMarkReactWithLogin.Data;
using BookMarkReactWithLogin.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookMarkReactWithLogin.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly string _connection;

        public UsersController(IConfiguration config)
        {
            _connection = config.GetConnectionString("ConStr");
        }

        [HttpGet("GetCurrentUser")]
        public User GetCurrentUser()
        {
            if(!User.Identity.IsAuthenticated)
            {
                return null;
            }

            var repo = new UsersRepository(_connection);
            return repo.GetByEmail(User.Identity.Name);
        }

        [HttpPost("SignUp")]
        public void Login(SignUpVM user)
        {
            var repo = new UsersRepository(_connection);
            repo.SignUp(user, user.Password);
        }

        [HttpPost("Login")]
        public User Login(LoginVM vm)
        {
            var repo = new UsersRepository(_connection);
            var user = repo.Login(vm.Email, vm.Password);

            if (user == null)
            {
                return null;
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, vm.Email)
            };

            HttpContext.SignInAsync(new ClaimsPrincipal(
                new ClaimsIdentity(claims, "Cookies", ClaimTypes.Email, "role"))).Wait();

            return user;
        }

        [HttpPost]
        [Route("logout")]
        public void Logout()
        {
            HttpContext.SignOutAsync().Wait();
        }
    }
}
